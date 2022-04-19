using ParcelLocker.Models.IServices;
using ParcelLocker.Models.ModelViews;
using ParcelLocker.Models.ViewModels;
using System.IO;
using System.Linq;
using System.Text;

namespace ParcelLocker.Models.Services
{
    public class CourierService : ICourierService
    {
        private readonly IParcelService _parcelService;

        public CourierService(IParcelService parcelService)
        {
            _parcelService = parcelService;
        }
        public ParcelVM CollectParcel(string parcelNumber)
        {
            var parcel = _parcelService.GetAllParcels().SingleOrDefault(x => x.ParcelNumber == parcelNumber && x.Status == Status.nadana);
            if (parcel != null)
            {
                parcel.Status = Status.wyslana;
                _parcelService.UpdateParcel(parcel);
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
                return parcel;
            }
            else
            {
                return null;
            }
        }
    }
}
