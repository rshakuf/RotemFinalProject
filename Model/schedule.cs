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
        private BabySitterTeens dayofweek;
        private BabySitterTeens starttime;
        private BabySitterTeens endtime;
        private BabySitterTeens braketime;

        public BabySitterTeens BabysitterId { get => babysitterId; set => babysitterId = value; }
        public BabySitterTeens DayofWeek { get => dayofweek; set => dayofweek = value; }
        public BabySitterTeens StartTime { get => starttime; set => starttime = value; }
        public BabySitterTeens EndTime { get => endtime; set => endtime = value; }
        public BabySitterTeens BrakeTime { get => braketime; set => braketime = value; }
    }
}
