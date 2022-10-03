using CleanArchitecture.Core.Repositories.Base;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories.Base;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApiContext _context;

    public Repository(ApiContext context)
    {
        _context = context;
    }

    public async Task<T> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        T existing = _context.Set<T>().Find(id);
        if (existing != null)
        {
            _context.Remove(existing);
            _context.SaveChanges();
        }
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync((long)id);
    }

    public async Task UpdateAsync(int id, T entity)
    {
        T existing = _context.Set<T>().Find(id);
        if (existing != null)
        {
            _context.Entry(existing).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }
    }
}