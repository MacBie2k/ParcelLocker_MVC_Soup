using ParcelLocker.Models.Entities;
using ParcelLocker.Models.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace ParcelLocker.Models.Repositories
{
    public class ParcelRepository : IParcelRepository
    {
        private readonly ParcelLockerContext _parcelockerContext;
        public ParcelRepository(ParcelLockerContext parcelockerContext)
        {
            _parcelockerContext = parcelockerContext;
        }
        public IEnumerable<Parcel> GetAll()
        {
            return _parcelockerContext.Parcels;
        }
        public Parcel Get(string parcelNumber)
        {
            return _parcelockerContext.Parcels.SingleOrDefault(x => x.ParcelNumber == parcelNumber);
        }
        public Parcel Add(Parcel parcel)
        {
           _parcelockerContext.Parcels.Add(parcel);
            _parcelockerContext.SaveChanges();
            return parcel;
        }
        public void Update(Parcel parcel)
        {
            _parcelockerContext.Parcels.Update(parcel);
            _parcelockerContext.SaveChanges();
        }

        public void Delete(Parcel parcel)
        {
            _parcelockerContext.Parcels.Remove(parcel);
            _parcelockerContext.SaveChanges();
        }        

    }
}
