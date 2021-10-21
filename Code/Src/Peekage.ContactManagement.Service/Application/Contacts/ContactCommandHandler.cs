using Peekage.ContactManagement.Service.Domain.Models;
using Peekage.ContactManagement.Service.Domain.Models.Contacts;
using Peekage.ContactManagement.Service.Framework;
using Peekage.ContactManagement.Service.Infrastructure.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Peekage.ContactManagement.Service.Application.Contacts
{
    public class ContactCommandHandler :
        ICommandHandler<DefineContactCommand>
    {
        readonly IContactRepository _repository;
        readonly IGithubService _githubService;

        public ContactCommandHandler(IContactRepository repository,
            IGithubService githubService)
        {
            _repository = repository;
            _githubService = githubService;
        }

        public async Task Handle(DefineContactCommand command)
        {
            command.Id = Guid.NewGuid();
            var arg = await CreateArgFrom(command, _githubService);
            var contact = Contact.Create(arg);
            await _repository.Add(contact);
        }

        async Task<ContactArg> CreateArgFrom(DefineContactCommand command,
            IGithubService githubService)
        {
            var githubRepoes = await githubService
                .GetAllRepositoryNamesByAccount(command.GithubAccountName);

            return new ContactArg
            {
                Id = command.Id,
                Name = command.Name,
                Email = command.Email,
                PhoneNumber = command.PhoneNumber,
                Organization = command.Organization,
                GithubAccountName = command.GithubAccountName,
                GithubRepositories = githubRepoes
                ?.Select(a => new GithubRepository(a)).ToList()
            };
        }
    }
}
