using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Linkers;

namespace PetAdoptionApp.Infrastructure.DataAccess.Config;

public class PetColorConfiguration : IEntityTypeConfiguration<PetColor>
{
	public void Configure(EntityTypeBuilder<PetColor> builder)
	{
		builder.ToTable("PetColors");

		builder.HasKey(pc => new { pc.ColorId, pc.PetProfileId });
		builder.HasIndex(pc => new { pc.ColorId, pc.PetProfileId });

		builder.HasOne(pc => pc.PetProfile)
			.WithMany(p => p.PetColors)
			.HasForeignKey(pc => pc.PetProfileId);

		builder.HasOne(pc => pc.Color)
			.WithMany()
			.HasForeignKey(pc => pc.ColorId);
	}
}
