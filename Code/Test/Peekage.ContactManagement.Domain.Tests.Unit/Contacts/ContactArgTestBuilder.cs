using Peekage.ContactManagement.Service.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Peekage.ContactManagement.Domain.Tests.Unit.Contacts
{
    internal class ContactArgTestBuilder : ContactArg
    {
        public ContactArgTestBuilder WithId(Guid value)
        {
            Id = value;
            return this;
        }

        public ContactArgTestBuilder WithName(string value)
        {
            Name = value;
            return this;
        }

        public ContactArgTestBuilder WithPhoneNumber(string value)
        {
            PhoneNumber = value;
            return this;
        }

        public ContactArgTestBuilder WithEmail(string value )
        {
            Email = value;
            return this;
        }

        public ContactArgTestBuilder WithOrganization(string value)
        {
            Organization = value;
            return this;
        }

        public ContactArgTestBuilder WithGithubAccountName(string value)
        {
            GithubAccountName = value;
            return this;
        }

        public ContactArgTestBuilder WithGithubRepository(string value)
        {
            GithubRepositories.Add(new GithubRepository(value));
            return this;
        }

        public ContactArg Build()
        {
            return this;
        }
    }
}
