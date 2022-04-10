using ParcelLocker.Models.Entities;
using System.Collections.Generic;

namespace ParcelLocker.Models.IRepositories
{
    public interface IParcelRepository
    {
        IEnumerable<Parcel> GetAll();
        Parcel Get(string parcelNumber);
        Parcel Add(Parcel  parcel);
        void Update(Parcel parcel);
        void Delete(Parcel parcel);
        

    }
}
