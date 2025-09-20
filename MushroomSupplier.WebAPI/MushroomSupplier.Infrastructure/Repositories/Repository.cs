using Microsoft.EntityFrameworkCore;
using MushroomSupplier.Core.Interfaces;
using MushroomSupplier.Infrastructure.Data;
namespace MushroomSupplier.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly MushroomContext _context;
    protected readonly DbSet<T> _dbSet;
    public Repository(MushroomContext context)
    {
        _context = _context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>?> GetAll()
    {
        var entity =  await _dbSet.ToListAsync();
        if (entity.Count == 0) return null;
        return entity;
    }

    public async Task<T> GetId(int id)
    {
        return await _dbSet!.FindAsync(id);
    }

    public async Task Add(T entity)
    {
        await _dbSet!.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _dbSet!.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet!.Remove(entity);
    }
}