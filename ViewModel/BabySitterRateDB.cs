using System;
using System.Collections.Generic;
using System.Data.OleDb;
using Model;

namespace ViewModel
{
    public class BabySitterRateDB : BaseDB
    {
        public override BaseEntity NewEntity() => new BabySitterRate();

        public BabySitterRateList SelectAll()
        {
            command.CommandText = "SELECT  * FROM BabySitterRate";
            var list = new BabySitterRateList();
            foreach (var e in Select())
                list.Add(e as BabySitterRate);
            return list;
        }

        public static BabySitterRate SelectById(int id)
        {
            var db = new BabySitterRateDB();
            db.command.CommandText = "SELECT BabySitterRate.* FROM BabySitterRate WHERE id=@id";
            db.command.Parameters.Clear();
            db.command.Parameters.Add(new OleDbParameter("@id", id));
            var list = new List<BabySitterRate>();
            foreach (var e in db.Select())
                list.Add(e as BabySitterRate);
            return list.Count > 0 ? list[0] : null;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            var r = entity as BabySitterRate ?? new BabySitterRate();

            if (reader["stars"] != DBNull.Value) r.Stars = Convert.ToInt32(reader["stars"]);
            if (reader["idBabySitter"] != DBNull.Value)
                r.IdBabySitter = BabySitterTeensDB.SelectById(Convert.ToInt32(reader["idBabySitter"]));
            if (reader["idParent"] != DBNull.Value)
                r.IdParent = ParentsDB.SelectById(Convert.ToInt32(reader["idParent"]));
            if (reader["dateOfRate"] != DBNull.Value)
                r.DateOfRate = Convert.ToDateTime(reader["dateOfRate"]);

            base.CreateModel(r);
            return r;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            BabySitterRate p = entity as BabySitterRate;
            if (p != null)
            {
                string sqlStr = "DELETE FROM BabySitterRate where ID=@pid";

                command.CommandText = sqlStr;

                command.Parameters.Add(new OleDbParameter("@pid", p.Id));

            }
        }

     

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            if (entity is not BabySitterRate r) return;

            cmd.CommandText =
                "INSERT INTO BabySitterRate (stars, idBabySitter, idParent, DateOfRate) " +
                "VALUES (?,?,?,?)";

            cmd.Parameters.Add(new OleDbParameter("@stars", r.Stars));
            cmd.Parameters.Add(new OleDbParameter("@idBabySitter", DbVal(r.IdBabySitter?.Id)));
            cmd.Parameters.Add(new OleDbParameter("@idParent", DbVal(r.IdParent?.Id)));
            cmd.Parameters.Add(new OleDbParameter("@DateOfRate", r.DateOfRate));
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            if (entity is not BabySitterRate r) return;

            cmd.CommandText =
                "UPDATE BabySitterRate SET stars=@stars, idBabySitter=@idBabySitter, idParent=@idParent, DateOfRate=@DateOfRate " +
                "WHERE ID=@id";

            cmd.Parameters.Add(new OleDbParameter("@stars", r.Stars));
            cmd.Parameters.Add(new OleDbParameter("@idBabySitter", DbVal(r.IdBabySitter?.Id)));
            cmd.Parameters.Add(new OleDbParameter("@idParent", DbVal(r.IdParent?.Id)));
            cmd.Parameters.Add(new OleDbParameter("@DateOfRate", r.DateOfRate));
            cmd.Parameters.Add(new OleDbParameter("@id", r.Id));
        }
    }
}
