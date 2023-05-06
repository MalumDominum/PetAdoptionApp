using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetProfileDomain.Domain.Aggregates.SpeciesAggregate;

namespace PetProfileDomain.Infrastructure.DataAccess.Config;

public class SpeciesConfiguration : IEntityTypeConfiguration<Species>
{
	public void Configure(EntityTypeBuilder<Species> builder)
	{
		builder.ToTable("Species");

		builder.HasKey(s => s.Id);
		builder.Property(s => s.Id)
			   .HasColumnName("SpeciesId");

		builder.Property(s => s.Title)
			   .HasMaxLength(50)
			   .IsRequired();

		builder.HasMany(s => s.Breeds)
			   .WithOne();
	}
}
