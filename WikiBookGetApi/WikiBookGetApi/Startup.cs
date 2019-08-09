using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WikiBookGetApi.Core.Models;
using WikiBookGetApi.Core.Services;
using WikiBookGetApi.DataAccessLayer.Data;
using WikiBookGetApi.DataAccessLayer.Repositories;
using WikiBookGetApi.Services;
using Books = WikiBookGetApi.Core.Models.Books;
using BookTags = WikiBookGetApi.Core.Models.BookTags;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using Ratings = WikiBookGetApi.Core.Models.Ratings;
using Tags = WikiBookGetApi.Core.Models.Tags;
using ToRead = WikiBookGetApi.Core.Models.ToRead;

namespace WikiBookGetApi
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var config = GetMapperConfiguration();
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddDbContext<WikiBookDBContext>(option =>
                option.UseSqlServer(Configuration.GetConnectionString("bookDatabase")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        private static MapperConfiguration GetMapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Books,Models.Books>();
                cfg.CreateMap<BookTags, BookTags>();
                cfg.CreateMap<Ratings, Ratings>();
                cfg.CreateMap<ToRead, ToRead>();
                cfg.CreateMap<Tags, Tags>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, WikiBookDBContext context)
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
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
