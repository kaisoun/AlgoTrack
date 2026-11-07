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
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Base.General;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using DataAnn = System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using DevExpress.ExpressApp;

namespace AlgoTrack.Module.BusinessObjects


{
    [DefaultClassOptions]
    [DefaultListViewOptions(allowEdit: true, newItemRowPosition: NewItemRowPosition.Top)]
    public class AutreTaxe : AuditedBaseObject
    {
        [DataAnn.Required]
        [DataAnn.StringLength(3)]
        [RuleRequiredField(DefaultContexts.Save)]
        [RuleUniqueValue(DefaultContexts.Save)] 
        public virtual string Intitule { get; set; }
        [RuleUniqueValue(DefaultContexts.Save)] 
        
        public virtual BaseAutTaxe Base { get; set; }
        public virtual TypeCalcAutTaxe TypeCalc { get; set; }
        [Precision(6,6)]
        public virtual decimal Valeur { get; set; }
        public virtual Compte CompteTvaVente { get; set; }
        public virtual Compte CompteVente{ get; set; }
        public virtual int SoumisTva { get; set; } = 0;
        public virtual int AppAchat{ get; set; } = 0;
        public virtual int AppVente{ get; set; } = 0;
        public virtual Compte? CompteAc{ get; set; }
        public virtual Compte? CompteVt { get; set; }
    }

    public enum BaseAutTaxe
    {
        Poids = 0,
        Quantite = 1,
        MontantHT = 2
    }

    public enum TypeCalcAutTaxe 
    {
       Fixe = 0,
       Taux = 1
    }
    
}