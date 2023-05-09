using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthProvider.Application.Models;
using AuthProvider.Application.Services.Interfaces;
using AuthProvider.Domain.Aggregates.UserAggregate;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PetAdoptionApp.SharedKernel.Providers;

namespace AuthProvider.Application.Services;

public class TokenProviderService : ITokenProviderService
{
	private readonly IDateTimeProvider _dateTimeProvider;
	private readonly IConfiguration _configuration;

	private const string JwtSecretSection = "JwtSettings:SecretKey";
	private const string JwtExpiringMinutes = "JwtSettings:ExpiringMinutes";

	#region Constructor

	public TokenProviderService(IDateTimeProvider dateTimeProvider, IConfiguration configuration)
	{
		_dateTimeProvider = dateTimeProvider;
		_configuration = configuration;
	}

	#endregion

	public Token GenerateToken(User user) =>
		GenerateToken(new List<Claim>
		{
			new (ClaimTypes.Email, user.Email),
			//new (ClaimTypes.Gender, user.Gender)
		});

	public Token GenerateToken(IEnumerable<Claim> claims)
	{
		var secretKey = Encoding.ASCII.GetBytes(_configuration.GetValue<string>(JwtSecretSection) ?? "");
		if (secretKey.Length == 0) throw new ConfigurationException("JWT secret key doesn't provided");

		var expiresAt = _dateTimeProvider.UtcNow.AddMinutes(
			_configuration.GetValue<int>(JwtExpiringMinutes));

		var jwt = new JwtSecurityToken(
			claims: claims,
			notBefore: _dateTimeProvider.UtcNow,
			expires: expiresAt,
			signingCredentials: new SigningCredentials(
				new SymmetricSecurityKey(secretKey),
				SecurityAlgorithms.HmacSha256Signature));

		return new Token(
			new JwtSecurityTokenHandler().WriteToken(jwt),
			expiresAt);
	}
}
