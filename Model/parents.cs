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
        private string password;
        private int numOfKids;
        public int Telephone { get => telephone; set => telephone = value; }
        public string Password { get => password; set => password = value; }
        public int NumOfKids { get => numOfKids; set => numOfKids = value; }
    }
}
