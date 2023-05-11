using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace PetProfileDomain.Application.Queries.Pets.OwnedBy;

public record PetsOwnedByQuery(
	int? PageNumber,
	Guid OwnerId,
	HttpRequest Request) : IRequest<ErrorOr<PetsOwnedByQueryResult>>;
