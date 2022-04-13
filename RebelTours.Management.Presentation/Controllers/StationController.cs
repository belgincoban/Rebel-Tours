using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            _stationService.Create(stationDTO);
            return RedirectToAction("Index");
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
            if (stationDTO != null)
            {
                _stationService.Update(stationDTO);
                return RedirectToAction("Index");
            }
            return Content("Hatalı işlem");
        }
        public IActionResult Delete(int id)
        {
            var station = _stationService.GetById(id);

            return View(station);
        }
        [HttpPost]
        public IActionResult Delete(StationDTO station)
        {
            if (station != null)
            {
                _stationService.Delete(station);
            }
            return RedirectToAction("Index");

        }
    }
}
