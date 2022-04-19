using ParcelLocker.Models.Entities;
using ParcelLocker.Models.IRepositories;
using ParcelLocker.Models.IServices;
using ParcelLocker.Models.ViewModels;
using System.Linq;

namespace ParcelLocker.Models.Services
{
    public class ComplaintService : IComplaintService
    {
        private readonly IComplaintRepository _complaintRepository;
        private readonly IParcelService _parcelService;

        public ComplaintService(IComplaintRepository complaintRepository, IParcelService parcelService)
        {
            _complaintRepository = complaintRepository;
            _parcelService = parcelService;
        }
        public ComplaintVM AddNewComplaint(ComplaintVM parcelVM)
        {
            if (parcelVM == null)
            {
                return null; 
            }
            var complaint = new Complaint
            {
                Email = parcelVM.Email,
                Reasons = parcelVM.Reasons.Select(x => new ComplaintReason {Name = x.Name}).ToList(),
                ParcelNumber = parcelVM.ParcelNumber,
                Phone = parcelVM.Phone,

            };
            return parcelVM;
        }
    }
}
