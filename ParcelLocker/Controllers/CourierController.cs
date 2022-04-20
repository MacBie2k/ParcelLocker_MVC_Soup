using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParcelLocker.Models.IServices;
using ParcelLocker.Models.ViewModels;
using System.Text;

namespace ParcelLocker.Controllers
{
    
    public class CourierController : Controller
    {
        private ICourierService _courierService;
        public CourierController(ICourierService courierService)
        {
            _courierService = courierService;

        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LogIn(LogInVM data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }
            if (_courierService.LogIn(data.Login, data.Password))
            {
                return RedirectToAction("DeliverParcel");
            }
            return View();
        }
        [HttpGet]
//#if DEBUG
       

        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterVM data)
        {

            if (!ModelState.IsValid)
            {
                return View(data);
            }
            if (_courierService.Register(data.Login, data.FirstName, data.LastName, data.Password))
            {
                return RedirectToAction("LogIn", "Courier");
            }
            return View(data);
        }
//#endif
        [Authorize]
        [HttpGet]
        public IActionResult LogOut()
        {
            _courierService.LogOut();
            return RedirectToAction("GetParcel", "User");
        }

        
        [Authorize]
        [HttpGet]
        public IActionResult DeliverParcel()
        {
            var vm = _courierService.GetParcelsToDeliver();
            return View(vm);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Delivery(string parcelNumber)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("DeliverParcel");
            }
            var x = _courierService.DeliverParcel(parcelNumber);
            if (x != null)
            {
                ViewBag.Message = "Pomyslnie dostarczono paczke";
                ModelState.Clear();
            }

            return RedirectToAction("DeliverParcel");
        }
        [Authorize]
        [HttpGet]
        public IActionResult CollectParcel()
        {
            var vm = _courierService.GetParcelsToCollect();
            return View(vm);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Collection(string parcelNumber)
        {
            
            if (!ModelState.IsValid)
            {
                return RedirectToAction("CollectParcel");
            }
            var x = _courierService.CollectParcel(parcelNumber);
            if (x != null)
            {
                ViewBag.Message = "Pomyslnie odebrano paczke";
                ModelState.Clear();
            }

            return RedirectToAction("CollectParcel");
        }
        [Authorize]
        [HttpGet]
        public IActionResult DownloadCSV()
        {
            try
            {
                return File(Encoding.UTF8.GetBytes(_courierService.ExportCSVFile().ToString()), "text/csv", "parcels.csv");
            }
            catch
            {
                return RedirectToAction("CollectParcel");
            }
        }
    }
}
