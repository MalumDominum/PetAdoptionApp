using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetAdoptionApp.Domain.Aggregates.SizeAggregate;

namespace PetAdoptionApp.Infrastructure.DataAccess.Config;

public class SizeConfiguration : IEntityTypeConfiguration<Size>
{
	public void Configure(EntityTypeBuilder<Size> builder)
	{
		builder.ToTable("Sizes");

		builder.HasKey(s => s.Id);
		builder.Property(s => s.Id)
			   .HasColumnName("SizeId");

		builder.Property(s => s.Title)
			   .HasMaxLength(50)
			   .IsRequired();

		builder.Property(s => s.From)
			   .IsRequired();

		builder.Property(s => s.To)
			   .IsRequired();
	}
}
