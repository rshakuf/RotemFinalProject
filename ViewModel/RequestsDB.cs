using System;
using System.Collections.Generic;
using System.Data.OleDb;
using Model;

namespace ViewModel
{
    public class RequestsDB : BaseDB
    {
        public override BaseEntity NewEntity() => new Requests();

        // Raw intermediate struct so we can close the outer reader before doing nested lookups
        private struct RawRequest
        {
            public int Id, ParentsId, BabysitterId, LenghtTime;
            public string Status;
            public DateTime TimeOfRequest;
        }

        private List<RawRequest> ReadRawRequests(string sql, OleDbParameter param = null)
        {
            var rows = new List<RawRequest>();
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                command.CommandText = sql;
                command.Parameters.Clear();
                if (param != null) command.Parameters.Add(param);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var raw = new RawRequest
                    {
                        Id            = Convert.ToInt32(reader["id"]),
                        Status        = reader["status"] != DBNull.Value ? reader["status"].ToString() : "",
                        TimeOfRequest = reader["TimeOfRequest"] != DBNull.Value ? Convert.ToDateTime(reader["TimeOfRequest"]) : default,
                        ParentsId     = reader["parentsId"] != DBNull.Value ? Convert.ToInt32(reader["parentsId"]) : 0,
                        BabysitterId  = reader["babysitterId"] != DBNull.Value ? Convert.ToInt32(reader["babysitterId"]) : 0,
                        LenghtTime    = reader["LenghtTime"] != DBNull.Value ? Convert.ToInt32(reader["LenghtTime"]) : 0
                    };
                    rows.Add(raw);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("RequestsDB.ReadRaw: " + ex.Message);
            }
            finally
            {
                reader?.Close();
                reader = null;
                command.Parameters.Clear();
            }
            return rows;
        }

        private static Requests HydrateRequest(RawRequest raw)
        {
            var r = new Requests
            {
                Id            = raw.Id,
                Status        = raw.Status,
                TimeOfRequest = raw.TimeOfRequest,
                LenghtTime    = raw.LenghtTime
            };
            if (raw.ParentsId    > 0) r.ParentsId    = ParentsDB.SelectById(raw.ParentsId);
            if (raw.BabysitterId > 0) r.BabysitterId = BabySitterTeensDB.SelectById(raw.BabysitterId);
            return r;
        }

        public RequestsList SelectAll()
        {
            var rows = ReadRawRequests("SELECT * FROM Requests");
            var list = new RequestsList();
            foreach (var raw in rows)
                list.Add(HydrateRequest(raw));
            return list;
        }

        public static Requests SelectById(int id)
        {
            var db = new RequestsDB();
            var rows = db.ReadRawRequests("SELECT * FROM Requests WHERE id=?",
                new OleDbParameter("@id", id));
            return rows.Count > 0 ? HydrateRequest(rows[0]) : null;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            // Kept for BaseDB compatibility — not called by SelectAll/SelectById above
            var r = entity as Requests ?? new Requests();
            if (reader["status"] != DBNull.Value)        r.Status        = reader["status"].ToString();
            if (reader["TimeOfRequest"] != DBNull.Value) r.TimeOfRequest = Convert.ToDateTime(reader["TimeOfRequest"]);
            if (reader["LenghtTime"] != DBNull.Value)    r.LenghtTime    = Convert.ToInt32(reader["LenghtTime"]);
            base.CreateModel(r);
            return r;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Requests p = entity as Requests;
            if (p != null)
            {
                string sqlStr = "DELETE FROM Requests where ID =@pid";

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
            if (entity is not Requests r) return;

            cmd.CommandText =
                "INSERT INTO Requests (status, TimeOfRequest, parentsId, babysitterId, LenghtTime) " +
                "VALUES (?,?,?,?,?)";

            cmd.Parameters.Add(new OleDbParameter("@status", r.Status));
            cmd.Parameters.Add(new OleDbParameter("@TimeOfRequest", r.TimeOfRequest));
            cmd.Parameters.Add(new OleDbParameter("@parentsId", DbVal(r.ParentsId?.Id)));
            cmd.Parameters.Add(new OleDbParameter("@babysitterId", DbVal(r.BabysitterId?.Id)));
            cmd.Parameters.Add(new OleDbParameter("@LenghtTime", r.LenghtTime));
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            if (entity is not Requests r) return;

            cmd.CommandText =
                "UPDATE Requests SET status=?, TimeOfRequest=?, parentsId=?, babysitterId=?, LenghtTime=? " +
                "WHERE id=?";

            cmd.Parameters.Add(new OleDbParameter("@status", r.Status));
            cmd.Parameters.Add(new OleDbParameter("@TimeOfRequest", r.TimeOfRequest));
            cmd.Parameters.Add(new OleDbParameter("@parentsId", DbVal(r.ParentsId?.Id)));
            cmd.Parameters.Add(new OleDbParameter("@babysitterId", DbVal(r.BabysitterId?.Id)));
            cmd.Parameters.Add(new OleDbParameter("@LenghtTime", r.LenghtTime));
            cmd.Parameters.Add(new OleDbParameter("@id", r.Id));
        }
    }
}
