// using api.Extensions;
// using api.Infrastructure.Authorization;
// using api.Infrastructure.Context;
// using api.Models.ServiceModels;
// using api.Models.Interface;
// using api.Extensions;

namespace api
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
            var connectionString = Configuration["Database:Mysql"];

            // services.AddTransient<CrawllerService>();

            // services.AddScoped<ICrawllerService, CrawllerService>();

            // services.AddDomainConfigurations(Configuration);


            services.AddResponseCompression();
            services.AddHttpContextAccessor();

            services.AddControllers().AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
                })
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressMapClientErrors = true;
                });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHttpsRedirection();
                app.UseHsts();
            }

            app.UseResponseCompression();
            app.UseRouting();

            app.UseCors(policy => policy
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
