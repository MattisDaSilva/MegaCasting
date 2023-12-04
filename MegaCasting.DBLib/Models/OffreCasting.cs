using System;
using System.Collections.Generic;

namespace MegaCasting.DBLib.Models;

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

    public virtual DomaineMetier Domaine { get; set; } = null!;

    public virtual Metier Metier { get; set; } = null!;

    public virtual TypeContrat TypeContrat { get; set; } = null!;
}
