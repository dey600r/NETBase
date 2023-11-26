using BASE.AppInfrastructure.Context;
using BASE.AppInfrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BASE.AppInfrastructure.Repository
{
	public class BaseReaderRepository<TEntity, TId> : BaseDisposable,
												IBaseReaderRepository<TEntity, TId> where TEntity : class, IBaseEntity<TId>, new()
																				where TId : struct
	{
		protected readonly DBContext _dbContext;

		public BaseReaderRepository(DBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IQueryable<TEntity> GetAll() => _dbContext.Set<TEntity>().AsNoTracking().AsQueryable();

		public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate) => GetAll().Where(predicate).AsNoTracking().AsQueryable();

		public IQueryable<TEntity> GetByColumn<TValue>(string column, TValue value)
		{
			return GetAll(x =>
				x.GetType().GetProperty(column) != null &&
				x.GetType().GetProperty(column).GetValue(x, null) != null &&
				x.GetType().GetProperty(column).GetValue(x, null).Equals(value));
		}

		public TEntity GetById(TId id) => GetByIds(new List<TId>() { id }).FirstOrDefault();

		public IEnumerable<TEntity> GetByIds(IEnumerable<TId> ids) => GetAll(x => ids.Contains(x.Id));
	}
}
