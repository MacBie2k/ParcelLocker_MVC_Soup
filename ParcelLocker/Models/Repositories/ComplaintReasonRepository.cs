using ParcelLocker.Models.Entities;
using ParcelLocker.Models.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace ParcelLocker.Models.Repositories
{
    public class ComplaintReasonRepository : IComplaintReasonRepository
    {
        private readonly ParcelLockerContext _parcelockerContext;
        public ComplaintReasonRepository(ParcelLockerContext parcelockerContext)
        {
            _parcelockerContext = parcelockerContext;
        }
        public IEnumerable<ComplaintReason> GetAll()
        {
            return _parcelockerContext.ComplaintReasons;
        }
        public ComplaintReason Get(int complaintReasonId)
        {
            return _parcelockerContext.ComplaintReasons.SingleOrDefault(x => x.Id == complaintReasonId);
        }
        public ComplaintReason Add(ComplaintReason complaintReason)
        {
            _parcelockerContext.ComplaintReasons.Add(complaintReason);
            _parcelockerContext.SaveChanges();
            return complaintReason;
        }
        public void Update(ComplaintReason complaintReason)
        {
            _parcelockerContext.ComplaintReasons.Update(complaintReason);
            _parcelockerContext.SaveChanges();
        }
        public void Delete(ComplaintReason complaintReason)
        {
            _parcelockerContext.ComplaintReasons.Remove(complaintReason);
            _parcelockerContext.SaveChanges();
        }
    }
}
