using AuthProvider.Application.Models;
using PetAdoptionApp.SharedKernel.Pagination;

namespace AuthProvider.Application.Queries.Users.Page;

public record PageUsersQueryResult(List<FullUserDto> Users, PaginationDetails Pagination);
