using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RebelTours.Management.Application.Buses;
using RebelTours.Management.Application.BusModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebelTours.Management.Presentation.Controllers
{
    public class BusController : Controller
    {
        private readonly IBusService _busService;
        private readonly IBusModelService _busModelService;

        public BusController(IBusService busService, IBusModelService busModelService)
        {
            _busService = busService;
            _busModelService = busModelService;
        }
        public IActionResult Index()
        {
            var buses = _busService.GetSummaries();
            return View(buses);

        }
        public IActionResult Create()
        {
            var busModels = _busModelService.GetAll();
            var busModelsSelect = new SelectList(busModels, "Id", "Name");
            ViewBag.busModel = busModelsSelect;
            return View();
        }

        [HttpPost]
        public IActionResult Create(BusDTO bus)
        {
            var result = _busService.Create(bus);
            if (result.IsSucceeded)
            {
                var resultJson = JsonConvert.SerializeObject(result);
                TempData["CommandResult"] = resultJson;
                return RedirectToAction("Index");
            }
            else
            {
                var busModels = _busModelService.GetAll();
                var busModelsSelect = new SelectList(busModels, "Id", "Name");
                ViewBag.BusModel = busModelsSelect;
                ViewBag.CommandResult = result;
                
                return View(bus);
            }
        }

        public IActionResult Update(int id)
        {
            var bus = _busService.GetById(id);
            return View(bus);
        }

        [HttpPost]
        public IActionResult Update(BusDTO bus)
        {
            var result= _busService.Update(bus);
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

        public IActionResult Delete(int id)
        {
            var bus = _busService.GetById(id);
            ViewBag.BusModel = _busModelService.GetById(bus.BusModelId).Name;
            return View(bus);
        }

        [HttpPost]
        public IActionResult Delete(BusDTO bus)
        {
            var result= _busService.Delete(bus);

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