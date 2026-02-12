using ApiInterface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Model;
using ClApi;
using System;
using System.Linq;
using System.Threading.Tasks;

class Program
{

    //static async Task Main(string[] args)
    //{
    //    var host = Host.CreateDefaultBuilder(args)
    //        .ConfigureServices((context, services) =>
    //        {
    //            services.AddHttpClient();
    //            services.AddScoped<ApiService>(sp =>
    //            {
    //                var client = sp.GetRequiredService<HttpClient>();
    //                var baseUri = "https://z9vchnvr-5266.euw.devtunnels.ms"; 
    //                return new ApiService(client, baseUri);
    //            });
    //        })
    //     .Build();

    // Get the service and use it
    //using (var scope = host.Services.CreateScope())
    //{
    //  var babysitterService = scope.ServiceProvider.GetRequiredService<ApiService>();
    //  var allCities = await babysitterService.GetAllCitiesAsync();
    //  int x = allCities.Count;
    //  // כאן תכתוב את התוכנית שלך 
    static async Task Main(string[] args)
    {
        //var host = Host.CreateDefaultBuilder(args)
        //    .ConfigureServices((context, services) =>
        //    {
        //        services.AddHttpClient();
        //        services.AddScoped<ApiService>(sp =>
        //        {
        //            var client = sp.GetRequiredService<HttpClient>();
        //            var baseUri = "https://z9vchnvr-5266.euw.devtunnels.ms";
        //            return new ApiService(client, baseUri);
        //        });
        //    })
        //    .Build();

        //using (var scope = host.Services.CreateScope())
        //{
        //    var api = scope.ServiceProvider.GetRequiredService<ApiService>();

        ////    using (var scope = host.Services.CreateScope())
        ////{
        ////    var buyerService = scope.ServiceProvider.GetRequiredService<ApiService>();
        ////    var buyers = await buyerService.GetBuyers();
        ////    int x = buyers.Count;
        //    
        


        ApiService api = new ApiService();

            // ===== Cities =====
            var cities = await api.GetAllCitiesAsync();
            Console.WriteLine($"Cities count: {cities.Count}");

            await api.InsertCityAsync(new City { CityName = "בדיקה עיר" });
            var city = cities.First();
            city.CityName = "עיר מעודכנת";
            await api.UpdateCityAsync(city);
            await api.DeleteCityAsync(cities.Last().Id);

            // ===== BabySitterRate =====
            var rates = await api.GetAllBabySitterRatesAsync();
            Console.WriteLine($"Rates count: {rates.Count}");

            await api.InsertBabySitterRateAsync(new BabySitterRate { Stars = 50 });
            var rate = rates.First();
            rate.Stars = 60;
            await api.UpdateBabySitterRateAsync(rate);
            await api.DeleteBabySitterRateAsync(rates.Last().Id);

            // ===== BabySitterTeens =====
            var teens = await api.GetAllBabySitterTeensAsync();
            Console.WriteLine($"Teens count: {teens.Count}");

            await api.InsertBabySitterTeenAsync(new BabySitterTeens { FirstName = "נער בדיקה" });
            var teen = teens.First();
            teen.FirstName = "נער מעודכן";
            await api.UpdateBabySitterTeenAsync(teen);
            await api.DeleteBabySitterTeenAsync(teens.Last().Id);

            // ===== Parents =====
            var parents = await api.GetAllParentsAsync();
            Console.WriteLine($"Parents count: {parents.Count}");

            await api.InsertParentAsync(new Parents { FirstName = "הורה בדיקה" });
            var parent = parents.First();
            parent.FirstName = "הורה מעודכן";
            await api.UpdateParentAsync(parent);
            await api.DeleteParentAsync(parents.Last().Id);

            // ===== Users =====
            var users = await api.GetAllUsersAsync();
            Console.WriteLine($"Users count: {users.Count}");

            await api.InsertUserAsync(new User { FirstName = "user_test" });
            var user = users.First();
            user.FirstName = "user_updated";
            await api.UpdateUserAsync(user);
            await api.DeleteUserAsync(users.Last().Id);

            // ===== UserProfile =====
            var profiles = await api.GetAllUserProfilesAsync();
            Console.WriteLine($"Profiles count: {profiles.Count}");

            await api.InsertUserProfileAsync(new UserProfile { Email = "בדיקה" });
            var profile = profiles.First();
            profile.Email = "עודכן";
            await api.UpdateUserProfileAsync(profile);
            await api.DeleteUserProfileAsync(profiles.Last().Id);

            // ===== Messages =====
            var messages = await api.GetAllMessagesAsync();
            Console.WriteLine($"Messages count: {messages.Count}");

            await api.InsertMessageAsync(new Messages { MessageText = "שלום" });
            var message = messages.First();
            message.MessageText = "עודכן";
            await api.UpdateMessageAsync(message);
            await api.DeleteMessageAsync(messages.Last().Id);

            // ===== Requests =====
            var requests = await api.GetAllRequestsAsync();
            Console.WriteLine($"Requests count: {requests.Count}");

            await api.InsertRequestAsync(new Requests { Status = "בקשה" });
            var request = requests.First();
            request.Status = "בקשה מעודכנת";
            await api.UpdateRequestAsync(request);
            await api.DeleteRequestAsync(requests.Last().Id);

            // ===== Reviews =====
            var reviews = await api.GetAllReviewsAsync();
            Console.WriteLine($"Reviews count: {reviews.Count}");

            await api.InsertReviewAsync(new Reviews { Rating = 5 });
            var review = reviews.First();
            review.Rating = 5;
            await api.UpdateReviewAsync(review);
            await api.DeleteReviewAsync(reviews.Last().Id);

            // ===== Schedule =====
            var schedules = await api.GetAllSchedulesAsync();
            Console.WriteLine($"Schedules count: {schedules.Count}");

            await api.InsertScheduleAsync(new Schedule { DayOfWeek = "Sunday" });
            var schedule = schedules.First();
            schedule.DayOfWeek = "Monday";
            await api.UpdateScheduleAsync(schedule);
            await api.DeleteScheduleAsync(schedules.Last().Id);

            // ===== JobHistory =====
            var jobs = await api.GetAllJobHistoriesAsync();
            Console.WriteLine($"Jobs count: {jobs.Count}");

            await api.InsertJobHistoryAsync(new JobHistory { TotalPayment = 10000 });
            var job = jobs.First();
            job.TotalPayment = 10000;
            await api.UpdateJobHistoryAsync(job);
            await api.DeleteJobHistoryAsync(jobs.Last().Id);

            // ===== ChildOfParent =====
            var children = await api.GetAllChildrenOfParentsAsync();
            Console.WriteLine($"Children count: {children.Count}");

            await api.InsertChildOfParentAsync(new ChildOfParent { FirstName = "נחום" });
            var child = children.First();
            child.FirstName = "מעודכן";
            await api.UpdateChildOfParentAsync(child);
            await api.DeleteChildOfParentAsync(children.Last().Id);

            Console.WriteLine("✔ All API tests finished");
        }

    }

//}
