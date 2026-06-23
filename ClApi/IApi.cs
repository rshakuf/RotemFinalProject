using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using BabysitterApi;

namespace ClApi
{
    public interface IApi
    {
        // ===== Cities =====
        Task<CityList> GetAllCitiesAsync();
        Task<int> InsertCityAsync(City city);
        Task<int> UpdateCityAsync(City city);
        Task<int> DeleteCityAsync(int id);

        // ===== BabySitterRate =====
        Task<BabySitterRateList> GetAllBabySitterRatesAsync();
        Task<int> InsertBabySitterRateAsync(BabySitterRate rate);
        Task<int> UpdateBabySitterRateAsync(BabySitterRate rate);
        Task<int> UpsertBabySitterRateAsync(BabySitterRate rate);
        Task<int> DeleteBabySitterRateAsync(int id);

        // ===== BabySitterTeens =====
        Task<BabySitterTeensList> GetAllBabySitterTeensAsync();
        Task<int> InsertBabySitterTeenAsync(BabySitterTeens teen);
        Task<int> UpdateBabySitterTeenAsync(BabySitterTeens teen);
        Task<int> DeleteBabySitterTeenAsync(int id);

        // ===== Parents =====
        Task<ParentsList> GetAllParentsAsync();
        Task<int> InsertParentAsync(Parents parent);
        Task<int> UpdateParentAsync(Parents parent);
        Task<int> DeleteParentAsync(int id);

        // ===== Users =====
        Task<UserList> GetAllUsersAsync();
        Task<int> InsertUserAsync(User user);
        Task<int> UpdateUserAsync(User user);
        Task<int> DeleteUserAsync(int id);

        // ===== Messages =====
        Task<MessagesList> GetAllMessagesAsync();
        Task<int> InsertMessageAsync(Messages message);
        Task<int> UpdateMessageAsync(Messages message);
        Task<int> DeleteMessageAsync(int id);

        // ===== Requests =====
        Task<RequestsList> GetAllRequestsAsync();
        Task<int> InsertRequestAsync(Requests request);
        Task<int> UpdateRequestAsync(Requests request);
        Task<int> DeleteRequestAsync(int id);

        // ===== Schedule =====
        Task<ScheduleList> GetAllSchedulesAsync();
        Task<int> InsertScheduleAsync(Schedule schedule);
        Task<int> UpdateScheduleAsync(Schedule schedule);
        Task<int> DeleteScheduleAsync(int id);

        // ===== JobHistory =====
        Task<JobHistoryList> GetAllJobHistoriesAsync();
        Task<int> InsertJobHistoryAsync(JobHistory job);
        Task<int> UpdateJobHistoryAsync(JobHistory job);
        Task<int> DeleteJobHistoryAsync(int id);

        // ===== ChildOfParent =====
        Task<ChildOfParentList> GetAllChildrenOfParentsAsync();
        Task<int> InsertChildOfParentAsync(ChildOfParent child);
        Task<int> UpdateChildOfParentAsync(ChildOfParent child);
        Task<int> DeleteChildOfParentAsync(int id);

        // ===== Profile picture =====
        /// <summary>
        /// Uploads a Base64-encoded photo to the server. Returns the saved filename
        /// (e.g. "user_5_637812345.jpg") to be stored in the DB as ProfilePicture.
        /// </summary>
        Task<string> UploadProfilePictureAsync(int babysitterId, string imageBase64);
    }
}
