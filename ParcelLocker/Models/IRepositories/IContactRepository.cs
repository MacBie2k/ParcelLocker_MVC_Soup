using ParcelLocker.Models.Entities;

namespace ParcelLocker.Models.IRepositories
{
    public interface IContactRepository
    {
        Contact Add(Contact contact);
    }
}
