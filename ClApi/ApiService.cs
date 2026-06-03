using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Model;
using BabysitterApi;
using System.Text.Json;

namespace ClApi
{
    public class ApiService : IApi
    {
        private readonly string uri;
        private readonly HttpClient client;

        public ApiService()
        {
            uri = "http://localhost:5266";
            //uri = "https://phb804d4-5266.euw.devtunnels.ms";
            //uri = "https://dzq4hh1r-5266.uks1.devtunnels.ms";
            client = new HttpClient();
        }

        public ApiService(HttpClient client, string baseUri)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
            this.uri    = baseUri ?? throw new ArgumentNullException(nameof(baseUri));
        }




        // City
        public Task<CityList> GetAllCitiesAsync() =>
            client.GetFromJsonAsync<CityList>(
                $"{uri}/api/Sellect/CitySelector/CitySelector");
     

        public async Task<int> InsertCityAsync(City city) =>
            (await client.PostAsJsonAsync($"{uri}/api/Sellect/InsertACity", city)).IsSuccessStatusCode ? 1 : 0;

        public async Task<int> UpdateCityAsync(City city) =>
            (await client.PutAsJsonAsync($"{uri}/api/Sellect/UpdateACity", city)).IsSuccessStatusCode ? 1 : 0;

        public async Task<int> DeleteCityAsync(int id) =>
            (await client.DeleteAsync($"{uri}/api/Sellect/DeleteACity/{id}")).IsSuccessStatusCode ? 1 : 0;

        // BabySitterRate
        public Task<BabySitterRateList> GetAllBabySitterRatesAsync() =>
            client.GetFromJsonAsync<BabySitterRateList>($"{uri}/api/Sellect/SelectAllBabySitterRate");

        public async Task<int> InsertBabySitterRateAsync(BabySitterRate rate) =>
            (await client.PostAsJsonAsync($"{uri}/api/Sellect/InsertABabySitterRate", rate)).IsSuccessStatusCode ? 1 : 0;

        public async Task<int> UpdateBabySitterRateAsync(BabySitterRate rate) =>
            (await client.PutAsJsonAsync($"{uri}/api/Sellect/UpdateABabySitterRate", rate)).IsSuccessStatusCode ? 1 : 0;

        /// <summary>Insert-or-update by babysitter+parent pair — no BabySitterRate.Id required.</summary>
        public async Task<int> UpsertBabySitterRateAsync(BabySitterRate rate) =>
            (await client.PutAsJsonAsync($"{uri}/api/Sellect/UpsertBabySitterRate", rate)).IsSuccessStatusCode ? 1 : 0;

        public async Task<int> DeleteBabySitterRateAsync(int id) =>
            (await client.DeleteAsync($"{uri}/api/Sellect/DeleteABabySitterRate/{id}")).IsSuccessStatusCode ? 1 : 0;

        // BabySitterTeens 
        public Task<BabySitterTeensList> GetAllBabySitterTeensAsync() =>
            client.GetFromJsonAsync<BabySitterTeensList>($"{uri}/api/Sellect/SelectAllBabySitterTeens");

        public async Task<int> InsertBabySitterTeenAsync(BabySitterTeens teen) =>
            (await client.PostAsJsonAsync($"{uri}/api/Sellect/InsertABabySitterTeens", teen)).IsSuccessStatusCode ? 1 : 0;

        public async Task<int> UpdateBabySitterTeenAsync(BabySitterTeens teen)
        {
            var response = await client.PutAsJsonAsync($"{uri}/api/Sellect/UpdateABabySitterTeens", teen);
            if (!response.IsSuccessStatusCode) return 0;
            var body = await response.Content.ReadAsStringAsync();
            return int.TryParse(body, out var n) ? n : 1;
        }

        public async Task<int> DeleteBabySitterTeenAsync(int id) =>
            (await client.DeleteAsync($"{uri}/api/Sellect/DeleteABabySitterTeens/{id}")).IsSuccessStatusCode ? 1 : 0;

