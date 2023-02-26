using Ardalis.Result;
using MediatR;
using PetAdoptionApp.Core.ContributorAggregate;
using PetAdoptionApp.Core.ContributorAggregate.Events;
using PetAdoptionApp.Core.Interfaces;
using PetAdoptionApp.SharedKernel.Interfaces;

namespace PetAdoptionApp.Core.Services;
public class DeleteContributorService : IDeleteContributorService
{
    private readonly IRepository<Contributor> _repository;
    private readonly IMediator _mediator;

    public DeleteContributorService(IRepository<Contributor> repository, IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task<Result> DeleteContributor(int contributorId)
    {
        var aggregateToDelete = await _repository.GetByIdAsync(contributorId);
        if (aggregateToDelete == null) return Result.NotFound();

        await _repository.DeleteAsync(aggregateToDelete);
        var domainEvent = new ContributorDeletedEvent(contributorId);
        await _mediator.Publish(domainEvent);
        return Result.Success();
    }
}
