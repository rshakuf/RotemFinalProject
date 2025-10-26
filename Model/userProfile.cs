using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserProfile : BaseEntity
    {
        private string email;
        private string pass;
        private int cityId;

        public string Email { get => email; set => email = value; }
        public string Pass { get => pass; set => pass = value; }
        public int CityId { get => cityId; set => cityId = value; }
    }
}
