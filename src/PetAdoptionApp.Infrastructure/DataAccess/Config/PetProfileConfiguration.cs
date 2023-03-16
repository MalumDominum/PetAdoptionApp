using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Enums;

namespace PetAdoptionApp.Infrastructure.DataAccess.Config;

public class PetProfileConfiguration : IEntityTypeConfiguration<PetProfile>
{
	public void Configure(EntityTypeBuilder<PetProfile> builder)
	{
		// TODO Configure OnDelete behaviors
		ConfigurePetProfileTable(builder);
		ConfigureRelationships(builder);
	}

	private static void ConfigureRelationships(EntityTypeBuilder<PetProfile> builder)
	{
		builder.HasMany(p => p.Colors)
			   .WithMany()
			   .UsingEntity(j => j.ToTable("PetColor"));
	}

	private static void ConfigurePetProfileTable(EntityTypeBuilder<PetProfile> builder)
	{
		builder.ToTable("PetProfiles");

		builder.HasKey(p => p.Id);
		builder.Property(p => p.Id)
			   .HasColumnName("PetProfileId");

		builder.Property(p => p.Name)
			   .HasMaxLength(100)
			   .IsRequired();

		builder.Property(p => p.Gender)
			   .HasColumnType("char(1)")
			   .IsRequired()
			   .HasConversion(g => g == Gender.Male ? 'm' : g == Gender.Female ? 'f' : 'u', // (char)g possible
					c => c == 'm' ? Gender.Male : c == 'f' ? Gender.Female : Gender.Unknown);
	}
}
