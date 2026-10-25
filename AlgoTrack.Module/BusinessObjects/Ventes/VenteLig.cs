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
using AlgoTrack.Module.BusinessObjects.Bases;

namespace AlgoTrack.Module.BusinessObjects.Ventes
{
    [NavigationItem(false)]
    public class VenteLig : AuditedBaseObject
    {
        [System.ComponentModel.DataAnnotations.Required]
        public virtual Vente Vente { get; set; } = null!;
        [System.ComponentModel.DataAnnotations.Required]
        public virtual Article Article { get; set; } = null!;
        public virtual string IntArticle { get; set; } = null!;
        public virtual string? Unite { get; set; } = "";
        public virtual decimal quantite{get; set;} = 0;
        
        public virtual decimal PUHT { get; set; } = 0;
        public virtual decimal PTHT { get; set; } = 0;
        public virtual decimal TauxRemLig { get; set; } = 0;
        public virtual decimal MtRemLig { get; set; } = 0;
        public virtual decimal PUNHT { get; set; } = 0;
        public virtual decimal PTNHT { get; set; } = 0;
        public virtual decimal TxDC { get; set; } = 0;
        public virtual decimal MtDC { get; set; } = 0;
        
        public virtual decimal TxFodec { get; set; } = 0;
        public virtual decimal MtFodec { get; set; } = 0;
        
        public virtual decimal MtAutTaxe { get; set; } = 0;
        public virtual decimal TxTVA { get; set; } = 0;
        public virtual decimal MtTVA { get; set; } = 0;
        
        public virtual decimal PUTTC { get; set; } = 0;
        public virtual decimal PTTTC { get; set; } = 0;
        public virtual decimal PUNTTC { get; set; } = 0;
        public virtual decimal PTNTTC { get; set; } = 0;
        
        
        
        
        
        

    }
}