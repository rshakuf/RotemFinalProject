using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ParentsList : List<Parents>
    {
        public ParentsList() { }
        public ParentsList(IEnumerable<Parents> list) : base(list) { }
        public ParentsList(IEnumerable<BaseEntity> list) : base(list.Cast<Parents>().ToList()) { }
    }
}
