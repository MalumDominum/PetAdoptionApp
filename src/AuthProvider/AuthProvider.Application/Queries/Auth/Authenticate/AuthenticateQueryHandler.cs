using System.Security.Claims;
using AuthProvider.Application.Services.Interfaces;
using AuthProvider.Domain.Aggregates.UserAggregate;
using AuthProvider.Domain.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using PetAdoptionApp.SharedKernel.DataAccess;

namespace AuthProvider.Application.Queries.Auth.Authenticate;

public class AuthenticateQueryHandler
	: IRequestHandler<AuthenticateQuery, ErrorOr<AuthenticateQueryResult>>
{
	private readonly IMapper _mapper;
	private readonly ITokenProviderService _tokenProvider;
	private readonly IRepository<User> _userRepository;

	#region Constructor

	public AuthenticateQueryHandler(IMapper mapper, IRepository<User> userRepository, ITokenProviderService tokenProvider)
	{
		_mapper = mapper;
		_userRepository = userRepository;
		_tokenProvider = tokenProvider;
	}

	#endregion

	public async Task<ErrorOr<AuthenticateQueryResult>> Handle(
		AuthenticateQuery query, CancellationToken cancellationToken)
	{
		//var specification = new PetByIdSpec(query.Id);
		//var result = await _petRepository.FirstOrDefaultAsync(specification, cancellationToken);
		//
		//return result != null
		//	? new AuthenticateQueryResult(_mapper.Map<DetailedPetDto>(result))
		//	: Errors.Pet.NoSuchRecordFoundError;

		if (query is not { Email: "test@gmail.com", Password: "password" })
			return  await Task.FromResult(Errors.User.NoSuchRecordFoundError);

		var token = _tokenProvider.GenerateToken(new List<Claim> { new(ClaimTypes.Email, query.Email) });
		return new AuthenticateQueryResult(token);
	}
}
