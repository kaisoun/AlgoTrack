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
using AlgoTrack.Module.BusinessObjects;
namespace AlgoTrack.Module.BusinessObjects.Parametres
{
    [NavigationItem("Parametres")]
    public class Logiciel : AuditedBaseObject
    { 
      [System.ComponentModel.DataAnnotations.RequiredAttribute]
      public virtual string Intitule { get; set; }
      public virtual string Description { get; set; }
      
      [Aggregated]
      [DisplayName("Versions")]
      public virtual ICollection<VersionLog> VersionLogs { get; set; } = new ObservableCollection<VersionLog>();
      
    }
}