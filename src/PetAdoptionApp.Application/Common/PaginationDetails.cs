namespace PetAdoptionApp.Application.Common;

public record PaginationDetails(
	int CurrentPageNumber,
	int LastPageNumber,
	int TotalResultCount,
	
	Uri First,
	Uri? BeforePreviousPage,
	Uri? PreviousPage,
	Uri? NextPage,
	Uri? AfterNextPage,
	Uri LastPage);
