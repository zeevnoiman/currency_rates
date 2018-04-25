using currency_rates.ViewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for LiveCurrencyView.xaml
    /// </summary>
    public partial class LiveCurrencyView : UserControl
    {
        //string currentCurrency;
        CurrencyViewModel currentVM;
        public LiveCurrencyView()
        {
            InitializeComponent();
            currentVM = new CurrencyViewModel();
            this.DataContext = currentVM;
            historyView.DataContext = currentVM.historyViewModel;
            Task task = Task.Factory.StartNew(()=>GetLive());
        }

        public void GetLive()
        {
            while (true)
            {                
                this.Dispatcher.Invoke(() =>
                {                  
                    currentVM.historyViewModel.getHistoryCommand.Target = currentVM.quote;
                    currentVM.getCurrencyCommand.Execute(this);
                    currentVM.historyViewModel.getHistoryCommand.Execute(this);
                    dateBlock.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                });
                Thread.Sleep(1000*60*5);
            }
                        
        }
    }
}
