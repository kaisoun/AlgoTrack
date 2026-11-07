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
using Microsoft.EntityFrameworkCore;

namespace AlgoTrack.Module.BusinessObjects
{
    [NavigationItem(false)]
    public abstract class Ligne : AuditedBaseObject
    {
        [System.ComponentModel.DataAnnotations.Required]
        public virtual Entete Entete  { get; set; } = null!;
        public virtual Depot Depot { get; set; }
        [DataAnn.Required]
        public virtual Article Article { get; set; } = null!;
        public virtual string IntArticle { get; set; } = null!;
        //Unite&quantite
        public virtual Unite? Unite { get; set; }
        [Precision(12,6)]
        public virtual decimal quantite{get; set;} = 0;
        [Precision(12,6)]
        public virtual decimal CoefUnite{get; set;} = 1;
        
        public virtual Unite? Unite1 { get; set; }
        [Precision(12,6)]
        public virtual decimal quantite1{get; set;} = 0;
        [Precision(12,6)]
        public virtual decimal CoefUnite1{get; set;} = 1;
        
        public virtual Unite? Unite2 { get; set; }
        [Precision(12,6)]
        public virtual decimal quantite2{get; set;} = 0;
        [Precision(12,6)]
        public virtual decimal CoefUnite2{get; set;} = 1;
        
        //Dimensions
        [Precision(12,6)]
        public virtual decimal Largeur{get; set;} = 0;
        [Precision(12,6)]
        public virtual decimal Longueur{get; set;} = 0;
        [Precision(12,6)]
        public virtual decimal Hauteur{get; set;} = 0;
        [Precision(12,6)]
        public virtual decimal Volume{get; set;} = 0;
        [Precision(12,6)]
        public virtual decimal Surface{get; set;} = 0;
        
        //Poids
        [Precision(12,6)]
        public virtual decimal PoidsBrut{get; set;} = 0;
        [Precision(12,6)]
        public virtual decimal PoidsNet{get; set;} = 0;
        
        //Conditionnement
        public virtual string? Condit{get; set;} = "";
        [Precision(12,6)]
        public virtual decimal QteCondit{get; set;} = 0;
        
        
        //Calcul
        [Precision(12,6)]
        public virtual decimal PUHT { get; set; } = 0;
        [Precision(12,6)]
        public virtual decimal PTHT { get; set; } = 0;
        [Precision(3,3)]
        public virtual decimal TauxRemLig { get; set; } = 0;
        [Precision(12,6)]
        public virtual decimal MtRemLig { get; set; } = 0;
        [Precision(12,6)]
        public virtual decimal PUNHT { get; set; } = 0;
        [Precision(12,6)]
        public virtual decimal PTNHT { get; set; } = 0;
        [Precision(2,3)]
        public virtual decimal TxDC { get; set; } = 0;
        [Precision(12,6)]
        public virtual decimal MtDC { get; set; } = 0;
        [Precision(2,3)]
        public virtual decimal TxFodec { get; set; } = 0;
        [Precision(12,6)]
        public virtual decimal MtFodec { get; set; } = 0;
        [Precision(12,6)]
        public virtual decimal MtAutTaxe { get; set; } = 0;
        [Precision(2,3)]
        public virtual decimal TxTVA { get; set; } = 0;
        [Precision(12,6)]
        public virtual decimal MtTVA { get; set; } = 0;
        [Precision(12,6)]
        public virtual decimal PUTTC { get; set; } = 0;
        [Precision(12,6)]
        public virtual decimal PTTTC { get; set; } = 0;
        [Precision(12,6)]
        public virtual decimal PUNTTC { get; set; } = 0;
        [Precision(12,6)]
        public virtual decimal PTNTTC { get; set; } = 0;
        
    }
}