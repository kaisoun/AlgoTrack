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
    public class TypeArt: BaseObject
    {
        [DataAnn.MaxLength(6)] public virtual string CodeType { get; set; } = string.Empty;
        [DataAnn.MaxLength(40)]
        public virtual string Intitule { get; set; }

        public virtual bool SuiviStock { get; set; } 
        public virtual ModeValStk ModeValStk { get; set; }= ModeValStk.Aucune;
        public virtual bool DispoVente { get; set; }
        public virtual bool DispoAchat { get; set; }
        public virtual bool DispoStock { get; set; }
        public virtual bool DispoProd { get; set; }
        
    }

    public enum ModeValStk
    {
        Aucune = 0,
        CMP = 1,
        Fifo = 2,
        Lifo = 3,
        
    }
}

