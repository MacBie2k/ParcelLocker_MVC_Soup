using ParcelLocker.Models.Entities;
using System.Collections.Generic;

namespace ParcelLocker.Models.IRepositories
{
    public interface ILockerRepository
    {
        IEnumerable<Locker> GetAll();
        Locker Get(string code);
        Locker Add(Locker locker);
        void Update(Locker locker);
        void Delete(Locker locker);
    }
}
