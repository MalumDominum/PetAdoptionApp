using PetProfileDomain.Application.Models.Pets;

namespace PetProfileDomain.Application.Queries.Pets.ById;

public record PetByIdQueryResult(DetailedPetDto Pet);
