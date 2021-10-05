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
        private string _happiDevApiKey;
        private string _spotifyClientId;
        private string _spotifyClientSecret;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        ///     Configuration property
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        ///     This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // declare configuration variables
            // if env vars are not set take secrets file 
            _spotifyClientId = Configuration["SPOTIFY_CLIENT_ID"] ?? Configuration["Spotify:ClientId"];
            _spotifyClientSecret = Configuration["SPOTIFY_CLIENT_SECRET"] ?? Configuration["Spotify:ClientSecret"];
            _happiDevApiKey = Configuration["HAPPI_DEV_API_KEY"] ?? Configuration["HappiDev:ApiKey"];

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "RunToBeat.Api", Version = "v1"});
            });

            // Add spotify services
            services.AddScoped<ISpotifyAuthenticationService, SpotifyAuthenticationService>(_ =>
                new SpotifyAuthenticationService(_spotifyClientId,
                    _spotifyClientSecret));
            services.AddScoped<ISpotifyService, SpotifyService>();
            // Add happi.dev services
            services.AddScoped<IBpmService, HappiDevMusicService>(provider =>
                new HappiDevMusicService(
                    Configuration["HappiDevUrl"],
                    _happiDevApiKey,
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