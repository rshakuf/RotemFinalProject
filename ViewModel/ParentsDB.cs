using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace ViewModel
{
    public class ParentsDB : UserDB
    {
       
        public ParentsList SelectAll()
        {
            command.CommandText = $"SELECT Parents.Id,[User].DateOfBirth,[User].firstName,[User].LastName, [User].CityName, [User].CityNameId FROM (Parents INNER JOIN [User] ON Parents.Id = [User].id)";
            ParentsList pList = new ParentsList(base.Select());
            return pList;
        }

        //public static Parents SelectById(int id)
        //{
        //    ParentsDB db = new ParentsDB();
        //    db.command.CommandText = "SELECT * FROM Owners WHERE ID=?";
        //    db.command.Parameters.Clear();
        //    db.command.Parameters.Add(new OleDbParameter("@id", id));
        //    ParentsList list = new ParentsList(db.Select());
        //    return list.Count > 0 ? list[0] : null;
        //}

        static private ParentsList list = new ParentsList();
        public static Parents SelectById(int id)
        {
            ParentsDB db = new ParentsDB();
            list = db.SelectAll();
            Parents g = list.Find(x => x.Id == id);
            return g;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Parents p = entity as Parents;
            //p.FirstName = reader["firstName"].ToString();
            //p.LastName = reader["lastName"].ToString();
            //p.CityName = CityDB.SelectById((int)reader["cityCode"]);
            base.CreateModel(entity);
            return p;
        }

        //protected override BaseEntity CreateModel(BaseEntity entity)
        //{
        //    Parents o = entity as Parents ?? new Parents();

        //    return o;
        //}

        public override BaseEntity NewEntity() => new Parents();

        //protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        //{
        //    if (entity is not Parents o) return;
        //    cmd.CommandText = "DELETE FROM Parents WHERE ID=@id";
        //    cmd.Parameters.Add(new OleDbParameter("@id", o.Id));
        //}
        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Parents p = entity as Parents;
            if (p != null)
            {
                string sqlStr = $"DELETE FROM ParentsTbl WHERE ID=@pid";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@pid", p.Id));
            }
        }
        //protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        //{
        //    if (entity is not Parents o) return;

        //}
        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Parents p = entity as Parents;
            if (p != null)
            {
                string sqlStr = $"INSERT INTO ParentsTbl (firstName, lastName, cityCode) VALUES (@fname, @lname, @city)";
                cmd.CommandText = sqlStr;
                //cmd.Parameters.Add(new OleDbParameter("@fname", p.FirstName));
                //cmd.Parameters.Add(new OleDbParameter("@lname", p.LastName));
                //cmd.Parameters.Add(new OleDbParameter("@city", p.CityName.Id));
            }
        }

        //protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        //{
        //    if (entity is not Parents o) return;

        //}
        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Parents p = entity as Parents;
            if (p != null)
            {
                string sqlStr = $"UPDATE ParentsTbl SET firstName=@fname, lastName=@lname, cityCode=@city WHERE ID=@id";
                cmd.CommandText = sqlStr;
                //cmd.Parameters.Add(new OleDbParameter("@fname", p.FirstName));
                //cmd.Parameters.Add(new OleDbParameter("@lname", p.LastName));
                //cmd.Parameters.Add(new OleDbParameter("@city", p.LivingCity.Id));
                cmd.Parameters.Add(new OleDbParameter("@id", p.Id));
            }
        }
    }

}

