using System;
using System.Collections.Generic;

namespace Peekage.ContactManagement.Service.Domain.Models
{
    public class ContactArg
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Organization { get; set; } 
        public string GithubAccountName { get; set; }
        public List<GithubRepository> GithubRepositories { get; set; } = new List<GithubRepository>();
    }
}
