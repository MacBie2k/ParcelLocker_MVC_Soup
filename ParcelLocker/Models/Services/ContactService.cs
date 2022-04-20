using ParcelLocker.Models.Entities;
using ParcelLocker.Models.IRepositories;
using ParcelLocker.Models.IServices;
using ParcelLocker.Models.ViewModels;

namespace ParcelLocker.Models.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public ContactVM AddNewContact(ContactVM contactVM)
        {
            if (contactVM == null)
            {
                return null;
            }
            var complaint = new Contact
            {
               Email = contactVM.Email,
               Name = contactVM.Name,
               Message = contactVM.Message, 

            };
            _contactRepository.Add(complaint);
            return contactVM;
        }
    }
}
