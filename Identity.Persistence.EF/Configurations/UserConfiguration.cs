

using Identity.Domain.Role.ValueObjects;
using Identity.Domain.User;
using Identity.Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Identity.Persistence.EF.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfigureUserTable(builder);
        ConfigureUserRoleTable(builder);

    }

    private static void ConfigureUserTable(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(U => U.Id);

        builder.Property(U => U.Id)
            .ValueGeneratedNever()
            .IsRequired(true)
            .HasConversion(
            id => id.Value,
            value => UserId.Create(value));

        builder.Property(U => U.FirstName)
            .HasMaxLength(100)
            .IsRequired(true);

        builder.Property(U => U.LastName)
            .HasMaxLength(100);

        builder.Property(U => U.Password)
            .IsRequired()
            .HasMaxLength(500);

        builder.OwnsOne(U => U.Mobile, m =>
        {
            m.Property(mn => mn.Number).HasMaxLength(10);
            m.Property(mc => mc.Country).HasMaxLength(3);
        });

        builder.OwnsOne(U => U.Address, a =>
        {
            a.Property(c => c.City).HasMaxLength(200);
            a.Property(c => c.CodePosti).HasMaxLength(50);
        });
    }

    private static void ConfigureUserRoleTable(EntityTypeBuilder<User> builder)
    {
        builder.OwnsMany(U => U.UserRoles, p =>
        {
            p.ToTable("UserRoles");

            p.WithOwner().HasForeignKey("UserId");

            p.HasKey(P => P.Id);


            p.Property(P => P.Id)
            .HasColumnName("UserRoleId")
            .ValueGeneratedNever()
            .IsRequired(true)
            .HasConversion(
                id => id.Value,
                value => UserRoleId.Create(value));

            p.Property(P => P.RoleId)
            .HasColumnName("RoleId")
            .ValueGeneratedNever()
            .IsRequired(true)
            .HasConversion(
                id => id.Value,
                value => RoleId.Create(value));
        });

    }
}
