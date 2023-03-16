namespace PetAdoptionApp.Application.Common;

public record PaginationDetails(
	int CurrentPageNumber,
	int LastPageNumber,
	int TotalResultCount,
	Pages Pages);
