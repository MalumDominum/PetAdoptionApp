using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Linkers;

namespace PetProfileDomain.Infrastructure.DataAccess.Config;

public class PetColorConfiguration : IEntityTypeConfiguration<PetColor>
{
	public void Configure(EntityTypeBuilder<PetColor> builder)
	{
		builder.ToTable("PetColors");

		builder.HasKey(pc => new { pc.ColorId, pc.PetId });
		builder.HasIndex(pc => new { pc.ColorId, pc.PetId });

		builder.HasOne(pc => pc.Pet)
			.WithMany(p => p.PetColors)
			.HasForeignKey(pc => pc.PetId);

		builder.HasOne(pc => pc.Color)
			.WithMany()
			.HasForeignKey(pc => pc.ColorId);
	}
}
