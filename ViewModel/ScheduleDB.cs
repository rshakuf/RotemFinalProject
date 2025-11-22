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
                s.BabysitterId = BabySitterTeensDB.SelectById(Convert.ToInt32(reader["babysitterId"]));

            if (reader["dayOfWeek"] != DBNull.Value)
                s.DayOfWeek = Convert.ToString(reader["DayOfWeek"]);

            if (reader["startTime"] != DBNull.Value)
                s.StartTime = Convert.ToDateTime(reader["startTime"]);

            if (reader["endTime"] != DBNull.Value)
                s.EndTime = Convert.ToDateTime(reader["endTime"]);

            base.CreateModel(s);
            return s;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            if (entity is not Schedule s) return;
            cmd.CommandText = "DELETE FROM Schedule WHERE id=@id";
            cmd.Parameters.Add(new OleDbParameter("@id", s.Id));
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
            if (entity is not Schedule s) return;

            cmd.CommandText =
                "INSERT INTO Schedule (babysitterId, dayOfWeek, startTime, endTime, breakTime) " +
                "VALUES (?,?,?,?,?)";

            cmd.Parameters.Add(new OleDbParameter("@babysitterId", DbVal(s.BabysitterId?.Id)));
            cmd.Parameters.Add(new OleDbParameter("@dayOfWeek", s.DayOfWeek));
            cmd.Parameters.Add(new OleDbParameter("@startTime", s.StartTime));
            cmd.Parameters.Add(new OleDbParameter("@endTime", s.EndTime));
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            if (entity is not Schedule s) return;

            cmd.CommandText =
                "UPDATE Schedule SET babysitterId=?, dayOfWeek=?, startTime=?, endTime=? " +
                "WHERE id=?";

            cmd.Parameters.Add(new OleDbParameter("@babysitterId", DbVal(s.BabysitterId?.Id)));
            cmd.Parameters.Add(new OleDbParameter("@dayOfWeek", s.DayOfWeek));
            cmd.Parameters.Add(new OleDbParameter("@startTime", s.StartTime));
            cmd.Parameters.Add(new OleDbParameter("@endTime", s.EndTime));
            cmd.Parameters.Add(new OleDbParameter("@id", s.Id));
        }
    }
}