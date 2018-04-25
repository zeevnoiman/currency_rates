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
    /// Interaction logic for CurrencyHistoryView.xaml
    /// </summary>
    public partial class CurrencyHistoryView : UserControl
    {
        CurrencyHistoryViewModel currentVM;
        public CurrencyHistoryView()
        {
            InitializeComponent();
            currentVM = new CurrencyHistoryViewModel();
            this.DataContext = currentVM;
            historyViewuc.DataContext = currentVM;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string source;
            source = Source.SelectedItem.ToString();

            currentVM.getHistoryCommand.Target = source;
        }
    }
}
