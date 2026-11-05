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
using DataAnn = System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AlgoTrack.Module.BusinessObjects
{
    public class TierAdresse : AuditedBaseObject

    {
        
        [DataAnn.MaxLength(100)]
        public virtual string? Adresse1 { get; set; }
        [DataAnn.MaxLength(100)]
        public virtual string? Adresse2 { get; set; }
        [DataAnn.MaxLength(80)]
        public virtual string? Ville { get; set; }
        [DataAnn.MaxLength(5)]
        public virtual string? CP { get; set; }
        [DataAnn.MaxLength(50)]
        public virtual string? Region { get; set; }
        [DataAnn.MaxLength(50)]
        public virtual string? Pays { get; set; }

        [DataAnn.MaxLength(20)] public virtual TypeAdress TypeAdress { get; set; } = TypeAdress.FactLivraison; //Facturation,Livraison...

        public virtual bool ParDefaut { get; set; } = false;
    }
 
}