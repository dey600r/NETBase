using AutoMapper;
using BASE.AppInfrastructure.Entities;
using BASE.AppInfrastructure.Repository;
using BASE.Common.Dtos;
using System.Linq.Expressions;

namespace BASE.AppCore.Services
{
	public class BaseReaderService<TModel, TEntity, TId> : BaseDisposable, IBaseReaderService<TModel, TEntity, TId>
															where TModel : class, IBaseModel<TId>, new()
															where TEntity : class, IBaseEntity<TId>, new()
															where TId : struct
	{
		protected readonly IMapper _mapper;
		private readonly IBaseReaderRepository<TEntity, TId> _baseRepository;

		public BaseReaderService(IMapper mapper, IBaseReaderRepository<TEntity, TId> baseRepository) 
		{
			_mapper = mapper;
			_baseRepository = baseRepository;
		}

		public IEnumerable<TModel> GetAll() => _baseRepository.GetAll().Select(x => _mapper.Map<TModel>(x));

		public IEnumerable<TModel> GetAll(Expression<Func<TEntity, bool>> predicate) =>
			_baseRepository.GetAll(predicate).Select(x => _mapper.Map<TModel>(x));

		public IEnumerable<TModel> GetByColumn<TValue>(string column, TValue value) =>
			_baseRepository.GetByColumn(column, value).Select(x => _mapper.Map<TModel>(x));

		public TModel GetById(TId id) => _mapper.Map<TModel>(_baseRepository.GetById(id));

		public IEnumerable<TModel> GetByIds(IEnumerable<TId> ids) => _baseRepository.GetByIds(ids).Select(x => _mapper.Map<TModel>(x));
	}
}
