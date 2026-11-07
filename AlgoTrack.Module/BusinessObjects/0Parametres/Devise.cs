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


    public class Devise : AuditedBaseObject

    {
        public virtual string CodeDev { get; set; }
        public virtual string Intitule { get; set; }
        public virtual string SousUnite { get; set; }
        public virtual decimal TauxConv { get; set; }
        public virtual int NbDec   {get; set;}
        public virtual int NbDecImpr {get; set;}
        public virtual bool Utilisable{get; set;}
        
        
    }
    
}