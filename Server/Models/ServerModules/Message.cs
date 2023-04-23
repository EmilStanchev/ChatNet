using Interfaces.ServerInterfaces;
using Interfaces.UserInterfaces;

namespace Models.ServerModules
{
    public class Message : IMessage
    {
        public Message(IUser sender, string content)
        {
            Id = Guid.NewGuid().ToString();
            Sender = sender;
            Content = content;
            SendAt = DateTime.Now;
        }

        public string Id { get; set; }
        public IUser Sender { get; set; }
        public string Content { get; set; }
        public DateTime SendAt { get; set; }
    }
}
