using PetProfileDomain.Application.Commands.Pets.Common;

namespace PetProfileDomain.Application.Queries.Pets.Commands.Update;

public class UpdatePetCommandValidator : CreateUpdatePetCommandValidator<UpdatePetCommand>
{
	public UpdatePetCommandValidator() { }
}
