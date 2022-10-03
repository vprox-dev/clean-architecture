namespace CleanArchitecture.Core.Repositories.Base;

public interface IRepository<T> where T : class
{
    Task<IReadOnlyList<T>> GetAllAsync();

    Task<T> GetByIdAsync(int id);

    Task<T> AddAsync(T entity);

    Task UpdateAsync(int id, T entity);

    Task DeleteAsync(int id);
}