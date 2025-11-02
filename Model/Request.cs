using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Requests : BaseEntity
    {
        private Parents parentsId;
        private BabySitterTeens babysitterId;
        private string status;
        private DateTime timeOfRequest;

        public Parents ParentsId { get => parentsId; set => parentsId = value; }
        public BabySitterTeens BabysitterId { get => babysitterId; set => babysitterId = value; }
        public string Status { get => status; set => status = value; }
        public DateTime TimeOfRequest { get => timeOfRequest; set => timeOfRequest = value; }
    }
}
