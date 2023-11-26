using BASE.AppInfrastructure.Context;
using BASE.AppInfrastructure.Entities;
using BASE.Common.Constants;
using BASE.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace BASE.AppInfrastructure.Repository
{
    public class BaseRepository<TEntity, TId> : BaseDisposable, 
                                                IBaseRepository<TEntity, TId> where TEntity : class, IBaseEntity<TId>, new()
                                                                                where TId : struct
    {
        protected readonly DBContext _dbContext;

        public BaseRepository(DBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public TEntity Add(TEntity entity) => Add(new List<TEntity>() { entity }).FirstOrDefault();

        public IEnumerable<TEntity> Add(IEnumerable<TEntity> entities)
        {
            try {
				if (entities == null || !entities.Any())
					throw new DataBaseException("No data to add");

				List<TEntity> results = new List<TEntity>();
			    foreach(TEntity item in entities)
                {
                    item.CreatedUser = Constants.USER_UNKNOWN_AUDIT;
                    item.CreatedDate = DateTime.UtcNow;
                    results.Add(_dbContext.Add(item).Entity);
                }
			    _dbContext.SaveChanges();
			    return results;
		    } catch(Exception ex)
                {
                    throw new DataBaseException("Adding", ex);
	        }
        }

        public bool Delete(TId id) => Delete(new List<TId>() { id });

		public bool Delete(TEntity entity) => Delete(new List<TEntity>() { entity });

		public bool DeleteByColumn<TValue>(string column, TValue value)
        {
            try
            {
                var itemsToDelete = GetByColumn(column, value);
                return Delete(itemsToDelete);
            } catch(Exception ex)
            {
                throw new DataBaseException("DeletingByColumn", ex);
            }
        }

        public bool Delete(IEnumerable<TId> ids)
        {
            try
            {
                var itemsToDelete = GetAll(x => ids.Contains(x.Id));
                return Delete(itemsToDelete);
            } catch(Exception ex)
            {
                throw new DataBaseException("Deleting", ex);
            }
        }

		public bool Delete(IEnumerable<TEntity> entities)
		{
			try
			{
                if(entities == null || !entities.Any())
					throw new DataBaseException("No data to delete");

				foreach (var item in entities)
					_dbContext.Remove(item);
				_dbContext.SaveChanges();
				return true;
			}
			catch (Exception ex)
            {
				throw new DataBaseException("Deleting", ex);
            }
		}

		public IQueryable<TEntity> GetAll() =>_dbContext.Set<TEntity>().AsNoTracking().AsQueryable();

		public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate) => GetAll().Where(predicate).AsNoTracking().AsQueryable();

		public IQueryable<TEntity> GetByColumn<TValue>(string column, TValue value)
        {
            return GetAll(x => 
                x.GetType().GetProperty(column) != null &&
				x.GetType().GetProperty(column).GetValue(x, null) != null &&
				x.GetType().GetProperty(column).GetValue(x, null).Equals(value));
        }

		public TEntity GetById(TId id) => GetAll(x => x.Id.Equals(id)).FirstOrDefault();

		public TEntity Update(TEntity entity) => Update(new List<TEntity>() { entity }).FirstOrDefault();

        public IEnumerable<TEntity> Update(IEnumerable<TEntity> entities)
        {
			if (entities == null || !entities.Any())
				throw new DataBaseException("No data to update");

			List<TEntity> results = new List<TEntity>();
			foreach (TEntity entity in entities)
            {
                entity.CreatedUser = Constants.USER_UNKNOWN_AUDIT;
                entity.CreatedDate = DateTime.UtcNow;
				results.Add(_dbContext.Update(entity).Entity);
            }
            _dbContext.SaveChanges();
            return results;

		}
    }
}
