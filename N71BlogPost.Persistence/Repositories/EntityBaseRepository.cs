using Microsoft.EntityFrameworkCore;
using N71BlogPost.Domain.Common;

namespace N71BlogPost.Persistence.Repositories;
public abstract class EntityBaseRepository<TEntity, TContext> where TEntity : class, IEntity
    where TContext : DbContext
{
    protected readonly DbContext _dbContext;
    protected TContext DbContext=>(TContext)_dbContext;

    protected EntityBaseRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    protected IQueryable<TEntity> Get(bool asNoTracking = true)
    {
        if (asNoTracking)
            DbContext.Set<TEntity>().AsNoTracking();

        return DbContext.Set<TEntity>().AsQueryable();

    }
 
    protected async ValueTask<TEntity?> GetByIdAsync(Guid id, bool asNoTracking = true,CancellationToken cancellationToken = default)
    {
        if(asNoTracking)
            DbContext.Set<TEntity>().AsNoTracking();

        return await DbContext.Set<TEntity>().SingleOrDefaultAsync(entity => entity.Id == id, cancellationToken);
    }

    protected async ValueTask<TEntity?> CreateAsync(TEntity entity,bool saveChanges = true,CancellationToken cancellationToken=default)
    {
        await DbContext.Set<TEntity>().AddAsync(entity,cancellationToken);

        if (saveChanges)
            await DbContext.SaveChangesAsync(cancellationToken);

        return entity;

    }
    protected async ValueTask<TEntity>Update(TEntity entity,bool saveChanges=true,CancellationToken cancellationToken=default)
    {
         DbContext.Update(entity);

        if (saveChanges)
            await DbContext.SaveChangesAsync(cancellationToken);
        
        return entity;
    }
    protected async ValueTask<TEntity>Delete(TEntity entity,bool saveChanges=true, CancellationToken cancellationToken=default)
    {
        DbContext.Remove(entity);
        if (saveChanges)
            await DbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }
}
