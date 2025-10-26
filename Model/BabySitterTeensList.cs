using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BabySitterTeensList : List<BabySitterTeens>
    {
        public BabySitterTeensList() { }
        public BabySitterTeensList(IEnumerable<BabySitterTeens> list) : base(list) { }
        public BabySitterTeensList(IEnumerable<BaseEntity> list) : base(list.Cast<BabySitterTeens>().ToList()) { }
    }
}
