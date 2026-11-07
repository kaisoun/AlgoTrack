
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
    
    [Microsoft.EntityFrameworkCore.Index(nameof(Code), IsUnique = true)]
    public abstract class FamTier : AuditedBaseObject, ICodeNumerique
    {
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        [DataAnn.MaxLength(16, ErrorMessage = "Le code ne peut pas dépasser 16 caractères")]
        [DataAnn.Display(Order = 2)]
        [DisplayName("Code")]
        [Column(Order = 8)]
        public virtual string Code { get; set; }
        [VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
        [ModelDefault("AllowEdit", "False")]
        [Column(Order = 9)]
        public virtual long CodeNum { get; set; }
        [DataAnn.Display(Order = 3)]
        [RuleRequiredField("IntituleFamille_Required", DefaultContexts.Save, "L'intitulé est obligatoire")]
        [DataAnn.MaxLength(60)]
        [DisplayName("Intitulé")]
        public virtual string IntFam { get; set; } = "";
        [DataAnn.MaxLength(200)]
        [DisplayName("Description")]
        [DataAnn.Display(Order = 4)]
        public virtual string Description { get; set; } = "";
    }
}