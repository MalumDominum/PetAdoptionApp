using Ardalis.Specification;

namespace PetAdoptionApp.SharedKernel.Specifications.Extensions;

public static class CommonSpecificationExtensions
{
	public static ISpecificationBuilder<T> Paginate<T>(
		this ISpecificationBuilder<T> query, int? pageNumber, int pageLimit)
	{
		return pageNumber != null
			? query.Skip((pageNumber.Value - 1) * pageLimit)
				   .Take(pageLimit)
			: query.Take(pageLimit);
	}
}
