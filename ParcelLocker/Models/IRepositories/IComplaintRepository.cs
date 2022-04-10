using ParcelLocker.Models.Entities;
using System.Collections.Generic;

namespace ParcelLocker.Models.IRepositories
{
    public interface IComplaintRepository
    {
        IEnumerable<Complaint> GetAll();
        Complaint Get(int complaintId);
        Complaint Add(Complaint parcel);
        void Update(Complaint parcel);
        void Delete(Complaint parcel);
    }
}
