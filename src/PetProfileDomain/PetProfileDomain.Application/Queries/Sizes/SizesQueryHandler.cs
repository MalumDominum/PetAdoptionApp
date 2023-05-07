using ErrorOr;
using MediatR;
using PetAdoptionApp.SharedKernel.DataAccess;
using PetProfileDomain.Domain.Aggregates.SizeAggregate;

namespace PetProfileDomain.Application.Queries.Sizes;

public class SizesQueryHandler : IRequestHandler<SizesQuery, ErrorOr<SizesQueryResult>>
{
	private readonly IReadRepository<Size> _sizeRepository;

	public SizesQueryHandler(IReadRepository<Size> sizeRepository) => _sizeRepository = sizeRepository;

	public async Task<ErrorOr<SizesQueryResult>> Handle(
		SizesQuery query, CancellationToken cancellationToken)
	{
		var result = await _sizeRepository.ListAsync(cancellationToken);
		return new SizesQueryResult(result);
	}
}
