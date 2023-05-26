namespace CityProjectDomain.Api.Models;

public record PutProjectRequest(
	Guid Id,
	string Title,
	string Link,
	string Description,
	string CityName,
	Guid PublisherId,
	DateTime StartOfVoting,
	DateTime EndOfVoting);
