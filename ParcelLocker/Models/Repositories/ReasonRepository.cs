using ParcelLocker.Models.Entities;
using ParcelLocker.Models.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace ParcelLocker.Models.Repositories
{
    public class ReasonRepository : IReasonRepository
    {
        private readonly ParcelLockerContext _parcelockerContext;
        public ReasonRepository(ParcelLockerContext parcelockerContext)
        {
            _parcelockerContext = parcelockerContext;
        }
        public IEnumerable<Reason> GetAll()
        {
            return _parcelockerContext.Reasons;
        }
        public Reason Get(int complaintReasonId)
        {
            return _parcelockerContext.Reasons.SingleOrDefault(x => x.ReasonId == complaintReasonId);
        }
        public Reason Add(Reason complaintReason)
        {
            _parcelockerContext.Reasons.Add(complaintReason);
            _parcelockerContext.SaveChanges();
            return complaintReason;
        }
        public void Update(Reason complaintReason)
        {
            _parcelockerContext.Reasons.Update(complaintReason);
            _parcelockerContext.SaveChanges();
        }
        public void Delete(Reason complaintReason)
        {
            _parcelockerContext.Reasons.Remove(complaintReason);
            _parcelockerContext.SaveChanges();
        }
    }
}
