using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Model;

namespace ViewModel
{
    public class UserDB : BaseDB
    {
        public UserList SelectAll()
        {
            command.CommandText = "SELECT [User].* FROM   [User]";
            UserList list = new UserList(base.Select());
            return list;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            User u = entity as User;
            u.FirstName = reader["firstName"].ToString();
            u.LastName = reader["lastName"].ToString();
            u.DateOfBirth = DateTime.Parse(reader["dateOfBirth"].ToString());

            base.CreateModel(entity); 
            return u;
        }

        public override BaseEntity NewEntity()
        {
            return new User();
        }

     
        private static UserList cache = new UserList();

        public static User SelectById(int id)
        {
            var db = new UserDB();
            cache = db.SelectAll();
            return cache.Find(x => x.Id == id);
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            var u = entity as User;
            cmd.CommandText = "DELETE FROM UserTbl WHERE id=@pid";
            cmd.Parameters.Add(new OleDbParameter("@pid", u.Id));
        }


        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            var u = entity as User;
            cmd.CommandText =
                "INSERT INTO UserTbl (firstName, lastName, dateOfBirth) VALUES (@fn, @ln, @dob)";
            cmd.Parameters.Add(new OleDbParameter("@fn", u.FirstName));
            cmd.Parameters.Add(new OleDbParameter("@ln", u.LastName));
            cmd.Parameters.Add(new OleDbParameter("@dob", u.DateOfBirth));
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            var u = entity as User;
            cmd.CommandText =
                "UPDATE UserTbl SET firstName=@fn, lastName=@ln, dateOfBirth=@dob WHERE id=@id";
            cmd.Parameters.Add(new OleDbParameter("@fn", u.FirstName));
            cmd.Parameters.Add(new OleDbParameter("@ln", u.LastName));
            cmd.Parameters.Add(new OleDbParameter("@dob", u.DateOfBirth));
            cmd.Parameters.Add(new OleDbParameter("@id", u.Id));
        }
    }
}