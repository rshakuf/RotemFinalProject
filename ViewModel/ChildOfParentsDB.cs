using Model;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.OleDb;


namespace ViewModel
{
    public class ChildOfParentDB: UserDB
    {
        static private ChildOfParentList list = new ChildOfParentList();
        public ChildOfParentList SelectAll()
        {
            command.CommandText = $"SELECT [User].DateOfBirth, [User].firstName, [User].LastName, [User].CityName, [User].CityNameId, ChildOfParent.IdParent, ChildOfParent.id FROM  (ChildOfParent INNER JOIN  [User] ON ChildOfParent.id = [User].id)";
            ChildOfParentList pList = new ChildOfParentList(base.Select());
            return pList;
        }
        public override BaseEntity NewEntity() => new ChildOfParent();
        public static ChildOfParent SelectById(int id)
        {
            var db = new ChildOfParentDB();
            db.command.CommandText = $"SELECT [User].DateOfBirth, [User].firstName, [User].LastName, [User].CityName, [User].CityNameId, ChildOfParent.IdParent, ChildOfParent.id FROM  (ChildOfParent INNER JOIN [User] ON ChildOfParent.id = [User].id WHERE id=@id)";
            db.command.Parameters.Clear();
            db.command.Parameters.Add(new OleDbParameter("@id", id));

            var list = new List<ChildOfParent>();
            foreach (var e in db.Select())
                list.Add(e as ChildOfParent);

            return list.Count > 0 ? list[0] : null;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            var cop = entity as ChildOfParent ?? new ChildOfParent();

            if (reader["id"] != DBNull.Value)
                cop.Id = UserDB.SelectById(Convert.ToInt32(reader["id"]));

            if (reader["idParent"] != DBNull.Value)
                cop.IdParent = ParentsDB.SelectById(Convert.ToInt32(reader["idParent"]));

            base.CreateModel(cop);
            return cop;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            if (entity is not ChildOfParent cop) return;
            cmd.CommandText = "DELETE FROM ChildOfParent WHERE id=?";
            cmd.Parameters.Add(new OleDbParameter("@id", cop.Id));
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            if (entity is not ChildOfParent cop) return;

            cmd.CommandText =
                "INSERT INTO ChildOfParent (idChild, Parentsid) " +
                "VALUES (?,?)";

            cmd.Parameters.Add(new OleDbParameter("@id", DbVal(cop.Id?.Id)));
            cmd.Parameters.Add(new OleDbParameter("@idParents", DbVal(cop.IdParent?.Id)));
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            if (entity is not ChildOfParent cop) return;

            cmd.CommandText =
                "UPDATE ChildOfParent SET idChild=?, Parentsid=? " +
                "WHERE id=?";

            cmd.Parameters.Add(new OleDbParameter("@id", DbVal(cop.Id?.Id)));
            cmd.Parameters.Add(new OleDbParameter("@idParents", DbVal(cop.IdParent?.Id)));
        }
    }
}
    
 
