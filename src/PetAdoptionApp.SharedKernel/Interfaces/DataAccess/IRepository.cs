namespace PetAdoptionApp.SharedKernel.Interfaces.DataAccess;

public interface IRepository<in TKey, TEntity> : IDisposable where TEntity : class
{
	Task<TEntity> AddAsync(TEntity entity);

	Task UpdateAsync(TEntity entity);

	Task<TEntity> DeleteAsync(TEntity entity);

	Task<List<TEntity>> GetAllAsync();

	Task<TEntity?> GetByIdAsync(TKey id);
}