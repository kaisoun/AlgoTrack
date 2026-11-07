namespace AlgoTrack.Module.BusinessObjects;

public class Employe : Adresse
{
    public virtual String CodePer { get; set; }
    public virtual string NomPer { get; set; }
    public virtual String Prenom { get; set; }
}