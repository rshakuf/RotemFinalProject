using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ScheduleList : List<Schedule>
    {
        public ScheduleList() { }
        public ScheduleList(IEnumerable<Schedule> list) : base(list) { }
        public ScheduleList(IEnumerable<BaseEntity> list) : base(list.Cast<Schedule>().ToList()) { }
    }
}
