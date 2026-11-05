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
namespace AlgoTrack.Module.BusinessObjects
{
   
    public abstract  class EnteteVt : Entete
    {
        [Aggregated]
        [DisplayName("Lignes")]
        public virtual ICollection<Ligne> Lignes { get; set; } = new ObservableCollection<Ligne>();  
        
        
    }
    
}