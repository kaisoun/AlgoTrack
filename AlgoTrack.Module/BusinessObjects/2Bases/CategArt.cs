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
    
    [Microsoft.EntityFrameworkCore.Index(nameof(CodeCateg), IsUnique = true)]
    public class CategArt : AuditedBaseObject
    {

        [DataAnn.MaxLength(25)]
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        public virtual String CodeCateg { get; set; } = null!;
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        [DataAnn.MaxLength(60)]
        public virtual string IntCateg { get; set; } = null!;
        [DataAnn.MaxLength(300)]
        public virtual string? Description { get; set; }
    }
    
    
}