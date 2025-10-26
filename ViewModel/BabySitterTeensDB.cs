using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ViewModel
{
    public class BabySitterTeensDB : BaseDB
    {
        public BabySitterTeensList SelectAll()
        {
            command.CommandText = $"SELECT * FROM BabySitterTeensTbl";
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
                string sqlStr = $"DELETE FROM BabySitterTeensTbl WHERE id=@pid";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@pid", b.Id));
            }
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            BabySitterTeens b = entity as BabySitterTeens;
            if (b != null)
            {
                string sqlStr =
                    $"INSERT INTO BabySitterTeensTbl (mailOfRecommender, priceForAnHour, profilePicture) " +
                    $"VALUES (@mail, @price, @pic)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@mail", b.MailOfRecommender));
                command.Parameters.Add(new OleDbParameter("@price", b.PriceForAnHour));
                command.Parameters.Add(new OleDbParameter("@pic", b.ProfilePicture));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            BabySitterTeens b = entity as BabySitterTeens;
            if (b != null)
            {
                string sqlStr =
                    $"UPDATE BabySitterTeensTbl " +
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
