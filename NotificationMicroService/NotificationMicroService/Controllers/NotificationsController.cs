using Microsoft.AspNetCore.Mvc;
using NotificationMicroService.Services;

namespace NotificationMicroService.Controllers
{
    public class NotificationsController : Controller
    {
        [HttpPost("send")]
        public async Task<IActionResult> Send([FromServices] NotificationService service, int templateId, string recipient)
        {
            var result = await service.SendNotificationAsync(templateId, recipient);
            if (result)
                return Ok("Notification sent successfully.");
            else
                return BadRequest("Failed to send notification.");
        }
    }
}
