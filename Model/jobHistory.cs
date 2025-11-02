using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class JobHistory : BaseEntity
    {
        private BabySitterTeens babySitterTeensid;
        private Parents parentId;
        private DateTime startTime;
        private DateTime endTime;
        private int totalPayment;

        public DateTime StartTime { get => startTime; set => startTime = value; }
        public DateTime EndTime { get => endTime; set => endTime = value; }
        public int TotalPayment { get => totalPayment; set => totalPayment = value; }
        
        public Parents Parentid { get => parentId; set => parentId = value; }
        public BabySitterTeens BabySitterTeensid { get => babySitterTeensid; set => babySitterTeensid = value; }

        public override string ToString()
        {
            return startTime + " - " + endTime + " - " + totalPayment + " for "+ parentId.FirstName+" "+parentId.LastName;
        }
    }
    
}