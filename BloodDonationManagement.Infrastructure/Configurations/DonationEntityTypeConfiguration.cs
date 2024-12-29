namespace BloodDonationManagement.Infrastructure.Configurations;

public class DonationEntityTypeConfiguration : IEntityTypeConfiguration<Donation>
{
    public void Configure(EntityTypeBuilder<Donation> builder)
    {
        builder
            .ToTable("Donations");

        builder
            .HasKey(d => d.Id);

        builder
            .Property(d => d.Id)
            .IsRequired();

        builder
            .Property(d => d.DonationDate)
            .IsRequired();
        
        builder
            .Property(d => d.Quantity)
            .IsRequired();

        builder
            .HasOne(d => d.Donator)
            .WithMany(d => d.Donations)
            .HasForeignKey(d => d.DonatorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}