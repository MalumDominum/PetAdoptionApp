using PetProfileDomain.Application.Models.Common;
using PetProfileDomain.Application.Models.Models;

namespace PetProfileDomain.Api.Models;

public record PagePetResponse(
	List<PetInListDto> Results,
	PaginationDetails Pagination);
