namespace BloodDonationManagement.Infrastructure.Configurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable("Users");

        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .IsRequired();

        builder
            .Property(x => x.Name)
            .IsRequired();

        builder
            .Property(x => x.Email)
            .IsRequired();

        builder
            .Property(x => x.Password)
            .IsRequired();
    }
}