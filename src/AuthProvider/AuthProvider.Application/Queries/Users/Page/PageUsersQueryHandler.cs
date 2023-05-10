using AuthProvider.Application.Models;
using AuthProvider.Domain.Aggregates.UserAggregate;
using AuthProvider.Domain.Aggregates.UserAggregate.Specifications;
using AuthProvider.Domain.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using PetAdoptionApp.SharedKernel.DataAccess;

namespace AuthProvider.Application.Queries.Users.Page;

public class PageUsersQueryHandler
	: IRequestHandler<PageUsersQuery, ErrorOr<PageUsersQueryResult>>
{
	private readonly IMapper _mapper;
	private readonly IRepository<User> _userRepository;
	private readonly IConfiguration _configuration;

	#region Constructor

	public PageUsersQueryHandler(IMapper mapper, IRepository<User> userRepository, IConfiguration configuration)
	{
		_mapper = mapper;
		_userRepository = userRepository;
		_configuration = configuration;
	}

	#endregion

	public async Task<ErrorOr<PageUsersQueryResult>> Handle(
		PageUsersQuery query, CancellationToken cancellationToken)
	{
		var specification = new PageUsersSpec(query.PageNumber, _configuration.GetValue<int>("PageLimit"));
		var result = await _userRepository.ListAsync(specification, cancellationToken);
		
		return result is { Count: > 0 }
			? new PageUsersQueryResult(_mapper.Map<List<FullUserDto>>(result))
			: Errors.User.NoSuchRecordsFoundError;
	}
}
