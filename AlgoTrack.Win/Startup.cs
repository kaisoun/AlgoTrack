using Azure.AI.OpenAI;
using DevExpress.AIIntegration;
using DevExpress.EntityFrameworkCore.Security;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ApplicationBuilder;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.ClientServer;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Win.ApplicationBuilder;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.XtraEditors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.AI;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace AlgoTrack.Win
{
    public class ApplicationBuilder : IDesignTimeApplicationFactory
    {
        public static WinApplication BuildApplication()
        {
            // https://www.npgsql.org/doc/types/datetime.html#timestamps-and-timezones
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            var builder = WinApplication.CreateBuilder();
            // Register custom services for Dependency Injection. For more information, refer to the following topic: https://docs.devexpress.com/eXpressAppFramework/404430/
            // builder.Services.AddScoped<CustomService>();
            // Register 3rd-party IoC containers (like Autofac, Dryloc, etc.)
            // builder.UseServiceProviderFactory(new DryIocServiceProviderFactory());
            // builder.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            #region AI Chat Client
            AIExtensionsContainerDesktop.Default.UnregisterChatClient();
            AIExtensionsContainerDesktop.Default.RegisterChatClient(_ =>
            {
                string azureOpenAIEndpoint = null;
                string azureOpenAIKey = null;
                string azureOpenAIDeployment = null;
                if (string.IsNullOrEmpty(azureOpenAIEndpoint) || string.IsNullOrEmpty(azureOpenAIKey))
                {
                    var message = "Credentials for AI Client were not found." +
                        " Specify azureOpenAIEndpoint, Key and Deployment at Startup.cs" +
                        "\nSee more: https://docs.devexpress.com/WindowsForms/405151/ai-powered-extensions#prerequisites";
                    throw new InvalidOperationException(message);
                }
                return new AzureOpenAIClient(new(azureOpenAIEndpoint), new System.ClientModel.ApiKeyCredential(azureOpenAIKey))
                        .GetChatClient(azureOpenAIDeployment).AsIChatClient();
            });
            #endregion

            builder.UseApplication<AlgoTrackWindowsFormsApplication>();
            builder.Modules
                .AddAI()
                .AddAuditTrailEFCore()
                .AddCharts()
                .AddCloning()
                .AddConditionalAppearance()
                .AddDashboards(options =>
                {
                    options.DashboardDataType = typeof(DevExpress.Persistent.BaseImpl.EF.DashboardData);
                    options.DesignerFormStyle = DevExpress.XtraBars.Ribbon.RibbonFormStyle.Ribbon;
                })
                .AddFileAttachments()
                .AddNotifications()
                .AddOffice()
                .AddPivotGrid()
                .AddReports(options =>
                {
                    options.EnableInplaceReports = true;
                    options.ReportDataType = typeof(DevExpress.Persistent.BaseImpl.EF.ReportDataV2);
                    options.ReportStoreMode = DevExpress.ExpressApp.ReportsV2.ReportStoreModes.XML;
                })
                .AddScheduler()
                .AddStateMachine(options =>
                {
                    options.StateMachineStorageType = typeof(DevExpress.Persistent.BaseImpl.EF.StateMachine.StateMachine);
                })
                .AddTreeListEditors()
                .AddValidation(options =>
                {
                    options.AllowValidationDetailsAccess = false;
                })
                .AddViewVariants()
                .Add<AlgoTrack.Module.AlgoTrackModule>()
                .Add<AlgoTrackWinModule>();
            builder.ObjectSpaceProviders
                .AddEFCore(options =>
                {
                    options.PreFetchReferenceProperties();
                })
                    .WithDbContext<AlgoTrack.Module.BusinessObjects.AlgoTrackEFCoreDbContext>((application, options) =>
                    {
                        options.UseMiddleTier(application.Security);
                        options.UseChangeTrackingProxies();
                        options.UseObjectSpaceLinkProxies();
                    })
                .AddNonPersistent();
            builder.Security
                .UseMiddleTierMode(options =>
                {
#if !RELEASE
                    options.WaitForMiddleTierServerReady();
                    options.BaseAddress = new Uri("http://localhost:5002/");
#else
                    options.BaseAddress = new Uri("https://localhost:44350/");
#endif
                })
                .AddPasswordAuthentication();
            builder.AddBuildStep(application =>
            {
                application.DatabaseUpdateMode = DatabaseUpdateMode.Never;
            });
            var winApplication = builder.Build();
            return winApplication;
        }

        XafApplication IDesignTimeApplicationFactory.Create()
        {
            DevExpress.EntityFrameworkCore.Security.MiddleTier.ClientServer.MiddleTierClientSecurity.DesignModeUserType = typeof(AlgoTrack.Module.BusinessObjects.ApplicationUser);
            DevExpress.EntityFrameworkCore.Security.MiddleTier.ClientServer.MiddleTierClientSecurity.DesignModeRoleType = typeof(DevExpress.Persistent.BaseImpl.EF.PermissionPolicy.PermissionPolicyRole);
            return BuildApplication();
        }
    }
}
