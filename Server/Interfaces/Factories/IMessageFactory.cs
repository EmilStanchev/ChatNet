using Interfaces.ServerInterfaces;
using Interfaces.UserInterfaces;

namespace Interfaces.Factories
{
    public interface IMessageFactory
    {
        public IMessage CreateMessage(IUser sender, string content);
    }
}
