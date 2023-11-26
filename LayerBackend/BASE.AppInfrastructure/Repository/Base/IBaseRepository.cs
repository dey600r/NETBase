using BASE.AppInfrastructure.Entities;
using System.Linq.Expressions;

namespace BASE.AppInfrastructure.Repository
{
    public interface IBaseRepository<TEntity, TId> where TEntity : class, IBaseEntity<TId>, new()
                                                    where TId : struct
    {
        public IQueryable<TEntity> GetAll();
		public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
		public TEntity GetById(TId id);
        public IQueryable<TEntity> GetByColumn<TValue>(string column, TValue value);
        public TEntity Add(TEntity entity);
        public IEnumerable<TEntity> Add(IEnumerable<TEntity> entities);
        public TEntity Update(TEntity entity);
        public IEnumerable<TEntity> Update(IEnumerable<TEntity> entity);
        public bool Delete(TId id);
		public bool Delete(TEntity id);
		public bool DeleteByColumn<TValue>(string column, TValue value);
        public bool Delete(IEnumerable<TId> id);
		public bool Delete(IEnumerable<TEntity> id);
	}
}
