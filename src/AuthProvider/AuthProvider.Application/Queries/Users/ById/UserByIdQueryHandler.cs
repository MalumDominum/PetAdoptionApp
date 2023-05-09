using AuthProvider.Application.Models;
using AuthProvider.Domain.Aggregates.UserAggregate;
using ErrorOr;
using MapsterMapper;
using MediatR;
using PetAdoptionApp.SharedKernel.DataAccess;

namespace AuthProvider.Application.Queries.Users.ById;

public class UserByIdQueryHandler
	: IRequestHandler<UserByIdQuery, ErrorOr<UserByIdQueryResult>>
{
	private readonly IMapper _mapper;
	private readonly IRepository<User> _userRepository;

	public UserByIdQueryHandler(IMapper mapper, IRepository<User> userRepository)
	{
		_mapper = mapper;
		_userRepository = userRepository;
	}

	public async Task<ErrorOr<UserByIdQueryResult>> Handle(
		UserByIdQuery query, CancellationToken cancellationToken)
	{
		//var specification = new UserByIdSpec(query.Id);
		//var result = await _userRepository.FirstOrDefaultAsync(specification, cancellationToken);
		//
		//return result != null
		//	? new UserByIdQueryResult(_mapper.Map<DetailedUserDto>(result))
		//	: Errors.User.NoSuchRecordFoundError;
		await Task.Delay(0);
		return new UserByIdQueryResult(new DetailedUserDto("A", "B"));
	}
}
