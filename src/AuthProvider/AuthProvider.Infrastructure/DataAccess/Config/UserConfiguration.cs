using AuthProvider.Domain.Aggregates.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthProvider.Infrastructure.DataAccess.Config;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.ToTable("Users");

		builder.Property(e => e.Id)
			.HasColumnName("UserId");

		builder.Property(e => e.Email)
			.HasMaxLength(254)
			.IsUnicode()
			.IsRequired();
		builder.HasIndex(e => e.Email)
			.IsUnique();

		builder.Property(e => e.PasswordHash)
			.IsRequired();

		builder.Property(e => e.FirstName)
			.HasMaxLength(50)
			.IsUnicode()
			.IsRequired();

		builder.Property(e => e.LastName)
			.HasMaxLength(50)
			.IsUnicode()
			.IsRequired();
	}
}
