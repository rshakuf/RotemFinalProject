using System;
using System.Collections.Generic;
using System.Data.OleDb;
using Model;

namespace ViewModel
{
    public class ScheduleDB : BaseDB
    {
        public override BaseEntity NewEntity()
        {
            return new Schedule();
        }

        public ScheduleList SelectAll()
        {
            command.CommandText =
                "SELECT    BabysitterId, DateAvailable, starttime, endtime, parentId, isRequested, isApproved, id FROM  Schedule";

            ScheduleList list = new ScheduleList();

            foreach (BaseEntity be in Select())
            {
                list.Add(be as Schedule);
            }

            return list;
        }

        public static Schedule SelectById(int id)
        {
            ScheduleDB db = new ScheduleDB();

            db.command.CommandText =
                "SELECT * FROM Schedule WHERE id=@id";

            db.command.Parameters.Clear();

            db.command.Parameters.Add(
                new OleDbParameter("@id", id));

            List<Schedule> list = new List<Schedule>();

            foreach (BaseEntity be in db.Select())
            {
                list.Add(be as Schedule);
            }

            if (list.Count > 0)
                return list[0];

            return null;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Schedule s = entity as Schedule;

            if (s == null)
                s = new Schedule();

            base.CreateModel(s);

            if (reader["babysitterId"] != DBNull.Value)
            {
                s.BabysitterId =
                    BabySitterTeensDB.SelectById(
                        Convert.ToInt32(reader["babysitterId"]));
            }

            if (reader["parentId"] != DBNull.Value)
            {
                s.ParentId =
                    ParentsDB.SelectById(
                        Convert.ToInt32(reader["parentId"]));
            }

            if (reader["dateAvailable"] != DBNull.Value)
            {
                s.DateAvailable =
                    Convert.ToDateTime(reader["dateAvailable"]);
            }

            if (reader["startTime"] != DBNull.Value)
            {
                DateTime dt =
                    Convert.ToDateTime(reader["startTime"]);

                s.Starttime =
                    TimeOnly.FromDateTime(dt);
            }

            if (reader["endTime"] != DBNull.Value)
            {
                DateTime dt =
                    Convert.ToDateTime(reader["endTime"]);

                s.Endtime =
                    TimeOnly.FromDateTime(dt);
            }

            if (reader["isRequested"] != DBNull.Value)
            {
                s.IsRequested =
                    Convert.ToBoolean(reader["isRequested"]);
            }

            if (reader["isApproved"] != DBNull.Value)
            {
                s.IsApproved =
                    Convert.ToBoolean(reader["isApproved"]);
            }

            return s;
        }

        protected override void CreateDeletedSQL(
            BaseEntity entity,
            OleDbCommand cmd)
        {
            Schedule s = entity as Schedule;

            if (s == null)
                return;

            cmd.CommandText =
                "DELETE FROM Schedule WHERE id=?";

            cmd.Parameters.AddWithValue(
                "@id",
                s.Id);
        }

        public override void Insert(BaseEntity entity)
        {
            BaseEntity newEntity = NewEntity();

            if (entity != null &&
                entity.GetType() == newEntity.GetType())
            {
                inserted.Add(
                    new ChangeEntity(
                        CreateInsertdSQL,
                        entity));
            }
        }

        protected override void CreateInsertdSQL(
            BaseEntity entity,
            OleDbCommand cmd)
        {
            Schedule s = entity as Schedule;

            if (s == null)
                return;

            cmd.CommandText =
                "INSERT INTO Schedule " +
                "(babysitterId, parentId, dateAvailable, startTime, endTime, isRequested, isApproved) " +
                "VALUES (?,?,?,?,?,?,?)";

            cmd.Parameters.AddWithValue(
                "@babysitterId",
                DbVal(s.BabysitterId?.Id));

            cmd.Parameters.AddWithValue(
                "@parentId",
                DbVal(s.ParentId?.Id));

            cmd.Parameters.AddWithValue(
                "@dateAvailable",
                s.DateAvailable);

            cmd.Parameters.AddWithValue(
                "@startTime",
                new DateTime(1900, 1, 1, s.Starttime.Hour, s.Starttime.Minute, s.Starttime.Second));

            cmd.Parameters.AddWithValue(
                "@endTime",
                new DateTime(1900, 1, 1, s.Endtime.Hour, s.Endtime.Minute, s.Endtime.Second));

            cmd.Parameters.AddWithValue(
                "@isRequested",
                s.IsRequested);

            cmd.Parameters.AddWithValue(
                "@isApproved",
                s.IsApproved);
        }

        protected override void CreateUpdatedSQL(
            BaseEntity entity,
            OleDbCommand cmd)
        {
            Schedule s = entity as Schedule;

            if (s == null)
                return;

            cmd.CommandText =
                "UPDATE Schedule SET " +
                "babysitterId=?, " +
                "parentId=?, " +
                "dateAvailable=?, " +
                "startTime=?, " +
                "endTime=?, " +
                "isRequested=?, " +
                "isApproved=? " +
                "WHERE id=?";

            cmd.Parameters.AddWithValue(
                "@babysitterId",
                DbVal(s.BabysitterId?.Id));

            cmd.Parameters.AddWithValue(
                "@parentId",
                DbVal(s.ParentId?.Id));

            cmd.Parameters.AddWithValue(
                "@dateAvailable",
                s.DateAvailable);

            cmd.Parameters.AddWithValue(
                "@startTime",
                new DateTime(1900, 1, 1, s.Starttime.Hour, s.Starttime.Minute, s.Starttime.Second));

            cmd.Parameters.AddWithValue(
                "@endTime",
                new DateTime(1900, 1, 1, s.Endtime.Hour, s.Endtime.Minute, s.Endtime.Second));

            cmd.Parameters.AddWithValue(
                "@isRequested",
                s.IsRequested);

            cmd.Parameters.AddWithValue(
                "@isApproved",
                s.IsApproved);

            cmd.Parameters.AddWithValue(
                "@id",
                s.Id);
        }
    }
}