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
    [DefaultClassOptions]
    [NavigationItem("Bases")]
    
    [Microsoft.EntityFrameworkCore.Index(nameof(CodeArt), IsUnique = true)]
    public class SsFamArticle : AuditedBaseObject
    {

        [DataAnn.MaxLength(25)]
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        public virtual String CodeArt { get; set; } = null!;
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        [DataAnn.MaxLength(60)]
        public virtual string IntArt { get; set; } = null!;
        public virtual decimal PrixVt { get; set; } 
        [System.ComponentModel.DataAnnotations.Required]
        public virtual decimal TauxTVA { get; set; }
        public virtual string? DesigLongue { get; set; }
    }
    
    
}