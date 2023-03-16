using ErrorOr;
using MediatR;

namespace PetAdoptionApp.Application.PetProfiles.Queries.Entities;

public record ColorsQuery : IRequest<ErrorOr<ColorsQueryResult>>;
