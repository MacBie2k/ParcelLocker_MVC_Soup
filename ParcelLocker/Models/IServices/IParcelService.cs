using ParcelLocker.Models.ModelViews;
using System.Collections.Generic;

namespace ParcelLocker.Models.IServices
{
    public interface IParcelService
    {
        IEnumerable<ParcelVM> GetAllParcels();
        ParcelVM GetParcelByNumber(string parcelNumber);
        ParcelVM AddNewParcel (ParcelVM parcelVM);
        void UpdateParcel(ParcelVM updateParcel);
        void DeleteParcel(string parcelNumber);
        
    }
}
