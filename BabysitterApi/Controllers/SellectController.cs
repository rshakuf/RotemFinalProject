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



        //[HttpGet]
        //[ActionName("CitySelector")]
        //public CityList SelectAllCity()
        //{
        //    CityDB db = new CityDB();
        //    CityList City = db.SelectAll();
        //    return City;
        //}
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
        public void UpdateABabySitterTeens([FromBody] BabySitterTeens BabySitterTeens)
        {
            BabySitterTeensDB db = new BabySitterTeensDB();
            db.Update(BabySitterTeens);
            int x = db.SaveChanges();
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


        [HttpGet]
        public ReviewsList SelectAllReviews()
        {
            ReviewsDB db = new ReviewsDB();
            ReviewsList Reviews = db.SelectAll();
            return Reviews;
        }
        [HttpPost]
        public int InsertAReviews([FromBody] Reviews Reviews)
        {
            ReviewsDB db = new ReviewsDB();
            db.Insert(Reviews);
            int x = db.SaveChanges();
            return x;
        }
        [HttpDelete("{id}")]
        public int DeleteAReviews(int id)
        {
            Reviews Reviews = ReviewsDB.SelectById(id);
            ReviewsDB db = new ReviewsDB();
            db.Delete(Reviews);
            int x = db.SaveChanges();
            return x;
        }
        [HttpPut]
        public void UpdateAReviews([FromBody] Reviews Reviews)
        {
            ReviewsDB db = new ReviewsDB();
            db.Update(Reviews);
            int x = db.SaveChanges();
        }


        [HttpGet]
        public ScheduleList SelectAllSchedule()
        {
            ScheduleDB db = new ScheduleDB();
            ScheduleList Schedule = db.SelectAll();
            return Schedule;
        }
        [HttpPost]
        public int InsertASchedule([FromBody] Schedule Schedule)
        {
            ScheduleDB db = new ScheduleDB();
            db.Insert(Schedule);
            int x = db.SaveChanges();
            return x;
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


        [HttpGet]
        public UserProfileList SelectAllUserProfile()
        {
            UserProfileDB db = new UserProfileDB();
            UserProfileList UserProfile = db.SelectAll();
            return UserProfile;
        }
        [HttpPost]
        public int InsertAUserProfile([FromBody] UserProfile UserProfile)
        {
            UserProfileDB db = new UserProfileDB();
            db.Insert(UserProfile);
            int x = db.SaveChanges();
            return x;
        }
        [HttpDelete("{id}")]
        public int DeleteAUserProfile(int id)
        {
            UserProfile UserProfile = UserProfileDB.SelectById(id);
            UserProfileDB db = new UserProfileDB();
            db.Delete(UserProfile);
            int x = db.SaveChanges();
            return x;
        }
        [HttpPut]
        public void UpdateAUserProfile([FromBody] UserProfile UserProfile)
        {
            UserProfileDB db = new UserProfileDB();
            db.Update(UserProfile);
            int x = db.SaveChanges();
        }
    }
}
