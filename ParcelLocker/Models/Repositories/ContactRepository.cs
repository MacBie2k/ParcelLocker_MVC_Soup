using ParcelLocker.Models.Entities;
using ParcelLocker.Models.IRepositories;

namespace ParcelLocker.Models.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ParcelLockerContext _parcelockerContext;
        public ContactRepository(ParcelLockerContext parcelockerContext)
        {
            _parcelockerContext = parcelockerContext;
        }
        public Contact Add(Contact contact)
        {
            if (contact == null)
            {
                return null;
            }
            _parcelockerContext.Contacts.Add(contact);
            _parcelockerContext.SaveChanges();
            return contact;
        }
    }
}
