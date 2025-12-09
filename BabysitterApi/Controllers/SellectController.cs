using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Reflection;
using ViewModel;

namespace BabysitterApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SellectController : ControllerBase
    {
        [HttpGet]
        [ActionName("CitySelector")]
        public CityList SelectAllCity()
        {
            CityDB db = new CityDB();
            CityList genders = db.SelectAll();
            return genders;
        }
        [HttpPost]
        public int InsertACity([FromBody] City City)
        {
            CityDB db = new CityDB();
            db.Insert(City);
            int x = db.SaveChanges();
            return x;
        }
        [HttpDelete("{id}")]
        public int DeleteACity(int id)
        {
            City City = CityDB.SelectById(id);
            CityDB db = new CityDB();
            db.Delete(City);
            int x = db.SaveChanges();
            return x;
        }
        [HttpPut]
        public void UpdateACity([FromBody] City City)
        {
            CityDB db = new CityDB();
            db.Update(City);
            int x = db.SaveChanges();
        }

    }
}
