using Peekage.ContactManagement.Service.Infrastructure.Query;
using Suzianna.Core.Screenplay.Actors;
using Suzianna.Core.Screenplay.Questions;
using Suzianna.Rest.Screenplay.Interactions;
using Suzianna.Rest.Screenplay.Questions;

namespace Peekage.ContactManagement.Specs.ScreenPlay.Contacts.Questions
{
    public class LastCreatedContactQuestion :
        IQuestion<SearchContactQueryResponse>
    {
        public SearchContactQueryResponse AnsweredBy(Actor actor)
        {
            var lastId = actor.AsksFor(LastResponse.Content<long>());
            actor.AttemptsTo(Get.ResourceAt($"/api/contacts/{lastId}"));
            return actor.AsksFor(LastResponse.Content<SearchContactQueryResponse>());
        }
    }
}
