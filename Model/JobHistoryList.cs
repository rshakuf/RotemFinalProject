using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class JobHistoryList : List<JobHistory>
    {
        public JobHistoryList() { }
        public JobHistoryList(IEnumerable<JobHistory> list) : base(list) { }
        public JobHistoryList(IEnumerable<BaseEntity> list) : base(list.Cast<JobHistory>().ToList()) { }
    }
}
