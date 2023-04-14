using ErrorOr;
using MediatR;
using PetAdoptionApp.Domain.Aggregates.SizeAggregate;
using PetAdoptionApp.SharedKernel.DataAccess;

namespace PetAdoptionApp.Application.Sizes.Queries;

public class SizesQueryHandler : IRequestHandler<SizesQuery, ErrorOr<SizesQueryResult>>
{
	private readonly IReadRepository<Size> _heightRepository;

	public SizesQueryHandler(IReadRepository<Size> heightRepository) => _heightRepository = heightRepository;

	public async Task<ErrorOr<SizesQueryResult>> Handle(
		SizesQuery query, CancellationToken cancellationToken)
	{
		var result = await _heightRepository.ListAsync(cancellationToken);
		return new SizesQueryResult(result);
	}
}
