namespace NotificationMicroService.Models
{
    public class NotificationLog
    {
        public int Id { get; set; }
        public string Recipient { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }

        //Link to the Template used for this notification
        //We use 'int?' (nullable) in case a notification is sent without a template
        public int? NotificationTemplateId { get; set; }
        public NotificationTemplate? NotificationTemplate { get; set; }

        //Link to the provider config used for this notification
        public int? NotificationproviderConfigId { get; set; }
        public NotificationProviderConfig? NotificationProviderConfig { get; set; }
    }
}
