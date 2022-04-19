using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RebelTours.Management.Application.BusManufacturers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebelTours.Management.Presentation.Controllers
{
    public class BusManufacturerController : Controller
    {
        private readonly IBusManufacturerService _busManuFacturerService;

        public BusManufacturerController(IBusManufacturerService busManuFacturerService)
        {
            _busManuFacturerService = busManuFacturerService;
        }
        public IActionResult Index()
        {
            var manuFacturers = _busManuFacturerService.GetAll();
            return View(manuFacturers);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BusManufacturerDTO manufacturerDTO)
        {
            var result = _busManuFacturerService.Create(manufacturerDTO);
            
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
        public IActionResult Update(int id)
        {
            var busManufacturer = _busManuFacturerService.GetById(id);
            return View(busManufacturer);
        }

        [HttpPost]
        public IActionResult Update(BusManufacturerDTO busManufacturer)
        {
            var result = _busManuFacturerService.Update(busManufacturer);
           
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
            var manufacturer = _busManuFacturerService.GetById(id);

            return View(manufacturer);
        }
        [HttpPost]
        public IActionResult Delete(BusManufacturerDTO busManufacturer)
        {
           var result= _busManuFacturerService.Delete(busManufacturer);

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
