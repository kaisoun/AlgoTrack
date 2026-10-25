using System.ComponentModel.DataAnnotations;

using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System.ComponentModel;
using DevExpress.ExpressApp.Model;

namespace AlgoTrack.Module.BusinessObjects
{ 
public abstract class AuditedBaseObject : BaseObject
{
    [VisibleInListView(false)] 
    [ModelDefault("AllowEdit", "False")]
    
    public virtual DateTime CreeLe { get; set; }
    [VisibleInListView(false)] 
    [ModelDefault("AllowEdit", "False")]
    public virtual string? CreePar { get; set; }
    [VisibleInListView(false)] 
    [ModelDefault("AllowEdit", "False")]
    [MaxLength(45)]
    public virtual string? CreeSur { get; set; }
    [VisibleInListView(false)] 
    [ModelDefault("AllowEdit", "False")]
    public virtual DateTime? ModifieLe { get; set; }
    [VisibleInListView(false)] 
    [ModelDefault("AllowEdit", "False")]
    public virtual string? ModifiePar { get; set; }
    [VisibleInListView(false)] 
    [ModelDefault("AllowEdit", "False")]
    [MaxLength(45)]
    public virtual string? ModifieSur { get; set; }
}
}