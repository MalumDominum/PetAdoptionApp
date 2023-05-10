using AuthProvider.Domain.Aggregates.UserAggregate;
using AuthProvider.Domain.Aggregates.UserAggregate.Entities;
using AuthProvider.Domain.Aggregates.UserAggregate.Specifications;
using AuthProvider.Domain.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using PetAdoptionApp.SharedKernel.DataAccess;

namespace AuthProvider.Application.Commands.Users.GrantRole;

public class GrantRoleCommandHandler : IRequestHandler<GrantRoleCommand, ErrorOr<GrantRoleCommandResult>>
{
	private readonly IMapper _mapper;
	private readonly IRepository<User> _userRepository;

	#region Constructor

	public GrantRoleCommandHandler(IMapper mapper, IRepository<User> userRepository)
	{
		_mapper = mapper;
		_userRepository = userRepository;
	}

	#endregion

	public async Task<ErrorOr<GrantRoleCommandResult>> Handle(
		GrantRoleCommand command, CancellationToken cancellationToken)
	{
		var user = await _userRepository.SingleOrDefaultAsync(new UserByIdSpec(command.GranterUserId), cancellationToken);
		if (user == null) return Errors.User.NoSuchRecordFoundError;

		if (user.Permissions.Select(p => p.Role.Value).Contains(command.Role))
			return Errors.Auth.UserAlreadyHasRoleError;

		user.Permissions.Add(_mapper.Map<Permission>(command));
		await _userRepository.UpdateAsync(user, cancellationToken);
		return new GrantRoleCommandResult();
	}
}
