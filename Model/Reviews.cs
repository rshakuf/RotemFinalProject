using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Reviews : BaseEntity
    {
        private Parents parentId;
        private BabySitterTeens babySitterId;
        private DateTime reviewDate;
        private int rating;

        public Parents ParentId { get => parentId; set => parentId = value; }
        public BabySitterTeens BabySitterId { get => babySitterId; set => babySitterId = value; }
        public DateTime ReviewDate { get => reviewDate; set => reviewDate = value; }
        public int Rating { get => rating; set => rating = value; }
    }
}
