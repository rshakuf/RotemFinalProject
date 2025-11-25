using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ViewModel
{

    public class CityDB : BaseDB
    {
        public CityList SelectAll()
        {
            command.CommandText = $"SELECT * FROM city";
            CityList groupList = new CityList(base.Select());
            return groupList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            City ct = entity as City;
            ct.CityName = reader["CityName"].ToString();
            base.CreateModel(entity);
            return ct;
        }
        public override BaseEntity NewEntity()
        {
            return new City();
        }
        static private CityList list = new CityList();

        public static City SelectById(int id)
        {
            CityDB db = new CityDB();
            list = db.SelectAll();

            City g = list.Find(item => item.Id == id);
            return g;
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
            City city = (City)entity;
            cmd.CommandText = "INSERT INTO City (cityName) VALUES (@cityName)";
            cmd.Parameters.AddWithValue("@cityName", DbVal(city.CityName));
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            City city = (City)entity;
            cmd.CommandText = "UPDATE City SET cityName=@cityName WHERE id=@id";
            cmd.Parameters.AddWithValue("@cityName", DbVal(city.CityName));
            cmd.Parameters.AddWithValue("@id", city.Id);
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            City p = entity as City;
            if (p != null)
            {
                string sqlStr = "DELETE FROM City where ID=@pid";

                command.CommandText = sqlStr;

                command.Parameters.Add(new OleDbParameter("@pid", p.Id));

            }
        }

        //protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        //{
        //    City city = (City)entity;
        //    cmd.CommandText = "DELETE FROM City WHERE id=@id";
        //    cmd.Parameters.AddWithValue("@id", city.Id);
        //}

    }
}
