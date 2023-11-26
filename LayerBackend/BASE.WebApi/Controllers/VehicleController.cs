using BASE.AppCore.Services.Vehicle;
using BASE.Common.Dtos.Vehicle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BASE.WebApi.Controllers
{
    public class VehicleController : BaseController
	{
		IVehicleService _vehicleService;

		public VehicleController(IVehicleService vehicleService, ILogger<BaseController> logger): base(logger)
		{
			_vehicleService = vehicleService;
		}

		[HttpGet]
		public ActionResult<IEnumerable<VehicleTypeModel>> Get()
		{
			try { 
				return Ok(_vehicleService.GetAll());
			} catch(Exception ex)
			{
				Log(ex.Message, LogLevel.Error);
				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		public ActionResult<VehicleTypeModel> Add(VehicleTypeModel addModel)
		{
			try
			{
				return Ok(_vehicleService.Add(addModel));
			} catch(Exception ex)
			{
				Log(ex.Message, LogLevel.Error);
				return BadRequest(ex.Message);
			}
		}

		[HttpPut]
		public ActionResult<VehicleTypeModel> Update(VehicleTypeModel addModel)
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
		public ActionResult<VehicleTypeModel> Delete(int id)
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
