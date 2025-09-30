using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Messages : BaseEntity
    {
        private int senderId;
        private int reciver;
        private string messageText;
        private DateTime timeSent;

        public int SenderId { get => senderId; set => senderId = value; }
        public int Reciver { get => reciver; set => reciver = value; }
        public string MessageText { get => messageText; set => messageText = value; }
        public DateTime TimeSent { get => timeSent; set => timeSent = value; }
    }
}
