﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetAdoptionApp.Domain.Aggregates.BreedAggregate;
using PetAdoptionApp.Domain.Aggregates.SpeciesAggregate;

namespace PetAdoptionApp.Infrastructure.DataAccess.Config;

public class BreedConfiguration : IEntityTypeConfiguration<Breed>
{
	public void Configure(EntityTypeBuilder<Breed> builder)
	{
		builder.ToTable("Breeds");

		builder.HasKey(b => b.Id);
		builder.Property(b => b.Id)
			   .HasColumnName("BreedId");

		builder.Property(b => b.Title)
			   .HasMaxLength(100)
			   .IsRequired();

		builder.HasOne<Species>()
			   .WithMany(s => s.Breeds)
			   .HasForeignKey(b => b.SpeciesId);
	}
}