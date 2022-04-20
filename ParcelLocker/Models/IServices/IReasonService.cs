using ParcelLocker.Models.ViewModels;
using System.Collections.Generic;

namespace ParcelLocker.Models.IServices
{
    public interface IReasonService
    {
        IEnumerable<ReasonVM> GetAllReasons();
    }
}
