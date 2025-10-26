using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ChildOfParentList : List<ChildOfParent>
    {
        public ChildOfParentList() { }
        public ChildOfParentList(IEnumerable<ChildOfParent> list) : base(list) { }
        public ChildOfParentList(IEnumerable<BaseEntity> list) : base(list.Cast<ChildOfParent>().ToList()) { }
    }
}
