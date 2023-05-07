namespace PetProfileDomain.Application.Configuration;

public class RabbitMqConfig
{
	public string Host { get; set; } = null!;
	public ushort Port { get; set; }
	public string UserName { get; set; } = null!;
	public string Password { get; set; } = null!;
	public string VirtualHost { get; set; } = null!;
}
