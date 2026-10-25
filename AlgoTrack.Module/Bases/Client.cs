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
namespace AlgoTrack.Module.BusinessObjects.Bases
{
    
    [DefaultClassOptions]
    [NavigationItem("Bases")]
    [Microsoft.EntityFrameworkCore.Index(nameof(CodeClt), IsUnique = true)]
    public class Client : AuditedBaseObject
    {
       
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        [MaxLength(16, ErrorMessage = "Le code client ne peut pas dépasser 16 caractères")]
        [Display(Order = 2)]
        [DisplayName("Code")]
        public virtual string CodeClt { get; set; }
        [Display(Order = 3)]
        [RuleRequiredField("IntituleClient_Required", DefaultContexts.Save, "L'intitulé du client est obligatoire")]
        [MaxLength(60)]
        [DisplayName("Intitule")]
        public virtual string IntClt { get; set; } = "";
        [MaxLength(30)]
        [DisplayName("Activité")]
        public virtual string? Activite { get; set; }
        [MaxLength(12)]
        public virtual string Tel1 { get; set; } = "";
        [MaxLength(12)]
        public virtual string Tel2 { get; set; } = "";
        [Display(Order = 10)]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Format d'email invalide")]
        [MaxLength(60)]
        public virtual string MailClt1 { get; set; } = "";
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Format d'email invalide")]
        [MaxLength(60)]
        public virtual string MailClt2 { get; set; } = "";
        [Display(Order = 11)]
        [DetailViewLayout("Tabs", LayoutGroupType.TabbedGroup, 100)]
        [ModelDefault("RowCount", "10")]
        [MaxLength(200)]
        [DisplayName("Notes")]
        public virtual string NoteClt { get; set; } = "";
        [Display(Order = 12)]
        [DisplayName("Taux Majoration/Forfaitaires")]
        public virtual TxMajForf MajForf { get; set; } = TxMajForf.Zero;

        // [Display(Order = 13)]
        // [EditorAlias("PopupLookupPropertyEditor")]
        // public virtual TypeRet TypeRet { get; set; }

        [MaxLength(1)] [Display(Order = 14)] 
        public virtual char? CategClt { get; set; }

        [MaxLength(1)]
        [Display(Order = 15)]
        public virtual string? RegimeTvaClt { get; set; } = "";
        [MaxLength(3)]
        [Display(Order = 16)]
        public virtual string? NbEtabClt { get; set; } = "";
        [MaxLength(7)]
        [Display(Order = 17)]
        [DisplayName("IdUnique")]
        public virtual string? IdUnique { get; set; } = "";
        [MaxLength(1)]
        [Display(Order = 18)]
        [DisplayName("Clé")]
        public virtual string? CleIdUnique { get; set; } = "";
        
        [Aggregated]
        [DisplayName("Adresses")]
        public virtual ICollection<CltAdresse> CltAdresses { get; set; } = new ObservableCollection<CltAdresse>();
        [Aggregated]
        [DisplayName("Contacts")]
        public virtual ICollection<CltContact> CltContacts { get; set; } = new ObservableCollection<CltContact>();
        [Aggregated]
        [DisplayName("Contrats")]
        public virtual ICollection<Contrat> Contrats { get; set; } = new ObservableCollection<Contrat>();

    }

    public enum TxMajForf
    {
        Zero = 0,
        Un = 1,
        Trois = 3
    }
}


