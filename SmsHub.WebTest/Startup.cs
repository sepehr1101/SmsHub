using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SmsHub.WebTest
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
            var rahyabSettingConfig = Configuration.GetSection("RahyabSetting");
            services.AddOptions<Rahyab.Dtos.Base.RahyabSetting>()
                    .Bind(rahyabSettingConfig);
            var rahyabSetting= rahyabSettingConfig.Get<Rahyab.Dtos.Base.RahyabSetting>();
            services.AddSingleton(rahyabSetting);
            services.AddHttpClient<Rahyab.HttpService.IHttpService, Rahyab.HttpService.HttpService>(
                 (sp, client) => ActivatorUtilities.CreateInstance<Rahyab.HttpService.HttpService>(sp,client,
                 rahyabSetting)
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
