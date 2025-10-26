using System;
using System.Collections.Generic;
using System.Data.OleDb;
using Model;

namespace ViewModel
{
    public class ReviewsDBR : BaseDB
    {
        public override BaseEntity NewEntity() => new Reviews();

        public List<Reviews> SelectAll()
        {
            command.CommandText = "SELECT * FROM Reviews";
            var list = new List<Reviews>();
            foreach (var e in Select())
                list.Add(e as Reviews);
            return list;
        }

        public static Reviews SelectById(int id)
        {
            var db = new ReviewsDB();
            db.command.CommandText = "SELECT * FROM Reviews WHERE id=?";
            db.command.Parameters.Clear();
            db.command.Parameters.Add(new OleDbParameter("@id", id));
            var list = new List<Reviews>();
            foreach (var e in db.Select())
                list.Add(e as Reviews);
            return list.Count > 0 ? list[0] : null;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            var r = entity as Reviews ?? new Reviews();

            if (reader["parentsid"] != DBNull.Value)
                r.Parentsid = ParentsDB.SelectById(Convert.ToInt32(reader["parentsid"]));

            if (reader["babySitterTeensid"] != DBNull.Value)
                r.BabySitterTeensid = BabySitterTeensDB.SelectById(Convert.ToInt32(reader["babySitterTeensid"]));

            if (reader["reviewDate"] != DBNull.Value)
                r.ReviewDate = Convert.ToDateTime(reader["reviewDate"]);

            if (reader["rating"] != DBNull.Value)
                r.Rating = Convert.ToInt32(reader["rating"]);

            base.CreateModel(r);
            return r;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            if (entity is not Reviews r) return;
            cmd.CommandText = "DELETE FROM Reviews WHERE id=?";
            cmd.Parameters.Add(new OleDbParameter("@id", r.Id));
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            if (entity is not Reviews r) return;

            cmd.CommandText =
                "INSERT INTO Reviews (parentsid, babySitterTeensid, reviewDate, rating) " +
                "VALUES (?,?,?,?)";

            cmd.Parameters.Add(new OleDbParameter("@parentsid", DbVal(r.Parentsid?.Id)));
            cmd.Parameters.Add(new OleDbParameter("@babySitterTeensid", DbVal(r.BabySitterTeensid?.Id)));
            cmd.Parameters.Add(new OleDbParameter("@reviewDate", r.ReviewDate));
            cmd.Parameters.Add(new OleDbParameter("@rating", r.Rating));
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            if (entity is not Reviews r) return;

            cmd.CommandText =
                "UPDATE Reviews SET parentsid=?, babySitterTeensid=?, reviewDate=?, rating=? " +
                "WHERE id=?";

            cmd.Parameters.Add(new OleDbParameter("@parentsid", DbVal(r.Parentsid?.Id)));
            cmd.Parameters.Add(new OleDbParameter("@babySitterTeensid", DbVal(r.BabySitterTeensid?.Id)));
            cmd.Parameters.Add(new OleDbParameter("@reviewDate", r.ReviewDate));
            cmd.Parameters.Add(new OleDbParameter("@rating", r.Rating));
            cmd.Parameters.Add(new OleDbParameter("@id", r.Id));
        }
    }
}