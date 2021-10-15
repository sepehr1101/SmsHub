using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Http;


namespace SmsHub.SimpleTest
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddHttpClient<Rahyab.HttpService.HttpService>();
            services.AddHttpClient<Rahyab.HttpService.IHttpService, Rahyab.HttpService.HttpService>((client, sp) =>
                // any other constructor dependencies in GitHubService will be filled in
                // by ActivatorUtilities from the provided IServiceProvider
                ActivatorUtilities.CreateInstance<Rahyab.HttpService.HttpService>(sp, client, 
                new Rahyab.Dtos.Base.RahyabSetting())
            );
        }
    }
}
