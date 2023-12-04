using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaCasting.Core;
using MegaCasting.DBLib.Models;

namespace MegaCasting.Wpf.ViewModels
{
    internal class ViewModelReferencielView : ObservableObject
    {
        #region Attributes

        /// <summary>
        /// Type de contrat sélectionnée
        /// </summary>
        private TypeContrat? _SelectedTypeContrat;

        private ObservableCollection<TypeContrat>? _TypeContrats;

        /// <summary>
        /// Metier sélectionnée
        /// </summary>
        private Metier? _SelectedMetier;

        private ObservableCollection<Metier>? _Metiers;

        /// <summary>
        /// Domaine de metier sélectionnée
        /// </summary>
        private DomaineMetier? _SelectedDomaineMetier;

        private ObservableCollection<DomaineMetier>? _DomaineMetiers;

        #endregion

        #region Properties

        /// <summary>
        /// Obtient ou défini le type de contrat séléctionné
        /// </summary>
        public ObservableCollection<TypeContrat>? TypeContrats
        {
            get => _TypeContrats;
            set => SetProperty(nameof(TypeContrats), ref _TypeContrats, value);
        }

        public TypeContrat? SelectedTypeContrat
        {
            get => _SelectedTypeContrat; 
            set => SetProperty(nameof(SelectedTypeContrat), ref _SelectedTypeContrat, value); 
        }

        /// <summary>
        /// Obtient ou défini le type de contrat séléctionné
        /// </summary>
        public ObservableCollection<DomaineMetier>? DomaineMetiers
        {
            get => _DomaineMetiers;
            set => SetProperty(nameof(DomaineMetiers), ref _DomaineMetiers, value);
        }

        public DomaineMetier? SelectedDomaineMetier
        {
            get => _SelectedDomaineMetier;
            set => SetProperty(nameof(SelectedDomaineMetier), ref _SelectedDomaineMetier, value);
        }

        /// <summary>
        /// Obtient ou défini le type de contrat séléctionné
        /// </summary>
        public ObservableCollection<Metier>? Metiers
        {
            get => _Metiers;
            set => SetProperty(nameof(Metiers), ref _Metiers, value);
        }

        public Metier? SelectedMetier
        {
            get => _SelectedMetier;
            set => SetProperty(nameof(SelectedMetier), ref _SelectedMetier, value);
        }
        #endregion

        #region Constructors


        public ViewModelReferencielView()
        {
            using(MegaCastingContext mg = new() )
            {
                TypeContrats = new ObservableCollection<TypeContrat>(mg.TypeContrats.ToList());
                DomaineMetiers = new ObservableCollection<DomaineMetier>(mg.DomaineMetiers.ToList());
                Metiers = new ObservableCollection<Metier>(mg.Metiers.ToList());

            }
        }


        #endregion
    }
}
