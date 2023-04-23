using Interfaces.ServerInterfaces;
using Interfaces.UserInterfaces;

namespace Models.ServerModules
{
    public class Room : IRoom
    {
        public Room(string name, string password)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Password = password;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Password { get; set; }
        public List<IUser> Users { get; set; } = new List<IUser>();
        public List<IMessage> History { get; set; } = new List<IMessage>();

    }
}
