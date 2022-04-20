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
        public ComplaintVM AddNewComplaint(ComplaintVM complaintVM)
        {
            if (complaintVM == null)
            {
                return null;
            }
            var complaint = new Complaint
            {
                Email = complaintVM.Email,
                ParcelNumber = complaintVM.ParcelNumber,
                Phone = complaintVM.Phone,
                Comment = complaintVM.Comment,

            };
            _complaintRepository.Add(complaint);
            return _complaintRepository.GetAll().Select(x => new ComplaintVM
            {
                Id = x.ComplaintId,
                Comment = x.Comment,
                Email = x.Email,
                Phone = x.Phone,
                ParcelNumber = x.ParcelNumber,
            }).SingleOrDefault(x => x.ParcelNumber == complaintVM.ParcelNumber);

        }
    }
}
