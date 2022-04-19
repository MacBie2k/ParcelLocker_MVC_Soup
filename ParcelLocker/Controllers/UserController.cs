using Microsoft.AspNetCore.Mvc;
using ParcelLocker.Models.IServices;
using ParcelLocker.Models.ViewModels;
using System.Collections.Generic;

namespace ParcelLocker.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult SendParcel()
        {
            var vm = new ParcelsAndLockersVM
            {
                Lockers = _userService.GetLockers()
            };


            return View(vm);
        }

        [HttpPost]
        public IActionResult SendParcel(ParcelsAndLockersVM data)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("SendParcel");
            }
            _userService.SendParcel(data.Parcel.SenderPhone, data.Parcel.SenderEmail, data.Parcel.ReceiverPhone, data.Parcel.ReceiverEmail, data.Parcel.LockerCode);
            ViewBag.Message = "Pomyslnie wyslano paczke";
            ModelState.Clear();
            var vm = new ParcelsAndLockersVM
            {
                Lockers = _userService.GetLockers()
            };
            return View(vm);
        }
        [HttpGet]
        public IActionResult GetParcel()
        {

            return View();
        }
        [HttpPost]
        public IActionResult GetParcel(AccessVM data)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var x = _userService.GetParcel(data.PhoneNumber, data.Code);
            if (x != null)
            {
                ViewBag.Message = "Pomyslnie odebrano paczkę";

            }
            else
            {
                ViewBag.Message = "Błąd!";

            }
            ModelState.Clear();
            return View();
        }

        [HttpGet]
        public IActionResult SendComplaint()
        {

            var vm = new ComplaintAndReasonsVM
            {
                Reasons = _userService.GetComplaintReasons(),
            };


            return View(vm);
        }
        [HttpPost]
        public IActionResult SendComplaint(ComplaintAndReasonsVM data)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("SendComplaint");
            }
            var x = _userService.ReturnParcel(data.Complaint.Phone, data.Complaint.Email, data.Complaint.ParcelNumber, data.Complaint.Comment, data.Complaint.Reasons);
            if (x)
            {
                ViewBag.Message = "Pomyslnie zgloszono reklamacje";
                ModelState.Clear();
            }

            return View();
        }

        [HttpGet]
        public IActionResult MapView()
        {

            return View();
        }
    }
}
