using currency_rates.ViewsModel;
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

namespace currency_rates.Views
{
    /// <summary>
    /// Interaction logic for ConvertView.xaml
    /// </summary>
    public partial class ConvertView : UserControl
    {

        ConvertViewModel currentVM;
        public ConvertView()
        {
            InitializeComponent();
            currentVM = new ConvertViewModel();
            this.DataContext = currentVM;
            historyViewuc.DataContext = currentVM.historyViewModel;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string source, target;
            source = Source.SelectedItem.ToString();
            target = Target.SelectedItem.ToString();

            historyViewuc.Visibility = Visibility.Visible;
            currentVM.GetConvertCommand.Source = source;
            currentVM.GetConvertCommand.Target = target;
        }

   
    }
}
