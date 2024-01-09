using MegaCasting.DBLib.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MegaCasting.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<OffreCasting> Offres { get; set; }
        public MainWindow()
        {
            using (MegaCastingContext context = new())
            {
                Offres = new ObservableCollection<OffreCasting>(context.OffreCastings);
            }
            this.DataContext = this;
            InitializeComponent();
        }

        
    }
}
