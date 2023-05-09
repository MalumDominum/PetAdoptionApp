using AuthProvider.Application.Models;
using System.Security.Claims;
using AuthProvider.Domain.Aggregates.UserAggregate;

namespace AuthProvider.Application.Services.Interfaces;

public interface ITokenProviderService
{
	Token GenerateToken(User user);

	Token GenerateToken(IEnumerable<Claim> claims);
}
