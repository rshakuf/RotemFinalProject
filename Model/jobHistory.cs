using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class JobHistory : BaseEntity
    {
        private BabySitterTeens BabySitterTeensid;
        private Parents parentsid;
        private DateTime startTime;
        private DateTime endTime;
        private int totalPayment;

        public DateTime StartTime { get => startTime; set => startTime = value; }
        public DateTime EndTime { get => endTime; set => endTime = value; }
        public int TotalPayment { get => totalPayment; set => totalPayment = value; }
        public BabySitterTeens BabySitterTeensid1 { get => BabySitterTeensid; set => BabySitterTeensid = value; }
        public Parents Parentsid { get => parentsid; set => parentsid = value; }
    }
}