        // ChildOfParent 
        public Task<ChildOfParentList> GetAllChildrenOfParentsAsync() =>
            client.GetFromJsonAsync<ChildOfParentList>(
                $"{uri}/api/Sellect/SelectAllChildOfParent");

        public async Task<int> InsertChildOfParentAsync(ChildOfParent child) =>
            (await client.PostAsJsonAsync(
                $"{uri}/api/Sellect/InsertAChildOfParent", child)).IsSuccessStatusCode ? 1 : 0;

        public async Task<int> UpdateChildOfParentAsync(ChildOfParent child) =>
            (await client.PutAsJsonAsync(
                $"{uri}/api/Sellect/UpdateAChildOfParent", child)).IsSuccessStatusCode ? 1 : 0;

        public async Task<int> DeleteChildOfParentAsync(int id) =>
            (await client.DeleteAsync(
                $"{uri}/api/Sellect/DeleteAChildOfParent/{id}")).IsSuccessStatusCode ? 1 : 0;

        // JobHistory 
        public Task<JobHistoryList> GetAllJobHistoryAsync() =>
            client.GetFromJsonAsync<JobHistoryList>($"{uri}/api/Sellect/SelectAllJobHistory");

        public async Task<int> InsertJobHistoryAsync(JobHistory job) =>
            (await client.PostAsJsonAsync($"{uri}/api/Sellect/InsertAJobHistory", job)).IsSuccessStatusCode ? 1 : 0;

        public async Task<int> UpdateJobHistoryAsync(JobHistory job) =>
            (await client.PutAsJsonAsync($"{uri}/api/Sellect/UpdateAJobHistory", job)).IsSuccessStatusCode ? 1 : 0;

        public async Task<int> DeleteJobHistoryAsync(int id) =>
            (await client.DeleteAsync($"{uri}/api/Sellect/DeleteAJobHistory/{id}")).IsSuccessStatusCode ? 1 : 0;

        // Messages 
        public Task<MessagesList> GetAllMessagesAsync() =>
            client.GetFromJsonAsync<MessagesList>($"{uri}/api/Sellect/SelectAllMessages");

        public async Task<int> InsertMessageAsync(Messages msg) =>
            (await client.PostAsJsonAsync($"{uri}/api/Sellect/InsertAMessages", msg)).IsSuccessStatusCode ? 1 : 0;

        public async Task<int> UpdateMessageAsync(Messages msg) =>
            (await client.PutAsJsonAsync($"{uri}/api/Sellect/UpdateAMessages", msg)).IsSuccessStatusCode ? 1 : 0;

        public async Task<int> DeleteMessageAsync(int id) =>
            (await client.DeleteAsync($"{uri}/api/Sellect/DeleteAMessages/{id}")).IsSuccessStatusCode ? 1 : 0;

        // Requests 
        public Task<RequestsList> GetAllRequestsAsync() =>
            client.GetFromJsonAsync<RequestsList>($"{uri}/api/Sellect/SelectAllRequests");

        public async Task<int> InsertRequestAsync(Requests r) =>
            (await client.PostAsJsonAsync($"{uri}/api/Sellect/InsertARequests", r)).IsSuccessStatusCode ? 1 : 0;

        public async Task<int> UpdateRequestAsync(Requests r) =>
            (await client.PutAsJsonAsync($"{uri}/api/Sellect/UpdateARequests", r)).IsSuccessStatusCode ? 1 : 0;

        public async Task<int> DeleteRequestAsync(int id) =>
            (await client.DeleteAsync($"{uri}/api/Sellect/DeleteARequests/{id}")).IsSuccessStatusCode ? 1 : 0;

        // Schedule
        public Task<ScheduleList> GetAllSchedulesAsync() =>
            client.GetFromJsonAsync<ScheduleList>($"{uri}/api/Sellect/SelectAllSchedule");

