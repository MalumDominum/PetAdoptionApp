using PetProfileDomain.Application.Commands.Pets.Common;

namespace PetProfileDomain.Application.Commands.Pets.Update;

public class UpdatePetCommandValidator : CreateUpdatePetCommandValidator<UpdatePetCommand>
{
	public UpdatePetCommandValidator() { }
}
