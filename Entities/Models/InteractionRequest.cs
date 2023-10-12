using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class InteractionRequest
    {
        public string message { get; set; }
        public bool messageType { get; set; }
        public string textColor { get; set; }
        public string contentColor { get; set; }
    }
}
