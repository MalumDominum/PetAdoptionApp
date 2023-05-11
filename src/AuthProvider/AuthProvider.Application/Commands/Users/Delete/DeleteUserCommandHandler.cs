using AuthProvider.Domain.Aggregates.UserAggregate;
using AuthProvider.Domain.Aggregates.UserAggregate.Events;
using AuthProvider.Domain.Errors;
using ErrorOr;
using MassTransit;
using MediatR;
using PetAdoptionApp.SharedKernel.DataAccess;

namespace AuthProvider.Application.Commands.Users.Delete;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ErrorOr<DeleteUserCommandResult>>
{
	private readonly IRepository<User> _userRepository;
	private readonly IPublishEndpoint _publishEndpoint;

	public DeleteUserCommandHandler(IRepository<User> userRepository, IPublishEndpoint publishEndpoint)
	{
		_userRepository = userRepository;
		_publishEndpoint = publishEndpoint;
	}

	public async Task<ErrorOr<DeleteUserCommandResult>> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
	{
		var user = await _userRepository.GetByIdAsync(command.UserId, cancellationToken);

		if (user == null) return Errors.User.NoSuchRecordFoundError;

		await _publishEndpoint.Publish(
			new UserDeletingEvent(command.UserId), cancellationToken);

		await _userRepository.DeleteAsync(user, cancellationToken);

		await _publishEndpoint.Publish(
			new UserDeletedEvent(command.UserId), cancellationToken);

		return new DeleteUserCommandResult();
	}
}
