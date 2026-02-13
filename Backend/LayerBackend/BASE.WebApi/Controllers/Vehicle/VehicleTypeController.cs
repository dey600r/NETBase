using BASE.AppCore.Services;
using BASE.AppCore.Services.Security;
using BASE.Common.Constants;
using BASE.Common.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BASE.WebApi.Controllers.Vehicle
{
	[Authorize(Policy = ConstantsSecurity.READ_POLICY)]
	public class VehicleTypeController : BaseAuthorizeController
	{
		IVehicleTypeService _vehicleTypeService;
		IAppVehicleTypeService _appvehicleTypeService;

        public VehicleTypeController(IAppVehicleTypeService appvehicleTypeService, IAppVehicleTypeService vehicleTypeService, ILogger<BaseController> logger, IHttpContextAccessor httpContextAccessor) : base(logger, httpContextAccessor)
		{
			_vehicleTypeService = vehicleTypeService;
            _appvehicleTypeService = appvehicleTypeService;
        }

		[HttpGet]
		public ActionResult<IEnumerable<VehicleTypeModel>> Get()
		{
			try
			{
				var result = _appvehicleTypeService.GetAll();

                return Ok(_vehicleTypeService.GetAll());
			}
			catch (Exception ex)
			{
				Log(ex.Message, LogLevel.Error);
				return BadRequest(ex.Message);
			}
		}
	}
}
