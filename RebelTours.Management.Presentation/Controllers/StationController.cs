using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RebelTours.Management.Application.Cities;
using RebelTours.Management.Application.Stations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebelTours.Management.Presentation.Controllers
{
    public class StationController : Controller
    {
        private readonly IStationService _stationService;
        private readonly ICityService _cityService;

        public StationController(IStationService stationService, ICityService cityService)
        {
            _stationService = stationService;
            _cityService = cityService;
        }
        public IActionResult Index()
        {
            var stations = _stationService.GetSummaries();
            return View(stations);
        }
        public IActionResult GetById(StationDTO stationDTO)
        {
            var station = _stationService.GetById(stationDTO.Id);
            return View(station);
        }
        public IActionResult Create()
        {
            var cities = _cityService.GetAll();
            ViewBag.Cities = new SelectList(cities, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(StationDTO stationDTO)
        {
            var result = _stationService.Create(stationDTO);

            if (result.IsSucceeded)
            {
                //TempData["SuccessMessage"] = "Kaydetme başarılı";

                // JSON
                // JavaScript Object Notation

                // Serialize => Stringleştirme
                var resultJson = JsonConvert.SerializeObject(result);
                TempData["CommandResult"] = resultJson;

                // Aaşağıdaki gibi bir Extension metot yazılarak Json serialize etme işlemi
                // pratikleştirilebilir
                // TempData.Set("CommandResult", result);

                return RedirectToAction("Index", "Station", new { redirected = true });
            }
            else
            {
                //ViewBag.ErrorMessage = "Kaydetme sırasında bir hata meydana geldi";

                var cities = _cityService.GetAll();

                ViewBag.Cities = new SelectList(cities, "Id", "Name");
                ViewBag.CommandResult = result;

                return View(stationDTO);
            }
        }
       
        public IActionResult Update(int id)
        {
            var stationDto = _stationService.GetById(id);
            var cities = _cityService.GetAll();
            ViewBag.Cities = new SelectList(cities, "Id", "Name");
            return View(stationDto);
        }
        [HttpPost]
        public IActionResult Update(StationDTO stationDTO)
        {
            var result=_stationService.Update(stationDTO);
            if (result.IsSucceeded)
            {
                var resultJson = JsonConvert.SerializeObject(result);
                TempData["CommandResult"] = resultJson;
                return RedirectToAction("Index");

            }
            else
            {
                var cities = _cityService.GetAll();
                ViewBag.Cities = new SelectList(cities, "Id", "Name");
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            var station = _stationService.GetById(id);

            return View(station);
        }
        [HttpPost]
        public IActionResult Delete(StationDTO station)
        {
            var result=_stationService.Delete(station);

            if (result.IsSucceeded)
            {
                var resultJson = JsonConvert.SerializeObject(result);
                TempData["CommandResult"] = resultJson;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.CommandResult = result;
                return View();
            }


        }
    }
}
