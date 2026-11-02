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
    [NavigationItem("Paramètres")]
    public class Banque : CompteTr
    {
        public virtual string? Agence { get; set; }
        public virtual string? Adresse { get; set; }
        public virtual string? Ville { get; set; }
        public virtual string? CP { get; set; }
        [MaxLength(20), MinLength(20)] 
        public virtual string? RIB { get; set; }
        public virtual string? Responsable1 { get; set; }
        public virtual string? FonctionResp1 { get; set; }
        public virtual string? TelResp1 { get; set; }
        public virtual string? MailResp1 { get; set; }
        public virtual string? Responsable2 { get; set; }
        public virtual string? FonctionResp2 { get; set; }
        public virtual string? TelResp2 { get; set; }
        public virtual string? MailResp2 { get; set; }
        public virtual string? Notes { get; set; }

        public Banque()
        {
            TypeCompte = "Banque";
        }
    }
}