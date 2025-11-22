using System;
using System.Collections.Generic;
using System.Data.OleDb;
using Model;

namespace ViewModel
{
    public class RequestsDB : BaseDB
    {
        public override BaseEntity NewEntity() => new Requests();

        public RequestsList SelectAll()
        {
            command.CommandText = "SELECT * FROM Requests";
            var list = new RequestsList();
            foreach (var e in Select())
                list.Add(e as Requests);
            return list;
        }

        public static Requests SelectById(int id)
        {
            var db = new RequestsDB();
            db.command.CommandText = "SELECT * FROM Requests WHERE id=?";
            db.command.Parameters.Clear();
            db.command.Parameters.Add(new OleDbParameter("@id", id));
            var list = new List<Requests>();
            foreach (var e in db.Select())
                list.Add(e as Requests);
            return list.Count > 0 ? list[0] : null;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            var r = entity as Requests ?? new Requests();

            if (reader["status"] != DBNull.Value)
                r.Status = reader["status"].ToString();

            if (reader["TimeOfRequest"] != DBNull.Value)
                r.TimeOfRequest = Convert.ToDateTime(reader["TimeOfRequest"]);

            if (reader["parentsId"] != DBNull.Value)
                r.ParentsId = ParentsDB.SelectById(Convert.ToInt32(reader["parentsId"]));

            if (reader["babysitterId"] != DBNull.Value)
                r.BabysitterId = BabySitterTeensDB.SelectById(Convert.ToInt32(reader["babysitterId"]));

            base.CreateModel(r);
            return r;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            if (entity is not Requests r) return;
            cmd.CommandText = "DELETE FROM Requests WHERE id=?";
            cmd.Parameters.Add(new OleDbParameter("@id", r.Id));
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
            if (entity is not Requests r) return;

            cmd.CommandText =
                "INSERT INTO Requests (status, TimeOfRequest, parentsId, babysitterId) " +
                "VALUES (?,?,?,?)";

            cmd.Parameters.Add(new OleDbParameter("@status", r.Status));
            cmd.Parameters.Add(new OleDbParameter("@TimeOfRequest", r.TimeOfRequest));
            cmd.Parameters.Add(new OleDbParameter("@parentsId", DbVal(r.ParentsId?.Id)));
            cmd.Parameters.Add(new OleDbParameter("@babysitterId", DbVal(r.BabysitterId?.Id)));
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            if (entity is not Requests r) return;

            cmd.CommandText =
                "UPDATE Requests SET status=?, TimeOfRequest=?, parentsId=?, babysitterId=? " +
                "WHERE id=?";

            cmd.Parameters.Add(new OleDbParameter("@status", r.Status));
            cmd.Parameters.Add(new OleDbParameter("@TimeOfRequest", r.TimeOfRequest));
            cmd.Parameters.Add(new OleDbParameter("@parentsId", DbVal(r.ParentsId?.Id)));
            cmd.Parameters.Add(new OleDbParameter("@babysitterId", DbVal(r.BabysitterId?.Id)));
            cmd.Parameters.Add(new OleDbParameter("@id", r.Id));
        }
    }
}
