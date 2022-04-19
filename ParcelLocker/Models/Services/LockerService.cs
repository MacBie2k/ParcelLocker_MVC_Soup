using ParcelLocker.Models.IRepositories;
using ParcelLocker.Models.IServices;
using ParcelLocker.Models.ViewModels;
using System.Collections.Generic;

namespace ParcelLocker.Models.Services
{
    public class LockerService : ILockerService
    {
        private readonly ILockerRepository _lockerRepository;
        public LockerService(ILockerRepository lockerRepository)
        {
            _lockerRepository = lockerRepository;
        }
        public IEnumerable<LockerVM> GetAllLockers()
        {
            var lockers  = _lockerRepository.GetAll();
            var lockersVN = new List<LockerVM>();
            foreach (var locker in lockers)
            {
                lockersVN.Add(new LockerVM
                {
                    City = locker.City,
                    Code = locker.Code,
                    Street = locker.Street,
                });
            }
            return lockersVN;
        }

        public LockerVM GetLockerByCode(string code)
        {
            var locker = _lockerRepository.Get(code);
            var lockerVM = new LockerVM
            {
                Code = locker.Code,
                City = locker.City,
                Street = locker.Street,
            };
            return lockerVM;
        }
    }
}
