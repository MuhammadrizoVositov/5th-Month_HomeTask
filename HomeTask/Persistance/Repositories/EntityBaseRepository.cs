﻿using HomeTask.Domain.Commons;
using Microsoft.EntityFrameworkCore;

namespace HomeTask.Persistance.Repositories;

public abstract class EntityBaseRepository<TEntity, TContext>
    where TContext : DbContext where TEntity : SoftDeleted
{

    protected TContext DbContext;

    protected EntityBaseRepository(TContext dbContext)
    {
        DbContext = dbContext;
    }

    protected IQueryable<TEntity> Get(Func<TEntity, bool>? predicate, bool asNoTracking = false)
    {
        var initialQuery = DbContext.Set<TEntity>().Where(entity => true);

        if (asNoTracking)
            initialQuery.AsNoTracking();

        if (predicate is null)
            return initialQuery;

        return initialQuery.Where(predicate).AsQueryable();
    }

    protected async ValueTask<TEntity?> GetByIdAsync(Guid id, bool asNoTracking = false,
        CancellationToken cancellationToken = default)
    {
        var initialQuery = DbContext.Set<TEntity>();

        if (asNoTracking)
            initialQuery.AsNoTracking();

        return await initialQuery.SingleOrDefaultAsync(enity => enity.Id == id, cancellationToken);
    }
    protected async ValueTask<TEntity> CreateAsync(TEntity entity, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        await DbContext.Set<TEntity>().AddAsync(entity, cancellationToken);

        if (saveChanges)
            await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    protected async ValueTask<TEntity> UpdateAsync(TEntity entity, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        DbContext.Set<TEntity>().Update(entity);

        if (saveChanges)
            await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }
    protected async ValueTask<TEntity> DeleteAsync(TEntity entity, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        DbContext.Set<TEntity>().Remove(entity);

        if (saveChanges)
            await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }
}
