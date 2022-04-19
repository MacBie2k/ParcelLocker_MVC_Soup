using ParcelLocker.Models.IServices;
using ParcelLocker.Models.ModelViews;
using System.Collections.Generic;

namespace ParcelLocker.Models.ViewModels
{
    public class ParcelsAndLockersVM
    {
        public IEnumerable<LockerVM> Lockers { get; set; }
        public ParcelVM Parcel { get; set; }

    }
}
