namespace BloodDonationManagement.Infrastructure.Configurations;

public class BloodStockEntityTypeConfiguration : IEntityTypeConfiguration<BloodStock>
{
    public void Configure(EntityTypeBuilder<BloodStock> builder)
    {
        builder
            .ToTable("BloodStocks");
        
        builder
            .HasKey(bs => bs.Id);

        builder
            .Property(bs => bs.Id)
            .IsRequired();

        builder
            .Property(bs => bs.BloodType)
            .IsRequired();
        
        builder
            .Property(bs => bs.RhFactor)
            .IsRequired();
        
        builder
            .Property(bs => bs.Quantity)
            .IsRequired();
    }
}