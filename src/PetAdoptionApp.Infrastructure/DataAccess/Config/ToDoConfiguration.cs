using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetAdoptionApp.Domain.Aggregates.ProjectAggregate;

namespace PetAdoptionApp.Infrastructure.DataAccess.Config;

public class ToDoConfiguration : IEntityTypeConfiguration<ToDoItem>
{
	public void Configure(EntityTypeBuilder<ToDoItem> builder)
	{
		builder.Property(t => t.Title)
				.IsRequired();
		builder.Property(t => t.ContributorId)
				.IsRequired(false);
	}
}
