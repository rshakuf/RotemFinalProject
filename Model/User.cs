using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User : BaseEntity
    {
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private int cityNameId;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public int CityNameId { get => cityNameId; set => cityNameId = value; }
    }
}
