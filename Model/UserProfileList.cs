using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserProfileList : List<UserProfile>
    {
        public UserProfileList() { }
        public UserProfileList(IEnumerable<UserProfile> list) : base(list) { }
        public UserProfileList(IEnumerable<BaseEntity> list) : base(list.Cast<UserProfile>().ToList()) { }
    }
}
