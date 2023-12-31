﻿using MegaCasting.Core;
using System;
using System.Collections.Generic;

namespace MegaCasting.DBLib.Models;

public partial class Metier : ObservableObject
{
    public int Id { get; set; }

    public string Nom { get; set ; } = null!;

    public virtual ICollection<OffreCasting> OffreCastings { get; set; } = new List<OffreCasting>();
}
