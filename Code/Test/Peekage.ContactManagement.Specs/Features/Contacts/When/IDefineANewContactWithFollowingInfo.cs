using Peekage.ContactManagement.Service.Application.Contacts;
using Peekage.ContactManagement.Specs.ScreenPlay.Contacts;
using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using Suzianna.Rest.Screenplay.Questions;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Peekage.ContactManagement.Specs.Features.Contacts.When
{
    [Binding]
    public class IDefineANewContactWithFollowingInfo
    {
        Actor _actor;
        ScenarioContext _context;
        public IDefineANewContactWithFollowingInfo(Stage stage,
            ScenarioContext scenarioContext)
        {
            _actor = stage.ActorInTheSpotlight;
            _context = scenarioContext;
        }

        [When(@"I define a new contact with following info")]
        public void Func(Table table)
        {
            var command = table.CreateInstance<DefineContactCommand>();
            _actor.AttemptsTo(Do.DefineAGenericProductWith(command));
            command.Id = _actor.AsksFor(LastResponse.Content<Guid>());
            _context.Set(command);
        }
    }
}
