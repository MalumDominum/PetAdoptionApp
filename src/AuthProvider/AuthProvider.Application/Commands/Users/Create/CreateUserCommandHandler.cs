using AuthProvider.Domain.Aggregates.UserAggregate;
using ErrorOr;
using MapsterMapper;
using MediatR;
using PetAdoptionApp.SharedKernel.DataAccess;

namespace AuthProvider.Application.Commands.Users.Create;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ErrorOr<CreateUserCommandResult>>
{
	private readonly IMapper _mapper;
	private readonly IRepository<User> _userRepository;

	#region Constructor

	public CreateUserCommandHandler(IMapper mapper, IRepository<User> userRepository)
	{
		_mapper = mapper;
		_userRepository = userRepository;
	}

	#endregion

	public async Task<ErrorOr<CreateUserCommandResult>> Handle(
		CreateUserCommand command, CancellationToken cancellationToken)
	{
		var pet = _mapper.Map<User>(command);

		var createdPet = await _userRepository.AddAsync(pet, cancellationToken);

		return _mapper.Map<CreateUserCommandResult>(createdPet);
	}
}
