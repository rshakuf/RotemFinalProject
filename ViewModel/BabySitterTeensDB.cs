using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace ViewModel
{
    public class BabySitterTeensDB : UserDB
    {
        public BabySitterTeensList SelectAll()
        {
            command.CommandText = "SELECT BabysitterTeens.Id, BabysitterTeens.Mail, BabysitterTeens.PriceForAnHour," +
                " BabysitterTeens.ProfilePicture, BabysitterTeens.telephone," +
                " BabysitterTeens.[password], [User].DateOfBirth, [User].firstName, [User].LastName, [User].CityNameId" +
                " FROM (BabysitterTeens INNER JOIN [User] ON BabysitterTeens.Id = [User].id)";
                
            BabySitterTeensList groupList = new BabySitterTeensList(base.Select());
            return groupList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            BabySitterTeens bst = entity as BabySitterTeens;
            bst.Mail          = reader["mail"].ToString();
            bst.PriceForAnHour = reader["priceForAnHour"] != DBNull.Value && !string.IsNullOrWhiteSpace(reader["priceForAnHour"].ToString())
                ? int.Parse(reader["priceForAnHour"].ToString()) : 0;
            bst.Telephone     = reader["Telephone"].ToString();
            bst.Password      = reader["Password"].ToString();

            string fileName = reader["profilePicture"]?.ToString() ?? "";
            if (!string.IsNullOrWhiteSpace(fileName))
                bst.ProfilePicture = ImageToBase64Converter.ImageFromResourceToBase64(fileName);
            else
                bst.ProfilePicture = null;

            base.CreateModel(entity);
            return bst;
        }

        public override BaseEntity NewEntity()
        {
            return new BabySitterTeens();
        }

        public static BabySitterTeens SelectById(int id)
        {
            // Query only the row we need — avoids a full-table scan per call
            var db = new BabySitterTeensDB();
            db.command.CommandText =
                "SELECT BabysitterTeens.Id, BabysitterTeens.Mail, BabysitterTeens.PriceForAnHour," +
                " BabysitterTeens.ProfilePicture, BabysitterTeens.telephone," +
                " BabysitterTeens.[password], [User].DateOfBirth, [User].firstName, [User].LastName, [User].CityNameId" +
                " FROM (BabysitterTeens INNER JOIN [User] ON BabysitterTeens.Id = [User].id)" +
                " WHERE BabysitterTeens.Id = ?";
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();
            db.command.Parameters.Clear();
            db.command.Parameters.Add(new OleDbParameter("@id", id));
            var results = new BabySitterTeensList(db.Select());
            return results.Count > 0 ? results[0] : null;
        }

       
        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            BabySitterTeens b = entity as BabySitterTeens;
            if (b != null)
            {
                string sqlStr = $"DELETE FROM BabySitterTeens WHERE ID=@pid";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@pid", b.Id));
            }
        }

        public virtual void Delete(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
                deleted.Add(new ChangeEntity(base.CreateUpdatedSQL, entity));
            }
        }


        public override void Insert(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity(); ;
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                inserted.Add(new ChangeEntity(base.CreateInsertdSQL, entity));
                inserted.Add(new ChangeEntity(this.CreateInsertdSQL, entity));
            }
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            BabySitterTeens b = entity as BabySitterTeens;
            if (b != null)
            {
                string sqlStr =
                    $"INSERT INTO BabySitterTeens (ID, mail, priceForAnHour, profilePicture, telephone, [password]) " +
                    $"VALUES (?, ?, ?, ?, ?, ?)";

                command.CommandText = sqlStr;
                command.Parameters.AddWithValue("@ID", b.Id);
                command.Parameters.AddWithValue("@mail", (object)b.Mail ?? DBNull.Value);
                command.Parameters.AddWithValue("@priceForAnHour", b.PriceForAnHour);
                command.Parameters.AddWithValue("@profilePicture", (object)b.ProfilePicture ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@telephone", (object)b.Telephone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@password", (object)b.Password ?? DBNull.Value);
            }
        }

        public override void Update(BaseEntity entity)
        {
            BaseEntity reqEntity = this.NewEntity();
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                updated.Add(new ChangeEntity(base.CreateUpdatedSQL, entity));  // [User] table: firstName, lastName, cityNameId
                updated.Add(new ChangeEntity(this.CreateUpdatedSQL, entity));  // BabySitterTeens table: mail, price, pic, telephone, password
            }
        }

        public int UpdateBabySitterProfile(BabySitterTeens b)
        {
            int recordsAffected = 0;
            OleDbTransaction trans = null;
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                trans = connection.BeginTransaction();
                command.Transaction = trans;

                // Update [User] table
                command.Parameters.Clear();
                command.CommandText = "UPDATE [User] SET firstName=@fn, LastName=@ln, DateOfBirth=@dob, CityNameId=@cni WHERE ID=@id";
                command.Parameters.Add(new OleDbParameter("@fn", b.FirstName ?? ""));
                command.Parameters.Add(new OleDbParameter("@ln", b.LastName ?? ""));
                command.Parameters.Add(new OleDbParameter("@dob", b.DateOfBirth));
                command.Parameters.Add(new OleDbParameter("@cni", b.CityNameId != null ? (object)b.CityNameId.Id : DBNull.Value));
                command.Parameters.Add(new OleDbParameter("@id", b.Id));
                recordsAffected += command.ExecuteNonQuery();

                // Update BabySitterTeens table (without profilePicture to avoid MEMO-in-transaction issues)
                command.Parameters.Clear();
                command.CommandText = "UPDATE BabySitterTeens SET mail=@mail, priceForAnHour=@price, telephone=@tel, [password]=@pwd WHERE id=@id";
                command.Parameters.Add(new OleDbParameter("@mail", b.Mail ?? ""));
                command.Parameters.Add(new OleDbParameter("@price", b.PriceForAnHour));
                command.Parameters.Add(new OleDbParameter("@tel", b.Telephone ?? ""));
                command.Parameters.Add(new OleDbParameter("@pwd", b.Password ?? ""));
                command.Parameters.Add(new OleDbParameter("@id", b.Id));
                recordsAffected += command.ExecuteNonQuery();

                trans.Commit();
                trans = null;

                // Update profilePicture separately (MEMO field; keep outside main transaction)
                if (!string.IsNullOrWhiteSpace(b.ProfilePicture) && b.ProfilePicture.Trim().Length > 10)
                {
                    command.Transaction = null;
                    command.Parameters.Clear();
                    command.CommandText = "UPDATE BabySitterTeens SET profilePicture=@pic WHERE id=@id";
                    command.Parameters.Add(new OleDbParameter("@pic", b.ProfilePicture));
                    command.Parameters.Add(new OleDbParameter("@id", b.Id));
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                try { trans?.Rollback(); } catch { }
                Console.WriteLine("!!! UpdateBabySitterProfile ERROR: " + ex.Message);
                return 0;
            }
            finally
            {
                command.Transaction = null;
                command.Parameters.Clear();
            }
            return recordsAffected;
        }

        public void ClearProfilePicture(int id)
        {
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();
            command.Parameters.Clear();
            command.CommandText = "UPDATE BabySitterTeens SET profilePicture=NULL WHERE id=@id";
            command.Parameters.Add(new OleDbParameter("@id", id));
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            BabySitterTeens b = entity as BabySitterTeens;
            if (b != null)
            {
                string sqlStr =
                    $"UPDATE BabySitterTeens " +
                    $"SET mail=@mail, priceForAnHour=@price, profilePicture=@pic, telephone=@telephone, [password]=@password " +
                    $"WHERE id=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@mail", b.Mail));
                command.Parameters.Add(new OleDbParameter("@price", b.PriceForAnHour));
                command.Parameters.Add(new OleDbParameter("@pic", b.ProfilePicture));
                command.Parameters.Add(new OleDbParameter("@telephone", b.Telephone));
                command.Parameters.Add(new OleDbParameter("@password", b.Password));
                command.Parameters.Add(new OleDbParameter("@id", b.Id));
            }
        }
    }
}
