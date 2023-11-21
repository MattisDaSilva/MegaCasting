using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.DBLib.Models
{
    /// <summary>
    /// Contexte megaCasting
    /// </summary>
    public class MegaCastingContext : DbContext
    {
        #region Properties

        #endregion

        #region Methods

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("connectionString");
        }

        #endregion

    }
}
