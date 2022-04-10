using ParcelLocker.Models.ViewModels;
using System.Collections.Generic;

namespace ParcelLocker.Models.IServices
{
    public interface ILockerService
    {
        IEnumerable<LockerVM> GetAllParcels();
        LockerVM GetLockerByCode(string code);
    }
}
