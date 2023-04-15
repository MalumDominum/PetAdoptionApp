using ErrorOr;
using MediatR;
using PetAdoptionApp.Domain.Aggregates.SizeAggregate;
using PetAdoptionApp.SharedKernel.DataAccess;

namespace PetAdoptionApp.Application.Sizes.Queries;

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
