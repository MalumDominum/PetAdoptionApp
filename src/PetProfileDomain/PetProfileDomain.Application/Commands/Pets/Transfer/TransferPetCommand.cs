using ErrorOr;
using MediatR;

namespace PetProfileDomain.Application.Commands.Pets.Transfer;

public record TransferPetCommand(
	Guid OldOwnerId,
	Guid NewOwnerId,
	Guid PetId) : IRequest<ErrorOr<TransferPetCommandResult>>;
