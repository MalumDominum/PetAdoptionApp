using AuthProvider.Application.Models;
using AuthProvider.Domain.Aggregates.UserAggregate;
using AuthProvider.Domain.Aggregates.UserAggregate.Specifications;
using AuthProvider.Domain.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using PetAdoptionApp.SharedKernel.DataAccess;

namespace AuthProvider.Application.Queries.Users.ByIdUndetailed;

public class UserByIdUndetailedQueryHandler
	: IRequestHandler<UserByIdUndetailedQuery, ErrorOr<UserByIdUndetailedQueryResult>>
{
	private readonly IMapper _mapper;
	private readonly IRepository<User> _userRepository;

	public UserByIdUndetailedQueryHandler(IMapper mapper, IRepository<User> userRepository)
	{
		_mapper = mapper;
		_userRepository = userRepository;
	}

	public async Task<ErrorOr<UserByIdUndetailedQueryResult>> Handle(
		UserByIdUndetailedQuery query, CancellationToken cancellationToken)
	{
		var specification = new UserByIdSpec(query.Id);
		var result = await _userRepository.SingleOrDefaultAsync(specification, cancellationToken);
		
		return result != null
			? new UserByIdUndetailedQueryResult(_mapper.Map<InListUserDto>(result))
			: Errors.User.NoSuchRecordFoundError;
	}
}
