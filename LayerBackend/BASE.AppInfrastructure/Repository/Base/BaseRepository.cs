using BASE.AppInfrastructure.Context;
using BASE.AppInfrastructure.Entities;
using BASE.Common.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BASE.AppInfrastructure.Repository
{
    public class BaseRepository<TEntity, TId> : BaseDisposable, IBaseRepository<TEntity, TId> where TEntity : class, IBaseEntity<TId>, new()
                                                                                where TId : struct
    {
        protected readonly DBContext _dbContext;
        public BaseRepository(DBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public TEntity Add(TEntity entity)
        {
            var result = _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public IEnumerable<TEntity> Adds(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public bool Delete(TId id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteByColumn(string column, TId value)
        {
            throw new NotImplementedException();
        }

        public bool Deletes(IEnumerable<TId> id)
        {
            throw new NotImplementedException();
        }

		public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public IEnumerable<TEntity> GetByColumn(string column, TId value)
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(TId id)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Updates(IEnumerable<TEntity> entity)
        {
            throw new NotImplementedException();
        }
    }
}
