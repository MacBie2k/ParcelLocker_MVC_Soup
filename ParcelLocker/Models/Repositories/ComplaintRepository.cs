using ParcelLocker.Models.Entities;
using ParcelLocker.Models.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace ParcelLocker.Models.Repositories
{
    public class ComplaintRepository : IComplaintRepository
    {
        private readonly ParcelLockerContext _parcelockerContext;
        public ComplaintRepository(ParcelLockerContext parcelockerContext)
        {
            _parcelockerContext = parcelockerContext;
        }
        public IEnumerable<Complaint> GetAll()
        {
            return _parcelockerContext.Complaints;
        }
        public Complaint Get(int complaintId)
        {
            return _parcelockerContext.Complaints.SingleOrDefault(x => x.Id == complaintId);
        }
        public Complaint Add(Complaint complaint)
        {
            _parcelockerContext.Complaints.Add(complaint);
            _parcelockerContext.SaveChanges();
            return complaint;
        }
        public void Update(Complaint complaint)
        {
            _parcelockerContext.Complaints.Update(complaint);
            _parcelockerContext.SaveChanges();
        }
        public void Delete(Complaint complaint) 
        {
            _parcelockerContext.Complaints.Remove(complaint);
            _parcelockerContext.SaveChanges();
        }
        
    }
}
