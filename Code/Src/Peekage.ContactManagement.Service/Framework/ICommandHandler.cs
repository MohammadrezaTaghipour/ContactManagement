using System.Threading.Tasks;

namespace Peekage.ContactManagement.Service.Framework
{
    public interface ICommandHandler<T>
    {
        Task Handle(T command);
    }
}
