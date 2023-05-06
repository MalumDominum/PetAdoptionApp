using PetProfileDomain.Application.Common;
using PetProfileDomain.Application.Pets.Queries.Models;

namespace PetProfileDomain.Application.Pets.Queries.FilterablePage;

public record FilterablePagePetsQueryResult(
	List<PetInListDto> Results,
	PaginationDetails Pagination);
