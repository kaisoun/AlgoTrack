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
    [DefaultClassOptions]
    [NavigationItem("Configuration")]

    public class ParamCodif : AuditedBaseObject 
    {
    [MaxLength(12)] 
    [System.ComponentModel.DataAnnotations.RequiredAttribute]
    public virtual int Nbcar { get; set; } = 12;
    [MaxLength(30)]
    public virtual string? MasqueCode { get; set; }
    [MaxLength(25)] 
    [System.ComponentModel.DataAnnotations.RequiredAttribute]
    public virtual TypeEntite TypeEntite{ get; set; }
    public bool Obligatoire { get; set; } = true;
    public virtual bool FormatSimple { get; set; } = false;
    }
}