using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TestApi.Models;
using TestApi.Services;
using WikiBookGetApi.Core.Models;
using WikiBookGetApi.Core.Services;
using WikiBookGetApi.DataAccessLayer.Models;
using WikiBookGetApi.DataAccessLayer.Repositories;

namespace TestApi
{
    public class Startup
    {
        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }
        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var config = GetMapperConfiguration();

            config.AssertConfigurationIsValid();

            IMapper mapper = config.CreateMapper();
            
            services.AddSingleton(mapper);

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserConnectionRepository, UserConnectionRepository>();
            services.AddScoped<IUserConnectionService, UserConnectionService>();
            services.AddDbContext<WikiBookDBContext>(option =>
                option.UseSqlServer(Configuration.GetConnectionString("bookDatabase")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        }

        private static MapperConfiguration GetMapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Book, BookModel>();
                cfg.CreateMap<Book, BookDTO>();
                cfg.CreateMap<LikedBookByUser, LikedBookByUserDTO>();
                
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseHttpsRedirection();

            app.UseMvc();

        }
    }
}
