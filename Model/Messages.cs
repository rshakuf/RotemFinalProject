using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Messages : BaseEntity
    {
        private User senderId;
        private User receiver;
        private string messageText;
        private DateTime timeSent;

        public User SenderId { get => senderId; set => senderId = value; }
        public User Receiver { get => receiver; set => receiver = value; }
        public string MessageText { get => messageText; set => messageText = value; }
        public DateTime TimeSent { get => timeSent; set => timeSent = value; }
    }
}
