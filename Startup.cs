using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineStore.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("OnlineStoreProducts")));
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "null",
                    pattern: "{Category}/Page{productPage:int}",
                    defaults: new { Controller = "Product", action = "List" }
                    );
                endpoints.MapControllerRoute(
                   name: "null",
                   pattern: "Page{productPage:int}",
                   defaults: new { Controller = "Product", action = "List", productPage = 1 }
                   );
                endpoints.MapControllerRoute(
                   name: "null",
                   pattern: "{Category}",
                   defaults: new { Controller = "Product", action = "List", productPage = 1 }
                   );

                endpoints.MapControllerRoute(
                    name: "null",
                    pattern: "",
                    defaults : new {Controller="Product",  action="List", productPage = 1 }
                    );
                endpoints.MapControllerRoute(
                    name: "null",
                    pattern: "{controller}/{action}/{id?}"
                    );
            });

            SeedData.EnsurePopulated(app);
        }
    }
}
