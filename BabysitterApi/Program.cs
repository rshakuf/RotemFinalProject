
using ViewModel;

namespace BabysitterApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Point ImageToBase64Converter at the runtime pictures folder.
            // Newly-uploaded photos are saved here; pre-loaded embedded pictures
            // are used as a fallback when a file isn't found on disk.
            string picturesDir = Path.Combine(AppContext.BaseDirectory, "mypictures");
            Directory.CreateDirectory(picturesDir);   // creates it if not yet present
            ImageToBase64Converter.PicturesFolder = picturesDir;

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
