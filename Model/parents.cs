using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Parents : User
    {
        private int telephone;
        private int password;
        public int Telephone { get => telephone; set => telephone = value; }
        public int Password { get => password; set => password = value; }
    }
}
