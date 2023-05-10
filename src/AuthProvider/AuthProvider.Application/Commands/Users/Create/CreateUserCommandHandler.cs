using AuthProvider.Application.Services.Interfaces;
using AuthProvider.Domain.Aggregates.UserAggregate;
using AuthProvider.Domain.Aggregates.UserAggregate.Specifications;
using AuthProvider.Domain.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using PetAdoptionApp.SharedKernel.DataAccess;

namespace AuthProvider.Application.Commands.Users.Create;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ErrorOr<CreateUserCommandResult>>
{
	private readonly IMapper _mapper;
	private readonly IRepository<User> _userRepository;
	private readonly ITokenProviderService _tokenProvider;

	#region Constructor

	public CreateUserCommandHandler(IMapper mapper, IRepository<User> userRepository, ITokenProviderService tokenProvider)
	{
		_mapper = mapper;
		_userRepository = userRepository;
		_tokenProvider = tokenProvider;
	}

	#endregion

	public async Task<ErrorOr<CreateUserCommandResult>> Handle(
		CreateUserCommand command, CancellationToken cancellationToken)
	{
		var previousUser = await _userRepository.SingleOrDefaultAsync(new UserByEmailSpec(command.Email), cancellationToken);
		if (previousUser != null) return Errors.Auth.UserAlreadyExistsError;

		var user = _mapper.Map<User>(command);
		var createdUser = await _userRepository.AddAsync(user, cancellationToken);
		return new CreateUserCommandResult(createdUser.Id, _tokenProvider.GenerateToken(createdUser));
	}
}
