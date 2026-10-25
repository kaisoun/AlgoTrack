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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using AlgoTrack.Module.BusinessObjects.Bases;
namespace AlgoTrack.Module.BusinessObjects.Ventes
{
   
    public abstract  class Vente : AuditedBaseObject
    {
        
        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(12)]
        public virtual String TypeDoc { get; set; } 
        [System.ComponentModel.DataAnnotations.Required]
        public virtual DateTime DateVente { get; set; } = DateTime.Now;
        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(8)]
        public virtual string CodeSouche { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public virtual int NumDoc { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public virtual Client Client { get; set; } = null!;
        public virtual decimal BrutHt { get; set; } = 0;
        public virtual decimal RemiseLig { get; set; } = 0;
        public virtual decimal TotalHt { get; set; } = 0;
        public virtual decimal TauxRemDoc { get; set; } = 0;
        public virtual decimal MontantRemDoc { get; set; } = 0;
        public virtual decimal NetHt { get; set; } = 0;
        public virtual decimal TotFocec { get; set; } = 0;
        public virtual decimal TotDc { get; set; } = 0;
        public virtual decimal TotTva { get; set; } = 0;
        public virtual decimal TotAutTaxe { get; set; } = 0;
        public virtual int Timbre { get; set; } = 0;
        public virtual decimal MtTimbre { get; set; } = 0;
        public virtual decimal TotTtc { get; set; } = 0;
        public virtual int AvForfait { get; set; } = 0;
        public virtual decimal MtAvanceforf { get; set; } = 0;
        [MaxLength(3)]
        public virtual string Devise { get; set; } = "DNT";
        public virtual decimal TauxConv { get; set; } = 1;
        public virtual decimal NetTtc { get; set; } = 0;
        
        [Aggregated]
        [DisplayName("Lignes")]
        public virtual ICollection<VenteLig> VenteLigs { get; set; } = new ObservableCollection<VenteLig>();
        
    }
    
}