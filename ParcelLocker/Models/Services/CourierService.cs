using Microsoft.AspNetCore.Identity;
using ParcelLocker.ExtensionMethods;
using ParcelLocker.Models.Entities;
using ParcelLocker.Models.IServices;
using ParcelLocker.Models.ModelViews;
using ParcelLocker.Models.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace ParcelLocker.Models.Services
{
    public class CourierService : ICourierService
    {
        private readonly IParcelService _parcelService;
        private UserManager<Courier> _userManager;
        private SignInManager<Courier> _signInManager;
        public CourierService(IParcelService parcelService, UserManager<Courier> userManager, SignInManager<Courier> signInManager)
        {
            _parcelService = parcelService;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public ParcelVM CollectParcel(string parcelNumber)
        {
            var parcel = _parcelService.GetAllParcels().SingleOrDefault(x => x.ParcelNumber == parcelNumber && x.Status == Status.nadana);
            if (parcel != null)
            {
                parcel.Status = Status.wyslana;
                _parcelService.UpdateParcel(parcel);
                MailClient.SendMail(parcelNumber, "Paczka wysłana!", $"Paczka {parcelNumber} została odebrana przez kuriera", parcel.ReceiverEmail);
                return parcel;
            }
            else
            {
                return null;
            }
        }
        public ParcelCollectionVM GetParcels()
        {
            var parcels = _parcelService.GetAllParcels();
            var parcelCollection = new ParcelCollectionVM { Parcels = parcels };
            return parcelCollection;
        }
        public StringBuilder ExportCSVFile()
        {
            var parcels = GetParcels().Parcels;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Lp.;Parcel Number; PickupCode; Sender Phone; Sender Email; Receiver Phone; Receiver Email; Status; Parcel Locker Code");
            int counter = 1;
            foreach (var item in parcels)
            {
                stringBuilder.AppendLine($"{counter}; {item.ParcelNumber}; {item.PickupCode}; {item.SenderPhone}; {item.SenderEmail}; {item.ReceiverPhone}; {item.ReceiverEmail};{item.Status}; {item.LockerCode}");
                counter++;
            }

            return stringBuilder;
        }
        public ParcelCollectionVM GetParcelsToCollect()
        {
            var parcels = _parcelService.GetAllParcels().Where(x => x.Status == Status.nadana);
            var parcelCollection = new ParcelCollectionVM { Parcels = parcels };
            return parcelCollection;

        }
        public ParcelCollectionVM GetParcelsToDeliver()
        {
            var parcels = _parcelService.GetAllParcels().Where(x => x.Status == Status.wyslana);
            var parcelCollection = new ParcelCollectionVM { Parcels = parcels };
            return parcelCollection;
        }
            
        public ParcelVM DeliverParcel(string parcelNumber)
        {
            var parcel = _parcelService.GetAllParcels().SingleOrDefault(x => x.ParcelNumber == parcelNumber && x.Status == Status.wyslana);
            if (parcel != null)
            {
                parcel.Status = Status.dostarczona;
                _parcelService.UpdateParcel(parcel);
                MailClient.SendMail(parcelNumber, "Paczka dostarczona!", $"Paczka {parcelNumber} jest gotowa do odbioru. \n Kod odbioru:{parcel.PickupCode}", parcel.ReceiverEmail);
                return parcel;
            }
            else
            {
                return null;
            }
        }

        public bool LogIn(string login, string password)
        {

            var result = _signInManager.PasswordSignInAsync(login, password, false, false).Result;

            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void LogOut()
        {

            var result = _signInManager.SignOutAsync();
        }
        public bool Register(string login, string firstName, string lastName, string password)
        {

            var entity = new Courier
            {
                UserName = login,
                FirstName = firstName,
                LastName = lastName


            };
            var result = _userManager.CreateAsync(entity, password).Result;
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
