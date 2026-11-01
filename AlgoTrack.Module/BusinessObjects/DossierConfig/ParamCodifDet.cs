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
namespace AlgoTrack.Module.BusinessObjects
{
 
    [NavigationItem("Config")] 
    [DefaultClassOptions]
    public class ParamCodifDet : AuditedBaseObject 
    {
        
        [MaxLength(12)] public virtual ParamCodif ParamCodif {get;set;}
        public virtual string TypeComposant {get;set;}
    }
}