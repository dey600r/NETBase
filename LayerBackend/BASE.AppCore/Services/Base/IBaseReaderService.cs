using BASE.AppInfrastructure.Entities;
using BASE.Common.Dtos;
using System.Linq.Expressions;

namespace BASE.AppCore.Services
{
	public interface IBaseReaderService<TModel, TEntity, TId> : IDisposable
															where TModel : class, IBaseModel<TId>, new()
															where TEntity : class, IBaseEntity<TId>, new()
															where TId : struct
	{
		public IQueryable<TModel> GetAll();
		public IQueryable<TModel> GetAll(Expression<Func<TEntity, bool>> predicate);
		public TModel GetById(TId id);
		public IEnumerable<TModel> GetByIds(IEnumerable<TId> ids);
		public IQueryable<TModel> GetByColumn<TValue>(string column, TValue value);
	}
}
