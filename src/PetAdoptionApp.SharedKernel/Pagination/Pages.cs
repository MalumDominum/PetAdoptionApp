namespace PetAdoptionApp.SharedKernel.Pagination;

public record Pages(
	Uri First,
	Uri? BeforePreviousPage,
	Uri? PreviousPage,
	Uri? NextPage,
	Uri? AfterNextPage,
	Uri? LastPage);
