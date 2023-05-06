using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PetAdoptionApp.SharedKernel.Events;
using PetProfileDomain.Domain.Aggregates.BreedAggregate;
using PetProfileDomain.Domain.Aggregates.ColorAggregate;
using PetProfileDomain.Domain.Aggregates.PetAggregate;
using PetProfileDomain.Domain.Aggregates.PetAggregate.Linkers;
using PetProfileDomain.Domain.Aggregates.SizeAggregate;
using PetProfileDomain.Domain.Aggregates.SpeciesAggregate;
using PetProfileDomain.Domain.Aggregates.StateAggregate;

namespace PetProfileDomain.Infrastructure.DataAccess;

public class AppDbContext : DbContext
{
	private readonly IDomainEventDispatcher? _dispatcher;

	public AppDbContext(DbContextOptions<AppDbContext> options,
		IDomainEventDispatcher? dispatcher) : base(options)
	{
		_dispatcher = dispatcher;
	}

	public DbSet<Pet> Pets => Set<Pet>();

	public DbSet<PetColor> PetColors => Set<PetColor>();

	public DbSet<Color> Colors => Set<Color>();

	public DbSet<Size> Sizes => Set<Size>();

	public DbSet<Species> Species => Set<Species>();

	public DbSet<Breed> Breeds => Set<Breed>();

	public DbSet<State> States => Set<State>();

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
