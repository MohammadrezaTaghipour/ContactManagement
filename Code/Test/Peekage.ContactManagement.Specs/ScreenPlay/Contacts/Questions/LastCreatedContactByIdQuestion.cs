using System;
using Peekage.ContactManagement.Service.Infrastructure.Query;
using Suzianna.Core.Screenplay.Actors;
using Suzianna.Core.Screenplay.Questions;
using Suzianna.Rest.Screenplay.Interactions;
using Suzianna.Rest.Screenplay.Questions;

namespace Peekage.ContactManagement.Specs.ScreenPlay.Contacts.Questions
{
    public class LastCreatedContactByIdQuestion :
        IQuestion<SearchContactQueryResponse>
    {
        private readonly Guid _id;
        public LastCreatedContactByIdQuestion(Guid id)
        {
            _id = id;
        }
        public SearchContactQueryResponse AnsweredBy(Actor actor)
        {
            actor.AttemptsTo(Get.ResourceAt($"/api/contacts/{_id}"));
            return actor.AsksFor(LastResponse.Content<SearchContactQueryResponse>());
        }
    }
}