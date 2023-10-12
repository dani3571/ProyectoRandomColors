using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Message
    {
        public string message { get; set; }
        public bool messageType { get; set; }
        public Message(string msg, bool type) {
            this.message = msg;
            this.messageType = type;
        }
    }
}
