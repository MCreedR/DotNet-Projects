using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotificationMicroService.Data;
using NotificationMicroService.Services;

namespace NotificationMicroService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : Controller
    {
        private readonly AppDbContext _context;

        public NotificationsController(AppDbContext ctx)
        {
            _context = ctx;
        }

        [HttpPost("send")]
        public async Task<IActionResult> Send([FromServices] NotificationService service, int templateId, string recipient)
        {
            var result = await service.SendNotificationAsync(templateId, recipient);
            if (result)
                return Ok("Notification sent successfully.");
            else
                return BadRequest("Failed to send notification.");
        }

        [HttpGet("logs")]
        public async Task<IActionResult> GetLogs()
        {
            var logs = await _context.NotificationLogs
                .OrderByDescending(l => l.SentAt)
                .ToListAsync();

            return Ok(logs);
        }
    }
}
