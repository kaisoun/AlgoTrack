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
    public abstract class TierAdresse : Adresse

    {
        [DataAnn.MaxLength(20)] public virtual TypeAdress TypeAdress { get; set; } = TypeAdress.FactLivraison; //Facturation,Livraison...

        public virtual bool ParDefaut { get; set; } = false;
    }
 
}