using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Enums;
using PetAdoptionApp.SharedKernel.DddModelsDefinition;

namespace PetAdoptionApp.Domain.Aggregates.PetProfileAggregate;

public class PetProfile : EntityBase, IAggregateRoot
{
	public int PetId { get; set; }

	public string Name { get; set; } = null!;

	public string Description { get; set; } = null!;

	public string Species { get; set; } = null!;

	public string Breed { get; set; } = null!;

	public DateTime? BirthDate { get; set; }
	
	public bool? Neutering { get; set; }
	
	public Gender Gender { get; set; }
	
	public bool Healthy { get; set; }

	public int ViewsNumber { get; } = 0;
	
	public DateTime CreatedAt { get; set; }
	
	public DateTime? LastUpdateAt { get; set; }

	//public int AddressId { get; }
	//public int UserId { get; }

	//public Address Address { get; set; }
	//public User User { get; set; }
	//private IEnumerable<Status> _statuses { get; set; } = new List<Status>();
	//private IEnumerable<Comment> _comments { get; set; } = new List<Comment>();
	//private IEnumerable<PetPhoto> _petPhotos { get; set; } = new List<PetPhoto>();
}
