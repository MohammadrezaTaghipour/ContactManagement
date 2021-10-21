using Peekage.ContactManagement.Service.Domain.Models;
using Peekage.ContactManagement.Service.Domain.Models.Contacts;
using Peekage.ContactManagement.Service.Framework;
using System;
using System.Threading.Tasks;

namespace Peekage.ContactManagement.Service.Application.Contacts
{
    public class ContactCommandHandler : ICommandHandler<DefineContactCommand>
    {
        IContactRepository _repository;

        public ContactCommandHandler(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DefineContactCommand command)
        {
            command.Id = Guid.NewGuid();
            var arg = CreateArgFrom(command);
            var contact = Contact.Create(arg);
            await _repository.Add(contact);
        }

        ContactArg CreateArgFrom(DefineContactCommand command)
        {
            return new ContactArg
            {
                Id = command.Id,
                Name = command.Name,
                Email = command.Email,
                PhoneNumber = command.PhoneNumber,
                Organization = command.Organization,
                GithubAccountName = command.GithubAccountName
            };
        }
    }
}
