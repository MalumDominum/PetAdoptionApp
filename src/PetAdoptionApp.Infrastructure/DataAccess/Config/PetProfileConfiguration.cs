using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate;

namespace PetAdoptionApp.Infrastructure.DataAccess.Config;

public class PetProfileConfiguration : IEntityTypeConfiguration<PetProfile>
{
	public void Configure(EntityTypeBuilder<PetProfile> builder)
	{
		builder.Property(p => p.Name)
				.HasMaxLength(100)
				.IsRequired();
	}
}
