using AutoMapper;
using Microservice.VehicleApi.Core.Dtos;
using Microservice.VehicleApi.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Microservice.VehicleApi.Infraestructure.Repository
{
    public class VehicleTypeRepository : IVehicleTypeRepository
    {
        private readonly DBContext _dbContext;
        private readonly IMapper _mapper;

        public VehicleTypeRepository(DBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<VehicleTypeModel> GetAll()
        {
            return _dbContext.VehicleTypes.AsNoTracking().Select(x => _mapper.Map<VehicleTypeModel>(x)).ToList();
        }
    }
}
