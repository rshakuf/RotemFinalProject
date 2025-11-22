using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ViewModel
{
    public class BabySitterTeensDB : UserDB
    {
        public BabySitterTeensList SelectAll()
        {
            command.CommandText = $"SELECT [User].DateOfBirth, [User].firstName, [User].LastName, [User].CityName, [User].CityNameId, BabysitterTeens.MailOfRecommender, BabysitterTeens.PriceForAnHour, BabysitterTeens.ProfilePicture, BabysitterTeens.Id FROM (BabysitterTeens INNER JOIN [User] ON BabysitterTeens.Id = [User].id)";
            BabySitterTeensList groupList = new BabySitterTeensList(base.Select());
            return groupList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            BabySitterTeens bst = entity as BabySitterTeens;
            bst.MailOfRecommender = reader["mailOfRecommender"].ToString();
            bst.PriceForAnHour = int.Parse(reader["priceForAnHour"].ToString());
            bst.ProfilePicture = reader["profilePicture"].ToString();

            base.CreateModel(entity);
            return bst;
        }

        public override BaseEntity NewEntity()
        {
            return new BabySitterTeens();
        }

        static private BabySitterTeensList list = new BabySitterTeensList();

        public static BabySitterTeens SelectById(int id)
        {
            BabySitterTeensDB db = new BabySitterTeensDB();
            list = db.SelectAll();

            BabySitterTeens g = list.Find(item => item.Id == id);
            return g;
        }


        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            BabySitterTeens b = entity as BabySitterTeens;
            if (b != null)
            {
                string sqlStr = $"DELETE FROM BabySitterTeens WHERE id=@pid";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@pid", b.Id));
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
                    $"INSERT INTO BabySitterTeens (ID, mailOfRecommender, priceForAnHour, profilePicture) " +
                    $"VALUES (?, ?, ?, ?)";

                command.CommandText = sqlStr;
                command.Parameters.AddWithValue("@ID", b.Id);
                command.Parameters.AddWithValue("@mailOfRecommender", b.MailOfRecommender);
                command.Parameters.AddWithValue("@priceForAnHour", b.PriceForAnHour);
                command.Parameters.AddWithValue("@profilePicture", b.ProfilePicture);
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            BabySitterTeens b = entity as BabySitterTeens;
            if (b != null)
            {
                string sqlStr =
                    $"UPDATE BabySitterTeens " +
                    $"SET mailOfRecommender=@mail, priceForAnHour=@price, profilePicture=@pic " +
                    $"WHERE id=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@mail", b.MailOfRecommender));
                command.Parameters.Add(new OleDbParameter("@price", b.PriceForAnHour));
                command.Parameters.Add(new OleDbParameter("@pic", b.ProfilePicture));
                command.Parameters.Add(new OleDbParameter("@id", b.Id));
            }
        }
    }
}
