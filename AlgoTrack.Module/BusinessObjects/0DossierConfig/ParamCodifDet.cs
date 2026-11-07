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
   
    
    public class ParamCodifDet : AuditedBaseObject 
    {
        
        [DataAnn.MaxLength(12)] public virtual ParamCodif ParamCodif {get;set;}
        public virtual string TypeComposant {get;set;}
        public virtual int NBCaract {get;set;}
        public virtual string? TexteFixe { get; set; } = "";
        public virtual int Rang {get;set;}
    }
}