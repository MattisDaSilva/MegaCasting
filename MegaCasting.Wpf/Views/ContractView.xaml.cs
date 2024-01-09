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
    public partial class ContractView : UserControl
    {
        public ContractView()
        {
            InitializeComponent();
            this.DataContext = new ViewModelContractView();
        }
    }
}
