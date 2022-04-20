using ParcelLocker.Models.ViewModels;

namespace ParcelLocker.Models.IServices
{
    public interface IContactService
    {
        ContactVM AddNewContact(ContactVM contactVM);
    }
}
