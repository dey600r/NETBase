using BASE.AppInfrastructure.Entities;
using System.Linq.Expressions;

namespace BASE.AppInfrastructure.Repository
{
	public interface IBaseReaderRepository<TEntity, TId> : IDisposable
													where TEntity : class, IBaseEntity<TId>, new()
													where TId : struct
	{
		public IQueryable<TEntity> GetAll();
		public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
		public TEntity GetById(TId id);
		public IEnumerable<TEntity> GetByIds(IEnumerable<TId> ids);
		public IQueryable<TEntity> GetByColumn<TValue>(string column, TValue value);
	}
}
