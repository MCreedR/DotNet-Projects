using Microsoft.EntityFrameworkCore;
using NotificationMicroService.Models;
using System.Security.Cryptography.X509Certificates;

namespace NotificationMicroService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<NotificationTemplate> NotificationTemplates { get; set; }
        public DbSet<NotificationProviderConfig> NotificationProviderConfigs { get; set; }
        public DbSet<NotificationLog> NotificationLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relationship: One template can have Many Logs
            modelBuilder.Entity<NotificationLog>()
                .HasOne(log => log.NotificationTemplate)
                .WithMany()
                .HasForeignKey(log => log.NotificationTemplateId)
                .OnDelete(DeleteBehavior.SetNull); // keep the log even if the template is deleted

            // Relationship: One provider config can have Many Logs
            modelBuilder.Entity<NotificationLog>()
                .HasOne(log => log.NotificationProviderConfig)
                .WithMany()
                .HasForeignKey(log => log.NotificationproviderConfigId);
        }

    }
}
