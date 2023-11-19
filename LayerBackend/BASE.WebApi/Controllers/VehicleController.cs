using BASE.AppCore.Services;
using BASE.Common.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BASE.WebApi.Controllers
{
	public class VehicleController : BaseController
	{
		IVehicleService _vehicleService;

		public VehicleController(IVehicleService vehicleService)
		{
			_vehicleService = vehicleService;
		}

		[HttpGet]
		public ActionResult<IEnumerable<VehicleTypeModel>> Get()
		{
			return Ok(_vehicleService.GetAll());
		}

		[HttpPost]
		public ActionResult<VehicleTypeModel> Add(VehicleTypeModel addModel)
		{
			return Ok(_vehicleService.Add(addModel));
		}


		//// GET: VehicleController
		//public ActionResult Index()
		//{
		//	return View();
		//}

		//// GET: VehicleController/Details/5
		//public ActionResult Details(int id)
		//{
		//	return View();
		//}

		//// GET: VehicleController/Create
		//public ActionResult Create()
		//{
		//	return View();
		//}

		//// POST: VehicleController/Create
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Create(IFormCollection collection)
		//{
		//	try
		//	{
		//		return RedirectToAction(nameof(Index));
		//	}
		//	catch
		//	{
		//		return View();
		//	}
		//}

		//// GET: VehicleController/Edit/5
		//public ActionResult Edit(int id)
		//{
		//	return View();
		//}

		//// POST: VehicleController/Edit/5
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Edit(int id, IFormCollection collection)
		//{
		//	try
		//	{
		//		return RedirectToAction(nameof(Index));
		//	}
		//	catch
		//	{
		//		return View();
		//	}
		//}

		//// GET: VehicleController/Delete/5
		//public ActionResult Delete(int id)
		//{
		//	return View();
		//}

		//// POST: VehicleController/Delete/5
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Delete(int id, IFormCollection collection)
		//{
		//	try
		//	{
		//		return RedirectToAction(nameof(Index));
		//	}
		//	catch
		//	{
		//		return View();
		//	}
		//}
	}
}
