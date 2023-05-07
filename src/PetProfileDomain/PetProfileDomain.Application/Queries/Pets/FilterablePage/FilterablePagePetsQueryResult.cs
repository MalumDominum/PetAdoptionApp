using PetProfileDomain.Application.Models.Common;
using PetProfileDomain.Application.Models.Models;

namespace PetProfileDomain.Application.Queries.Pets.FilterablePage;

public record FilterablePagePetsQueryResult(
	List<PetInListDto> Results,
	PaginationDetails Pagination);
