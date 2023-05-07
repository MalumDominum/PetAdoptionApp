using ErrorOr;
using MediatR;

namespace PetProfileDomain.Application.Commands.Pets.Delete;

public record DeletePetCommand(Guid PetId) : IRequest<ErrorOr<DeletePetCommandResult>>;
