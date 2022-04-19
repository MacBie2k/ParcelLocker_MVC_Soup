using ParcelLocker.ExtensionMethods;
using ParcelLocker.Models.Entities;
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
        private readonly IComplaintService _complaintService;
        private readonly IComplaintReasonService _complaintReasonService;
        public UserService(IParcelService parcelService, ILockerService lockerService, IComplaintService complaintService, IComplaintReasonService complaintReasonService)
        {
            _parcelService = parcelService;
            _lockerService = lockerService;
            _complaintService = complaintService;
            _complaintReasonService = complaintReasonService;
        }
        public void SendParcel(string senderPhone, string senderEmail, string receiverPhone, string receiverEmail, string lockerCode)
        {
            string parcelNumber;
            string pickupCode;
            var parcels = _parcelService.GetAllParcels();
            do
            {
                parcelNumber = GenerateNumber.RandomNumber(6);
                pickupCode = GenerateNumber.RandomNumber(6);
            } while (parcels.SingleOrDefault(x => x.ParcelNumber == parcelNumber || x.PickupCode == pickupCode) != null);

            var newParcel = new ParcelVM
            {
                ParcelNumber = parcelNumber,
                PickupCode = pickupCode,
                SenderEmail = senderEmail,
                SenderPhone = senderPhone,
                ReceiverPhone = receiverPhone,
                ReceiverEmail = receiverEmail,
                Status = Status.nadana,
                LockerCode = _lockerService.GetLockerByCode(lockerCode).Code

            };
            _parcelService.AddNewParcel(newParcel);
        }
        public ParcelVM GetParcel(string receiverPhone, string pickupCode)
        {
            var parcel = _parcelService.GetAllParcels().SingleOrDefault(x => x.ReceiverPhone == receiverPhone && x.PickupCode == pickupCode && x.Status == Status.dostarczona);
            if (parcel != null)
            {
                parcel.Status = Status.odebrana;
                _parcelService.UpdateParcel(parcel);
                return parcel;
            }
            else
            {
                return null;
            }
        }

        public bool ReturnParcel(string receiverPhone, string receiverEmail, string parcelNumber, string comment, ICollection<ComplaintReasonVM> reasons)
        {
            var parcel = _parcelService.GetAllParcels().SingleOrDefault(x => x.ReceiverPhone == receiverPhone && x.PickupCode == parcelNumber && x.ReceiverEmail == receiverEmail);
            if (parcel != null && parcel.Status == Status.odebrana)
            {
                parcel.Status = Status.zwrocona;
                _parcelService.UpdateParcel(parcel);
                var res = reasons.Select(x => new ComplaintReason
                {
                    Name = x.Name
                }).ToList();
                var complaintVM = new ComplaintVM
                {
                    Comment = comment,
                    Email = receiverEmail,
                    Phone = receiverPhone,
                    ParcelNumber = parcelNumber,
                    Reasons = reasons
                };
                _complaintService.AddNewComplaint(complaintVM);
                //dodawanie nowego zwrotu;
                return true;
            }
            return false;

        }
        public IEnumerable<LockerVM> GetLockers()
        {
            return _lockerService.GetAllLockers();
        }
        public IEnumerable<ComplaintReasonVM> GetComplaintReasons()
        {
            return _complaintReasonService.GetAllReasons();
        }
    }
}
