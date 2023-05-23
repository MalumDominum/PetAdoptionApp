namespace PetProfileDomain.Api.Models;

public record TransferPetRequest(Guid PetId, Guid OwnerId);
