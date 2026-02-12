
using ClApi;

namespace TestApi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            ApiService api = new ApiService();
            var cities = api.GetAllCitiesAsync().Result;

        }
    }
}
