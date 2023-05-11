using PetAdoptionApp.SharedKernel.Pagination;
using PetProfileDomain.Application.Models.Pets;

namespace PetProfileDomain.Application.Queries.Pets.OwnedBy;

public record PetsOwnedByQueryResult(List<PetInListDto> Pets, PaginationDetails Pagination);
