using DevExpress.EntityFrameworkCore.Security.MiddleTier.ClientServer;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ApplicationBuilder;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.Authentication.ClientServer;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.Persistent.BaseImpl.EFCore.AuditTrail;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace AlgoTrack.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // https://www.npgsql.org/doc/types/datetime.html#timestamps-and-timezones
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            services.AddXafMiddleTier(Configuration, builder =>
            {

                builder.Modules
                    .AddReports(options =>
                    {
                        options.ReportDataType = typeof(DevExpress.Persistent.BaseImpl.EF.ReportDataV2);
                    })
                    .Add<AlgoTrack.Module.AlgoTrackModule>();


                builder.ObjectSpaceProviders
                    .AddSecuredEFCore(options =>
                    {
                    })
                        .WithAuditedDbContext(contexts =>
                        {
                            contexts.Configure<AlgoTrack.Module.BusinessObjects.AlgoTrackEFCoreDbContext, AlgoTrack.Module.BusinessObjects.AlgoTrackAuditingDbContext>(
                                (serviceProvider, businessObjectDbContextOptions) =>
                                {
                                    // Uncomment this code to use an in-memory database. This database is recreated each time the server starts. With the in-memory database, you don't need to make a migration when the data model is changed.
                                    // Do not use this code in production environment to avoid data loss.
                                    // We recommend that you refer to the following help topic before you use an in-memory database: https://docs.microsoft.com/en-us/ef/core/testing/in-memory
                                    //businessObjectDbContextOptions.UseInMemoryDatabase();
                                    string connectionString = null;
                                    if (Configuration.GetConnectionString("ConnectionString") != null)
                                    {
                                        connectionString = Configuration.GetConnectionString("ConnectionString");
                                    }
#if EASYTEST
                                    if(Configuration.GetConnectionString("EasyTestConnectionString") != null) {
                                        connectionString = Configuration.GetConnectionString("EasyTestConnectionString");
                                    }
#endif
                                    ArgumentNullException.ThrowIfNull(connectionString);
                                    businessObjectDbContextOptions.UseConnectionString(connectionString);
                                },
                                (serviceProvider, auditHistoryDbContextOptions) =>
                                {
                                    string connectionString = null;
                                    if (Configuration.GetConnectionString("ConnectionString") != null)
                                    {
                                        connectionString = Configuration.GetConnectionString("ConnectionString");
                                    }
#if EASYTEST
                                    if(Configuration.GetConnectionString("EasyTestConnectionString") != null) {
                                        connectionString = Configuration.GetConnectionString("EasyTestConnectionString");
                                    }
#endif
                                    ArgumentNullException.ThrowIfNull(connectionString);
                                    auditHistoryDbContextOptions.UseConnectionString(connectionString);
                                });
                        })
                    .AddNonPersistent();

                builder.Security
                    .UseIntegratedMode(options =>
                    {
                        options.Lockout.Enabled = true;

                        options.RoleType = typeof(PermissionPolicyRole);
                        // ApplicationUser descends from PermissionPolicyUser and supports the OAuth authentication. For more information, refer to the following topic: https://docs.devexpress.com/eXpressAppFramework/402197
                        // If your application uses PermissionPolicyUser or a custom user type, set the UserType property as follows:
                        options.UserType = typeof(AlgoTrack.Module.BusinessObjects.ApplicationUser);
                        options.UserTokenType = typeof(UserToken);
                        // ApplicationUserLoginInfo is only necessary for applications that use the ApplicationUser user type.
                        // If you use PermissionPolicyUser or a custom user type, comment out the following line:
                        options.UserLoginInfoType = typeof(AlgoTrack.Module.BusinessObjects.ApplicationUserLoginInfo);
                        options.Events.OnSecurityStrategyCreated += securityStrategy =>
                        {
                            //((SecurityStrategy)securityStrategy).AnonymousAllowedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.EF.ModelDifference));
                            //((SecurityStrategy)securityStrategy).AnonymousAllowedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.EF.ModelDifferenceAspect));
                            ((SecurityStrategy)securityStrategy).PermissionsReloadMode = PermissionsReloadMode.CacheOnFirstAccess;
                        };
                    })
                    .AddPasswordAuthentication(options =>
                    {
                        options.IsSupportChangePassword = true;
                    });

                builder.AddBuildStep(application =>
                {
                    application.ApplicationName = "SetupApplication.AlgoTrack";
                    application.CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema;
                    //application.CreateCustomModelDifferenceStore += (s, e) => {
                    //    e.Store = new ModelDifferenceDbStore((XafApplication)sender!, typeof(ModelDifference), true, "Win");
                    //    e.Handled = true;
                    //};
#if !RELEASE
                    if (application.CheckCompatibilityType == CheckCompatibilityType.DatabaseSchema)
                    {
                        application.DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;
                        application.DatabaseVersionMismatch += (s, e) =>
                        {
                            e.Updater.Update();
                            e.Handled = true;
                        };
                    }
#endif
                });
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        //ValidIssuer = Configuration["Authentication:Jwt:Issuer"],
                        //ValidAudience = Configuration["Authentication:Jwt:Audience"],
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:Jwt:IssuerSigningKey"])),
                        AuthenticationType = JwtBearerDefaults.AuthenticationScheme
                    };
                });

            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(
                    JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .RequireXafAuthentication()
                    .Build();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime hostApplicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. To change this for production scenarios, see: https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
#if RELEASE
            app.UseHttpsRedirection();
#endif
            app.UseRequestLocalization();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseAntiforgery();
            app.UseXafMiddleTier();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
