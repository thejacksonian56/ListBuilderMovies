using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListBuilderMovies.Services;
using Microsoft.EntityFrameworkCore;
using ListBuilderMovies.Models;
using Microsoft.AspNetCore.Identity;

namespace ListBuilderMovies
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
            services.AddControllersWithViews();
            //services.AddSingleton<IMovieListData, MovieListData>();
            services.AddScoped<IMovieListData, DBMovieListData>();
            services.AddDbContext<MovieListContext>(options => options.UseSqlServer("Server=DESKTOP-OEDSC2T\\SQLEXPRESS;Database=MovieListDB;Trusted_Connection=true;MultipleActiveResultSets=true"));
            services.AddDbContext<UserContext>(options => options.UseSqlServer("Server=DESKTOP-OEDSC2T\\SQLEXPRESS;Database=MovieListUsersDB;Trusted_Connection=true;MultipleActiveResultSets=true"));
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredUniqueChars = 3;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 8;
            }).AddEntityFrameworkStores<UserContext>();
            services.AddHttpClient();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(UserContext userContext, MovieListContext movieListContext, IApplicationBuilder app, IWebHostEnvironment env)
        {
            userContext.Database.EnsureCreated();
            movieListContext.Database.EnsureCreated();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
