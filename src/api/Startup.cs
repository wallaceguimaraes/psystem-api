// using api.Extensions;
// using api.Infrastructure.Authorization;
// using api.Infrastructure.Context;
// using api.Models.ServiceModels;
// using api.Models.Interface;
// using api.Extensions;

using api.Data.Context;
using api.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
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


            services.AddJwtAuthentication(options =>
    {
        Configuration.GetSection("Authorization").Bind(options);
    });

            // Configuração da autenticação JWT
            // var tokenKey = "12345"; // Defina sua chave secreta para geração/validação de tokens

            // services.AddAuthentication(options =>
            // {
            //     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            // })
            // .AddJwtBearer(options =>
            // {
            //     options.TokenValidationParameters = new TokenValidationParameters
            //     {
            //         ValidateIssuer = true,
            //         ValidateAudience = true,
            //         ValidateIssuerSigningKey = true,
            //         ValidIssuer = "seu_issuer_aqui",
            //         ValidAudience = "seu_audience_aqui",
            //         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey))
            //     };
            // });

            // Configuração da autorização
            // services.AddAuthorization();

            // string connectionString = Configuration["Database:ConnectionString"];

            // services.AddDbContext<ApiDbContext>(options =>
            // {
            //     options.UseMySQL(connectionString, mysqlOptions =>
            //     {
            //         mysqlOptions.MigrationsHistoryTable("__MigrationHistory", "cadastro");
            //     });
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
