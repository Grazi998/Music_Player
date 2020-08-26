using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Music_Player.DbModels;
using Music_Player.Repositories;
using Music_Player.Services;

namespace Music_Player
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private void SetupDbContext(IServiceCollection services)
        {
            var connString = Configuration.GetConnectionString("pma");

            services.AddDbContext<msc_plyContext>(options => options.UseSqlServer(connString));
        }

        public class SessionUserTimeout : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                if (context.HttpContext.Session == null || !context.HttpContext.Session.TryGetValue("SessionUser", out byte[] val))
                {
                    context.Result =
                        new RedirectToRouteResult(new RouteValueDictionary(new
                        {
                            controller = "Authentication",
                            action = "UserSignIn"
                        }));
                }
                base.OnActionExecuting(context);
            }
        }

        public class SessionAdminTimeout : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                if (context.HttpContext.Session == null || !context.HttpContext.Session.TryGetValue("SessionAdmin", out byte[] val))
                {
                    context.Result =
                        new RedirectToRouteResult(new RouteValueDictionary(new
                        {
                            controller = "Authentication",
                            action = "AdminSignin"
                        }));
                }
                base.OnActionExecuting(context);
            }
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddNewtonsoftJson();
            services.AddControllersWithViews();

            services.AddScoped<SongRepository>();
            services.AddScoped<SongService>();
            services.AddScoped<ArtistRepository>();
            services.AddScoped<ArtistService>();
            services.AddScoped<UserRepository>();
            services.AddScoped<UserService>();
            services.AddScoped<PlaylistRepository>();
            services.AddScoped<PlaylistService>();

            SetupDbContext(services);
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromSeconds(3600);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    "Artists",
                    "music/artists",
                    new { controller = "Admin", action = "Artists" }
                    );

                endpoints.MapControllerRoute(
                    "Songs",
                    "music/songs",
                    new { controller = "Admin", action = "Songs" }
                    );

                endpoints.MapControllerRoute(
                    "Users",
                    "music/users",
                    new { controller = "Admin", action = "Users" }
                    );

                endpoints.MapControllerRoute(
                    "newArtist",
                    "music/newArtist",
                    new { controller = "Admin", action = "newArtist" }
                    );

                endpoints.MapControllerRoute(
                    "editArtist",
                    "music/editArtist",
                    new { controller = "Admin", action = "editArtist" }
                    );

                endpoints.MapControllerRoute(
                    "newSong",
                    "music/newSong",
                    new { controller = "Admin", action = "newSong" }
                    );

                endpoints.MapControllerRoute(
                    "editSong",
                    "music/editSong",
                    new { controller = "Admin", action = "editSong" }
                    );

                endpoints.MapControllerRoute(
                    "AdminSignin",
                    "music/adminsignin",
                    new { controller = "Authentication", action = "AdminSignin" }
                    );

                endpoints.MapControllerRoute(
                    "AdminHome",
                    "music/adminhome",
                    new { controller = "Admin", action = "AdminHome" }
                    );

                endpoints.MapControllerRoute(
                    "UserSignIn",
                    "music/usersignin",
                    new { controller = "Authentication", action = "UserSignIn" }
                    );

                endpoints.MapControllerRoute(
                    "UserSignUp",
                    "music/usersignup",
                    new { controller = "Authentication", action = "UserSignUp" }
                    );

                endpoints.MapControllerRoute(
                    "AllSongs",
                    "music/allsongs",
                    new { controller = "User", action = "AllSongs" }
                    );
                endpoints.MapControllerRoute(
                    "Playlists",
                    "music/user/playlists",
                    new { controller = "User", action = "Playlists" }
                    );
            });
        }
    }
}
