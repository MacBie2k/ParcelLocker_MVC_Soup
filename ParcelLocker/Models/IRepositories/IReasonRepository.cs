using ParcelLocker.Models.Entities;
using System.Collections.Generic;

namespace ParcelLocker.Models.IRepositories
{
    public interface IReasonRepository
    {
        IEnumerable<Reason> GetAll();
        Reason Get(int complaintId);
        Reason Add(Reason parcel);
        void Update(Reason parcel);
        void Delete(Reason parcel);
    }
}
