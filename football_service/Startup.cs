using FootballService.Models;
using FootballService.Interfaces;
using FootballService.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;
using RazorPartialToString.Services;

namespace FootballService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"), ServerVersion.Parse("5.5.62-mysql")));

            services.AddControllersWithViews();

            services.AddRazorPages().AddMvcOptions(options =>
            {
                options.MaxModelValidationErrors = 50;
                options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
                    _ => "Обязательное поле");
            });

            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
            services.AddTransient<IRazorPartialToStringRenderer, RazorPartialToStringRenderer>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<ITeamService, TeamService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
                app.UseHsts();

            app.UseExceptionHandler(new ExceptionHandlerOptions()
            {
                AllowStatusCode404Response = true,
                ExceptionHandlingPath = "/error"
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=MainPage}/{action=AddPlayer}/{id?}");
            });
        }
    }
}
