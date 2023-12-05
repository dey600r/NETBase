using BASE.AppCore.Services;
using BASE.AppCore.Services.Security;
using BASE.Common.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BASE.WebApi.Controllers
{
    public class VehicleController : BaseAuthorizeController
    {
        IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService, ILogger<BaseController> logger, IJwtGenerator jwtGenerator) : base(logger, jwtGenerator)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VehicleModel>> Get()
        {
            try
            {
                return Ok(_vehicleService.GetAll().ToList());
            }
            catch (Exception ex)
            {
                Log(ex.Message, LogLevel.Error);
                return BadRequest(ex.Message);
            }
        }

		[HttpGet]
		[Route("testing")]
		public ActionResult<IEnumerable<VehicleModel>> Testing()
		{
			try
			{
				return Ok(_vehicleService.GetVehicles().ToList());
			}
			catch (Exception ex)
			{
				Log(ex.Message, LogLevel.Error);
				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
        public ActionResult<VehicleModel> Add(VehicleModel addModel)
        {
            try
            {
                return Ok(_vehicleService.Add(addModel));
            }
            catch (Exception ex)
            {
                Log(ex.Message, LogLevel.Error);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<VehicleModel> Update(VehicleModel addModel)
        {
            try
            {
                return Ok(_vehicleService.Update(addModel));
            }
            catch (Exception ex)
            {
                Log(ex.Message, LogLevel.Error);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                return Ok(_vehicleService.Delete(id));
            }
            catch (Exception ex)
            {
                Log(ex.Message, LogLevel.Error);
                return BadRequest(ex.Message);
            }
        }
    }
}
