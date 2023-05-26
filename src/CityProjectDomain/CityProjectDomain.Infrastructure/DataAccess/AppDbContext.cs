using System.Reflection;
using CityProjectDomain.Domain.Aggregates.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using PetAdoptionApp.SharedKernel.DomainEvents;

namespace CityProjectDomain.Infrastructure.DataAccess;

public class AppDbContext : DbContext
{
	private readonly IDomainEventDispatcher? _dispatcher;

	public AppDbContext(DbContextOptions<AppDbContext> options,
		IDomainEventDispatcher? dispatcher) : base(options)
	{
		_dispatcher = dispatcher;
	}

	public DbSet<Project> Projects => Set<Project>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
	}

	public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
	{
		var result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

		// ignore events if no dispatcher provided
		if (_dispatcher == null) return result;

		// dispatch events only if save was successful
		var entitiesWithEvents = ChangeTracker.Entries<DomainEventSender>()
			.Select(e => e.Entity)
			.Where(e => e.DomainEvents.Any())
			.ToArray();

		await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

		return result;
	}

	public override int SaveChanges() => SaveChangesAsync().GetAwaiter().GetResult();
}
