using ErrorOr;
using MediatR;

namespace PetProfileDomain.Application.Queries.Pets.Commands.Delete;

public record DeletePetCommand(Guid PetId) : IRequest<ErrorOr<DeletePetCommandResult>>;
