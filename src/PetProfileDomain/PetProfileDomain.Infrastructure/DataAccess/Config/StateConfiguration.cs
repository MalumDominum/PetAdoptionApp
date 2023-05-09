using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetProfileDomain.Domain.Aggregates.StateAggregate.Enums;

namespace PetProfileDomain.Infrastructure.DataAccess.Config;

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

		builder.HasOne<Pet>()
			   .WithMany(p => p.States)
			   .HasForeignKey(p => p.PetId)
			   .IsRequired();
	}
}
