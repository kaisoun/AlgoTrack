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
using AlgoTrack.Module.BusinessObjects;
using MonApp.Module.BusinessObjects;

namespace AlgoTrack.Module.BusinessObjects
{
    
    [DefaultClassOptions]
    [NavigationItem("Bases")]
    [Microsoft.EntityFrameworkCore.Index(nameof(Code), IsUnique = true)]
    public class Client : Tier , ICodeNumerique
    {
        /*
         [System.ComponentModel.DataAnnotations.RequiredAttribute]
         [MaxLength(16, ErrorMessage = "Le code client ne peut pas dépasser 16 caractères")]
         [Display(Order = 2)]
         [DisplayName("Code")]
         [Column(Order = 8)]
         public virtual string Code { get; set; }
         [VisibleInListView(false), VisibleInDetailView(false), VisibleInLookupListView(false)]
         [ModelDefault("AllowEdit", "False")]
         [Column(Order = 9)]
         public virtual long CodeNum { get; set; }
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

     // ==========================================
     // 1. Categorie
     // ==========================================
     private Categorie? _categorie;
     [MaxLength(1)]
     [Display(Order = 14)]
     [ImmediatePostData]
     public virtual Categorie? categorie
     {
         get => _categorie;
         set
         {
             if (_categorie != value)
             {
                 _categorie = value;
                 OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(categorie)));
                 OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(MatFiscal)));
             }
         }
     }

     // ==========================================
     // 2. RegimeTva
     // ==========================================
     private RegimeTva? _regimeTva;
     [MaxLength(1)]
     [Display(Order = 15)]
     [ImmediatePostData]
     public virtual RegimeTva? RegimeTva
     {
         get => _regimeTva;
         set
         {
             if (_regimeTva != value)
             {
                 _regimeTva = value;
                 OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(RegimeTva)));
                 OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(MatFiscal)));
             }
         }
     }

     // ==========================================
     // 3. NbEtabClt
     // ==========================================
     private string? _nbEtabClt = "";
     [MaxLength(3)]
     [Display(Order = 16)]
     [ImmediatePostData]
     public virtual string? NbEtabClt
     {
         get => _nbEtabClt;
         set
         {
             if (_nbEtabClt != value)
             {
                 _nbEtabClt = value;
                 OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(NbEtabClt)));
                 OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(MatFiscal)));
             }
         }
     }

     // ==========================================
     // 4. IdUnique
     // ==========================================
     private string? _idUnique = "";
     [MaxLength(7)]
     [Display(Order = 17)]
     [DisplayName("IdUnique")]
     [ImmediatePostData]
     public virtual string? IdUnique
     {
         get => _idUnique;
         set
         {
             if (_idUnique != value)
             {
                 _idUnique = value;
                 OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(IdUnique)));
                 OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(MatFiscal)));
             }
         }
     }

     // ==========================================
     // 5. CleIdUnique
     // ==========================================
     private string? _cleIdUnique = "";
     [MaxLength(1)]
     [Display(Order = 18)]
     [DisplayName("Clé")]
     [ImmediatePostData]
     public virtual string? CleIdUnique
     {
         get => _cleIdUnique;
         set
         {
             if (_cleIdUnique != value)
             {
                 _cleIdUnique = value;
                 OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(CleIdUnique))); //[cite: 3]
                 OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(MatFiscal)));
             }
         }
     }

     // ==========================================
     // 6. Champ Calculé Non Mappé (MatFiscal)
     // ==========================================
     [NotMapped]
     [Display(Order = 19)]
     [DisplayName("Matricule Fiscal Complet")]
     public virtual string MatFiscal
     {
         get => $"{IdUnique}/{CleIdUnique}/{categorie}/{RegimeTva}/{NbEtabClt}";
     }
         [Aggregated]
         [DisplayName("Adresses")]
         public virtual ICollection<CltAdresse> CltAdresses { get; set; } = new ObservableCollection<CltAdresse>();
         [Aggregated]
         [DisplayName("Contacts")]
         public virtual ICollection<CltContact> CltContacts { get; set; } = new ObservableCollection<CltContact>();
         [Aggregated]
         [DisplayName("Contrats")]
         public virtual ICollection<Contrat> Contrats { get; set; } = new ObservableCollection<Contrat>();
         */

    }
}


