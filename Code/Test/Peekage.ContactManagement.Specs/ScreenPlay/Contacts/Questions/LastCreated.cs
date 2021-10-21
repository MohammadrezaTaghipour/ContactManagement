using Peekage.ContactManagement.Service.Infrastructure.Query;
using Suzianna.Core.Screenplay.Questions;
using System;

namespace Peekage.ContactManagement.Specs.ScreenPlay.Contacts.Questions
{
    public static class LastCreated
    {
        public static IQuestion<SearchContactQueryResponse> Contract()
            => new LastCreatedContactQuestion();

        public static IQuestion<SearchContactQueryResponse> ContractBy(Guid id)
            => new LastCreatedContactByIdQuestion(id);
    }
}
