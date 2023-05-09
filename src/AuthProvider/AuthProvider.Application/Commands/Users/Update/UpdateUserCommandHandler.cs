using AuthProvider.Domain.Aggregates.UserAggregate;
using AuthProvider.Domain.Aggregates.UserAggregate.Specifications;
using AuthProvider.Domain.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using PetAdoptionApp.SharedKernel.DataAccess;

namespace AuthProvider.Application.Commands.Users.Update;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ErrorOr<UpdateUserCommandResult>>
{
	private readonly IMapper _mapper;

	private readonly IRepository<User> _userRepository;

	#region Constructor

	public UpdateUserCommandHandler(IMapper mapper, IRepository<User> userRepository)
	{
		_mapper = mapper;
		_userRepository = userRepository;
	}

	#endregion

	public async Task<ErrorOr<UpdateUserCommandResult>> Handle(
		UpdateUserCommand command, CancellationToken cancellationToken)
	{
		var user = await _userRepository.SingleOrDefaultAsync(
			new UserForUpdateSpec(command.Id), cancellationToken);

		if (user == null)
			return Errors.User.NoSuchRecordFoundError;
		
		_mapper.From(command).AdaptTo(user);

		await _userRepository.UpdateAsync(user, cancellationToken);

		return new UpdateUserCommandResult();
	}
}
