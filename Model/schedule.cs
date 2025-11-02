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
        private String dayofweek;
        private DateTime starttime;
        private DateTime endtime;

        public BabySitterTeens BabysitterId { get => babysitterId; set => babysitterId = value; }
        public String DayOfWeek { get => dayofweek; set => dayofweek = value; }
        public DateTime StartTime { get => starttime; set => starttime = value; }
        public DateTime EndTime { get => endtime; set => endtime = value; }

    }
}