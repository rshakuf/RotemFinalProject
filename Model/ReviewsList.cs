using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ReviewsList : List<Reviews>
    {
        public ReviewsList() { }
        public ReviewsList(IEnumerable<Reviews> list) : base(list) { }
        public ReviewsList(IEnumerable<BaseEntity> list) : base(list.Cast<Reviews>().ToList()) { }
    }
}
