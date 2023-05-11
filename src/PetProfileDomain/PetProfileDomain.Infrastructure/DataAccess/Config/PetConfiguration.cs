using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetProfileDomain.Domain.Aggregates.PetAggregate;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Enums;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Linkers;

namespace PetProfileDomain.Infrastructure.DataAccess.Config;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
	public void Configure(EntityTypeBuilder<Pet> builder)
	{
		// TODO Configure OnDelete behaviors
		ConfigurePetTable(builder);

		ConfigureColorRelationship(builder);
		
		ConfigureSpeciesRelationship(builder);
		ConfigureSizeRelationship(builder);
	}

	#region Configure Many-to-Many Relationships

	private static void ConfigureColorRelationship(EntityTypeBuilder<Pet> builder)
	{
		builder.HasMany(p => p.Colors)
			   .WithMany()
			   .UsingEntity<PetColor>();

		builder.Navigation(p => p.Colors).Metadata.SetField("_colors");
		builder.Navigation(p => p.Colors).UsePropertyAccessMode(PropertyAccessMode.Field);
	}

	#endregion

	#region Configure One-to-Many Relationships

	private static void ConfigureSpeciesRelationship(EntityTypeBuilder<Pet> builder)
	{
		builder.HasOne(p => p.Species)
			   .WithMany()
			   .HasForeignKey(p => p.SpeciesId)
			   .IsRequired();
	}

	private static void ConfigureSizeRelationship(EntityTypeBuilder<Pet> builder)
	{
		builder.HasOne(p => p.Size)
			   .WithMany()
			   .HasForeignKey(p => p.SizeId);
	}

	#endregion

	private static void ConfigurePetTable(EntityTypeBuilder<Pet> builder)
	{
		builder.ToTable("Pets");

		builder.HasKey(p => p.Id);
		builder.Property(p => p.Id)
			   .HasColumnName("PetId");

		builder.Property(p => p.Name)
			   .HasMaxLength(100)
			   .IsRequired();

		builder.Property(p => p.Gender)
			   .HasColumnType("char(1)")
			   .IsRequired()
			   .HasConversion(e => e.Value, v => Gender.FromValue(v));

		builder.OwnsOne(p => p.BirthDate).WithOwner();
		builder.Property(p => p.BackfieldBirthDate).IsRequired();
		
		builder.OwnsOne(p => p.Details, dBuilder =>
		{
			dBuilder.WithOwner();
			dBuilder.HasOne(d => d.Breed)
					.WithMany()
					.HasForeignKey(d => d.BreedId);
		});

		builder.Property(p => p.OwnerId)
			   .IsRequired();

		builder.Property(p => p.CreatedAt)
			   .HasDefaultValueSql("NOW()");

		builder.Property(p => p.NewStatesAddedAt)
			   .HasDefaultValue(DateTime.MinValue);
	}
}
