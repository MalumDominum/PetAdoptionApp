﻿using Microsoft.EntityFrameworkCore;
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
		ConfigureColorRelationship(builder);
	}

	private static void ConfigureColorRelationship(EntityTypeBuilder<PetProfile> builder)
	{
		builder.HasMany(p => p.Colors)
			   .WithMany()
			   .UsingEntity<PetColor>(pc =>
			   {
				   pc.ToTable("PetColor");
				   pc.HasKey(p => new { p.ColorId, p.PetProfileId });
				   pc.HasIndex(p => new { p.ColorId, p.PetProfileId });
			   });
		builder.Navigation(p => p.Colors).Metadata.SetField("_colors");
		builder.Navigation(p => p.Colors).UsePropertyAccessMode(PropertyAccessMode.Field);
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
			   .HasConversion(e => e.Value, v => Gender.FromValue(v));
	}
}
