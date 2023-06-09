﻿using AuthProvider.Application.Models;
using AuthProvider.Domain.Aggregates.UserAggregate;
using AuthProvider.Domain.Aggregates.UserAggregate.Specifications;
using AuthProvider.Domain.Errors;
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
		var specification = new UserByIdSpec(query.Id);
		var result = await _userRepository.SingleOrDefaultAsync(specification, cancellationToken);
		
		return result != null
			? new UserByIdQueryResult(_mapper.Map<DetailedUserDto>(result))
			: Errors.User.NoSuchRecordFoundError;
	}
}
