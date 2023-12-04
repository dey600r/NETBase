using BASE.AppInfrastructure.Entities;
using BASE.Common.Dtos;
using BASE.WebApiTest.DependencyInjection.Moq;
using System.Linq.Expressions;

namespace BASE.WebApiTest.DependencyInjection.Fake
{
	public class VehicleFakeService : IVehicleFakeService
	{
		public VehicleModel Add(VehicleModel model)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<VehicleModel> Add(IEnumerable<VehicleModel> model)
		{
			throw new NotImplementedException();
		}

		public bool Delete(int id)
		{
			throw new NotImplementedException();
		}

		public bool Delete(VehicleModel model)
		{
			throw new NotImplementedException();
		}

		public bool Delete(IEnumerable<int> ids)
		{
			throw new NotImplementedException();
		}

		public bool Delete(IEnumerable<VehicleModel> models)
		{
			throw new NotImplementedException();
		}

		public bool DeleteByColumn<TValue>(string column, TValue value)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			// Clear
		}

		public IEnumerable<VehicleModel> GetAll()
		{
			return TestDependencyInjectionMoq.InitializeFakeData();
		}

		public IEnumerable<VehicleModel> GetAll(Expression<Func<Vehicle, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<VehicleModel> GetByColumn<TValue>(string column, TValue value)
		{
			throw new NotImplementedException();
		}

		public VehicleModel GetById(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<VehicleModel> GetByIds(IEnumerable<int> ids)
		{
			throw new NotImplementedException();
		}

		public VehicleModel Update(VehicleModel model)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<VehicleModel> Update(IEnumerable<VehicleModel> model)
		{
			throw new NotImplementedException();
		}
	}
}
