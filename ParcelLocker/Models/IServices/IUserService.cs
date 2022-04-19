using ParcelLocker.Models.ModelViews;
using ParcelLocker.Models.ViewModels;
using System.Collections.Generic;

namespace ParcelLocker.Models.IServices
{
    public interface IUserService
    {
        void SendParcel(string senderPhone, string senderEmail, string receiverPhone, string receiverEmail, string lockerCode);
        ParcelVM GetParcel(string receiverPhone, string pickupCode);
        bool ReturnParcel(string receiverPhone,string receiverEmail, string parcelNumber, string comment, ICollection<ComplaintReasonVM> reasons);
        IEnumerable<LockerVM> GetLockers();
        public IEnumerable<ComplaintReasonVM> GetComplaintReasons();
    }
}
