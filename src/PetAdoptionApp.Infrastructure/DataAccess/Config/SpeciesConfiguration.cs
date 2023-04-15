﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetAdoptionApp.Domain.Aggregates.BreedAggregate;
using PetAdoptionApp.Domain.Aggregates.SpeciesAggregate;

namespace PetAdoptionApp.Infrastructure.DataAccess.Config;

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