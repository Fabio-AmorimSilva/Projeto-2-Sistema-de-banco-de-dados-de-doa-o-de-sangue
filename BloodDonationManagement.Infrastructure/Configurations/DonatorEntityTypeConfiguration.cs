namespace BloodDonationManagement.Infrastructure.Configurations;

public class DonatorEntityTypeConfiguration : IEntityTypeConfiguration<Donator>
{
    public void Configure(EntityTypeBuilder<Donator> builder)
    {
        builder
            .ToTable("Donators");
        
        builder
            .HasKey(d => d.Id);

        builder
            .Property(d => d.Id)
            .IsRequired();

        builder
            .Property(d => d.Name)
            .IsRequired();
        
        builder
            .Property(d => d.Email)
            .IsRequired();
        builder
            .Property(d => d.Birth)
            .IsRequired();
        
        builder
            .Property(d => d.Gender)
            .IsRequired();
        
        builder
            .Property(d => d.Weight)
            .IsRequired();
        
        builder
            .Property(d => d.BloodType)
            .IsRequired();
        
        builder
            .Property(d => d.RhFactor)
            .IsRequired();
        
        builder
            .OwnsOne(d => d.Address, address =>
            {
                address
                    .Property<Guid>("Id")
                    .ValueGeneratedOnAdd();
                
                address
                    .Property(p => p.PublicArea)
                    .IsRequired();
                
                address
                    .Property(p => p.City)
                    .IsRequired();
                
                address
                    .Property(p => p.State)
                    .IsRequired();
                
                address
                    .Property(p => p.Cep)
                    .IsRequired();
            });
    }
}