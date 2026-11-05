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
    [NavigationItem(false)]
    public class LogicielVers : AuditedBaseObject
    { 
      [System.ComponentModel.DataAnnotations.RequiredAttribute(ErrorMessage ="La version du logiciel est obligatoire")]
      public virtual string LogVers { get; set; }
      public virtual DateTime DateVersion { get; set; }
      public virtual string? Description { get; set; }
      
      
      
    }
}