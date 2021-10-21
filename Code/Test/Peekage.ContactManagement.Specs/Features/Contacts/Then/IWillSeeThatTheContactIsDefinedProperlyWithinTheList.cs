using FluentAssertions;
using Peekage.ContactManagement.Service.Application.Contacts;
using Peekage.ContactManagement.Specs.ScreenPlay.Contacts.Questions;
using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using TechTalk.SpecFlow;

namespace Peekage.ContactManagement.Specs.Features.Contacts.Then
{
    [Binding]
    public class IWillSeeThatTheContactIsDefinedProperlyWithinTheList
    {
        Actor _actor;
        ScenarioContext _context;

        public IWillSeeThatTheContactIsDefinedProperlyWithinTheList(
            Stage stage, ScenarioContext context)
        {
            _actor = stage.ActorInTheSpotlight;
            _context = context;
        }

        [Then(@"I will see that the contact is defined properly within the list")]
        public void Func()
        {
            var expected = _context.Get<DefineContactCommand>();
            var actual = _actor.AsksFor(LastCreated.ContractBy(expected.Id));
            actual.Should().BeEquivalentTo(expected, opt =>
                opt.Excluding(a => a.Id));
        }
    }
}
