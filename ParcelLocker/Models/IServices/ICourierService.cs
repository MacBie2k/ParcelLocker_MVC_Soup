using ParcelLocker.Models.ModelViews;
using ParcelLocker.Models.ViewModels;
using System.Text;

namespace ParcelLocker.Models.IServices
{
    public interface ICourierService
    {
        public ParcelVM CollectParcel(string parcelNumber);
        public ParcelVM DeliverParcel(string parcelNumber);
        public ParcelCollectionVM GetParcels();
        public ParcelCollectionVM GetParcelsToCollect();
        public ParcelCollectionVM GetParcelsToDeliver();
        public StringBuilder ExportCSVFile();
    }
}
