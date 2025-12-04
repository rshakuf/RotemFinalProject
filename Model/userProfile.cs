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
        private City cityId;

        public string Email { get => email; set => email = value; }
        public string Pass { get => pass; set => pass = value; }
        public City CityId { get => cityId; set => cityId = value; }
    }
}
