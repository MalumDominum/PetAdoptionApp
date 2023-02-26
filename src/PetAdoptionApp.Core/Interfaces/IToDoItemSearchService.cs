using Ardalis.Result;
using PetAdoptionApp.Core.ProjectAggregate;

namespace PetAdoptionApp.Core.Interfaces;
public interface IToDoItemSearchService
{
    Task<Result<ToDoItem>> GetNextIncompleteItemAsync(int projectId);
    Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(int projectId, string searchString);
}
