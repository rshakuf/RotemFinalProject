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
            //command.CommandText = $"SELECT [User].DateOfBirth, [User].firstName, [User].LastName, [User].CityNameId, Parents.Id, Parents.telephone, Parents.[password], Parents.numOfKids FROM  (Parents INNER JOIN [User] ON Parents.Id = [User].id))";
            command.CommandText = $"SELECT  Parents.Id, Parents.telephone, Parents.[password], Parents.numOfKids, [User].DateOfBirth, [User].firstName, [User].LastName, [User].CityNameId FROM   (Parents INNER JOIN     [User] ON Parents.Id = [User].id)";

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
            p.Telephone = int.Parse(reader["Telephone"].ToString());
            p.Password = reader["Password"].ToString();
            p.NumOfKids = int.Parse(reader["NumOfKids"].ToString());
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
                string sqlStr = $"DELETE FROM Parents WHERE ID=@pid";
                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@pid", p.Id));
            }
        }

        public virtual void Delete(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
                deleted.Add(new ChangeEntity(base.CreateUpdatedSQL, entity));
            }
        }


        public override void Insert(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity(); ;
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                inserted.Add(new ChangeEntity(base.CreateInsertdSQL, entity));
                inserted.Add(new ChangeEntity(this.CreateInsertdSQL, entity));
            }

        }
        public override void Update(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity(); ;
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                updated.Add(new ChangeEntity(base.CreateUpdatedSQL, entity));
                updated.Add(new ChangeEntity(this.CreateUpdatedSQL, entity));
            }
        }
        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Parents p = entity as Parents;
            if (p != null)
            {
                string sqlStr = @"INSERT INTO Parents (TELEPHONE,[PASSWORD], NUMOFKIDS, ID) VALUES (?,?,?,?);";

                cmd.CommandText = sqlStr;
                cmd.Parameters.AddWithValue("@TELEPHONE", p.Telephone);
                cmd.Parameters.AddWithValue("@PASSWORD", p.Password);
                cmd.Parameters.AddWithValue("@NUMOFKIDS", p.NumOfKids);
                cmd.Parameters.AddWithValue("@ID", p.Id);

            }
        }

      
        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Parents p = entity as Parents;
            if (p != null)
            {
                string sqlStr = "UPDATE   [parents] SET telephone= @telephone , [password]=@password , numOfKids=@numodkids, WHERE ID = @id";///ךהוסיף telephone firstName = @fname, lastName = @lname, CityNameId = @cityId

                cmd.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@telephone", p.Telephone));
                cmd.Parameters.Add(new OleDbParameter("@password", p.Password));
                cmd.Parameters.Add(new OleDbParameter("@numodkids", p.NumOfKids));
                cmd.Parameters.Add(new OleDbParameter("@id", p.Id));
            }

        }
    }

}

