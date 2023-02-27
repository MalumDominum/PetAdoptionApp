using Ardalis.Result;
using PetAdoptionApp.Domain.Aggregates.ProjectAggregate;

namespace PetAdoptionApp.Application.Interfaces;
public interface IToDoItemSearchService
{
    Task<Result<ToDoItem>> GetNextIncompleteItemAsync(int projectId);
    Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(int projectId, string searchString);
}
