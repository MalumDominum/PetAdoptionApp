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

		ConfigureColorRelationship(builder);
		
		ConfigureSpeciesRelationship(builder);
		ConfigureSizeRelationship(builder);
	}

	#region Configure Many-to-Many Relationships

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

	#endregion

	#region Configure One-to-Many Relationships

	private static void ConfigureSpeciesRelationship(EntityTypeBuilder<PetProfile> builder)
	{
		builder.HasOne(p => p.Species)
			   .WithMany()
			   .HasForeignKey(p => p.SpeciesId)
			   .IsRequired();
	}

	private static void ConfigureSizeRelationship(EntityTypeBuilder<PetProfile> builder)
	{
		builder.HasOne(p => p.Size)
			   .WithMany()
			   .HasForeignKey(p => p.SizeId);
	}

	#endregion

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

		builder.OwnsOne(p => p.BirthDate).WithOwner();
		builder.Property(p => p.BackfieldBirthDate).IsRequired();

		builder.OwnsOne(p => p.Details, db =>
		{
			db.WithOwner();
			db.HasOne(d => d.Breed)
				.WithMany()
				.HasForeignKey(d => d.BreedId);
		});

		builder.Property(p => p.CreatedAt)
			   .HasDefaultValueSql("NOW()");
	}
}
