using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RebelTours.Management.Application.BusManufacturers;
using RebelTours.Management.Application.BusModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebelTours.Management.Presentation.Controllers
{
    public class BusModelController : Controller
    {
        private readonly IBusModelService _busModelService;
        private readonly IBusManufacturerService _manufacturerService;

        public BusModelController(IBusModelService busModelService, IBusManufacturerService manufacturerService)
        {
            _busModelService = busModelService;
            _manufacturerService = manufacturerService;
        }
        public IActionResult Index()
        {
            var busModel = _busModelService.GetSummaries();
            return View(busModel);
        }
        public IActionResult GetById(BusModelDTO busModelDTO)
        {
            var busModel = _busModelService.GetById(busModelDTO.Id);
            return View(busModel);
        }
        public IActionResult Create()
        {
            var manufacturers = _manufacturerService.GetAll();
            ViewBag.Manufacturers = new SelectList(manufacturers, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(BusModelDTO modelDTO)
        {
            var result=_busModelService.Create(modelDTO);
            if (result.IsSucceeded)
            {
                var resultJson = JsonConvert.SerializeObject(result);
                TempData["CommandResult"] = resultJson;
                return RedirectToAction("Index");
            }
            else
            {
                var manufacturers = _manufacturerService.GetAll();
                ViewBag.Manufacturers = new SelectList(manufacturers, "Id", "Name");
                ViewBag.CommandResult = result;

                return View(modelDTO);
            }
        }
        public IActionResult Update(int id)
        {
            var model = _busModelService.GetById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(BusModelDTO modelDTO)
        {
            var result=_busModelService.Update(modelDTO);
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
            var busModel = _busModelService.GetById(id);
            return View(busModel);
        }

        [HttpPost]
        public IActionResult Delete(BusModelDTO modelDTO)
        {
            var result=_busModelService.Delete(modelDTO);

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
