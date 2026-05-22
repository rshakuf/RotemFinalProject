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
        private DateTime dateAvailable;
        private TimeOnly starttime;
        private TimeOnly endtime;

        public BabySitterTeens BabysitterId { get => babysitterId; set => babysitterId = value; }
        public DateTime DateAvailable { get => dateAvailable; set => dateAvailable = value; }
        public TimeOnly Starttime { get => starttime; set => starttime = value; }
        public TimeOnly Endtime { get => endtime; set => endtime = value; }
    }
}