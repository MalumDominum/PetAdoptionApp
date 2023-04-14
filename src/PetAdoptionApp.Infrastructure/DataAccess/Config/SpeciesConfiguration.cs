using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetAdoptionApp.Domain.Aggregates.SpeciesAggregate;

namespace PetAdoptionApp.Infrastructure.DataAccess.Config;

public class SpeciesConfiguration : IEntityTypeConfiguration<Species>
{
	public void Configure(EntityTypeBuilder<Species> builder)
	{
		builder.ToTable("Species");

		builder.HasKey(p => p.Id);
		builder.Property(p => p.Id)
			   .HasColumnName("SpeciesId");

		builder.Property(c => c.Title)
			   .HasMaxLength(50)
			   .IsRequired();
	}
}
