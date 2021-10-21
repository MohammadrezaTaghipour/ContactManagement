using System;

namespace Peekage.ContactManagement.Service.Application.Contacts
{
    public class DefineContactCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Organization { get; set; }
        public string GithubAccountName { get; set; }
    }
}
