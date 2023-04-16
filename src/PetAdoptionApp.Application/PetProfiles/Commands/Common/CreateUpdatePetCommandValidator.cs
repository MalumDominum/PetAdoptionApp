using FluentValidation;
using PetAdoptionApp.Domain.Aggregates.StateAggregate.Enums;
using static System.String;

namespace PetAdoptionApp.Application.PetProfiles.Commands.Shared;

public class CreateUpdatePetCommandValidator<TCommand> : AbstractValidator<TCommand>
	where TCommand : ICreateUpdatePetCommand
{
	public CreateUpdatePetCommandValidator()
	{
		const int maxColors = 4;
		RuleFor(x => x.ColorIds).Must(x => x == null || x.Count <= maxColors)
			.WithMessage($"The pet must have no more than {maxColors} colors");

		RuleFor(x => x.BirthDate)
			.Must(x => x.IsValid())
			.WithMessage("This date is not valid")
			.Must(x => DateTime.Today.Year - x.Year < 50)
			.WithMessage("The age of the pet is too old")
			.Must(x => x.IsPast())
			.WithMessage("The date of birth cannot be later than today");

		When(petProfile => petProfile.States != null, () =>
		{
			var statusList = Status.List.Select(s => s.Value);
			RuleFor(x => x.States)
				.Must(x => x!.All(s => statusList.Contains(s)))
				.WithMessage(p =>
				{
					var wrongStates = p.States!.Where(s => !statusList.Contains(s)).ToList();
					return wrongStates.Count == 1
						? $"Status with provided state value \'{wrongStates[0]}\' dont exists"
						: $"Statuses with provided state values [{Join(", ", wrongStates)}] dont exists";
				})
				.Must(x => Status.FilterConflicted(x!).Count <= 1)
				.WithMessage(p =>
					$"Inputed status values [{Join(", ", Status.FilterConflicted(p.States!))}] " +
					"are conflicted. PetProfile can have only one listed status at a time")
				.Must(x =>
				{
					var diffChecker = new HashSet<ushort>();
					var isAllDifferent = x!.All(diffChecker.Add);
					return isAllDifferent;
				}).WithMessage("Some statuses have duplicates");
		});
	}
}
