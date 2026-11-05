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


