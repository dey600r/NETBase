using AutoMapper;
using BASE.AppInfrastructure.Entities;
using BASE.AppInfrastructure.Repository;
using BASE.Common.Dtos;
using System.Linq.Expressions;

namespace BASE.AppCore.Services.Base
{
	public class BaseService<TModel, TEntity, TId> : BaseDisposable,
														IBaseService<TModel, TEntity, TId>
															where TModel : class, IBaseModel<TId>, new()
															where TEntity : class, IBaseEntity<TId>, new()
															where TId : struct
	{
		protected readonly IMapper _mapper;
		protected readonly IBaseRepository<TEntity, TId> _baseRepository;

		public BaseService(IMapper mapper, IBaseRepository<TEntity, TId> baseRepository) 
		{
			_mapper = mapper;
			_baseRepository = baseRepository;
		}

		public TModel Add(TModel model) =>_mapper.Map<TModel>(_baseRepository.Add(_mapper.Map<TEntity>(model)));

		public IEnumerable<TModel> Add(IEnumerable<TModel> model) =>
			_baseRepository.Add(model.Select(x => _mapper.Map<TEntity>(x))).Select(x => _mapper.Map<TModel>(x));

		public bool Delete(TId id) => _baseRepository.Delete(id);

		public bool Delete(TModel model) => _baseRepository.Delete(_mapper.Map<TEntity>(model));

		public bool Delete(IEnumerable<TId> ids) => _baseRepository.Delete(ids);

		public bool Delete(IEnumerable<TModel> models) => _baseRepository.Delete(models.Select(x => _mapper.Map<TEntity>(x)));

		public bool DeleteByColumn<TValue>(string column, TValue value) => _baseRepository.DeleteByColumn(column, value);

		public IQueryable<TModel> GetAll() => _baseRepository.GetAll().Select(x => _mapper.Map<TModel>(x));

		public IQueryable<TModel> GetAll(Expression<Func<TEntity, bool>> predicate) => 
			_baseRepository.GetAll(predicate).Select(x => _mapper.Map<TModel>(x));

		public IQueryable<TModel> GetByColumn<TValue>(string column, TValue value) =>
			_baseRepository.GetByColumn(column, value).Select(x => _mapper.Map<TModel>(x));

		public TModel GetById(TId id) => _mapper.Map<TModel>(_baseRepository.GetById(id));

		public IEnumerable<TModel> GetByIds(IEnumerable<TId> ids) => _baseRepository.GetByIds(ids).Select(x => _mapper.Map<TModel>(x));

		public TModel Update(TModel model) => _mapper.Map<TModel>(_baseRepository.Update(_mapper.Map<TEntity>(model)));

		public IEnumerable<TModel> Update(IEnumerable<TModel> model) =>
			_baseRepository.Update(model.Select(x => _mapper.Map<TEntity>(x))).Select(x => _mapper.Map<TModel>(x));
	}
}
