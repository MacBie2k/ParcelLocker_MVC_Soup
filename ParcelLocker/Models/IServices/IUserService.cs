using Microsoft.AspNetCore.Mvc.Rendering;
using ParcelLocker.Models.ModelViews;
using ParcelLocker.Models.ViewModels;
using System.Collections.Generic;

namespace ParcelLocker.Models.IServices
{
    public interface IUserService
    {
        void SendParcel(string senderPhone, string senderEmail, string receiverPhone, string receiverEmail, string lockerCode);
        ParcelVM GetParcel(string receiverPhone, string pickupCode);
        bool ReturnParcel(string receiverPhone,string receiverEmail, string parcelNumber, string comment, List<SelectListItem> selectedReasons);
        public void SendMessage(string name, string email, string message);
        IEnumerable<LockerVM> GetLockers();
        public IEnumerable<ReasonVM> GetComplaintReasons();
    }
}
