using System;
using System.Collections.Generic;
using System.Data.OleDb;
using Model;

namespace ViewModel
{
    public class ScheduleDB : BaseDB
    {
        public override BaseEntity NewEntity() => new Schedule();

        public ScheduleList SelectAll()
        {
            command.CommandText = "SELECT * FROM Schedule";

            var list = new ScheduleList();

            foreach (var e in Select())
                list.Add(e as Schedule);

            return list;
        }

        public static Schedule SelectById(int id)
        {
            var db = new ScheduleDB();

            db.command.CommandText = "SELECT * FROM Schedule WHERE id=@id";
            db.command.Parameters.Clear();
            db.command.Parameters.Add(new OleDbParameter("@id", id));

            var list = new List<Schedule>();

            foreach (var e in db.Select())
                list.Add(e as Schedule);

            return list.Count > 0 ? list[0] : null;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            var s = entity as Schedule ?? new Schedule();

            if (reader["babysitterId"] != DBNull.Value)
                s.BabysitterId =
                    BabySitterTeensDB.SelectById(
                        Convert.ToInt32(reader["babysitterId"]));

            if (reader["parentId"] != DBNull.Value)
                s.ParentId =
                    ParentsDB.SelectById(
                        Convert.ToInt32(reader["parentId"]));

            if (reader["avialableDate"] != DBNull.Value)
                s.AvialableDate =
                    Convert.ToDateTime(reader["avialableDate"]);

            if (reader["startTime"] != DBNull.Value)
                s.Starttime =
                   TimeOnly.Parse((reader["startTime"]).ToString());

            if (reader["endTime"] != DBNull.Value)
                s.Endtime =
                    TimeOnly.Parse((reader["endTime"].ToString()));

            if (reader["isRequested"] != DBNull.Value)
                s.IsRequested =
                    Convert.ToBoolean(reader["isRequested"]);

            if (reader["isApproved"] != DBNull.Value)
                s.IsApproved =
                    Convert.ToBoolean(reader["isApproved"]);

            base.CreateModel(s);
            return s;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Schedule s = entity as Schedule;

            if (s != null)
            {
                string sqlStr =
                    "DELETE FROM Schedule WHERE id=@pid";

                cmd.CommandText = sqlStr;

                cmd.Parameters.Add(
                    new OleDbParameter("@pid", s.Id));
            }
        }

        public override void Insert(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();

            if (entity != null &&
                entity.GetType() == reqEntity.GetType())
            {
                inserted.Add(
                    new ChangeEntity(
                        this.CreateInsertdSQL,
                        entity));
            }
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            if (entity is not Schedule s)
                return;

            cmd.CommandText =
                "INSERT INTO Schedule " +
                "(babysitterId, avialableDate, startTime, endTime, parentId, isRequested, isApproved) " +
                "VALUES (?,?,?,?,?,?,?)";

            cmd.Parameters.AddWithValue(
                "@babysitterId",
                DbVal(s.BabysitterId?.Id));

            cmd.Parameters.AddWithValue(
                "@avialableDate",
                s.AvialableDate);

            cmd.Parameters.AddWithValue(
                "@startTime",
                s.Starttime.ToString());

            cmd.Parameters.AddWithValue(
                "@endTime",
                s.Endtime.ToString());

            cmd.Parameters.AddWithValue(
                "@parentId",
                DbVal(s.ParentId?.Id));

            cmd.Parameters.AddWithValue(
                "@isRequested",
                s.IsRequested);

            cmd.Parameters.AddWithValue(
                "@isApproved",
                s.IsApproved);
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            if (entity is not Schedule s)
                return;

            cmd.CommandText =
                "UPDATE Schedule SET " +
                "babysitterId=?, " +
                "avialableDate=?, " +
                "startTime=?, " +
                "endTime=?, " +
                "parentId=?, " +
                "isRequested=?, " +
                "isApproved=? " +
                "WHERE id=?";

            cmd.Parameters.Add(
                new OleDbParameter(
                    "@babysitterId",
                    DbVal(s.BabysitterId?.Id)));

            cmd.Parameters.Add(
                new OleDbParameter(
                    "@avialableDate",
                    s.AvialableDate));

            cmd.Parameters.Add(
                new OleDbParameter(
                    "@startTime",
                    s.Starttime.ToString()));

            cmd.Parameters.Add(
                new OleDbParameter(
                    "@endTime",
                    s.Endtime.ToString()));

            cmd.Parameters.Add(
                new OleDbParameter(
                    "@parentId",
                    DbVal(s.ParentId?.Id)));

            cmd.Parameters.Add(
                new OleDbParameter(
                    "@isRequested",
                    s.IsRequested));

            cmd.Parameters.Add(
                new OleDbParameter(
                    "@isApproved",
                    s.IsApproved));

            cmd.Parameters.Add(
                new OleDbParameter(
                    "@id",
                    s.Id));
        }
    }
}