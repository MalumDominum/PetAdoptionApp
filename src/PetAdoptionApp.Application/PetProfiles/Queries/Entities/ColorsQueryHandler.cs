using ErrorOr;
using MediatR;
using PetAdoptionApp.Domain.Aggregates.ColorAggregate;
using PetAdoptionApp.SharedKernel.DataAccess;

namespace PetAdoptionApp.Application.PetProfiles.Queries.Entities;

public class ColorsQueryHandler : IRequestHandler<ColorsQuery, ErrorOr<ColorsQueryResult>>
{
	private readonly IReadRepository<Color> _colorRepository;

	public ColorsQueryHandler(IReadRepository<Color> colorRepository) => _colorRepository = colorRepository;

	public async Task<ErrorOr<ColorsQueryResult>> Handle(
		ColorsQuery query, CancellationToken cancellationToken)
	{
		var result = await _colorRepository.ListAsync(cancellationToken);
		return new ColorsQueryResult(result);
	}
}
