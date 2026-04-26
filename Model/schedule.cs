using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Schedule : BaseEntity
    {
        private BabySitterTeens babysitterId;
        private DateTime avialableDate;
        private TimeOnly starttime;
        private TimeOnly endtime;
        private Parents parentId;
        private bool isRequested;
        private bool isApproved;
      


        public BabySitterTeens BabysitterId { get => babysitterId; set => babysitterId = value; }

        public DateTime AvialableDate { get => avialableDate; set => avialableDate = value; }
        public TimeOnly Starttime { get => starttime; set => starttime = value; }
        public TimeOnly Endtime { get => endtime; set => endtime = value; }
        public Parents ParentId { get => parentId; set => parentId = value; }
        public bool IsRequested { get => isRequested; set => isRequested = value; }
        public bool IsApproved { get => isApproved; set => isApproved = value; }
       
    }
}