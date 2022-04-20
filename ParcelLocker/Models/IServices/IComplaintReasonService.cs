using ParcelLocker.Models.ViewModels;

namespace ParcelLocker.Models.IServices
{
    public interface IComplaintReasonService
    {
        public ComplaintReasonVM AddNewComplaintReason(ComplaintReasonVM complaintReasonVM);
    }
}
