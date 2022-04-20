using ParcelLocker.Models.Entities;

namespace ParcelLocker.Models.IRepositories
{
    public interface IComplaintReasonRepository
    {
       ComplaintReason Add(ComplaintReason complaint);
    }
}
