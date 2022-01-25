using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NHibernate;
using StoreContext.Domain.Repositories;
using StoreContext.Infra.Database;
using StoreContext.Infra.Database.Repositories;

namespace StoreContext.Api
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
            services.AddControllers();
            
            string con = Configuration["CONNECTIONSTRING_DATABASE"];
            var sesFact = SessionFactory.Create(con);

            services.AddSingleton<ISessionFactory>(sesFact);
            services.AddScoped<ISession>(s => sesFact.OpenSession());

            services.AddTransient<IStoreRepository, StoreRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
