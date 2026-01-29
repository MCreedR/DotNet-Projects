using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotificationMicroService.Data;
using NotificationMicroService.Models;

namespace NotificationMicroService.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TemplatesController : Controller
    {
        private readonly AppDbContext _context;

        public TemplatesController(AppDbContext ctx)
        {
            _context = ctx;
        }

        //GET: api/templates
        //Purpose: get all notification templates for the UI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotificationTemplate>>> GetTemplates()
        {
            return await _context.NotificationTemplates.ToListAsync();
        }

        //Post: api/templates
        //Purpose: create a new notification template
        [HttpPost]
        public async Task<ActionResult<NotificationTemplate>> CreateTemplate(NotificationTemplate template)
        {
            _context.NotificationTemplates.Add(template);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTemplates), new { id = template.Id }, template);

        }
    }
}
