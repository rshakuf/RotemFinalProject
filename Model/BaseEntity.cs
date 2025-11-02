using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BaseEntity
    {
        private int ID;
        public int Id
        {
            get { return ID; }
            set { ID = value; }
        }
        public override string ToString()
        {
            return ID + " ";
        }


    }
}
