using ErrorOr;
using MediatR;

namespace PetAdoptionApp.Application.Sizes.Queries;

public record SizesQuery : IRequest<ErrorOr<SizesQueryResult>>;
