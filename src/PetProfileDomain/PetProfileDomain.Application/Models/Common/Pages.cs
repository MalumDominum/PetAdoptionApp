namespace PetProfileDomain.Application.Models.Common;

public record Pages(
	Uri First,
	Uri? BeforePreviousPage,
	Uri? PreviousPage,
	Uri? NextPage,
	Uri? AfterNextPage,
	Uri? LastPage);
