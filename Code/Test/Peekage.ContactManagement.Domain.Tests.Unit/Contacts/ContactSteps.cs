using FluentAssertions;
using Peekage.ContactManagement.Service.Domain.Models;
using System;

namespace Peekage.ContactManagement.Domain.Tests.Unit.Contacts
{
    internal class ContactSteps
    {
        ContactArg _arg;
        Contact _contact;

        public void TodayIs()
        {

        }

        public void DefiningContact(Action<ContactArgTestBuilder> config)
        {
            _arg = BuildArg(config);
            _contact = Contact.Create(_arg);
        }

        public void ItGetsDefinedProperly()
        {
            _contact.Should().BeEquivalentTo(_arg);
        }

        ContactArg BuildArg(Action<ContactArgTestBuilder> config)
        {
            var builder = new ContactArgTestBuilder();
            config(builder);
            return builder.Build();
        }
    }
}
