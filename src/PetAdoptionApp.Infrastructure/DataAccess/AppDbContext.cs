using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PetAdoptionApp.Domain.Aggregates.ContributorAggregate;
using PetAdoptionApp.Domain.Aggregates.ProjectAggregate;
using PetAdoptionApp.SharedKernel;
using PetAdoptionApp.SharedKernel.Interfaces;

namespace PetAdoptionApp.Infrastructure.DataAccess;

public class AppDbContext : DbContext
{
	private readonly IDomainEventDispatcher? _dispatcher;

	public AppDbContext(DbContextOptions<AppDbContext> options,
		IDomainEventDispatcher? dispatcher) : base(options)
	{
		_dispatcher = dispatcher;
	}

	public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();
	public DbSet<Project> Projects => Set<Project>();
	public DbSet<Contributor> Contributors => Set<Contributor>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}

	public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
	{
		var result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

		// ignore events if no dispatcher provided
		if (_dispatcher == null) return result;

		// dispatch events only if save was successful
		var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
			.Select(e => e.Entity)
			.Where(e => e.DomainEvents.Any())
			.ToArray();

		await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

		return result;
	}

	public override int SaveChanges() => SaveChangesAsync().GetAwaiter().GetResult();
}
