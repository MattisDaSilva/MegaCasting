using MegaCasting.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MegaCasting.DBLib.Models;

namespace MegaCasting.Wpf.Views
{
    /// <summary>
    /// Logique d'interaction pour ReferencielView.xaml
    /// </summary>
    public partial class ReferencielView : UserControl
    {
        public ReferencielView()
        {
            InitializeComponent();
            this.DataContext = new ViewModelReferencielView();
        }

        private void UpdateTypeContratButton_Click(object sender, RoutedEventArgs e)
        {
            if (((ViewModelReferencielView)this.DataContext).SelectedTypeContrat != null)
            {
                ((ViewModelReferencielView)this.DataContext).SelectedTypeContrat.Nom = _TypeContratNomTextBox.Text;

            }
        }

        private void DeleteTypeContratButton_Click(object sender, RoutedEventArgs e)
        {
            if (((ViewModelReferencielView)this.DataContext).SelectedTypeContrat != null)
            {
                ((ViewModelReferencielView)this.DataContext).TypeContrats?.Remove(((ViewModelReferencielView)this.DataContext).SelectedTypeContrat);
            }
        }

        private void DeleteDomaineMetierButton_Click(object sender, RoutedEventArgs e)
        {
            if (((ViewModelReferencielView)this.DataContext).SelectedDomaineMetier != null)
            {
                ((ViewModelReferencielView)this.DataContext).DomaineMetiers?.Remove(((ViewModelReferencielView)this.DataContext).SelectedDomaineMetier);
            }
           
        }

        private void UpdateDomaineMetierButton_Click(object sender, RoutedEventArgs e)
        {
            if (((ViewModelReferencielView)this.DataContext).SelectedDomaineMetier != null)
            {
                ((ViewModelReferencielView)this.DataContext).SelectedDomaineMetier.Nom = _DomaineMetierNomTextBox.Text;

            }
        }

        private void UpdateMetierButton_Click(object sender, RoutedEventArgs e)
        {
            if (((ViewModelReferencielView)this.DataContext).SelectedMetier != null)
            {
                ((ViewModelReferencielView)this.DataContext).SelectedMetier.Nom = _MetierNomTextBox.Text;

            }
        }

        private void DeleteMetierButton_Click(object sender, RoutedEventArgs e)
        {
            if (((ViewModelReferencielView)this.DataContext).SelectedMetier != null)
            {
                ((ViewModelReferencielView)this.DataContext).Metiers?.Remove(((ViewModelReferencielView)this.DataContext).SelectedMetier);
            }
        }
    }
}
