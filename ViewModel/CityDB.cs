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
        public override BaseEntity NewEntity() => new City();

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            City city = entity as City;
            city.Id = Convert.ToInt32(reader["id"]);
            city.CityName = reader["cityName"].ToString();
            return city;
        }

        public List<City> GetAllCities()
        {
            command.CommandText = "SELECT * FROM City";
            var list = new List<City>();
            foreach (var e in Select())
                list.Add(e as City);
            return list;
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
            City city = (City)entity;
            cmd.CommandText = "DELETE FROM City WHERE id=@id";
            cmd.Parameters.AddWithValue("@id", city.Id);
        }
    }
}
