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

namespace AlgoTrack.Module.BusinessObjects.Configuration
{
    public class Indentification : AuditedBaseObject
    {
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        public virtual string RaisonSociale { get; set; }
        public virtual string? FormeJur { get; set; }
        public virtual string? Activite { get; set; }
        public virtual string? Adresse1 { get; set; }
        public virtual string? Adresse2 { get; set; }
        public virtual string? Ville { get; set; }
        public virtual string? CP { get; set; }
        public virtual string? Region { get; set; }
        public virtual string? Gouvernorat { get; set; }
        public virtual string? Reponsable1 { get; set; }
        public virtual string? FctReponsable1 { get; set; }
        public virtual string? Tel1Resp1 { get; set; }
        public virtual string? Tel2Resp1 { get; set; }
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Format d'email invalide")]
        public virtual string? Mail1Resp1 { get; set; }
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Format d'email invalide")]
        public virtual string? mail2Resp1 { get; set; }
        public virtual string? Reponsable2 { get; set; }
        public virtual string? FctReponsable2 { get; set; }
        public virtual string? Tel1Resp2 { get; set; }
        public virtual string? Tel2Resp2 { get; set; }
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Format d'email invalide")]
        public virtual string? Mail1Resp2 { get; set; }
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Format d'email invalide")]
        public virtual string? mail2Resp2 { get; set; }
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
        
        
        

    }
}