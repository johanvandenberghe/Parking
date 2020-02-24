using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RouteManager.Interfaces;
using RouteManager.Services;

namespace RouteManager
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
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<IRouteViewModelService, RouteViewModelService>();
            services.AddScoped<IParkingViewModelService, ParkingViewModelService>();
            services.AddScoped<ICarViewModelService, CarViewModelService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IParkingService, ParkingService>();
            services.AddScoped<IRouteService, RouteService>();
            //services.Configure<CatalogSettings>(Configuration);
            services.AddDbContext<ParkingDbContext>(c => c.UseInMemoryDatabase("InterParkingDB"));
            //services.AddDbContext<ParkingDbContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:InterParkingDB"], b => b.MigrationsAssembly("WebApplication.Back")));
            services.AddControllersWithViews();
        }

        //private void ConfigureInMemoryDatabases(IServiceCollection services)
        //{
        //    // use in-memory database
        //    services.AddDbContext<ParkingDbContext>(c => c.UseInMemoryDatabase("Catalog"));

        //    // Add Identity DbContext
        //    //services.AddDbContext<AppIdentityDbContext>(options => options.UseInMemoryDatabase("Identity"));

        //    ConfigureServices(services);
        //}

        //public void ConfigureProductionServices(IServiceCollection services)
        //{
        //    services.AddDbContext<ParkingDbContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:InterParkingDB"]));

        //    // Add Identity DbContext
        //    //services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));

        //    ConfigureServices(services);
        //}

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
