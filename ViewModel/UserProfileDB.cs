using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Model;

namespace ViewModel
{
    public class UserProfileDB : BaseDB
    {
        public UserProfileList SelectAll()
        {
            command.CommandText = "SELECT * FROM UserProfile";
            UserProfileList list = new UserProfileList(base.Select());
            return list;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            UserProfile up = entity as UserProfile;
            up.Email = reader["email"].ToString();
            up.Pass = reader["pass"].ToString();
            up.CityId = int.Parse(reader["cityId"].ToString());

            base.CreateModel(entity); // sets Id
            return up;
        }

        public override BaseEntity NewEntity()
        {
            return new UserProfile();
        }

        private static UserProfileList cache = new UserProfileList();

        public static UserProfile SelectById(int id)
        {
            var db = new UserProfileDB();
            cache = db.SelectAll();
            return cache.Find(x => x.Id == id);
        }


        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            UserProfile p = entity as UserProfile;
            if (p != null)
            {
                string sqlStr = "DELETE FROM [UserProfile] where ID=@pid";

                command.CommandText = sqlStr;

                command.Parameters.Add(new OleDbParameter("@pid", p.Id));

            }
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            var up = entity as UserProfile;
            cmd.CommandText =
                "INSERT INTO UserProfile (email, pass, cityId) VALUES (@mail, @pass, @city)";
            cmd.Parameters.Add(new OleDbParameter("@mail", up.Email));
            cmd.Parameters.Add(new OleDbParameter("@pass", up.Pass));
            cmd.Parameters.Add(new OleDbParameter("@city", up.CityId));
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            var up = entity as UserProfile;
            cmd.CommandText =
                "UPDATE UserProfile SET email=@mail, pass=@pass, cityId=@city WHERE id=@id";
            cmd.Parameters.Add(new OleDbParameter("@mail", up.Email));
            cmd.Parameters.Add(new OleDbParameter("@pass", up.Pass));
            cmd.Parameters.Add(new OleDbParameter("@city", up.CityId));
            cmd.Parameters.Add(new OleDbParameter("@id", up.Id));
        }
    }
}

