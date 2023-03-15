using PetAdoptionApp.Application.Common;
using PetAdoptionApp.Application.PetProfiles.Queries.Models;

namespace PetAdoptionApp.Api.Models;

public record PetProfilePageResponse(
	List<PetProfileListDto> Results,
	PaginationDetails Pagination);
