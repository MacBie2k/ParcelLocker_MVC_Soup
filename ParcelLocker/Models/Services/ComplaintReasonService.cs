using ParcelLocker.Models.Entities;
using ParcelLocker.Models.IRepositories;
using ParcelLocker.Models.IServices;
using ParcelLocker.Models.ViewModels;

namespace ParcelLocker.Models.Services
{
    public class ComplaintReasonService : IComplaintReasonService
    {
        private readonly IComplaintReasonRepository _complaintRepository;
        

        public ComplaintReasonService(IComplaintReasonRepository complaintRepository)
        {
            _complaintRepository = complaintRepository;
        }
        public ComplaintReasonVM AddNewComplaintReason(ComplaintReasonVM complaintReasonVM)
        {

            if (complaintReasonVM == null)
            {
                return null;
            }
            foreach (var item in complaintReasonVM.Reasons)
            {
                var complaintReason = new ComplaintReason
                {
                    ComplaintId = complaintReasonVM.Complaint.Id,
                    ReasonId = item.Id,
                };
                _complaintRepository.Add(complaintReason);
            }

            
            return complaintReasonVM;
        }
    }
}
