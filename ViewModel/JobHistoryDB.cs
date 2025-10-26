using System;
using System.Collections.Generic;
using System.Data.OleDb;
using Model;

namespace ViewModel
{
    public class JobHistoryDB : BaseDB
    {
        public override BaseEntity NewEntity() => new JobHistory();

        public List<JobHistory> SelectAll()
        {
            command.CommandText = "SELECT * FROM JobHistory";
            var list = new List<JobHistory>();
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

            if (reader["startTime"] != DBNull.Value) jh.StartTime = Convert.ToDateTime(reader["startTime"]);
            if (reader["endTime"] != DBNull.Value) jh.EndTime = Convert.ToDateTime(reader["endTime"]);
            if (reader["totalPayment"] != DBNull.Value) jh.TotalPayment = Convert.ToInt32(reader["totalPayment"]);
            if (reader["BabySitterTeensid"] != DBNull.Value)
                jh.BabySitterTeensid = BabySitterTeensDB.SelectById(Convert.ToInt32(reader["BabySitterTeensid"]));
            if (reader["Parentsid"] != DBNull.Value)
                jh.Parentsid = ParentsDB.SelectById(Convert.ToInt32(reader["Parentsid"]));

            base.CreateModel(jh);
            return jh;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            if (entity is not JobHistory jh) return;
            cmd.CommandText = "DELETE FROM JobHistory WHERE id=?";
            cmd.Parameters.Add(new OleDbParameter("@id", jh.Id));
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            if (entity is not JobHistory jh) return;

            cmd.CommandText =
                "INSERT INTO JobHistory (BabySitterTeensid, Parentsid, startTime, endTime, totalPayment) " +
                "VALUES (?,?,?,?,?)";

            cmd.Parameters.Add(new OleDbParameter("@BabySitterTeensid", DbVal(jh.BabySitterTeensid?.Id)));
            cmd.Parameters.Add(new OleDbParameter("@Parentsid", DbVal(jh.Parentsid?.Id)));
            cmd.Parameters.Add(new OleDbParameter("@startTime", jh.StartTime));
            cmd.Parameters.Add(new OleDbParameter("@endTime", jh.EndTime));
            cmd.Parameters.Add(new OleDbParameter("@totalPayment", jh.TotalPayment));
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            if (entity is not JobHistory jh) return;

            cmd.CommandText =
                "UPDATE JobHistory SET BabySitterTeensid=?, Parentsid=?, startTime=?, endTime=?, totalPayment=? " +
                "WHERE id=?";

            cmd.Parameters.Add(new OleDbParameter("@BabySitterTeensid", DbVal(jh.BabySitterTeensid?.Id)));
            cmd.Parameters.Add(new OleDbParameter("@Parentsid", DbVal(jh.Parentsid?.Id)));
            cmd.Parameters.Add(new OleDbParameter("@startTime", jh.StartTime));
            cmd.Parameters.Add(new OleDbParameter("@endTime", jh.EndTime));
            cmd.Parameters.Add(new OleDbParameter("@totalPayment", jh.TotalPayment));
            cmd.Parameters.Add(new OleDbParameter("@id", jh.Id));
        }
    }
}

