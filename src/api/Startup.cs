// using api.Extensions;
// using api.Infrastructure.Authorization;
// using api.Infrastructure.Context;
// using api.Models.ServiceModels;
// using api.Models.Interface;
// using api.Extensions;

using api.Extensions.DependencyInjection;

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
            services.AddAuthorization();

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
