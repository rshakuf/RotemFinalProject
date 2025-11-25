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
            u.CityNameId = int.Parse(reader["CityNameId"].ToString());

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
            User p = entity as User;
            if (p != null)
            {
                string sqlStr = "DELETE FROM [User] where ID=@pid";

                command.CommandText = sqlStr;

                command.Parameters.Add(new OleDbParameter("@pid", p.Id));

            }
        }


        public override void Insert(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity(); ;
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                //inserted.Add(new ChangeEntity(base.CreateInsertdSQL, entity));
                inserted.Add(new ChangeEntity(this.CreateInsertdSQL, entity));
            }
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            var u = entity as User;
            cmd.CommandText =
                "INSERT INTO [User] (firstName, lastName, dateOfBirth, cityNameId) VALUES (?, ?, ?, ?)";
            cmd.Parameters.Add(new OleDbParameter("@fn", u.FirstName));
            cmd.Parameters.Add(new OleDbParameter("@ln", u.LastName));
            cmd.Parameters.Add(new OleDbParameter("@dob", u.DateOfBirth));
            cmd.Parameters.Add(new OleDbParameter("@cni", u.CityNameId));
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            var u = entity as User;
            cmd.CommandText =
                "UPDATE [User] SET firstName=@fn, LastName=@ln, DateOfBirth=@dob, CityNameId=@cni WHERE ID=@id";
            cmd.Parameters.Add(new OleDbParameter("@fn", u.FirstName));
            cmd.Parameters.Add(new OleDbParameter("@ln", u.LastName));
            cmd.Parameters.Add(new OleDbParameter("@dob", u.DateOfBirth));
            cmd.Parameters.Add(new OleDbParameter("@cni", u.CityNameId));
            cmd.Parameters.Add(new OleDbParameter("@id", u.Id));
        }
    }
}