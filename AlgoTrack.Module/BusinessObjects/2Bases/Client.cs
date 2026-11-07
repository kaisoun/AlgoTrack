using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Persistent.Validation;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Filtering;
using DevExpress.ExpressApp.DC;
using System.Collections.ObjectModel;
using DevExpress.Persistent.Base.General;
using System.ComponentModel.DataAnnotations.Schema;
using DataAnn = System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using AlgoTrack.Module.BusinessObjects;
using MonApp.Module.BusinessObjects;

namespace AlgoTrack.Module.BusinessObjects 
{
    [NavigationItem("Bases")]
    [Microsoft.EntityFrameworkCore.Index(nameof(Code), IsUnique = true)]
    public class FamClient : FamTier
    {
    
    }
   
    public class CltAdresse : TierAdresse

    {
        public virtual Client Client { get; set; }
    }
    
    public class CltContact : Adresse

    {
        [System.ComponentModel.DataAnnotations.Required]
        public virtual Client Client { get; set; } = null!;
        [DataAnn.MaxLength(50)]
        public virtual char? IntCt { get; set; }
        [DataAnn.MaxLength(80)]
        public virtual string? FonctionCt { get; set; }
        [DataAnn.MaxLength(200)]
        public virtual string? NoteCt { get; set; }
    }
    
    [NavigationItem(false)]
    public class ContratClt : AuditedBaseObject
    {
        [System.ComponentModel.DataAnnotations.Required]
        public virtual Client Client { get; set; } = null!;
        [System.ComponentModel.DataAnnotations.Required]
        [DataAnn.Display(Order = 1)]
        [DisplayName("Libellé")]
        public virtual String LibContrat { get; set; } = null!;
        
        [DataAnn.Display(Order = 2)]
        public virtual DateTime DateDebContrat { get; set; } = DateTime.Now;
        [DataAnn.Display(Order = 3)]
        public virtual DateTime DateFinContrat { get; set; } = DateTime.Now;
        
        [DataAnn.Display(Order = 4)] 
        [DisplayName("Libellé")]
        public virtual string? NotesContrat { get; set; } = "";
        
    }
    
    [DefaultClassOptions]
    [NavigationItem("Bases")]
    [Microsoft.EntityFrameworkCore.Index(nameof(Code), IsUnique = true)]
    public class Client : Tier
    {
        [Aggregated]
        [DisplayName("Adresses")]
        public virtual ICollection<CltAdresse> CltAdresses { get; set; } = new ObservableCollection<CltAdresse>();
        [Aggregated]
        [DisplayName("Contacts")]
        public virtual ICollection<CltContact> CltContacts { get; set; } = new ObservableCollection<CltContact>();
        [Aggregated]
        [DisplayName("Contrats")]
        public virtual ICollection<ContratClt> ContratClts { get; set; } = new ObservableCollection<ContratClt>(); 
    }
}


