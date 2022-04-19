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
        public IActionResult DeliverParcel()
        {
            var vm = _courierService.GetParcelsToDeliver();
            return View(vm);
        }
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
        [HttpGet]
        public IActionResult CollectParcel()
        {
            var vm = _courierService.GetParcelsToCollect();
            return View(vm);
        }
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
