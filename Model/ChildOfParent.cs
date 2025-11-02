using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ChildOfParent : User
    {
        private User id;
        private Parents idParent;

        public User Id { get => id; set => id = value; }
        public Parents IdParent { get => idParent; set => idParent = value; }
    }
}
