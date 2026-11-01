using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.ExpressApp.StateMachine;
using DevExpress.ExpressApp.Updating;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.Persistent.BaseImpl.EF.StateMachine;
using System.ComponentModel;
using AlgoTrack.Module.BusinessObjects;
using DevExpress.ExpressApp.Security;
using MonApp.Module.BusinessObjects;


namespace AlgoTrack.Module
{
    // For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
    public sealed class AlgoTrackModule : ModuleBase
    {
        public AlgoTrackModule()
        {
            //
            // AlgoTrackModule
            //
            AdditionalExportedTypes.Add(typeof(AlgoTrack.Module.BusinessObjects.ApplicationUser));
            AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.EF.PermissionPolicy.PermissionPolicyRole));
            AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.EF.ModelDifference));
            AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.EF.ModelDifferenceAspect));
            RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.SystemModule.SystemModule));
            RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Security.SecurityModule));
            RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.AuditTrail.EFCore.AuditTrailModule));
            RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Chart.ChartModule));
            RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.CloneObject.CloneObjectModule));
            RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule));
            RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Dashboards.DashboardsModule));
            RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Notifications.NotificationsModule));
            RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Office.OfficeModule));
            RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.PivotGrid.PivotGridModule));
            RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ReportsV2.ReportsModuleV2));
            RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Scheduler.SchedulerModuleBase));
            RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.StateMachine.StateMachineModule));
            RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.TreeListEditors.TreeListEditorsModuleBase));
            RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Validation.ValidationModule));
            RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ViewVariantsModule.ViewVariantsModule));
            DevExpress.ExpressApp.Security.SecurityModule.UsedExportedTypes = DevExpress.Persistent.Base.UsedExportedTypes.Custom;
            AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.EF.FileData));
            AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.EF.FileAttachment));
            AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.EF.Event));
            AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.EF.Resource));
            AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.EF.HCategory));
            AdditionalExportedTypes.Add(typeof(StateMachine));
            AdditionalExportedTypes.Add(typeof(StateMachineTransition));
            AdditionalExportedTypes.Add(typeof(StateMachineAppearance));
            AdditionalExportedTypes.Add(typeof(StateMachineState));
            AdditionalExportedTypes.Add(typeof(UserToken));
        }
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
        {
            ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
            return new ModuleUpdater[] { updater };
        }
        public override void Setup(XafApplication application)
        {
            base.Setup(application);
            application.ObjectSpaceCreated += Application_ObjectSpaceCreated;
        }

        private void Application_ObjectSpaceCreated(object sender, ObjectSpaceCreatedEventArgs e)
        {
            
            if (e.ObjectSpace is NonPersistentObjectSpace) return;
            e.ObjectSpace.Committing += ObjectSpace_Commiting;
        }

        private void ObjectSpace_Commiting(object sender, CancelEventArgs e)
        {
            var os = (IObjectSpace)sender;
            foreach (var obj in os.ModifiedObjects.OfType<ICodeNumerique>())
                if (!os.IsDeletedObject(obj))
                    obj.CodeNum = CodeNumHelper.Calculer(obj.Code);
        }
        public override void Setup(ApplicationModulesManager moduleManager)
        {
            base.Setup(moduleManager);
            StateMachineModule stateMachineModule = moduleManager.Modules.FindModule<StateMachineModule>();
            stateMachineModule.StateMachineStorageType = typeof(StateMachine);
        }
    }
    
}
