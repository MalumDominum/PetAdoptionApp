using AuthProvider.Application.Services.Interfaces;
using AuthProvider.Domain.Aggregates.UserAggregate;
using AuthProvider.Domain.Aggregates.UserAggregate.Specifications;
using AuthProvider.Domain.Errors;
using ErrorOr;
using MediatR;
using PetAdoptionApp.SharedKernel.DataAccess;
using static BCrypt.Net.BCrypt;

namespace AuthProvider.Application.Queries.Auth.Authenticate;

public class AuthenticateQueryHandler
	: IRequestHandler<AuthenticateQuery, ErrorOr<AuthenticateQueryResult>>
{
	private readonly ITokenProviderService _tokenProvider;
	private readonly IRepository<User> _userRepository;

	#region Constructor

	public AuthenticateQueryHandler(IRepository<User> userRepository, ITokenProviderService tokenProvider)
	{
		_userRepository = userRepository;
		_tokenProvider = tokenProvider;
	}

	#endregion

	public async Task<ErrorOr<AuthenticateQueryResult>> Handle(
		AuthenticateQuery query, CancellationToken cancellationToken)
	{
		var user = await _userRepository.SingleOrDefaultAsync(
			new UserByEmailSpec(query.Email), cancellationToken);
		if (user == null || !Verify(query.Password, user.PasswordHash))
			return Errors.Auth.WrongCredentialsError;

		var token = _tokenProvider.GenerateToken(user);
		return new AuthenticateQueryResult(user.Id, token,
			user.FirstName, user.LastName, user.Permissions);
	}
}
