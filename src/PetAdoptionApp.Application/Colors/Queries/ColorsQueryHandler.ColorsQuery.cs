using ErrorOr;
using MediatR;

namespace PetAdoptionApp.Application.Colors.Queries;

public record ColorsQuery : IRequest<ErrorOr<ColorsQueryResult>>;
