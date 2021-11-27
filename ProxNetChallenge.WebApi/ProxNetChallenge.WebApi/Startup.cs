using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProxNet.ProjectSettings;
using ProxNetChallenge.Repository;
using ProxNetChallenge.Repository.Interfaces;
using ProxNetChallenge.Services;
using ProxNetChallenge.Services.Interfaces;
using ProxNetChallenge.WebApi.Middlewares;

namespace ProxNetChallenge.WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            var dbConnectionString = Configuration["DbConnectString"];
            services.AddDbContext<Context>(options => options.UseSqlServer(dbConnectionString));

            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<ILobbyService, LobbyService>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<ILobbyPlayerRepository, LobbyPlayerRepository>();


            services.Configure<Settings>(Configuration);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
