using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BabySitterRate: BaseEntity
    {
        private int stars;
        private BabySitterTeens idBabySitter;
        private Parents idParent;
        private DateTime dateOfRate;

        public int Stars { get => stars; set => stars = value; }
        public BabySitterTeens IdBabySitter { get => idBabySitter; set => idBabySitter = value; }
        public Parents IdParent { get => idParent; set => idParent = value; }
        public DateTime DateOfRate { get => dateOfRate; set => dateOfRate = value; }
    }
}
