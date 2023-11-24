using BASE.AppInfrastructure.Entities;

namespace BASE.AppInfrastructure.Repository
{
    public interface IBaseRepository<TEntity, TId> where TEntity : class, IBaseEntity<TId>, new()
                                                    where TId : struct
    {
        public IEnumerable<TEntity> GetAll();
        public TEntity GetById(TId id);
        public IEnumerable<TEntity> GetByColumn(string column, TId value);
        public TEntity Add(TEntity entity);
        public IEnumerable<TEntity> Adds(IEnumerable<TEntity> entities);
        public TEntity Update(TEntity entity);
        public IEnumerable<TEntity> Updates(IEnumerable<TEntity> entity);
        public bool Delete(TId id);
        public bool DeleteByColumn(string column, TId value);
        public bool Deletes(IEnumerable<TId> id);
    }
}
