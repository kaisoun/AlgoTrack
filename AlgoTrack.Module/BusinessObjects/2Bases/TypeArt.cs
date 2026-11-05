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
    [NavigationItem("Paramètres")]

    public class TypeArt : AuditedBaseObject
    {
        [DataAnn.MaxLength(3)] public virtual string Abreviation { get; set; }
        public virtual string NomType { get; set; }
        public virtual bool GestStock { get; set; }
        public virtual string ModeValor { get; set; }
        public virtual String Suivi { get; set; } //par lot , serialise , standard
        public virtual bool DispVente { get; set; }
        public virtual bool DispAchat { get; set; }
        public virtual bool DispStock { get; set; }
        public virtual bool DispProd { get; set; }
    }
}