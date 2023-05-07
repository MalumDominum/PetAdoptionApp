namespace PetProfileDomain.Application.Models.Common;

public record PaginationDetails(
	int CurrentPageNumber,
	int LastPageNumber,
	int TotalResultCount,
	Pages Pages);
