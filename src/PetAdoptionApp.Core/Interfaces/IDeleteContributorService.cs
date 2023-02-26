using Ardalis.Result;

namespace PetAdoptionApp.Core.Interfaces;
public interface IDeleteContributorService
{
    public Task<Result> DeleteContributor(int contributorId);
}
