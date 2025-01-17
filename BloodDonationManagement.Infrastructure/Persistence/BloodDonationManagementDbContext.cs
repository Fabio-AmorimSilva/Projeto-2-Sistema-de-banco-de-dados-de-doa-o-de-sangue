namespace BloodDonationManagement.Infrastructure.Persistence;

public class BloodDonationManagementDbContext(DbContextOptions<BloodDonationManagementDbContext> options) : DbContext(options)
{
    public DbSet<Donor> Donors { get; set; }
    public DbSet<BloodStock> BloodStocks { get; set; }
    public DbSet<Donation> Donations { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BloodDonationManagementDbContext).Assembly);
    }
}