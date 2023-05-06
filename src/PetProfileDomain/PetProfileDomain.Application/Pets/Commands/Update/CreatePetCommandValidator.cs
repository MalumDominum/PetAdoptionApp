using PetProfileDomain.Application.Pets.Commands.Common;

namespace PetProfileDomain.Application.Pets.Commands.Update;

public class UpdatePetCommandValidator : CreateUpdatePetCommandValidator<UpdatePetCommand>
{
	public UpdatePetCommandValidator() { }
}
