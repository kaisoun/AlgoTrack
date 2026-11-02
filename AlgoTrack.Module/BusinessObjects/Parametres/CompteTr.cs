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
    public abstract class CompteTr : AuditedBaseObject
    {
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        [MaxLength(8)]
        public virtual string CodeCpteTr { get; set; }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        [MaxLength(30)]
        public virtual string Intitule { get; set; }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        public virtual String TypeCompte { get; set; }
        
       
    }

}