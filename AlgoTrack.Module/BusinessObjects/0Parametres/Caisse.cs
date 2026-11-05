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
    public class Caisse : CompteTr
    {
        public virtual string? Agence { get; set; }
        [DataAnn.MaxLength(12)] 
        public virtual string? TypeCaisse { get; set; } = "Divers";

        public Caisse()
        {
            TypeCompte = "Caisse";
        }
    }
}