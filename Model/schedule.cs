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
        private DateTime dayofweek;
        private DateTime starttime;
        private DateTime endtime;
        private DateTime braketime;

        public BabySitterTeens BabysitterId { get => babysitterId; set => babysitterId = value; }
        public DateTime DayOfWeek { get => dayofweek; set => dayofweek = value; }
        public DateTime StartTime { get => starttime; set => starttime = value; }
        public DateTime EndTime { get => endtime; set => endtime = value; }
        public DateTime BreakTime { get => braketime; set => braketime = value; }

    }
}