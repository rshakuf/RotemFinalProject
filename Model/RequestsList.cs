using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RequestsList : List<Requests>
    {
        public RequestsList() { }
        public RequestsList(IEnumerable<Requests> list) : base(list) { }
        public RequestsList(IEnumerable<BaseEntity> list) : base(list.Cast<Requests>().ToList()) { }
    }
}
