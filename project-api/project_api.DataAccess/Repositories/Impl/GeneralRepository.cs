using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace project_api.DataAccess.Repositories.Impl;

public abstract class GeneralRepository<T> : IGeneralRepository<T> where T : class
{
    public const int _defaultResultsSize = 10;
    public const int _defaultOffset = 0;
    private readonly AppDbContext _dbContext;

    public GeneralRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task Create(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task<T> Get(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public virtual async Task<int> Count(Expression<Func<T, bool>> filter)
    {
        return await _dbContext.Set<T>().Where(filter).CountAsync();
    }

    public virtual async Task<int> Count()
    {
        return await _dbContext.Set<T>().CountAsync();
    }

    public virtual async Task<IEnumerable<T>> List(int resultsSize = _defaultResultsSize, int offset = _defaultOffset)
    {
        return await _dbContext.Set<T>()
            .Skip(offset)
            .Take(resultsSize)
            .ToListAsync();
    }

    public virtual async Task<IEnumerable<T>> List()
    {
        return await _dbContext.Set<T>()
            .ToListAsync();
    }

    public virtual async Task<IEnumerable<T>> Search(Expression<Func<T, bool>> filter, int resultsSize = _defaultResultsSize, int offset = _defaultOffset)
    {
        return await _dbContext.Set<T>()
            .Where(filter)
            .Skip(offset)
            .Take(resultsSize)
            .ToListAsync();
    }

    public virtual async Task Update(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task<bool> Exist(Expression<Func<T, bool>> filter)
    {
        return await _dbContext.Set<T>().AnyAsync(filter);
    }

    public virtual async Task<IEnumerable<T>> Search(Expression<Func<T, bool>> filter)
    {
        return await _dbContext.Set<T>()
            .Where(filter)
            .ToListAsync();
    }
}
