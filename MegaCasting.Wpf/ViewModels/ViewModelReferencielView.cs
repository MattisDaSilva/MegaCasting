using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MegaCasting.Core;
using MegaCasting.DBLib.Models;
using Prism.Commands;

namespace MegaCasting.Wpf.ViewModels
{
    internal class ViewModelReferencielView : ObservableObject
    {
        #region Attributes

        /// <summary>
        /// Type de contrat sélectionnée
        /// </summary>
        private TypeContrat? _SelectedTypeContrat;

        private OffreCasting? _SelectedOffreCasting;

        private ObservableCollection<OffreCasting> _OffreCastings;
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

        private DelegateCommand<object> _CmdAddOffreCasting;


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
            
            CmdAddOffreCasting = new DelegateCommand<object>(AddOffreCasting, CanAddOffreCasting).ObservesProperty(() => this.SelectedOffreCasting);

            using (MegaCastingContext context = new MegaCastingContext())
            {
                if (this.OffreCastings != null && !context.OffreCastings.Any())
                {;
                    context.OffreCastings.AddRange(OffreCastings);
                    context.SaveChanges();
                }
                else
                {
                    this.OffreCastings = new ObservableCollection<OffreCasting>(context.OffreCastings);
                }
            }
        }


        #endregion
        #region Commands

        private void AddOffreCasting(object parameter = null)
        {
            OffreCasting offrecasting = new OffreCasting();
            this.OffreCastings.Add(offrecasting);

            using (MegaCastingContext context = new MegaCastingContext())
            {
                context.OffreCastings.Add(offrecasting);
                context.SaveChanges();
            }

        }

        private bool CanAddOffreCasting(object parameter = null) => !(this.SelectedOffreCasting == null);

        private void ReloadContext()
        {
            this.OffreCastings.Clear();
            using (MegaCastingContext context = new MegaCastingContext())
            {
                //context.OffreCastings.Add(new OffreCasting("Nouvelle offre de casting"));
                //this._Brands context.Brands.ToList();
                context.SaveChanges();
            }
        }
        #endregion
    }
}
