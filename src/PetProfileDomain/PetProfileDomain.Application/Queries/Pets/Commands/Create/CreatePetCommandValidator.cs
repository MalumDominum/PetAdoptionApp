using PetProfileDomain.Application.Commands.Pets.Common;

namespace PetProfileDomain.Application.Queries.Pets.Commands.Create;

public class CreatePetCommandValidator : CreateUpdatePetCommandValidator<CreatePetCommand>
{
	public CreatePetCommandValidator() { }
}
