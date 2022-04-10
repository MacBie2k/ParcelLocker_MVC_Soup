using ParcelLocker.Models.Entities;
using ParcelLocker.Models.IRepositories;
using ParcelLocker.Models.IServices;
using ParcelLocker.Models.ModelViews;
using System;
using System.Collections.Generic;

namespace ParcelLocker.Models.Services
{
    public class ParcelService : IParcelService
    {
        private readonly IParcelRepository _parcelRepository;

        public ParcelService(IParcelRepository parcelRepository)
        {
            _parcelRepository = parcelRepository;
        }
        public IEnumerable<ParcelVM> GetAllParcels()
        {
            var parcels = _parcelRepository.GetAll();
            var parcelsVM = new List<ParcelVM>();
            foreach (var parcel in parcels)
            {
                parcelsVM.Add(new ParcelVM { 
                    ParcelNumber = parcel.ParcelNumber,
                    PickupCode = parcel.PickupCode,
                    SenderPhone = parcel.SenderPhone,
                    SenderEmail = parcel.SenderEmail,
                    ReceiverPhone = parcel.ReceiverPhone,
                    ReceiverEmail = parcel.ReceiverEmail,
                    Status = Enum.Parse<Status>(parcel.Status),
                    LockerCode = parcel.LockerCode                    
                });
            }
            return parcelsVM;
        }

        public ParcelVM GetParcelByNumber(string parcelNumber)
        {
            var parcel = _parcelRepository.Get(parcelNumber);
            var parcelVM = new ParcelVM {
                ParcelNumber = parcel.ParcelNumber,
                PickupCode = parcel.PickupCode,
                SenderPhone = parcel.SenderPhone,
                SenderEmail = parcel.SenderEmail,
                ReceiverPhone = parcel.ReceiverPhone,
                ReceiverEmail = parcel.ReceiverEmail,
                Status = Enum.Parse<Status>(parcel.Status),
                LockerCode = parcel.LockerCode
            };
            return parcelVM;
        }
        public ParcelVM AddNewParcel(ParcelVM parcelVM)
        {
            var parcel = new Parcel
            {
                ParcelNumber = parcelVM.ParcelNumber,
                PickupCode = parcelVM.PickupCode,
                SenderPhone = parcelVM.SenderPhone,
                SenderEmail = parcelVM.SenderEmail,
                ReceiverPhone = parcelVM.ReceiverPhone,
                ReceiverEmail = parcelVM.ReceiverEmail,
                Status = parcelVM.Status.ToString(),
                LockerCode = parcelVM.LockerCode,
            };
            _parcelRepository.Add(parcel);
            return parcelVM;
        }
        public void UpdateParcel(ParcelVM updateParcel)
        {
            var existingParcel = _parcelRepository.Get(updateParcel.ParcelNumber);

            existingParcel.ParcelNumber = updateParcel.ParcelNumber;
            existingParcel.PickupCode = updateParcel.PickupCode;
            existingParcel.SenderPhone = updateParcel.SenderPhone;
            existingParcel.SenderEmail = updateParcel.SenderEmail;
            existingParcel.ReceiverPhone = updateParcel.ReceiverPhone;
            existingParcel.ReceiverEmail = updateParcel.ReceiverEmail;
            existingParcel.Status = updateParcel.Status.ToString();
            existingParcel.LockerCode = updateParcel.LockerCode;
            
            _parcelRepository.Update(existingParcel);
        }
        public void DeleteParcel(string parcelNumber)
        {
           var parcel = _parcelRepository.Get(parcelNumber);
           _parcelRepository.Delete(parcel);
        }

       
    }
}
