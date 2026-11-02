using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore.DesignTime;
using DevExpress.ExpressApp.EFCore.Updating;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.Persistent.BaseImpl.EF.StateMachine;

using DevExpress.Persistent.BaseImpl.EFCore.AuditTrail;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata;
namespace AlgoTrack.Module.BusinessObjects
{
    [TypesInfoInitializer(typeof(DbContextTypesInfoInitializer<AlgoTrackEFCoreDbContext>))]
    public class AlgoTrackEFCoreDbContext : DbContext
    {
        public AlgoTrackEFCoreDbContext(DbContextOptions<AlgoTrackEFCoreDbContext> options) : base(options)
        {
        }
        //public DbSet<ModuleInfo> ModulesInfo { get; set; }
        public DbSet<ModelDifference> ModelDifferences { get; set; }
        public DbSet<ModelDifferenceAspect> ModelDifferenceAspects { get; set; }
        public DbSet<PermissionPolicyRole> Roles { get; set; }
        public DbSet<AlgoTrack.Module.BusinessObjects.ApplicationUser> Users { get; set; }
        public DbSet<AlgoTrack.Module.BusinessObjects.ApplicationUserLoginInfo> UserLoginsInfo { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        public DbSet<FileData> FileData { get; set; }
        public DbSet<ReportDataV2> ReportDataV2 { get; set; }
        public DbSet<StateMachine> StateMachines { get; set; }
        public DbSet<StateMachineState> StateMachineStates { get; set; }
        public DbSet<StateMachineTransition> StateMachineTransitions { get; set; }
        public DbSet<StateMachineAppearance> StateMachineAppearances { get; set; }
        public DbSet<DashboardData> DashboardData { get; set; }
        public DbSet<AuditDataItemPersistent> AuditData { get; set; }
        public DbSet<AuditEFCoreWeakReference> AuditEFCoreWeakReferences { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<HCategory> HCategories { get; set; }
        //Mes classes
        public DbSet<Article> Articles { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Fournisseur> Fournisseurs { get; set; }
        public DbSet<CltAdresse> CltAdresses { get; set; }
        public DbSet<CltContact> CltContacts { get; set; }
        public DbSet<Projet> Projets { get; set; }
        
        public DbSet<Contrat> Contrats { get; set; }
        
        //Ventes
        public DbSet<Vente> Ventes { get; set; }
        public DbSet<VenteLig> VenteLigs { get; set; }
        public DbSet<Devis> Deviss { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Livraison> Livraisons { get; set; }
        public DbSet<BonPour> BonPours { get; set; }
        public DbSet<Retour> Retours { get; set; }
        public DbSet<Facture> Factures { get; set; }
        public DbSet<Avoir> Avoirs { get; set; }
        
        //MvtTiers
        public DbSet<AffectRegl> AffectRegs { get; set; }

        public DbSet<Reglement> Reglements { get; set; }
        //public DbSet<ReglClient> ReglementClients { get; set; }
        //public DbSet<ReglFournisseur> ReglementFournisseurs { get; set; }
        //Tresorerie
        public DbSet<CompteTr> CompteTrs { get; set; }
        public DbSet<Caisse> Caissess { get; set; }
        public DbSet<Banque> Banquess { get; set; }
        
        //Track
        public DbSet<Logiciel> Logiciels { get; set; }
        public DbSet<LogicielVers> VersionLogs { get; set; }
        public DbSet<GpTache> GpTaches { get; set; }
        public DbSet<Tache> Taches { get; set; }
        public DbSet<SsTache> SsTaches { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketPJ> TicketPJs { get; set; }
        public DbSet<TicketComment> TicketComments { get; set; }
        //Rendre les enumeration au format string possible : clarté d'affichage dans la base
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder); // Bonne pratique d'appeler la base

            // Convertit automatiquement TOUTES les enums en string dans la BDD
            configurationBuilder.Properties<Enum>()
                .HaveConversion<string>();
        }
        //Surcharge de savechages pour renseigner les champs d'audit 
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ApplyAuditFields();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ApplyAuditFields();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void ApplyAuditFields()
        {
            var now = DateTime.Now;
            var user = SecuritySystem.CurrentUserName; // même source que ton code actuel

            foreach (var e in ChangeTracker.Entries<AuditedBaseObject>())
            {
                if (e.State == EntityState.Added)
                {
                    e.Entity.CreeLe = now;
                    e.Entity.CreePar = user;
                }
                if (e.State is EntityState.Added or EntityState.Modified)
                {
                    e.Entity.ModifieLe = now;
                    e.Entity.ModifiePar = user;
                }
            }
            
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseDeferredDeletion(this);
            modelBuilder.UseOptimisticLock();
            modelBuilder.SetOneToManyAssociationDeleteBehavior(DeleteBehavior.SetNull, DeleteBehavior.Cascade);
            modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues);
            modelBuilder.UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction);
            modelBuilder.Entity<AlgoTrack.Module.BusinessObjects.ApplicationUserLoginInfo>(b =>
            {
                b.HasIndex(nameof(DevExpress.ExpressApp.Security.ISecurityUserLoginInfo.LoginProviderName), nameof(DevExpress.ExpressApp.Security.ISecurityUserLoginInfo.ProviderUserKey)).IsUnique();
            });
            modelBuilder.Entity<AuditEFCoreWeakReference>()
                .HasMany(p => p.AuditItems)
                .WithOne(p => p.AuditedObject);
            modelBuilder.Entity<AuditEFCoreWeakReference>()
                .HasMany(p => p.OldItems)
                .WithOne(p => p.OldObject);
            modelBuilder.Entity<AuditEFCoreWeakReference>()
                .HasMany(p => p.NewItems)
                .WithOne(p => p.NewObject);
            modelBuilder.Entity<AuditEFCoreWeakReference>()
                .HasMany(p => p.UserItems)
                .WithOne(p => p.UserObject);
            modelBuilder.Entity<StateMachine>()
                .HasMany(t => t.States)
                .WithOne(t => t.StateMachine)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ModelDifference>()
                .HasMany(t => t.Aspects)
                .WithOne(t => t.Owner)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<CompteTr>()
                .ToTable("CompteTr");
            modelBuilder.Entity<Caisse>()
                .ToTable("Caisse");
            modelBuilder.Entity<Banque>()
                .ToTable("Banque");       
            foreach (var e in modelBuilder.Model.GetEntityTypes())
                Console.WriteLine(e.ClrType.FullName);
            foreach (var t in modelBuilder.Model.GetEntityTypes()
                         .Where(t => typeof(AuditedBaseObject).IsAssignableFrom(t.ClrType)))
            {
                var e = modelBuilder.Entity(t.ClrType);
                var p = e.Property(nameof(AuditedBaseObject.SeqNum));
                p.HasColumnOrder(0);          // première colonne
                p.UseIdentityByDefaultColumn();
                p.Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
                e.HasIndex(nameof(AuditedBaseObject.SeqNum)).IsUnique();
            }
            foreach (var t in modelBuilder.Model.GetEntityTypes()
                         .Where(t => typeof(AuditedBaseObject).IsAssignableFrom(t.ClrType)))
            {
                var e = modelBuilder.Entity(t.ClrType);

                e.Property(nameof(AuditedBaseObject.SeqNum)).HasColumnOrder(0);
                e.Property("ID").HasColumnOrder(1);                                  // la clé Guid
                e.Property(nameof(AuditedBaseObject.CreeLe)).HasColumnOrder(2);
                e.Property(nameof(AuditedBaseObject.CreePar)).HasColumnOrder(3);   // voir note ci-dessous
                e.Property(nameof(AuditedBaseObject.CreeSur)).HasColumnOrder(4);
                e.Property(nameof(AuditedBaseObject.ModifieLe)).HasColumnOrder(5);
                e.Property(nameof(AuditedBaseObject.ModifiePar)).HasColumnOrder(6);
                e.Property(nameof(AuditedBaseObject.ModifieSur)).HasColumnOrder(7);

                // ... identity et index de SeqNum comme avant
            }
        }
 
    }
    
    public class AlgoTrackAuditingDbContext : DbContext
    {
        public AlgoTrackAuditingDbContext(DbContextOptions<AlgoTrackAuditingDbContext> options) : base(options)
        {
        }
        public DbSet<AuditDataItemPersistent> AuditData { get; set; }
        public DbSet<AuditEFCoreWeakReference> AuditEFCoreWeakReferences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseDeferredDeletion(this);
            modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues);
            modelBuilder.Entity<AuditEFCoreWeakReference>()
                .HasMany(p => p.AuditItems)
                .WithOne(p => p.AuditedObject);
            modelBuilder.Entity<AuditEFCoreWeakReference>()
                .HasMany(p => p.OldItems)
                .WithOne(p => p.OldObject);
            modelBuilder.Entity<AuditEFCoreWeakReference>()
                .HasMany(p => p.NewItems)
                .WithOne(p => p.NewObject);
            modelBuilder.Entity<AuditEFCoreWeakReference>()
                .HasMany(p => p.UserItems)
                .WithOne(p => p.UserObject);
        }
    }
}
