// using api.Extensions;
// using api.Infrastructure.Authorization;
// using api.Infrastructure.Context;
// using api.Models.ServiceModels;
// using api.Models.Interface;
// using api.Extensions;

using api.Data.Context;
using api.Extensions.DependencyInjection;
using api.Filters;
using api.Infrastructure.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

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
            // services.Configure<KestrelServerOptions>(options =>
            //  {
            //      options.Limits.MaxRequestBodySize = 10 * 1024 * 1024; // Define o tamanho máximo do corpo da solicitação para 10 MB
            //  });

            // services.Configure<KestrelServerOptions>(options =>
            // {
            //     options.Limits.RequestHeadersTimeout = TimeSpan.FromSeconds(60); // Define um tempo limite de leitura de cabeçalhos de 60 segundos
            //     options.Limits.RequestHeadersTimeout = TimeSpan.FromSeconds(60); // Define um tempo limite de escrita de corpo de 60 segundos
            // });

            // services.AddResponseCompression();
            // services.AddHttpContextAccessor();


            services.AddControllersWithViews(options =>
                    {
                        options.Filters.Add(typeof(ErrorHandlerAttribute));
                        options.Filters.Add(typeof(ModelValidationAttribute));
                    })
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                        options.SerializerSettings.Converters.Add(new CustomEnumConverter());
                    })
                    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

            // services.AddControllers().AddJsonOptions(options =>
            //     {
            //         options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
            //     })
            //     .ConfigureApiBehaviorOptions(options =>
            //     {
            //         options.SuppressMapClientErrors = true;
            //     });


            // services.AddJwtAuthentication(options =>
            // {
            //     Configuration.GetSection("Authorization").Bind(options);
            // });



            string connectionString = Configuration["ConnectionStrings:ConnectionString"];
            ServerVersion serverVersion = ServerVersion.AutoDetect(connectionString);


            services.AddDbContext<ApiDbContext>(options =>
            {
                options.UseMySql(connectionString, serverVersion, mysqlOptions =>
                {
                    mysqlOptions.MigrationsHistoryTable("__MigrationHistory", "cadastro")
                                .SchemaBehavior(MySqlSchemaBehavior.Ignore);
                });
            });

            // optionsBuilder.UseMySql("connectionString",
            //       mysqlOptions => mysqlOptions
            //           .ServerVersion(new Version(8, 0, 26), ServerType.MySql)
            //           .SchemaBehavior(MySqlSchemaBehavior.Ignore));


            // services.AddDbContext<ApiDbContext>(options =>
            // {
            //     options.UseSqlServer(Configuration.GetConnectionString("ConnectionString"),
            //         sqlServerOptions => sqlServerOptions.MigrationsHistoryTable("__MigrationHistory", "cadastro"));
            // });


            services.AddTransientServices();
            // services.AddSingletonServices();
            // services.AddHttpClients();

        }

        // public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        // {

        //     app.Use(async (context, next) =>
        //       {
        //           context.Request.BodyReader.ReadTimeout = TimeSpan.FromSeconds(60); // Define um tempo limite de leitura de 60 segundos
        //           context.Request.BodyWriter.WriteTimeout = TimeSpan.FromSeconds(60); // Define um tempo limite de escrita de 60 segundos

        //           await next();
        //       });


        //     if (env.IsDevelopment())
        //     {
        //         app.UseDeveloperExceptionPage();
        //     }
        //     else
        //     {
        //         app.UseHttpsRedirection();
        //         app.UseHsts();
        //     }

        //     app.UseResponseCompression();
        //     app.UseRouting();

        //     app.UseCors(policy => policy
        //         .AllowAnyMethod()
        //         .AllowAnyHeader()
        //         .SetIsOriginAllowed(origin => true)
        //         .AllowCredentials());

        //     app.UseAuthorization();

        //     app.UseEndpoints(endpoints =>
        //     {
        //         endpoints.MapControllers();
        //     });
        // }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //     app.Use(async (context, next) =>
            //       {
            //           context.Request.BodyReader.ReadTimeout = TimeSpan.FromSeconds(60); // Define um tempo limite de leitura de 60 segundos
            //           context.Request.BodyWriter.WriteTimeout = TimeSpan.FromSeconds(60); // Define um tempo limite de escrita de 60 segundos

            //           await next();
            //       });


            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors(policy => policy
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());
            app.UseEndpoints(endpoints => endpoints.MapControllers());
            app.UseHttpsRedirection();
            app.UseAuthentication();
        }
    }
}
