

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

namespace AlgoTrack.Module.BusinessObjects.Parametres
{
    [DefaultClassOptions]
    [NavigationItem("Paramètres")]
    public class ModeReg :AuditedBaseObject
    {
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        public virtual string LibelleModeReg { get; set; }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        public virtual string TypeReg { get; set; }
        
    }
}