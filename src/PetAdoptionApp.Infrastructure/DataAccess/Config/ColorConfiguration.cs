using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetAdoptionApp.Domain.Aggregates.ColorAggregate;

namespace PetAdoptionApp.Infrastructure.DataAccess.Config;

public class ColorConfiguration : IEntityTypeConfiguration<Color>
{
	public void Configure(EntityTypeBuilder<Color> builder)
	{
		builder.ToTable("Colors");

		builder.HasKey(p => p.Id);
		builder.Property(p => p.Id)
			   .HasColumnName("ColorId");

		builder.Property(c => c.Name)
			   .HasMaxLength(50)
			   .IsRequired();

		builder.Property(c => c.HexValue)
			   .HasColumnType("char(7)")
			   .IsRequired();
	}
}
