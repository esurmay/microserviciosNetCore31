using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lil.Search.Interfaces;
using Lil.Search.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Lil.Search
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
            services.AddControllers();

            services.AddSingleton<ICustomersService, CustomersService>();
            services.AddSingleton<IProductsService, ProductsService>();
            services.AddSingleton<ISalesService, SalesServices>();

            //indicates the webServices' EndPoint. Also could be url, like: http://localhost:Port
            services.AddHttpClient("customersService", c => {
                c.BaseAddress = new Uri(Configuration["Services:Customers"]);
                //c.BaseAddress = new Uri("http://localhost:65100");
            });

            services.AddHttpClient("productsService", c => {
                c.BaseAddress = new Uri(Configuration["Services:Products"]);
            });

            services.AddHttpClient("salesService", c => {
                c.BaseAddress = new Uri(Configuration["Services:Sales"]);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
