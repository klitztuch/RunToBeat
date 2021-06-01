using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RunToBeat.Api.Services;

namespace RunToBeat.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "RunToBeat.Api", Version = "v1"});
            });

            // Add spotify services
            services.AddScoped<ISpotifyAuthenticationService, SpotifyAuthenticationService>(_ =>
                new SpotifyAuthenticationService(Configuration["Spotify:ClientId"],
                    Configuration["Spotify:ClientSecret"]));
            services.AddScoped<ISpotifyService, SpotifyService>();
            // Add happi.dev services
            services.AddScoped<IHappiDevMusicService, HappiDevMusicService>(provider =>
                new HappiDevMusicService(
                    Configuration["HappiDev:ApiKey"],
                    Configuration["HappiDevUrl"],
                    provider.GetService<ILogger<HappiDevMusicService>>()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RunToBeat.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}