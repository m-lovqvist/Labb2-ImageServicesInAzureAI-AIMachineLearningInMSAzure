using Labb2_ImageServicesInAzureAI_AIMachineLearningInMSAzure;

namespace Labb2_ImageServicesInAzureAI_AIMachineLearningInMSAzure
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Loading settings from appsettings.json
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            // Adding Azure Computer Vision services
            builder.Services.AddSingleton<ComputerVisionService>();

            // Adding MVC services
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Image}/{action=Upload}/{id?}");

            app.Run();
        }
    }
}

