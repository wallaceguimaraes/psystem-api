using api.Authorization;
using api.Models.ServiceModel;
using api.Models.ServiceModel.Companies;
using api.Models.ServiceModel.Employees;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace api.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        // private static IOptions<RabbitMQOptions> _rabbitOptions;

        // public static void AddAuthorizationPolicies(this IServiceCollection services)
        // {
        //     services.AddAuthorization(options =>
        //     {
        //         options.AddPolicy("Employee", policy =>
        //         {
        //             policy.RequireClaim(ClaimTypes.Actor, "Employee");
        //             policy.RequireClaim(ApiClaimTypes.ApplicationId);
        //             policy.RequireClaim(ApiClaimTypes.UserId);
        //             policy.RequireClaim(ApiClaimTypes.LinkCode);
        //             policy.RequireClaim(ApiClaimTypes.Salt);
        //         });

        //         options.AddPolicy("User", policy =>
        //         {
        //             policy.RequireClaim(ClaimTypes.Actor, "User");
        //             policy.RequireClaim(ApiClaimTypes.ApplicationId);
        //             policy.RequireClaim(ApiClaimTypes.HolderId);
        //             policy.RequireClaim(ApiClaimTypes.UserId);
        //             policy.RequireClaim(ApiClaimTypes.LinkCode);
        //             policy.RequireClaim(ApiClaimTypes.Salt);
        //         });

        //         options.AddPolicy("Temporary", policy =>
        //         {
        //             policy.RequireClaim(ClaimTypes.Actor, "User");
        //             policy.RequireClaim(ApiClaimTypes.ApplicationId);
        //             policy.RequireClaim(ApiClaimTypes.UserId);
        //             policy.RequireClaim(ApiClaimTypes.Salt);
        //         });
        //     });
        // }

        public static void AddJwtAuthentication(this IServiceCollection services, Action<AuthOptions> configure)
        {
            services.Configure<AuthOptions>(configure);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var authOptions = new AuthOptions();
                var token = new ApiToken(authOptions);

                configure(authOptions);

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authOptions.Issuer,
                    ValidAudience = authOptions.Audience,
                    IssuerSigningKey = token.SecurityKey,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    RequireExpirationTime = false,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        // public static void AddRateLimitConfiguration(this IServiceCollection services, IConfiguration configuration)
        // {
        //     services.Configure<IpRateLimitOptions>(configuration.GetSection("RateLimiting:GlobalRules"));
        //     services.Configure<IpRateLimitPolicies>(configuration.GetSection("RateLimiting:IpPolicies"));

        //     services.AddInMemoryRateLimiting();

        //     services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

        //     services.AddSingleton<IIpPolicyStore, DistributedCacheIpPolicyStore>();
        //     services.AddSingleton<IRateLimitCounterStore, DistributedCacheRateLimitCounterStore>();
        // }

        // public static void AddServiceBus(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        // {
        //     if (hostEnvironment.EnvironmentName != "Testing")
        //     {
        //         services.Configure<RabbitMQOptions>(configuration.GetSection("RabbitMQ"));

        //         services.AddMassTransit(x =>
        //         {
        //             x.AddConsumer<PaymentAccountBlockConsumer>();

        //             x.UsingRabbitMq((context, config) =>
        //             {
        //                 _rabbitOptions = context.GetRequiredService<IOptions<RabbitMQOptions>>();
        //                 config.Host(new Uri(_rabbitOptions.Value.Uri));

        //                 config.ReceiveEndpoint(_rabbitOptions.Value.BlockAccountQueue, e =>
        //                 {
        //                     e.ConfigureConsumer<PaymentAccountBlockConsumer>(context);
        //                 });
        //             });
        //         });

        //         services.AddMassTransitHostedService();
        //     }
        // }

        public static void AddTransientServices(this IServiceCollection services)
        {
            // services.AddTransient<IAmazonS3Api, AmazonS3Api>();
            // services.AddTransient<ILogoAmazonS3Api, LogoAmazonS3Api>();
            // services.AddTransient<ILogoPartnerAmazonS3Api, LogoPartnerAmazonS3Api>();
            // services.AddTransient<INotificationsApi, NotificationsProducer>();
            // services.AddTransient<IHolderService, HolderService>();
            // services.AddTransient<WebhooksManagement>();
            // services.AddTransient<InstitutionAccountManagement>();
            // services.AddTransient<HolderRegistration>();
            // services.AddTransient<AntifraudAnalysis>();
            // services.AddTransient<SellerRegistration>();
            // services.AddTransient<AccountConfirmation>();
            // services.AddTransient<PartnerRegistration>();
            services.AddTransient<UserAuthentication>();
            services.AddTransient<EmployeeService>();
            services.AddTransient<CompanyService>();


            // services.AddTransient<PresetManagement>();
            // services.AddTransient<AnticipationManagement>();
            // services.AddTransient<AdiqManagement>();
            // services.AddTransient<DeactiveHolderManagement>();
            // services.AddTransient<CryptographyHolderManagement>();
            // services.AddTransient<FeaturesService>();
            // services.AddTransient<IWebhooksProducer, WebhooksProducer>();
            // services.AddTransient<IKN1Client, KN1Client>();
            // services.AddTransient<ISellerAnalysis, SellerAnalysis>();
            // services.AddTransient<AccountBlockManagement>();
            // services.AddTransient<IDocumentAnalysisService, DocumentAnalysisService>();
            // services.AddTransient<EmployeeRegistration>();
            // services.AddTransient<IAccountIntegration, VindiManagement>();
            // services.AddTransient<SimpleCommunicationService>();
        }

        // public static void AddSingletonServices(this IServiceCollection services)
        // {
        //     services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        // }

        // public static void AddHttpClients(this IServiceCollection services)
        // {
        //     services.AddHttpClient();
        //     services.AddHttpClient<IPaymentsApi, PaymentsApi>();
        //     services.AddHttpClient<IWarningsApi, WarningsApi>();
        //     services.AddHttpClient<ITransfeeraApi, TransfeeraApi>();
        //     services.AddHttpClient<IPaymentAccountApi, PaymentAccountApi>();
        //     services.AddHttpClient<IAdiqApi, AdiqApi>();
        //     services.AddHttpClient<IZoopApi, ZoopApi>();
        //     services.AddHttpClient<IAntifraudApi, AntifraudApi>();
        //     services.AddHttpClient<IViacepApi, ViacepApi>();
        //     services.AddHttpClient<IIdWallApi, IdWallApi>();
        //     services.AddHttpClient<IVindiApi, VindiApi>();
        // }

        public static void ConfigureOptions(this IServiceCollection services, IConfiguration config)
        {
            services.AddOptions();

            // services.Configure<AmazonS3ApiOptions>(config.GetSection("Integration:AmazonS3"));
            // services.Configure<LogoAmazonS3ApiOptions>(config.GetSection("Integration:LogoAmazonS3"));
            // services.Configure<LogoPartnerAmazonS3ApiOptions>(config.GetSection("Integration:LogoPartnerAmazonS3"));
            // services.Configure<PaymentsApiOptions>(config.GetSection("Integration:Payments"));
            // services.Configure<NotificationsApiOptions>(config.GetSection("Integration:Notifications"));
            // services.Configure<WarningOptions>(config.GetSection("Integration:Warnings"));
            // services.Configure<TransfeeraApiOptions>(config.GetSection("Integration:Transfeera"));
            // services.Configure<PaymentAccountApiOptions>(config.GetSection("Integration:PaymentAccount"));
            // services.Configure<TransferDaysOptions>(config.GetSection("TransferDays"));
            // services.Configure<ZoopApiOptions>(config.GetSection("Integration:Zoop"));
            // services.Configure<AntifraudApiOptions>(config.GetSection("Integration:Antifraud"));
            // services.Configure<AdiqApiOptions>(config.GetSection("Integration:Adiq"));
            // services.Configure<KN1Options>(config.GetSection("Integration:KN1"));
            // services.Configure<DocumentAnalysisOptions>(config.GetSection("Antifraud:DocumentAnalysis"));
            // services.Configure<IdWallOptions>(config.GetSection("Integration:IdWall"));
            // services.Configure<ViacepOptions>(config.GetSection("Integration:Viacep"));
            // services.Configure<UserAuthenticationOptions>(config.GetSection("UserAuthentication"));
            // services.Configure<SellerRegistrationOptions>(config.GetSection("SellerRegistration"));
            // services.Configure<VindiApiOptions>(config.GetSection("Integration:VindiApi"));
            // services.Configure<EmailListOptions>(config.GetSection("EmailList"));
        }
    }
}