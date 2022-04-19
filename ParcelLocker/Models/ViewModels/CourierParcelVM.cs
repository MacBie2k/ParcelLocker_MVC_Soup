using ParcelLocker.Models.ModelViews;
using System.Collections.Generic;

namespace ParcelLocker.Models.ViewModels
{
    public class ParcelCollectionVM
    {
        public IEnumerable<ParcelVM> Parcels { get; set; }
        public string ParcelNumber { get; set; }
    }
}
