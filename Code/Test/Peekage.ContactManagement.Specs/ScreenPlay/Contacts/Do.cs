using Peekage.ContactManagement.Service.Application.Contacts;
using Peekage.ContactManagement.Specs.ScreenPlay.Contacts.Tasks;
using Suzianna.Core.Screenplay;

namespace Peekage.ContactManagement.Specs.ScreenPlay.Contacts
{
    public static class Do
    {
        public static ITask DefineAGenericProductWith(DefineContactCommand command)
            => new DefineContactTask(command);
    }
}
