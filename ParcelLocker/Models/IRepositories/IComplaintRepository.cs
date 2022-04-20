using ParcelLocker.Models.Entities;
using System.Collections.Generic;

namespace ParcelLocker.Models.IRepositories
{
    public interface IComplaintRepository
    {
        IEnumerable<Complaint> GetAll();
        Complaint Get(int complaintId);
        Complaint Add(Complaint complaint);
        void Update(Complaint complaint);
        void Delete(Complaint complaint);
    }
}
