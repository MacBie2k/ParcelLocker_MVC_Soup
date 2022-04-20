using ParcelLocker.Models.IRepositories;
using ParcelLocker.Models.IServices;
using ParcelLocker.Models.ViewModels;
using System.Collections.Generic;

namespace ParcelLocker.Models.Services
{
    public class ReasonService : IReasonService
    {
        private readonly IReasonRepository _complaintReasonRepository;
        public ReasonService(IReasonRepository complaintReasonRepository)
        {
            _complaintReasonRepository = complaintReasonRepository;
        }
        public IEnumerable<ReasonVM> GetAllReasons()
        {
            var reasons = _complaintReasonRepository.GetAll();
            var reasonsVN = new List<ReasonVM>();
            foreach (var reason in reasons)
            {
                reasonsVN.Add(new ReasonVM
                {
                    Id = reason.ReasonId,
                    Name = reason.Name,
                    
                });
            }
            return reasonsVN;
        }
    }
}
