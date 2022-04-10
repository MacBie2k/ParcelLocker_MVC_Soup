using ParcelLocker.Models.ModelViews;
using ParcelLocker.Models.ViewModels;
using System.Collections.Generic;

namespace ParcelLocker.Models.IServices
{
    public interface IUserService
    {
        void SendParcel(string senderPhone, string senderEmail, string receiverPhone, string receiverEmail, Status status, string lockerCode);
        void GetParcel(string receiverPhone, string pickupCode);
        void ReturnParcel(string receiverPhone, string parcelNumber, string comment, IEnumerable<ComplaintReasonVM> reasons);
    }
}
