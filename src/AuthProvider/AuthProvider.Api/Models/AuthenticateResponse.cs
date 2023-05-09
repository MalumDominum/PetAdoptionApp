namespace AuthProvider.Api.Models;

public class AuthenticateResponse
{
	public long Id { get; set; }

	public string Email { get; set; } = null!;
        
	public string FirstName { get; set; } = null!;

	public string LastName { get; set; } = null!;

	public string Token { get; set; } = null!;
}
