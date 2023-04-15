using ErrorOr;
using MediatR;

namespace PetAdoptionApp.Application.PetProfiles.Commands.Delete;

public record DeletePetCommand(Guid PetProfileId) : IRequest<ErrorOr<DeletePetCommandResult>>;
