using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Persistent.Validation;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.Filtering;
using DevExpress.ExpressApp.DC;
using System.Collections.ObjectModel;
using DevExpress.Persistent.Base.General;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AlgoTrack.Module.BusinessObjects
{
    public class CltAdresse : AuditedBaseObject

    {
      
        public virtual Client Client { get; set; }
        [MaxLength(100)]
        public virtual string? Adresse1 { get; set; }
        [MaxLength(100)]
        public virtual string? Adresse2 { get; set; }
        [MaxLength(80)]
        public virtual string? Ville { get; set; }
        [MaxLength(5)]
        public virtual string? CP { get; set; }
        [MaxLength(50)]
        public virtual string? Region { get; set; }
        [MaxLength(50)]
        public virtual string? Pays { get; set; }

        [MaxLength(20)] public virtual TypeAdresse TypeAdresse { get; set; } = TypeAdresse.FactLivraison; //Facturation,Livraison...

        public virtual bool ParDefaut { get; set; } = false;
    }
    
    public enum TypeAdresse
    {
        FactLivraison= 0,
        Facturation = 1,
        Livraison = 2
    }
}