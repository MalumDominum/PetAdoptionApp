using Ardalis.Result;

namespace PetAdoptionApp.Application.Interfaces;

public interface IDeleteContributorService
{
	public Task<Result> DeleteContributor(int contributorId);
}
