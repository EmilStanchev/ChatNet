using Interfaces.ServerInterfaces;
using Interfaces.UserInterfaces;

namespace Interfaces.Services.RoomServices
{
    public interface ICommandHandler
    {
        public void HandleCommand(string message, IUser user, IRoom room);
    }
}
