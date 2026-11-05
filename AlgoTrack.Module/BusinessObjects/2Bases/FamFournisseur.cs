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
using MonApp.Module.BusinessObjects;

namespace AlgoTrack.Module.BusinessObjects
{

    [NavigationItem("Bases")]
    [Microsoft.EntityFrameworkCore.Index(nameof(Code), IsUnique = true)]
    public class FamFournisseur : FamTier
    {
    
    }
}