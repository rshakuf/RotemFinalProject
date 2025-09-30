using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Request : BaseEntity
    {
        private string status;
        private DateTime TimeOfRequest;

        public string Status { get => status; set => status = value; }
        public DateTime TimeOfRequest1 { get => TimeOfRequest; set => TimeOfRequest = value; }
    }
}
