using System;
using TestStack.BDDfy;
using Xunit;

namespace Peekage.ContactManagement.Domain.Tests.Unit.Contacts
{
    public class When_defining_new_contact
    {
        ContactSteps _ = new ContactSteps();

        [Fact]
        public void it_gets_defined_properly()
        {
            this.When(s => _.DefiningContact(a => a
                .WithId(Guid.NewGuid())
                .WithName("Dave Ferry")
                .WithPhoneNumber("+1 (321)3666556")
                .WithEmail("daveferry@info.com")
                .WithOrganization("Continuous Delivery")
                .WithGithubAccountName("DaveFerry")))
            .Then(s => _.ItGetsDefinedProperly())
            .BDDfy();
        }
    }
}
