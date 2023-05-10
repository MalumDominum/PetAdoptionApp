using AuthProvider.Domain.Aggregates.UserAggregate;
using AuthProvider.Domain.Aggregates.UserAggregate.Entities;
using AuthProvider.Domain.Aggregates.UserAggregate.Specifications;
using AuthProvider.Domain.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using PetAdoptionApp.SharedKernel.DataAccess;

namespace AuthProvider.Application.Commands.Users.RevokeRole;

public class RevokeRoleCommandHandler : IRequestHandler<RevokeRoleCommand, ErrorOr<RevokeRoleCommandResult>>
{
	private readonly IMapper _mapper;
	private readonly IRepository<User> _userRepository;

	#region Constructor

	public RevokeRoleCommandHandler(IMapper mapper, IRepository<User> userRepository)
	{
		_mapper = mapper;
		_userRepository = userRepository;
	}

	#endregion

	public async Task<ErrorOr<RevokeRoleCommandResult>> Handle(
		RevokeRoleCommand command, CancellationToken cancellationToken)
	{
		var user = await _userRepository.SingleOrDefaultAsync(
			new UserByIdSpec(command.TargetUserId), cancellationToken);
		if (user == null) return Errors.User.NoSuchRecordFoundError;

		var permissionIndex = Array.IndexOf(
			user.Permissions.Select(p => p.Role.Value).ToArray(),
			command.Role);

		if (permissionIndex == -1)
			return Errors.Auth.UserHasNoSuchRoleError;

		user.Permissions.RemoveAt(permissionIndex);
		await _userRepository.UpdateAsync(user, cancellationToken);
		return new RevokeRoleCommandResult();
	}
}
