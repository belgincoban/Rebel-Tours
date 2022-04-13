using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var manufacturies = _manufacturerService.GetAll();
            ViewBag.manufacturies = new SelectList(manufacturies, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(BusModelDTO modelDTO)
        {
            _busModelService.Create(modelDTO);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var model = _busModelService.GetById(id);
            //ViewBag.models = new SelectList( "Id", "Name");
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(BusModelDTO modelDTO)
        {
            if (modelDTO != null)
            {
                _busModelService.Update(modelDTO);
                return RedirectToAction("Index");
            }
            return Content("Hatalı işlem");
        }

        public IActionResult Delete(int id)
        {
            var busModel = _busModelService.GetById(id);
            return View(busModel);
        }

        [HttpPost]
        public IActionResult Delete(BusModelDTO modelDTO)
        {
            if (modelDTO!=null)
            {
                _busModelService.Delete(modelDTO);

            }
            return RedirectToAction("Index");
        }
    }
}
