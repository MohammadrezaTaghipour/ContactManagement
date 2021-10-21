using System;

namespace Peekage.ContactManagement.Service.Infrastructure.Query
{
    public class SearchContactQuery
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Organization { get; set; }
        public string GithubAccountName { get; set; }
    }

    public class SearchContactQueryResponse
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Organization { get; set; }
        public string GithubAccountName { get; set; }
        public bool Deleted { get; set; }
    }
}
