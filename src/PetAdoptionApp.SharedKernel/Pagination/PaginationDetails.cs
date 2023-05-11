namespace PetAdoptionApp.SharedKernel.Pagination;

public record PaginationDetails(
	int CurrentPageNumber,
	int LastPageNumber,
	int TotalResultCount,
	Pages Pages);
