using ParcelLocker.Models.Entities;
using ParcelLocker.Models.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace ParcelLocker.Models.Repositories
{
    public class LockerRepository : ILockerRepository
    {
        private readonly ParcelLockerContext _parcelockerContext;
        public LockerRepository(ParcelLockerContext parcelockerContext)
        {
            _parcelockerContext = parcelockerContext;
        }
        public IEnumerable<Locker> GetAll()
        {
            return _parcelockerContext.Lockers;
        }
        public Locker Get(string lockerCode)
        {
            return _parcelockerContext.Lockers.SingleOrDefault(x => x.Id == lockerId);
        }
        public Locker Add(Locker locker)
        {
            _parcelockerContext.Lockers.Add(locker); 
            _parcelockerContext.SaveChanges();
            return locker;
        }
        public void Update(Locker locker)
        { 
            _parcelockerContext.Lockers.Update(locker);
            _parcelockerContext.SaveChanges();
        }
        public void Delete(Locker locker)
        {
            _parcelockerContext.Lockers.Remove(locker);
            _parcelockerContext.SaveChanges();
        }    
    }
}
