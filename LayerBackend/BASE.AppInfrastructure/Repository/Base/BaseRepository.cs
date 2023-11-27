using BASE.AppInfrastructure.Context;
using BASE.AppInfrastructure.Entities;
using BASE.Common.Constants;
using BASE.Common.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BASE.AppInfrastructure.Repository
{
    public class BaseRepository<TEntity, TId> : BaseReaderRepository<TEntity, TId>, 
                                                IBaseRepository<TEntity, TId> where TEntity : class, IBaseEntity<TId>, new()
                                                                                where TId : struct
    {
        public BaseRepository(DBContext dbContext) : base(dbContext) { }

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
					_dbContext.Entry(item).State = EntityState.Added;
					results.Add(_dbContext.Set<TEntity>().Add(item).Entity);
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

		public TEntity Update(TEntity entity) => Update(new List<TEntity>() { entity }).FirstOrDefault();

        public IEnumerable<TEntity> Update(IEnumerable<TEntity> entities)
        {
			if (entities == null || !entities.Any())
				throw new DataBaseException("No data to update");

            var entitiesDB = GetByIds(entities.Select(x => x.Id));
            if (entitiesDB.Any(x => entities.Any(y => y.CreatedDate < x.CreatedDate)))
                throw new ConcurrencyDataBaseException("Creation date higher than the new one");

			var results = new List<TEntity>();
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
