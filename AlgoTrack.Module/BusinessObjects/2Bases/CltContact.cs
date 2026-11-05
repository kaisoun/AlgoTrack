using System;
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

    public class CltContact : AuditedBaseObject

    {
        [System.ComponentModel.DataAnnotations.Required]
        public virtual Client Client { get; set; } = null!;
        [DataAnn.MaxLength(50)]
        public virtual char? IntCt { get; set; }
        [DataAnn.MaxLength(80)]
        public virtual string? FonctionCt { get; set; }
        [DataAnn.MaxLength(15)]
        public virtual string? TelCt1 { get; set; }
        [DataAnn.MaxLength(15)]
        public virtual string? TelCt2 { get; set; }
        [DataAnn.MaxLength(200)]
        public virtual string? MailCt1 { get; set; }
        [DataAnn.MaxLength(200)]
        public virtual string? MailCt2 { get; set; }
        [DataAnn.MaxLength(200)]
        public virtual string? NoteCt { get; set; }
    }
}