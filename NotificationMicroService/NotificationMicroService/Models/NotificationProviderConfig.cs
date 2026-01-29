namespace NotificationMicroService.Models
{
    public class NotificationProviderConfig
    {
        public int Id { get; set; }
        public string ProviderName { get; set; } = string.Empty;
        public string ApiKey { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
