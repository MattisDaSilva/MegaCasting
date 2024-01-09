using MegaCasting.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MegaCasting.DBLib.Models;

//TODO : Remettre comme avant
public partial class OffreCasting
{
    public int Id { get; set; }

    public string Intitule { get; set; } = null!;

    public int Reference { get; set; }

    public int DomaineId { get; set; }

    public int MetierId { get; set; }

    public int TypeContratId { get; set; }

    public DateTime DatePublication { get; set; }

    public int DureeDiffusion { get; set; }

    public DateTime DateDebutContrat { get; set; }

    public int NombrePoste { get; set; }

    public string DescriptionProfil { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    //TODO : Remettre comme avant
    public virtual DomaineMetier Domaine { get; set; }
    public virtual Metier Metier { get; set; }
    public virtual TypeContrat TypeContrat { get; set; }

    #region Constructors


    public OffreCasting(string intitule, int reference)
    {
        this.Intitule = intitule;
        this.Reference = reference;
        DateDebutContrat = DateTime.Now;
        DatePublication = DateTime.Now;
    }

    #endregion
}
