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
    [NavigationItem(false)]
    public class ContratClt : AuditedBaseObject
    {
        [System.ComponentModel.DataAnnotations.Required]
        public virtual Client Client { get; set; } = null!;
        [System.ComponentModel.DataAnnotations.Required]
        [DataAnn.Display(Order = 1)]
        [DisplayName("Libellé")]
        public virtual String LibContrat { get; set; } = null!;
        
        [DataAnn.Display(Order = 2)]
        public virtual DateTime DateDebContrat { get; set; } = DateTime.Now;
        [DataAnn.Display(Order = 3)]
        public virtual DateTime DateFinContrat { get; set; } = DateTime.Now;
        
        [DataAnn.Display(Order = 4)] 
        [DisplayName("Libellé")]
        public virtual string? NotesContrat { get; set; } = "";
    
        
        
        
        
        
        
    }
}