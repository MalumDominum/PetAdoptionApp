namespace CityProjectDomain.Api.Models;

public record PostProjectRequest(
	string Title,
	string Link,
	string Description,
	string CityName,
	Guid PublisherId,
	DateTime StartOfVoting,
	DateTime EndOfVoting);
