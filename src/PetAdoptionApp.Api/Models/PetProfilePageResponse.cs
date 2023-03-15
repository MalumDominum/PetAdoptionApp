using PetAdoptionApp.Application.Common;
using PetAdoptionApp.Application.PetProfiles.Queries;

namespace PetAdoptionApp.Api.Models;

public record PetProfilePageResponse(
	List<PetProfileListDto> Results,
	PaginationDetails Pagination);
