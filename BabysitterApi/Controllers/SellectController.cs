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
        [HttpGet("CitySelector")]
        public ActionResult<List<City>> CitySelector()
        {
            CityDB db = new CityDB();
            var cities = db.SelectAll();
            return Ok(cities);
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

        [HttpGet]
        public BabySitterRateList SelectAllBabySitterRate()
        {
            BabySitterRateDB db = new BabySitterRateDB();
            BabySitterRateList BabySitterRate = db.SelectAll();
            return BabySitterRate;
        }
        [HttpPost]
        public int InsertABabySitterRate([FromBody] BabySitterRate BabySitterRate)
        {
            BabySitterRateDB db = new BabySitterRateDB();
            db.Insert(BabySitterRate);
            int x = db.SaveChanges();
            return x;
        }
        [HttpDelete("{id}")]
        public int DeleteABabySitterRate(int id)
        {
            BabySitterRate BabySitterRate = BabySitterRateDB.SelectById(id);
            BabySitterRateDB db = new BabySitterRateDB();
            db.Delete(BabySitterRate);
            int x = db.SaveChanges();
            return x;
        }
        [HttpPut]
        public void UpdateABabySitterRate([FromBody] BabySitterRate BabySitterRate)
        {
            BabySitterRateDB db = new BabySitterRateDB();
            db.Update(BabySitterRate);
            int x = db.SaveChanges();
        }

        [HttpPut]
        public IActionResult UpsertBabySitterRate([FromBody] BabySitterRate rate)
        {
            if (rate?.IdBabySitter == null || rate?.IdParent == null)
                return BadRequest("IdBabySitter and IdParent are required");

            BabySitterRateDB db = new BabySitterRateDB();
            var all      = db.SelectAll();
            var existing = all.FirstOrDefault(r =>
                r.IdBabySitter?.Id == rate.IdBabySitter.Id &&
                r.IdParent?.Id     == rate.IdParent.Id);

            if (existing != null)
            {
                existing.Stars      = rate.Stars;
                existing.DateOfRate = rate.DateOfRate;
                db.Update(existing);
            }
            else
            {
                db.Insert(rate);
            }

            db.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public BabySitterTeensList SelectAllBabySitterTeens()
        {
            BabySitterTeensDB db = new BabySitterTeensDB();
            BabySitterTeensList BabySitterTeens = db.SelectAll();
            return BabySitterTeens;
        }
        [HttpPost]
        public int InsertABabySitterTeens([FromBody] BabySitterTeens BabySitterTeens)
        {
            BabySitterTeensDB db = new BabySitterTeensDB();
            db.Insert(BabySitterTeens);
            int x = db.SaveChanges();
            return x;
        }
        [HttpDelete("{id}")]
        public int DeleteABabySitterTeens(int id)
        {
            BabySitterTeens BabySitterTeens = BabySitterTeensDB.SelectById(id);
            BabySitterTeensDB db = new BabySitterTeensDB();
            db.Delete(BabySitterTeens);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPut]
        public int UpdateABabySitterTeens([FromBody] BabySitterTeens BabySitterTeens)
        {
            BabySitterTeensDB db = new BabySitterTeensDB();
            return db.UpdateBabySitterProfile(BabySitterTeens);
        }
        [HttpGet]
        public ChildOfParentList SelectAllChildOfParent()
        {
            ChildOfParentDB db = new ChildOfParentDB();
            ChildOfParentList ChildOfParent = db.SelectAll();
            return ChildOfParent;
        }
        [HttpPost]
        public int InsertAChildOfParent([FromBody] ChildOfParent ChildOfParent)
        {
            ChildOfParentDB db = new ChildOfParentDB();
            db.Insert(ChildOfParent);
            int x = db.SaveChanges();
            return x;
        }
        [HttpDelete("{id}")]
        public int DeleteAChildOfParent(int id)
        {
            ChildOfParent ChildOfParent = ChildOfParentDB.SelectById(id);
            ChildOfParentDB db = new ChildOfParentDB();
            db.Delete(ChildOfParent);
            int x = db.SaveChanges();
            return x;
        }
        [HttpPut]
        public void UpdateAChildOfParent([FromBody] ChildOfParent ChildOfParent)
        {
            ChildOfParentDB db = new ChildOfParentDB();
            db.Update(ChildOfParent);
            int x = db.SaveChanges();
        }
        [HttpGet]

        public JobHistoryList SelectAllJobHistory()
        {
            JobHistoryDB db = new JobHistoryDB();
            JobHistoryList JobHistory = db.SelectAll();
            return JobHistory;
        }
        [HttpPost]
        public int InsertAJobHistory([FromBody] JobHistory JobHistory)
        {
            JobHistoryDB db = new JobHistoryDB();
            db.Insert(JobHistory);
            int x = db.SaveChanges();
            return x;
        }
        [HttpDelete("{id}")]
        public int DeleteAJobHistory(int id)
        {
            JobHistory JobHistory = JobHistoryDB.SelectById(id);
            JobHistoryDB db = new JobHistoryDB();
            db.Delete(JobHistory);
            int x = db.SaveChanges();
            return x;
        }
        [HttpPut]
        public void UpdateAJobHistory([FromBody] JobHistory JobHistory)
        {
            JobHistoryDB db = new JobHistoryDB();
            db.Update(JobHistory);
            int x = db.SaveChanges();
        }


        [HttpGet]
        public MessagesList SelectAllMessages()
        {
            MessagesDB db = new MessagesDB();
            MessagesList Messages = db.SelectAll();
            return Messages;
        }
        [HttpPost]
        public int InsertAMessages([FromBody] Messages Messages)
        {
            MessagesDB db = new MessagesDB();
            db.Insert(Messages);
            int x = db.SaveChanges();
            return x;
        }
        [HttpDelete("{id}")]
        public int DeleteAMessages(int id)
        {
            Messages Messages = MessagesDB.SelectById(id);
            MessagesDB db = new MessagesDB();
            db.Delete(Messages);
            int x = db.SaveChanges();
            return x;
        }
        [HttpPut]
        public void UpdateAMessages([FromBody] Messages Messages)
        {
            MessagesDB db = new MessagesDB();
            db.Update(Messages);
            int x = db.SaveChanges();
        }

        [HttpGet]
        public ParentsList SelectAllParents()
        {
            ParentsDB db = new ParentsDB();
            ParentsList Parents = db.SelectAll();
            return Parents;
        }
        [HttpPost]
        public int InsertAParents([FromBody] Parents Parents)
        {
            ParentsDB db = new ParentsDB();
            db.Insert(Parents);
            int x = db.SaveChanges();
            return x;
        }
        [HttpDelete("{id}")]
        public int DeleteAParents(int id)
        {
            Parents Parents = ParentsDB.SelectById(id);
            ParentsDB db = new ParentsDB();
            db.Delete(Parents);
            int x = db.SaveChanges();
            return x;
        }
        [HttpPut]
        public void UpdateAParents([FromBody] Parents Parents)
        {
            ParentsDB db = new ParentsDB();
            db.Update(Parents);
            int x = db.SaveChanges();
        }


        [HttpGet]
        public RequestsList SelectAllRequests()
        {
            RequestsDB db = new RequestsDB();
            RequestsList Requests = db.SelectAll();
            return Requests;
        }
        [HttpPost]
        public int InsertARequests([FromBody] Requests Requests)
        {
            RequestsDB db = new RequestsDB();
            db.Insert(Requests);
            int x = db.SaveChanges();
            return x;
        }
        [HttpDelete("{id}")]
        public int DeleteARequests(int id)
        {
            Requests Requests = RequestsDB.SelectById(id);
            RequestsDB db = new RequestsDB();
            db.Delete(Requests);
            int x = db.SaveChanges();
            return x;
        }
        [HttpPut]
        public void UpdateARequests([FromBody] Requests Requests)
        {
            RequestsDB db = new RequestsDB();
            db.Update(Requests);
            int x = db.SaveChanges();
        }

        [HttpPut("{id}/status")]
        public IActionResult UpdateRequestStatus(int id, [FromBody] string status)
        {
            Requests existing = RequestsDB.SelectById(id);
            if (existing == null) return NotFound();
            existing.Status = status;
            RequestsDB db = new RequestsDB();
            db.Update(existing);
            db.SaveChanges();
            return Ok();
        }


        [HttpGet]
        public ScheduleList SelectAllSchedule()
        {
            ScheduleDB db = new ScheduleDB();
            ScheduleList Schedule = db.SelectAll();
            return Schedule;
        }
        [HttpPost]
        public IActionResult InsertASchedule([FromBody] Schedule Schedule)
        {
            ScheduleDB db = new ScheduleDB();
            db.Insert(Schedule);
            int x = db.SaveChanges();
            return x > 0 ? Ok(x) : StatusCode(500, "Insert failed");
        }
        [HttpDelete("{id}")]
        public int DeleteASchedule(int id)
        {
            Schedule Schedule = ScheduleDB.SelectById(id);
            ScheduleDB db = new ScheduleDB();
            db.Delete(Schedule);
            int x = db.SaveChanges();
            return x;
        }
        [HttpPut]
        public void UpdateASchedule([FromBody] Schedule Schedule)
        {
            ScheduleDB db = new ScheduleDB();
            db.Update(Schedule);
            int x = db.SaveChanges();
        }
        [HttpGet("{id}")]
        public List<Schedule> GetByBabysitter(int id)
        {
            ScheduleDB db = new ScheduleDB();

            var schedules = db.SelectAll()
                              .Where(x => x.BabysitterId != null &&
                                          x.BabysitterId.Id == id)
                              .ToList();

            return schedules;
        }

        [HttpGet]
        public UserList SelectAllUser()
        {
            UserDB db = new UserDB();
            UserList User = db.SelectAll();
            return User;
        }
        [HttpPost]
        public int InsertAUser([FromBody] User User)
        {
            UserDB db = new UserDB();
            db.Insert(User);
            int x = db.SaveChanges();
            return x;
        }
        [HttpDelete("{id}")]
        public int DeleteAUser(int id)
        {
            User User = UserDB.SelectById(id);
            UserDB db = new UserDB();
            db.Delete(User);
            int x = db.SaveChanges();
            return x;
        }
        [HttpPut]
        public void UpdateAUser([FromBody] User User)
        {
            UserDB db = new UserDB();
            db.Update(User);
            int x = db.SaveChanges();
        }


    }
}
