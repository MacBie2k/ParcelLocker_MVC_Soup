using ParcelLocker.Models.IRepositories;
using ParcelLocker.Models.IServices;
using ParcelLocker.Models.ViewModels;
using System.Collections.Generic;

namespace ParcelLocker.Models.Services
{
    public class ComplaintReasonService : IComplaintReasonService
    {
        private readonly IComplaintReasonRepository _complaintReasonRepository;
        public ComplaintReasonService(IComplaintReasonRepository complaintReasonRepository)
        {
            _complaintReasonRepository = complaintReasonRepository;
        }
        public IEnumerable<ComplaintReasonVM> GetAllReasons()
        {
            var reasons = _complaintReasonRepository.GetAll();
            var reasonsVN = new List<ComplaintReasonVM>();
            foreach (var reason in reasons)
            {
                reasonsVN.Add(new ComplaintReasonVM
                {
                    Name = reason.Name,
                    
                });
            }
            return reasonsVN;
        }
    }
}
