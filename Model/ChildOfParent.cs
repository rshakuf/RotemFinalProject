using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ChildOfParent : User
    {
        private User idChild;
        private Parents parent;

        
        public User IdChild { get => idChild; set => idChild = value; }
        public Parents Parent { get => parent; set => parent = value; }
    }
}
