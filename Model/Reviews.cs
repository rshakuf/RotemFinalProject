using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Reviews : BaseEntity
    {
        private Parents parentsid;
        private BabySitterTeens babySitterTeensid;
        private DateTime reviewDate;
        private int rating;

        public Parents Parentsid { get => parentsid; set => parentsid = value; }
        public BabySitterTeens BabySitterTeensid { get => babySitterTeensid; set => babySitterTeensid = value; }
        public DateTime ReviewDate { get => reviewDate; set => reviewDate = value; }
        public int Rating { get => rating; set => rating = value; }
    }
}
