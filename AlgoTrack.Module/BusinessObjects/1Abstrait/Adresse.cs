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

namespace AlgoTrack.Module.BusinessObjects;

public class Adresse : AuditedBaseObject
{
    [DataAnn.MaxLength(12)]
    public virtual string Tel1 { get; set; } = "";
    [DataAnn.MaxLength(12)]
    public virtual string Tel2 { get; set; } = "";
    [DataAnn.Display(Order = 10)]
    [DataAnn.RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Format d'email invalide")]
    [DataAnn.MaxLength(60)]
    public virtual string MailClt1 { get; set; } = "";
    [DataAnn.RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Format d'email invalide")]
    [DataAnn.MaxLength(60)]
    public virtual string MailClt2 { get; set; } = "";
    
    [DataAnn.MaxLength(100)]
    public virtual string? Adresse1 { get; set; }
    [DataAnn.MaxLength(100)]
    public virtual string? Adresse2 { get; set; }
    [DataAnn.MaxLength(80)]
    public virtual string? Ville { get; set; }
    [DataAnn.MaxLength(5)]
    public virtual string? CP { get; set; }
    [DataAnn.MaxLength(50)]
    public virtual string? Gouvernorat { get; set; }
    [DataAnn.MaxLength(50)]
    public virtual string? Region { get; set; }
    [DataAnn.MaxLength(50)]
    public virtual string? Pays { get; set; }
}