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

namespace MyLibraryStore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // here we will add our dependancies to services of ConfigureServices method so that they will be added to IOC container of asp.net core and be used as needed.
           
            //Adding the dependancy of mvc design pattern
            services.AddMvc();

            //Now we will add the dependancy of AuthorRepository:
            //IBookstoreRepository is interface abstraction, AuthorRepository is a concrete class:
            services.AddSingleton<IBookstoreRepository<Author>, AuthorRepository>();

            //Now we will add the dependancy of BookRepository:
            services.AddSingleton<IBookstoreRepository<Book>, BookRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();           //DefaultRoute for mvc
            app.UseMvcWithDefaultRoute();
        }


    }
}
