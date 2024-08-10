


using Identity.Domain.Role;
using Identity.Domain.Role.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Identity.Persistence.EF.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        ConfigureRoleTable(builder);

    }

    private static void ConfigureRoleTable(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");

        builder.HasKey(R => R.Id);

        builder.Property(R => R.Id)
            .ValueGeneratedNever()
            .IsRequired(true)
            .HasConversion(
              id => id.Value,
              value => RoleId.Create(value));

        builder.Property(R => R.Name)
            .HasMaxLength(70)
            .IsRequired();

    }
}
