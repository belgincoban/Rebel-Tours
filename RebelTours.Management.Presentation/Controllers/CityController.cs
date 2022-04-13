using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RebelTours.Management.Application.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebelTours.Management.Presentation.Controllers
{
    public class CityController : Controller
    {
        //loosely coupling
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        //public IActionResult Index()
        //{
        //    var dbContext = new RebelToursContext();
        //    var cities = dbContext.Cities.ToList();

        //    return View(cities);
        //}

        public IActionResult Index()
        {
            //Service
            //Aslında çok genel bir ifade, ama yinede Business/Application
            //katmanında işlemlerin yapıldığı nesnelere verilen isim
            //CityService
            //StationService

            var cities = _cityService.GetAll();
            return View(cities);
        }
        public IActionResult Create()
        {
            return View();
        }

        #region FormCollection in HttpContext.Request object
        //public IActionResult CreateSubmitted()
        //{
        //    var cityName = Request.Form["cityName"];

        //    _cityService.Create(new CityDTO()
        //    {
        //        Name = cityName
        //    });

        //    return new EmptyResult();
        //} 
        #endregion

        #region FormCollection as parameter
        //public IActionResult CreateSubmitted(IFormCollection formCollection)
        //{
        //    var cityName = formCollection["cityName"];

        //    _cityService.Create(new CityDTO()
        //    {
        //        Name = cityName
        //    });

        //    return new EmptyResult();
        //} 
        #endregion

        #region input values as parameters
        //public IActionResult CreateSubmitted(string cityName)
        //{
        //    _cityService.Create(new CityDTO()
        //    {
        //        Name = cityName
        //    });

        //    return new EmptyResult();
        //} 
        #endregion

        //hiçbir şey yazmazsan herhangi bir metodu kaarşılayabilir.(sınırlandırma yok).
        //aynı metot iismini kullanıyorsam en az biri bir http metotla işaretlenmesi gerekiyor
        //dynamic runtime 'da ne verirsek onu oluşturan nesne.
        [HttpPost]
        public IActionResult Create(CityDTO cityDTO)
        {
            try
            {
                _cityService.Create(cityDTO);
                return RedirectToAction("Index", "City");
            }
            catch (Exception)
            {

                // ViewBag isimli yapı, View'a ekstra bilgi/veri taşımak için kullanılan bir koleksiyon
                // ViewBag'in tipi dynamic olarak belirlenmiştir. Dynamic tipi DotNet içerisinde özel
                // esnek bir tiptir. Dynamic tipinin tuttuğu değer, veri, nesne veya o nesnenin property'leri
                // runtime'da belli olur.

                // ViewBag ile ViewData aslında arka tarafta aynı nesneyi işaret eder
                // İkisi arasında yazım şekli farkı var 

                // ViewBag, dynamic tipinde
                ViewBag.ErrorMessage = "Kaydetme sırasında bir hata meydana geldi";

                // ViewData dictionary tipinde
                //ViewData["ErrorMessage"] = "Kaydetme sırasında bir hata meydana geldi";
                return View();
            }

        }

        public IActionResult Update(int id)
        {
            var city = _cityService.GetById(id);
            return View(city);
        }

        [HttpPost]
        public IActionResult Update(CityDTO city)
        {
            try
            {
                _cityService.Update(city);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Güncelleme sırasında bir hata meydana geldi";

                return View(city);
            }
        }

        // HttpGet
        // City/Delete/10
        public IActionResult Delete(int id)
        {
            var city = _cityService.GetById(id);

            return View(city);
        }

        /*
          /City/Create
          /City/Edit
          /City/Delete/10
          /City/DeleteConfirmed
       */

        //[HttpPost(Name = "Delete")]
        [HttpPost]
        public IActionResult Delete(CityDTO city)
        {
            if (city !=null)
            {
                _cityService.Delete(city);
            }
            return RedirectToAction("Index");

        }
        public IActionResult GetById(int id)
        {
            var city = _cityService.GetById(id);
            return View(city);
        }

    }
}
