using AuthProvider.Domain.Aggregates.UserAggregate;
using AuthProvider.Domain.Aggregates.UserAggregate.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetAdoptionApp.SharedKernel.Authorization.Enums;

namespace AuthProvider.Infrastructure.DataAccess.Config;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.ToTable("Users");

		builder.Property(u => u.Id)
			.HasColumnName("UserId");

		builder.Property(u => u.Email)
			.HasMaxLength(254)
			.IsUnicode()
			.IsRequired();
		builder.HasIndex(u => u.Email)
			.IsUnique();

		builder.Property(u => u.PasswordHash)
			.IsRequired();

		builder.Property(u => u.FirstName)
			.HasMaxLength(50)
			.IsUnicode()
			.IsRequired();

		builder.Property(u => u.LastName)
			.HasMaxLength(50)
			.IsUnicode()
			.IsRequired();

		builder.Property(u => u.Gender)
			.HasColumnType("char(1)")
			.IsRequired()
			.HasConversion(e => e.Value, v => Gender.FromValue(v));

		builder.OwnsMany(u => u.Permissions,
			pBuilder =>
			{
				pBuilder.ToTable("UserRoles");

				pBuilder.WithOwner().HasForeignKey("UserId");

				pBuilder.Property(p => p.Role)
						.IsRequired()
						.HasConversion(e => e.Value, v => Role.FromValue(v));

				pBuilder.HasOne<User>().WithMany()
						.HasForeignKey(p => p.GrantedBy)
						.IsRequired();

				pBuilder.Property(p => p.GrantedTime)
						.IsRequired();
			});
	}
}
