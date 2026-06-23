using System;
using System.Collections.Generic;
using System.Data.OleDb;
using Model;

namespace ViewModel
{
    public class BabySitterRateDB : BaseDB
    {
        public override BaseEntity NewEntity() => new BabySitterRate();

        private struct RawRate
        {
            public int Id, IdBabySitter, IdParent, Stars;
            public DateTime DateOfRate;
            public string ReviewText, Tags;
        }

        private List<RawRate> ReadRawRates(string sql, OleDbParameter param = null)
        {
            var rows = new List<RawRate>();
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
                    rows.Add(new RawRate
                    {
                        Id           = Convert.ToInt32(reader["id"]),
                        Stars        = reader["stars"] != DBNull.Value ? Convert.ToInt32(reader["stars"]) : 0,
                        IdBabySitter = reader["idBabySitter"] != DBNull.Value ? Convert.ToInt32(reader["idBabySitter"]) : 0,
                        IdParent     = reader["idParent"] != DBNull.Value ? Convert.ToInt32(reader["idParent"]) : 0,
                        DateOfRate   = reader["dateOfRate"] != DBNull.Value ? Convert.ToDateTime(reader["dateOfRate"]) : default,
                        ReviewText   = reader["ReviewText"] != DBNull.Value ? reader["ReviewText"].ToString() : null,
                        Tags         = reader["Tags"] != DBNull.Value ? reader["Tags"].ToString() : null
                    });
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("BabySitterRateDB.ReadRaw: " + ex.Message);
            }
            finally
            {
                reader?.Close();
                reader = null;
                command.Parameters.Clear();
            }
            return rows;
        }

        private static BabySitterRate HydrateRate(RawRate raw)
        {
            var r = new BabySitterRate { Id = raw.Id, Stars = raw.Stars, DateOfRate = raw.DateOfRate, ReviewText = raw.ReviewText, Tags = raw.Tags };
            if (raw.IdBabySitter > 0) r.IdBabySitter = new BabySitterTeens { Id = raw.IdBabySitter };
            if (raw.IdParent     > 0) r.IdParent     = ParentsDB.SelectById(raw.IdParent);
            return r;
        }

        public BabySitterRateList SelectAll()
        {
            var rows = ReadRawRates("SELECT * FROM BabySitterRate");
            if (rows.Count == 0) return new BabySitterRateList();

            var parentMap = new ParentsDB().SelectAll().ToDictionary(p => p.Id);

            var list = new BabySitterRateList();
            foreach (var raw in rows)
            {
                var r = new BabySitterRate { Id = raw.Id, Stars = raw.Stars, DateOfRate = raw.DateOfRate, ReviewText = raw.ReviewText, Tags = raw.Tags };
                if (raw.IdBabySitter > 0) r.IdBabySitter = new BabySitterTeens { Id = raw.IdBabySitter };
                if (raw.IdParent     > 0 && parentMap.TryGetValue(raw.IdParent, out var parent)) r.IdParent = parent;
                list.Add(r);
            }
            return list;
        }

        public static BabySitterRate SelectById(int id)
        {
            var db = new BabySitterRateDB();
            var rows = db.ReadRawRates("SELECT * FROM BabySitterRate WHERE id=?",
                new OleDbParameter("@id", id));
            return rows.Count > 0 ? HydrateRate(rows[0]) : null;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            var r = entity as BabySitterRate ?? new BabySitterRate();
            if (reader["stars"] != DBNull.Value)      r.Stars      = Convert.ToInt32(reader["stars"]);
            if (reader["dateOfRate"] != DBNull.Value)  r.DateOfRate = Convert.ToDateTime(reader["dateOfRate"]);
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
                "INSERT INTO BabySitterRate (stars, idBabySitter, idParent, DateOfRate, ReviewText, Tags) " +
                "VALUES (?,?,?,?,?,?)";

            cmd.Parameters.Add(new OleDbParameter("@stars", r.Stars));
            cmd.Parameters.Add(new OleDbParameter("@idBabySitter", DbVal(r.IdBabySitter?.Id)));
            cmd.Parameters.Add(new OleDbParameter("@idParent", DbVal(r.IdParent?.Id)));
            cmd.Parameters.Add(new OleDbParameter("@DateOfRate", r.DateOfRate));
            cmd.Parameters.Add(new OleDbParameter("@ReviewText", (object)r.ReviewText ?? DBNull.Value));
            cmd.Parameters.Add(new OleDbParameter("@Tags", (object)r.Tags ?? DBNull.Value));
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            if (entity is not BabySitterRate r) return;

            cmd.CommandText =
                "UPDATE BabySitterRate SET stars=@stars, idBabySitter=@idBabySitter, idParent=@idParent, DateOfRate=@DateOfRate, ReviewText=@ReviewText, Tags=@Tags " +
                "WHERE ID=@id";

            cmd.Parameters.Add(new OleDbParameter("@stars", r.Stars));
            cmd.Parameters.Add(new OleDbParameter("@idBabySitter", DbVal(r.IdBabySitter?.Id)));
            cmd.Parameters.Add(new OleDbParameter("@idParent", DbVal(r.IdParent?.Id)));
            cmd.Parameters.Add(new OleDbParameter("@DateOfRate", r.DateOfRate));
            cmd.Parameters.Add(new OleDbParameter("@ReviewText", (object)r.ReviewText ?? DBNull.Value));
            cmd.Parameters.Add(new OleDbParameter("@Tags", (object)r.Tags ?? DBNull.Value));
            cmd.Parameters.Add(new OleDbParameter("@id", r.Id));
        }
    }
}
