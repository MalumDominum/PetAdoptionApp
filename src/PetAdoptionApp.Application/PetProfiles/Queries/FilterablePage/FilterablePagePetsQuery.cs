﻿using ErrorOr;
using MediatR;
using PetAdoptionApp.Domain.Aggregates.PetProfileAggregate.Specifications.Models;

namespace PetAdoptionApp.Application.PetProfiles.Queries.FilterablePage;

public record FilterablePagePetsQuery(
		DateTime? FromTime,
		PetProfileFilteringValues Filtering
		) : IRequest<ErrorOr<FilterablePagePetsQueryResult>>;
