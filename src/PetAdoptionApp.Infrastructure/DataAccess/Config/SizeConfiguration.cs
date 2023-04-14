using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetAdoptionApp.Domain.Aggregates.SizeAggregate;

namespace PetAdoptionApp.Infrastructure.DataAccess.Config;

public class SizeConfiguration : IEntityTypeConfiguration<Size>
{
	public void Configure(EntityTypeBuilder<Size> builder)
	{
		builder.ToTable("Sizes");

		builder.HasKey(p => p.Id);
		builder.Property(p => p.Id)
			   .HasColumnName("SizeId");

		builder.Property(c => c.Title)
			   .HasMaxLength(50)
			   .IsRequired();

		builder.Property(c => c.From)
			   .IsRequired();

		builder.Property(c => c.To)
			   .IsRequired();
	}
}
