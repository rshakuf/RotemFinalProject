using System;
using System.Collections.Generic;
using System.Data.OleDb;
using Model;

namespace ViewModel
{
    public class JobHistoryDB : BaseDB
    {
        public override BaseEntity NewEntity() => new JobHistory();

        public JobHistoryList SelectAll()
        {
            command.CommandText = "SELECT JobHistory.* FROM JobHistory";
            var list = new JobHistoryList();
            foreach (var e in Select())
                list.Add(e as JobHistory);
            return list;
        }

        public static JobHistory SelectById(int id)
        {
            var db = new JobHistoryDB();
            db.command.CommandText = "SELECT * FROM JobHistory WHERE id=?";
            db.command.Parameters.Clear();
            db.command.Parameters.Add(new OleDbParameter("@id", id));
            var list = new List<JobHistory>();
            foreach (var e in db.Select())
                list.Add(e as JobHistory);
            return list.Count > 0 ? list[0] : null;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            var jh = entity as JobHistory ?? new JobHistory();

            if (reader["StartTime"] != DBNull.Value) jh.StartTime = Convert.ToDateTime(reader["StartTime"]);
            if (reader["EndTime"] != DBNull.Value) jh.EndTime = Convert.ToDateTime(reader["EndTime"]);
            if (reader["TotalPayment"] != DBNull.Value) jh.TotalPayment = Convert.ToInt32(reader["totalPayment"]);
            if (reader["BabySitterId"] != DBNull.Value)
                jh.BabySitterId = BabySitterTeensDB.SelectById(Convert.ToInt32(reader["BabysitterId"]));
            if (reader["ParentId"] != DBNull.Value)
                jh.Parentid = ParentsDB.SelectById(Convert.ToInt32(reader["ParentId"]));

            base.CreateModel(jh);
            return jh;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            JobHistory p = entity as JobHistory;
            if (p != null)
            {
                string sqlStr = "DELETE FROM JobHistory where ID=@pid";

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
            if (entity is not JobHistory jh) return;

            cmd.CommandText =
                "INSERT INTO JobHistory (BabySitterid, ParentId, startTime, endTime, totalPayment) " +
                "VALUES (?,?,?,?,?)";

            cmd.Parameters.AddWithValue("@BabySitterid", DbVal(jh.BabySitterId?.Id));
            cmd.Parameters.AddWithValue("@ParentId", DbVal(jh.Parentid?.Id));
            cmd.Parameters.AddWithValue("@startTime", jh.StartTime);
            cmd.Parameters.AddWithValue("@endTime", jh.EndTime);
            cmd.Parameters.AddWithValue("@totalPayment", jh.TotalPayment);
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            if (entity is not JobHistory jh) return;

            cmd.CommandText =
                "UPDATE JobHistory SET  BabysitterId=@BabysitterId, ParentId=@ParentId, StartTime=@startTime, EndTime=@endTime, TotalPayment=@totalPayment " +
                "WHERE ID=@id";

            cmd.Parameters.Add(new OleDbParameter("@BabysitterId", jh.BabySitterId));
            cmd.Parameters.Add(new OleDbParameter("@ParentId", DbVal(jh.Parentid?.Id)));
            cmd.Parameters.Add(new OleDbParameter("@startTime", jh.StartTime));
            cmd.Parameters.Add(new OleDbParameter("@endTime", jh.EndTime));
            cmd.Parameters.Add(new OleDbParameter("@totalPayment", jh.TotalPayment));
            cmd.Parameters.Add(new OleDbParameter("@id", jh.Id));
        }
    }
}

