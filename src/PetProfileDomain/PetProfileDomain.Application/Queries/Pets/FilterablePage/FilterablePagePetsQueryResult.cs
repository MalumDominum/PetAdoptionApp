using PetAdoptionApp.SharedKernel.Pagination;
using PetProfileDomain.Application.Models.Pets;

namespace PetProfileDomain.Application.Queries.Pets.FilterablePage;

public record FilterablePagePetsQueryResult(
	List<PetInListDto> Results,
	PaginationDetails Pagination);
