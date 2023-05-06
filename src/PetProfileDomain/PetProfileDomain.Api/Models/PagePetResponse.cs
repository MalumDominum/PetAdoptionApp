using PetProfileDomain.Application.Common;
using PetProfileDomain.Application.Pets.Queries.Models;

namespace PetProfileDomain.Api.Models;

public record PagePetResponse(
	List<PetInListDto> Results,
	PaginationDetails Pagination);
