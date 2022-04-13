using Microsoft.AspNetCore.Mvc;
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
            try
            {
                _busManuFacturerService.Create(manufacturerDTO);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Kaydetme sırasında bir hata meydana geldi";
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
            try
            {
                _busManuFacturerService.Update(busManufacturer);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Güncelleme sırasında bir hata meydana geldi";
                return View(busManufacturer);
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
            if (busManufacturer != null)
            {
                _busManuFacturerService.Delete(busManufacturer);
            }
            return RedirectToAction("Index");

        }
        public IActionResult GetById(int id)
        {
            var busManufacturer = _busManuFacturerService.GetById(id);
            return View(busManufacturer);
        }
    }
}
