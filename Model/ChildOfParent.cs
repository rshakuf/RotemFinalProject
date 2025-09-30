using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ChildOfParent : User
    {
        private parents parent;

        public parents Parent { get => parent; set => parent = value; }
    }
}
