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
using AlgoTrack.Module.BusinessObjects.Parametres;
namespace AlgoTrack.Module.BusinessObjects
{
    [NavigationItem("Ventes")]
    public class Reglement : AuditedBaseObject
    {
        public virtual DateTime DateRegl { get; set; } = DateTime.Now;
        public virtual String TypeReg { get; set; }
        public virtual string Libelle { get; set; } = "";
        public virtual string ReferenceRef { get; set; } = "";
        public virtual ModeReg ModeReg { get; set; }
        public virtual DateTime DateEch { get; set; }
        public virtual CompteTr CompteTr { get; set; }
    }
}