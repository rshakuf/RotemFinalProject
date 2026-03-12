using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public class ChildOfParent : User
    {
        private Parents idParent;

        public Parents IdParent { get => idParent; set => idParent = value; }
    }
}
