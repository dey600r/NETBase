using BASE.AppInfrastructure.Entities;
using BASE.Common.Dtos;
using System.Linq.Expressions;

namespace BASE.AppCore.Services.Base
{
	public interface IBaseService<TModel, TEntity, TId> : IDisposable
															where TModel : class, IBaseModel<TId>, new()
															where TEntity : class, IBaseEntity<TId>, new()
															where TId : struct
	{
		public IQueryable<TModel> GetAll();
		public IQueryable<TModel> GetAll(Expression<Func<TEntity, bool>> predicate);
		public TModel GetById(TId id);
		public IEnumerable<TModel> GetByIds(IEnumerable<TId> ids);
		public IQueryable<TModel> GetByColumn<TValue>(string column, TValue value);
		public TModel Add(TModel model);
		public IEnumerable<TModel> Add(IEnumerable<TModel> model);
		public TModel Update(TModel model);
		public IEnumerable<TModel> Update(IEnumerable<TModel> model);
		public bool Delete(TId id);
		public bool Delete(TModel model);
		public bool DeleteByColumn<TValue>(string column, TValue value);
		public bool Delete(IEnumerable<TId> ids);
		public bool Delete(IEnumerable<TModel> models);
	}
}
