using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BabySitterRateList : List<BabySitterRate>
    {
        public BabySitterRateList() { }
        public BabySitterRateList(IEnumerable<BabySitterRate> list) : base(list) { }
        public BabySitterRateList(IEnumerable<BaseEntity> list) : base(list.Cast<BabySitterRate>().ToList()) { }
    }
}
