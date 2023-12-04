using System;
using System.Collections.Generic;
using MegaCasting.Core;

namespace MegaCasting.DBLib.Models;

public partial class TypeContrat : ObservableObject
{
    public int Id { get; set; }

    private string _Nom;

    public string Nom
    {
        get { return _Nom; }
        set => SetProperty(nameof(Nom), ref _Nom, value);

    }

    public virtual ICollection<OffreCasting> OffreCastings { get; set; } = new List<OffreCasting>();
}
