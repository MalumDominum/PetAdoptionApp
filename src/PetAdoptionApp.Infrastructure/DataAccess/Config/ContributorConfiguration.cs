using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetAdoptionApp.Domain.Aggregates.ContributorAggregate;

namespace PetAdoptionApp.Infrastructure.DataAccess.Config;

public class ContributorConfiguration : IEntityTypeConfiguration<Contributor>
{
	public void Configure(EntityTypeBuilder<Contributor> builder)
	{
		builder.Property(p => p.Name)
				.HasMaxLength(100)
				.IsRequired();
	}
}
