using ParcelLocker.Models.Entities;
using System.Collections.Generic;

namespace ParcelLocker.Models.IRepositories
{
    public interface IComplaintReasonRepository
    {
        IEnumerable<ComplaintReason> GetAll();
        ComplaintReason Get(int complaintId);
        ComplaintReason Add(ComplaintReason parcel);
        void Update(ComplaintReason parcel);
        void Delete(ComplaintReason parcel);
    }
}
