using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebAspNetCoreTests.Models;
using WebAspNetCoreTests.Repositories;
using WebAspNetCoreTests.Services;

namespace WebAspNetCoreTests
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc();



            // Add framework services.
            services.AddScoped<ApplicationDbContext>(_ => new ApplicationDbContext("Data Source=cz-dev3002.develop.local;Initial Catalog=AspNetCoreTests;user ID=sa;password=cisco"));
            
            // Add application services.
            services.AddTransient<IPriceResolver, PriceResolver>();

            // repositories
            services.AddTransient<IBasicPriceRepository, BasicPriceRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerPriceRepository, CustomerPriceRepository>();
            services.AddTransient<ICustomerProductGroupDiscountRepository, CustomerProductGroupDiscountRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();

            // UI services
            services.AddTransient<ICustomerSelectOptions, CustomerSelectOptions>();
            services.AddTransient<IProductSelectOptions, ProductSelectOptions>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
