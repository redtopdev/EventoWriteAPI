using Engaze.Core.Web;
using EventStore.ClientAPI;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evento.Service
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
            Dependency.Configure(services, Configuration);
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IEventStoreConnection conn)
        {
            app.UseRouting();

            //app.UseAuthorization();

            app.UseAppException();
            app.UseAppStatus();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            conn.ConnectAsync().Wait();
        }
    }
}
