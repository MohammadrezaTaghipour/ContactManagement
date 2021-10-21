using Peekage.ContactManagement.Service.Application.Contacts;
using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using Suzianna.Rest.Screenplay.Interactions;

namespace Peekage.ContactManagement.Specs.ScreenPlay.Contacts.Tasks
{
    public class DefineContactTask : ITask
    {
        private DefineContactCommand _command;

        public DefineContactTask(DefineContactCommand command)
        {
            _command = command;
        }

        public void PerformAs<T>(T actor) where T : Actor
        {
            actor.AttemptsTo(Post.DataAsJson(_command)
                .To("/api/contacts"));
        }
    }
}
