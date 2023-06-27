using Com.ACSCorp.AccountPlanning.Service.IRepository;
using Com.ACSCorp.AccountPlanning.Service.Repository.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Com.ACSCorp.AccountPlanning.Service.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository where TEntity : class
    {
        protected readonly SampleContext _dbContext;
        protected readonly AccountPlanningContext _AccountPlanningContext;

        public BaseRepository(SampleContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BaseRepository(AccountPlanningContext AccountPlanningContext)
        {
            _AccountPlanningContext = AccountPlanningContext;
        }



        protected virtual IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        protected virtual IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().AsNoTracking().Where(predicate);
        }

        protected virtual async Task<TEntity> GetAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        protected virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        protected virtual async Task Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            await SaveChangesAsync();
        }

        protected virtual async Task AddRange(List<TEntity> entities)
        {
            _dbContext.Set<TEntity>().AddRange(entities);
            await SaveChangesAsync();
        }

        protected virtual async Task Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await SaveChangesAsync();
        }

        public virtual async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync().ConfigureAwait(false) > 0;
        }

        public virtual IDbContextTransaction BeginTransaction()
        {
            return _dbContext.Database.BeginTransaction();
        }
    }
}