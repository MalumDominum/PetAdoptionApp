using AuthProvider.Application.Models;
using System.Security.Claims;

namespace AuthProvider.Application.Services.Interfaces;

public interface ITokenProviderService
{
	Token GenerateToken(IEnumerable<Claim> claims);
}