        public async Task<int> InsertScheduleAsync(Schedule s)
        {
            var response = await client.PostAsJsonAsync($"{uri}/api/Sellect/InsertASchedule", s);
            if (!response.IsSuccessStatusCode)
            {
                string body = await response.Content.ReadAsStringAsync();
                throw new Exception($"HTTP {(int)response.StatusCode}: {body}");
            }
            return 1;
        }

        public async Task<int> UpdateScheduleAsync(Schedule s) =>
            (await client.PutAsJsonAsync($"{uri}/api/Sellect/UpdateASchedule", s)).IsSuccessStatusCode ? 1 : 0;

        public async Task<int> DeleteScheduleAsync(int id) =>
            (await client.DeleteAsync($"{uri}/api/Sellect/DeleteASchedule/{id}")).IsSuccessStatusCode ? 1 : 0;

        public async Task<List<Schedule>> GetSchedulesByBabysitterIdAsync(int babysitterId)
        {
            HttpResponseMessage response =
                await client.GetAsync($"{uri}/api/Sellect/GetByBabysitter/{babysitterId}");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<List<Schedule>>(json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }

            return new List<Schedule>();
        }

        // Parents
        public Task<ParentsList> GetAllParentsAsync()=>
           client.GetFromJsonAsync<ParentsList>($"{uri}/api/Sellect/SelectAllParents");
        // https://phb804d4-5266.euw.devtunnels.ms/api/Sellect/SelectAllParents
        //https://phb804d4-5266.euw.devtunnels.ms/api/Sellect/SelectAllParents
        public async Task<int> InsertParentAsync(Parents parent) =>
            (await client.PostAsJsonAsync($"{uri}/api/Sellect/InsertAParents", parent)).IsSuccessStatusCode ? 1 : 0;

        public async Task<int> UpdateParentAsync(Parents parent) =>
            (await client.PutAsJsonAsync($"{uri}/api/Sellect/UpdateAParents", parent)).IsSuccessStatusCode ? 1 : 0;

        public async Task<int> DeleteParentAsync(int id) =>
            (await client.DeleteAsync($"{uri}/api/Sellect/DeleteAParents/{id}")).IsSuccessStatusCode ? 1 : 0;

        // Users 
        public Task<UserList> GetAllUsersAsync() =>
            client.GetFromJsonAsync<UserList>($"{uri}/api/Sellect/SelectAllUser");

        public async Task<int> InsertUserAsync(User user) =>
            (await client.PostAsJsonAsync($"{uri}/api/Sellect/InsertAUser", user)).IsSuccessStatusCode ? 1 : 0;

        public async Task<int> UpdateUserAsync(User user) =>
            (await client.PutAsJsonAsync($"{uri}/api/Sellect/UpdateAUser", user)).IsSuccessStatusCode ? 1 : 0;

        public async Task<int> DeleteUserAsync(int id) =>
            (await client.DeleteAsync($"{uri}/api/Sellect/DeleteAUser/{id}")).IsSuccessStatusCode ? 1 : 0;

        public Task<JobHistoryList> GetAllJobHistoriesAsync()
        {
            throw new NotImplementedException();
        }

        // Profile picture upload
        public async Task<string> UploadProfilePictureAsync(int babysitterId, string imageBase64)
        {
            var payload = new { BabysitterId = babysitterId, ImageBase64 = imageBase64 };
            var response = await client.PostAsJsonAsync(
                $"{uri}/api/Sellect/UploadProfilePicture", payload);

            if (!response.IsSuccessStatusCode)
            {
                string err = await response.Content.ReadAsStringAsync();
                throw new Exception($"Upload failed ({(int)response.StatusCode}): {err}");
            }

            // Server returns the filename as a plain JSON string, e.g. "user_5_637812345.jpg"
            string fileName = await response.Content.ReadAsStringAsync();
            // Strip surrounding quotes that JSON adds around a bare string
            return fileName.Trim('"');
        }

        //public Task<JobHistoryList> GetAllJobHistoriesAsync()
        //{
        //    throw new NotImplementedException();
        //http://localhost:5266/api/Sellect/SelectAllJobHistory
        //}
    }

}
