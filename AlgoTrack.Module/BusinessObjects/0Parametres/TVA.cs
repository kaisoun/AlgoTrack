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
    public class TVA
    {
        [DataAnn.Required]
        [DataAnn.StringLength(3)]
        [RuleRequiredField(DefaultContexts.Save)]
        [RuleUniqueValue(DefaultContexts.Save)] 
        public virtual string CodeTVA { get; set; }
        [RuleUniqueValue(DefaultContexts.Save)] 
        [Precision(2, 2)]
        public virtual decimal TauxTVA { get; set; }
        public virtual Compte CompteTvaAchat { get; set; }
        public virtual Compte CompteTvaVente { get; set; }
        public virtual Compte CompteVente{ get; set; }
        
    }
}