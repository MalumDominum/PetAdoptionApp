using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate;
using PetAdoptionApp.Domain.Aggregates.StateAggregate;
using PetAdoptionApp.Domain.Aggregates.StateAggregate.Enums;

namespace PetAdoptionApp.Infrastructure.DataAccess.Config;

public class StateConfiguration : IEntityTypeConfiguration<State>
{
	public void Configure(EntityTypeBuilder<State> builder)
	{
		builder.ToTable("States");

		builder.HasKey(p => p.Id);
		builder.Property(p => p.Id)
			   .HasColumnName("StateId");

		builder.Property(p => p.Status)
			   .HasColumnType("smallint")
			   .IsRequired()
			   .HasConversion(e => e.Value, v => Status.FromValue(v));

		builder.Property(p => p.AssignedTime)
			   .HasDefaultValueSql("NOW()");

		builder.HasOne<PetProfile>()
			   .WithMany(p => p.States)
			   .HasForeignKey(p => p.PetProfileId)
			   .IsRequired();
	}
}
