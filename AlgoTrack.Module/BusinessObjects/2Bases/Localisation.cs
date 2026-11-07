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

namespace AlgoTrack.Module.BusinessObjects
{
    [NavigationItem("Bases")]
    public class Localisation : Adresse
    {
        
        [Aggregated]
        [DisplayName("Dépots")]
        public virtual ICollection<Depot> Depots { get; set; } = new ObservableCollection<Depot>(); 
    }
    
    
    [NavigationItem("Bases")]
    public class Depot : Adresse
    {
        public virtual String CodeDepot { get; set; }
        public virtual Localisation Localisation { get; set; }
    }
}