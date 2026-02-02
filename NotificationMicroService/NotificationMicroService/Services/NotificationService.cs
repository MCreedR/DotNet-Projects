using Microsoft.EntityFrameworkCore;
using NotificationMicroService.Data;
using NotificationMicroService.Models;

namespace NotificationMicroService.Services
{
    public class NotificationService
    {
        private readonly AppDbContext _context;

        public NotificationService(AppDbContext ctx)
        {
            _context = ctx;
        }

        public async Task<bool> SendNotificationAsync(int templateId, string recipient)   
        {
            var template = await _context.NotificationTemplates.FindAsync(templateId);
            if (template == null) return false;

            var provider = await _context.NotificationProviderConfigs
                                .FirstOrDefaultAsync(p => p.IsActive && p.Type == template.Type);

            if (provider == null) return false;

            // Simulate sending notification
            Console.WriteLine($"[MOCK] Sending {template.Type} with {provider.ProviderName}...");
            Console.WriteLine($"[AUTH] Using key: {provider.ApiKey}");

            var log = new NotificationLog
            {
                NotificationTemplateId = templateId,
                NotificationproviderConfigId = provider.Id,
                Recipient = recipient,
                Message = template.Body,
                Type = template.Type,
                SentAt = DateTime.UtcNow,
                IsSuccess = true
            };

            _context.NotificationLogs.Add(log);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
