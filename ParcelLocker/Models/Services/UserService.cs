using ParcelLocker.ExtensionMethods;
using ParcelLocker.Models.IServices;
using ParcelLocker.Models.ModelViews;
using ParcelLocker.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParcelLocker.Models.Services
{
    public class UserService : IUserService
    {
        private readonly IParcelService _parcelService;
        private readonly ILockerService _lockerService;
        public UserService(IParcelService parcelService, ILockerService lockerService)
        {
            _parcelService = parcelService;
            _lockerService = lockerService;
        }
        public void SendParcel(string senderPhone, string senderEmail, string receiverPhone, string receiverEmail, Status status, string lockerCode)
        {
            string parcelNumber;
            string pickupCode;
            var parcels = _parcelService.GetAllParcels();
            do
            {
                parcelNumber = GenerateNumber.RandomNumber(6);
                pickupCode = GenerateNumber.RandomNumber(6);
            } while (parcels.SingleOrDefault(x => x.ParcelNumber == parcelNumber || x.PickupCode == pickupCode) != null);

            var newParcel = new ParcelVM {
                ParcelNumber = parcelNumber,
                PickupCode = pickupCode,
                SenderEmail = senderEmail,
                SenderPhone = senderPhone,
                ReceiverPhone = receiverPhone,
                ReceiverEmail = receiverEmail,
                Status = status,
                LockerCode = lockerCode

            };
            _parcelService.AddNewParcel(newParcel);
        }
        public void GetParcel(string receiverPhone, string pickupCode)
        {
            var parcel = _parcelService.GetAllParcels().SingleOrDefault(x => x.ReceiverPhone == receiverPhone && x.PickupCode == pickupCode);
            parcel.Status = Status.odebrana;
            _parcelService.UpdateParcel(parcel);
        }

        public void ReturnParcel(string receiverPhone, string parcelNumber, string comment, IEnumerable<ComplaintReasonVM> reasons)
        {
            var parcel = _parcelService.GetAllParcels().SingleOrDefault(x => x.ReceiverPhone == receiverPhone && x.PickupCode == parcelNumber);
            if (parcel != null && parcel.Status == Status.odebrana)
            {
                parcel.Status = Status.zwrocona;
                _parcelService.UpdateParcel(parcel);
            }
            else
            {
                throw new Exception("Can't return this parcel");
            }

            
        }
        
    }
}
