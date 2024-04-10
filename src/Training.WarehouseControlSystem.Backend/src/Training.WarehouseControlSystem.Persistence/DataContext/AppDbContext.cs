using Microsoft.EntityFrameworkCore;
using Training.WarehouseControlSystem.Domain.Entities;

namespace Training.WarehouseControlSystem.Persistence.DataContext;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    #region Identity
    public DbSet<User> Users => Set<User>();

    public DbSet<Role> Roles => Set<Role>();

    public DbSet<UserRole> UserRoles => Set<UserRole>();

    public DbSet<UserSettings> UserSettings => Set<UserSettings>();

    public DbSet<Customer> Customers => Set<Customer>();

    #endregion

    #region Notification
    
    public DbSet<NotificationTemplate> NotificationTemplates => Set<NotificationTemplate>();

    public DbSet<EmailTemplate> EmailTemplates => Set<EmailTemplate>();

    public DbSet<SmsTemplate> SmsTemplates => Set<SmsTemplate>();

    public DbSet<NotificationHistory> NotificationHistory => Set<NotificationHistory>();

    public DbSet<EmailHistory> EmailHistory => Set<EmailHistory>();

    public DbSet<SmsHistory> SmsHistory => Set<SmsHistory>();
    #endregion

    #region Verificaiton

    public DbSet<VerificationCode> VerificationCode => Set<VerificationCode>();

    public DbSet<UserInfoVerificationCode> UserInfoVerificationCodes => Set<UserInfoVerificationCode>();

    #endregion

    #region Media
    
    public DbSet<StorageFile> StorageFile => Set<StorageFile>();

    #endregion

    #region Product

    public DbSet<Product> Products => Set<Product>();

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
