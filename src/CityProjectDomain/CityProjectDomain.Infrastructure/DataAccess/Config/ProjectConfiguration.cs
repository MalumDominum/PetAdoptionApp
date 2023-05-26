using CityProjectDomain.Domain.Aggregates.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityProjectDomain.Infrastructure.DataAccess.Config;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
	public void Configure(EntityTypeBuilder<Project> builder)
	{
		builder.ToTable("Projects");

		builder.HasKey(s => s.Id);
		builder.Property(s => s.Id)
			   .HasColumnName("ProjectId");

		builder.Property(s => s.Title)
			   .HasMaxLength(150)
			   .IsRequired();

		builder.Property(s => s.Link)
			   .HasMaxLength(200)
			   .IsRequired();

		builder.Property(s => s.Description)
			   .HasMaxLength(3000)
			   .IsRequired();

		builder.Property(s => s.CityName)
			   .HasMaxLength(50)
			   .IsRequired();

		builder.Property(s => s.PublisherId)
			   .IsRequired();

		builder.Property(s => s.StartOfVoting);
		builder.Property(s => s.EndOfVoting);
	}
}
