using ErrorOr;
using MediatR;

namespace PetProfileDomain.Application.Commands.Pets.Delete;

public record DeletePetCommand(
	Guid SenderId,
	Guid PetId) : IRequest<ErrorOr<DeletePetCommandResult>>;
