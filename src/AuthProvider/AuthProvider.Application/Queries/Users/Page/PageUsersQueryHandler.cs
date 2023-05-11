using AuthProvider.Application.Models;
using AuthProvider.Domain.Aggregates.UserAggregate;
using AuthProvider.Domain.Aggregates.UserAggregate.Specifications;
using AuthProvider.Domain.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using PetAdoptionApp.SharedKernel.DataAccess;
using PetAdoptionApp.SharedKernel.Pagination.Extensions;

namespace AuthProvider.Application.Queries.Users.Page;

public class PageUsersQueryHandler
	: IRequestHandler<PageUsersQuery, ErrorOr<PageUsersQueryResult>>
{
	private readonly IMapper _mapper;
	private readonly IConfiguration _configuration;
	private readonly IRepository<User> _userRepository;

	#region Constructor

	public PageUsersQueryHandler(IMapper mapper, IConfiguration configuration, IRepository<User> userRepository)
	{
		_mapper = mapper;
		_configuration = configuration;
		_userRepository = userRepository;
	}

	#endregion

	public async Task<ErrorOr<PageUsersQueryResult>> Handle(
		PageUsersQuery query, CancellationToken cancellationToken)
	{
		var pageLimit = _configuration.GetValue<int>("Pagination:PageLimit");
		var specification = new PageUsersSpec(query.PageNumber, pageLimit);
		var result = await _userRepository.ListAsync(specification, cancellationToken);

		var rowsCount = await _userRepository.CountAsync(cancellationToken);
		return result.Count > 0
			? new PageUsersQueryResult(
				_mapper.Map<List<FullUserDto>>(result),
				PaginationExtensions.GetPaginationDetails(query.PageNumber, pageLimit, rowsCount, query.Request))
			: Errors.User.NoFurtherRecordsError;
	}
}
