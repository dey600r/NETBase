using BASE.AppInfrastructure.Entities;

namespace BASE.AppInfrastructure.Repository
{
    public interface IBaseRepository<TEntity, TId> : IBaseReaderRepository<TEntity, TId>, IDisposable
                                                    where TEntity : class, IBaseEntity<TId>, new()
                                                    where TId : struct
    {
        public TEntity Add(TEntity entity);
        public IEnumerable<TEntity> Add(IEnumerable<TEntity> entities);
        public TEntity Update(TEntity entity);
        public IEnumerable<TEntity> Update(IEnumerable<TEntity> entity);
        public bool Delete(TId id);
		public bool Delete(TEntity entitiy);
		public bool DeleteByColumn<TValue>(string column, TValue value);
        public bool Delete(IEnumerable<TId> ids);
		public bool Delete(IEnumerable<TEntity> entities);
	}
}
