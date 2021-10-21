using System;
using System.Threading.Tasks;

namespace Peekage.ContactManagement.Service.Domain.Models.Contacts
{
    public interface IContactRepository
    {
        Task<Contact> GetById(Guid id);
        Task Add(Contact contact);
    }
}
