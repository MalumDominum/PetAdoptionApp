using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PetAdoptionApp.Domain.Aggregates.BreedAggregate;
using PetAdoptionApp.Domain.Aggregates.ColorAggregate;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate;
using PetAdoptionApp.Domain.Aggregates.SizeAggregate;
using PetAdoptionApp.Domain.Aggregates.SpeciesAggregate;
using PetAdoptionApp.SharedKernel.Events;

namespace PetAdoptionApp.Infrastructure.DataAccess;

public class AppDbContext : DbContext
{
	private readonly IDomainEventDispatcher? _dispatcher;

	public AppDbContext(DbContextOptions<AppDbContext> options,
		IDomainEventDispatcher? dispatcher) : base(options)
	{
		_dispatcher = dispatcher;
	}

	public DbSet<PetProfile> PetProfiles => Set<PetProfile>();

	public DbSet<PetColor> PetColors => Set<PetColor>();

	public DbSet<Color> Colors => Set<Color>();

	public DbSet<Size> Sizes => Set<Size>();

	public DbSet<Species> Species => Set<Species>();

	public DbSet<Breed> Breeds => Set<Breed>();

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
		var entitiesWithEvents = ChangeTracker.Entries<DomainEventSender>()
			.Select(e => e.Entity)
			.Where(e => e.DomainEvents.Any())
			.ToArray();

		await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

		return result;
	}

	public override int SaveChanges() => SaveChangesAsync().GetAwaiter().GetResult();
}
