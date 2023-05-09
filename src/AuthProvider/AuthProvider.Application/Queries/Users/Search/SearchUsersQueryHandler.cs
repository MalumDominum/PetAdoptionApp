using AuthProvider.Application.Models;
using AuthProvider.Domain.Aggregates.UserAggregate;
using AuthProvider.Domain.Aggregates.UserAggregate.Specifications;
using AuthProvider.Domain.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using PetAdoptionApp.SharedKernel.DataAccess;

namespace AuthProvider.Application.Queries.Users.Search;

public class SearchUsersQueryHandler
	: IRequestHandler<SearchUsersQuery, ErrorOr<SearchUsersQueryResult>>
{
	private readonly IMapper _mapper;
	private readonly IRepository<User> _userRepository;

	public SearchUsersQueryHandler(IMapper mapper, IRepository<User> userRepository)
	{
		_mapper = mapper;
		_userRepository = userRepository;
	}

	public async Task<ErrorOr<SearchUsersQueryResult>> Handle(
		SearchUsersQuery query, CancellationToken cancellationToken)
	{
		var specification = new SearchUsersSpec(query.SearchValue);
		var result = await _userRepository.ListAsync(specification, cancellationToken);
		
		return result is { Count: > 0 }
			? new SearchUsersQueryResult(_mapper.Map<List<InListUserDto>>(result))
			: Errors.User.NoSuchRecordsFoundError;
	}
}
