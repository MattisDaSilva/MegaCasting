using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MegaCasting.Core;
using MegaCasting.DBLib.Models;
using Microsoft.EntityFrameworkCore;
using Prism.Commands;

namespace MegaCasting.Wpf.ViewModels
{
    internal class ViewModelContractView : ObservableObject
    {
        #region Attributes

        /// <summary>
        /// Type de contrat sélectionnée
        /// </summary>
        private TypeContrat? _SelectedTypeContrat;

        private OffreCasting? _SelectedOffreCasting;

        private ObservableCollection<OffreCasting> _OffreCastings;


        private ObservableCollection<TypeContrat>? _TypeContrats;

        private OffreCasting _AddCasting;

        /// <summary>
        /// Metier sélectionnée
        /// </summary>
        private Metier? _SelectedMetier;


        /// <summary>
        /// Liste des métiers
        /// </summary>
        private ObservableCollection<Metier>? _Metiers;

        /// <summary>
        /// Domaine de metier sélectionnée
        /// </summary>
        private DomaineMetier? _SelectedDomaineMetier;

        private ObservableCollection<DomaineMetier>? _DomaineMetiers;

        private DelegateCommand<object> _CmdAddOffreCasting;
        //TODO : Ajout des commandes
        private DelegateCommand<object> _CmdUpdateOffreCasting;
        private DelegateCommand<object> _CmdDeleteOffreCasting;


        #endregion

        #region Properties

        /// <summary>
        /// Obtient ou défini le type de contrat séléctionné
        /// </summary>

        public ObservableCollection<OffreCasting> OffreCastings
        {
            get => _OffreCastings;
            set => SetProperty(nameof(OffreCastings), ref _OffreCastings, value);
        }
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

        public OffreCasting? SelectedOffreCasting
        {
            get => _SelectedOffreCasting;
            set => SetProperty(nameof(SelectedOffreCasting), ref _SelectedOffreCasting, value);
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
        
        public DelegateCommand<object> CmdAddOffreCasting
        {
            get => _CmdAddOffreCasting;
            set => _CmdAddOffreCasting = value;
        }
        //TODO : Ajout des commandes
        public DelegateCommand<object> CmdUpdateOffreCasting
        {
            get => _CmdUpdateOffreCasting;
            set => _CmdUpdateOffreCasting = value;
        }


        public DelegateCommand<object> CmdDeleteOffreCasting
        {
            get => _CmdDeleteOffreCasting;
            set => _CmdDeleteOffreCasting = value;
        }

        public OffreCasting AddCasting 
        { 
            get => _AddCasting; 
            set => SetProperty(nameof(AddCasting), ref _AddCasting, value);
        }

        #endregion

        #region Constructors

        public ViewModelContractView()
        {
            using (MegaCastingContext mg = new())
            {
                TypeContrats = new ObservableCollection<TypeContrat>(mg.TypeContrats.ToList());
                DomaineMetiers = new ObservableCollection<DomaineMetier>(mg.DomaineMetiers.ToList());
                Metiers = new ObservableCollection<Metier>(mg.Metiers.ToList());

            }
            //TODO : La propriété observée n'était pas bonne
            CmdAddOffreCasting = new DelegateCommand<object>(AddOffreCasting, CanAddOffreCasting)
                .ObservesProperty(() => this.AddCasting)
                .ObservesProperty(() => this.SelectedDomaineMetier)
                .ObservesProperty(() => this.SelectedMetier)
                .ObservesProperty(() => this.SelectedTypeContrat);

            //TODO : La propriété observée n'était pas bonne
            CmdUpdateOffreCasting = new DelegateCommand<object>(UpdateOffreCasting, CanUpdateOffreCasting)
                .ObservesProperty(() => this.SelectedOffreCasting);

            //TODO : La propriété observée n'était pas bonne
            CmdDeleteOffreCasting = new DelegateCommand<object>(DeleteOffreCasting, CanDeleteOffreCasting)
                .ObservesProperty(() => this.SelectedOffreCasting);

            using (MegaCastingContext context = new MegaCastingContext())
            {
                 this.OffreCastings = new ObservableCollection<OffreCasting>(context.OffreCastings.Include(o => o.Metier).Include(o => o.Domaine).Include(o => o.TypeContrat));
            }

            this.AddCasting = new OffreCasting("", 0);
        }


        #endregion

        #region Commands

        private void AddOffreCasting(object parameter = null)
        {
            if (SelectedDomaineMetier == null || SelectedMetier == null || SelectedTypeContrat == null)
                throw new Exception("Les éléments nécessaire ne sont pas sélectionnés");

            AddCasting.DomaineId = SelectedDomaineMetier.Id; 
            AddCasting.MetierId = SelectedMetier.Id;
            AddCasting.TypeContratId = SelectedTypeContrat.Id;
            using (MegaCastingContext context = new MegaCastingContext())
            {
                context.OffreCastings.Add(AddCasting); 
                context.SaveChanges();
            }
            this.OffreCastings.Add(AddCasting);
          
            this.AddCasting = new OffreCasting("", 0);
        }

        //TODO : Remettre les propriétés qu'on vérifie
        private bool CanAddOffreCasting(object? parameter = null) => 
            this.AddCasting != null 
            &&  this.SelectedMetier != null
            &&  this.SelectedDomaineMetier != null
            &&  this.SelectedTypeContrat != null;


        // TODO : Ajout de la commande de mise à jour
        private void UpdateOffreCasting(object? parameter = null)
        {
            if (SelectedOffreCasting?.Domaine== null || SelectedOffreCasting?.Metier == null || SelectedOffreCasting?.TypeContrat == null)
                throw new Exception("Les éléments nécessaire ne sont pas sélectionnés");

            using (MegaCastingContext context = new MegaCastingContext())
            {
                context.OffreCastings.Update(SelectedOffreCasting);
                context.SaveChanges();
            }
        }

        //TODO : Remettre les propriétés qu'on vérifie
        private bool CanUpdateOffreCasting(object? parameter = null) =>
            this.SelectedOffreCasting != null
            && this.SelectedOffreCasting.Domaine != null
            && this.SelectedOffreCasting?.Metier != null
            && this.SelectedOffreCasting?.TypeContrat != null;

        // TODO : Ajout de la commande de suppression
        private void DeleteOffreCasting(object? parameter = null)
        {
            if (SelectedOffreCasting == null)
                throw new Exception("Les éléments nécessaire ne sont pas sélectionnés");

            using (MegaCastingContext context = new MegaCastingContext())
            {
                context.OffreCastings.Remove(SelectedOffreCasting);
                context.SaveChanges();
            }
            this.OffreCastings.Remove(SelectedOffreCasting);
        }

        //TODO : Remettre les propriétés qu'on vérifie
        private bool CanDeleteOffreCasting(object? parameter = null) =>
            this.SelectedOffreCasting != null;


        #endregion
    }
}
