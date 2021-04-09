using MyLibraryStore.Models;
using MyLibraryStore.Models.Repositors;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MyLibraryStore
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
              
            // here we will add our dependancies to services of ConfigureServices method so that they will be added to IOC container of asp.net core and be used as needed.
           
            //Adding the dependancy of mvc design pattern
            services.AddMvc();

            //Now we will add the dependancy of AuthorRepository:
            //IBookstoreRepository is interface abstraction, AuthorRepository is a concrete class:
            services.AddScoped<IBookstoreRepository<Author>, AuthorDbRepository>();

            //Now we will add the dependancy of BookRepository:
            services.AddScoped<IBookstoreRepository<Book>, BookDbRepository>();
            services.AddDbContext<myLibraryDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("sqlCon"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();           //DefaultRoute for mvc
            app.UseMvc(route => {
                route.MapRoute("default", "{controller=Book}/{action=Index}/{id?}");
            });
        }
    }

}
