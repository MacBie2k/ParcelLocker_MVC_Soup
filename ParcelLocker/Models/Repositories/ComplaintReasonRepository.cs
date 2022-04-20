using ParcelLocker.Models.Entities;
using ParcelLocker.Models.IRepositories;

namespace ParcelLocker.Models.Repositories
{
    public class ComplaintReasonRepository : IComplaintReasonRepository
    {
        private readonly ParcelLockerContext _parcelockerContext;
        public ComplaintReasonRepository(ParcelLockerContext parcelockerContext)
        {
            _parcelockerContext = parcelockerContext;
        }
        public ComplaintReason Add(ComplaintReason complaintReason)
        {
            if (complaintReason == null)
            {
                return null;
            }
            _parcelockerContext.ComplaintReasons.Add(complaintReason);
            _parcelockerContext.SaveChanges();
            return complaintReason;
        }
    }
}
