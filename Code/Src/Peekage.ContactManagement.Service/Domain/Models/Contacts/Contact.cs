using System;

namespace Peekage.ContactManagement.Service.Domain.Models
{
    public class Contact
    {
        protected Contact() { }
        protected Contact(Guid id, string name, string phoneNumber,
            string email, string organization, string githubAccountName)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            Organization = organization;
            GithubAccountName = githubAccountName;
            //Deleted = false;
        }

        public static Contact Create(ContactArg arg)
        {
            //TODO: check invarinats here...

            var contact = new Contact(arg.Id, arg.Name,
                arg.PhoneNumber, arg.Email, arg.Organization,
                arg.GithubAccountName);
            return contact;
        }

        #region Props
        public Guid Id { get; }
        public string Name { get; }
        public string PhoneNumber { get; }
        public string Email { get; }
        public string Organization { get; }
        public string GithubAccountName { get; }
        public bool Deleted { get; }
        #endregion
    }
}
