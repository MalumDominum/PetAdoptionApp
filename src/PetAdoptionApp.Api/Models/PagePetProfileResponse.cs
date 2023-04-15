using PetAdoptionApp.Application.Common;
using PetAdoptionApp.Application.PetProfiles.Queries.Models;

namespace PetAdoptionApp.Api.Models;

public record PagePetProfileResponse(
	List<PetProfileInListDto> Results,
	PaginationDetails Pagination);
