using ParcelLocker.Models.ViewModels;

namespace ParcelLocker.Models.IServices
{
    public interface IComplaintService
    {
        ComplaintVM AddNewComplaint(ComplaintVM parcelVM);
    }
}
