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
using System.Runtime.CompilerServices;
namespace AlgoTrack.Module.BusinessObjects

{
    [DefaultClassOptions]
    [NavigationItem("Track")]
    public class Ticket : AuditedBaseObject
    {
        
        [Display(Order = 2)]
        public virtual DateTime DateTicket { get; set; } = DateTime.Now;
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        public virtual string Intitule { get; set; }
        public virtual string? Description  { get; set; }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        public virtual Logiciel Logiciel { get; set; }
        public virtual LogicielVers LogicielVers { get; set; }
        public virtual Client? Client { get; set; }
        public virtual CltContact? CltContact { get; set; }
        public virtual Projet? Projet { get; set; }
        public virtual StatutTick? StatutTicket { get; set; } = 0;
        public virtual ApplicationUser? Rapporteur { get; set; }
        public virtual PrioriteTick? Priorite { get; set; } = 0;
        
        [Aggregated]
        [DisplayName("TicketComments")]
        public virtual ICollection<TicketComment> TicketComments { get; set; } = new ObservableCollection<TicketComment>();
        
        public enum StatutTick
        {
            EnCours = 0,
            Traité = 1,
            Obsolete = 2
        }

        public enum PrioriteTick
        {
            Normale = 0,
            Importante = 1,
            Bloquante = 2,
            Vital = 3
        }
    }
}