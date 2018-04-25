using currency_rates.Commands;
using currency_rates.Models;
using Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace currency_rates.ViewsModel
{
    class CurrencyViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Currency> currencys { get; set; }
        public CurrencyModel currentModel { get; set; }
        public HistoryViewModel historyViewModel { get; set; }
        public GetCurrencyCommand getCurrencyCommand { get; set; }
        public string quote { get; set; }
        private string value;
        string dateNow { get; set; }
        public string Value
        { get => value;
            set
            {
                this.value = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Value"));
            }
           }

        public CurrencyViewModel()
        {
            currentModel = new CurrencyModel();
            historyViewModel = new HistoryViewModel();
            currencys = new ObservableCollection<Currency>();
            //currencys.CollectionChanged += Currency_CollectionChanged;
            quote = "ILS";
            getCurrencyCommand = new GetCurrencyCommand(quote);
            getCurrencyCommand.CurrencyAdded += AddCureency_CurrencyAdded;
            GetLiveThread();
           
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void AddCureency_CurrencyAdded(List<Currency> curr)
        {
            Value = "";

            foreach (var currency in curr)
            {
                currencys.Add(currency);
                Value += currency.Value;
            }
          if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Value"));
                
        }
        
        private void Currency_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var x = e.Action;
            if (x == NotifyCollectionChangedAction.Add)
            {
                
                    foreach (Currency c in e.NewItems)
                    {
                        try
                        {
                            currentModel.Currencies.Add(c);
                            currentModel.SaveChanges();
                        }
                        catch (Exception)
                        {
                            // the currency already is in the table
                        }
                    }

            }
        }
        //כאן עדכן את המודל בשינויים שנעשו בוויו
      

        private async void GetLiveThread()
        {
        

    
            /*
                var uiContext = TaskScheduler.FromCurrentSynchronizationContext();

            // Start a task - this runs on the background thread...
            Task task = Task.Factory.StartNew(() =>
            {
                for (int i = 1; i < 5; i++)
                {
                    Thread.Sleep(5000);

                    Task.Factory.StartNew(() =>
                    {
                        getCurrencyCommand.Execute(this);
                        historyViewModel.getHistoryCommand.Target = quote;                       
                        historyViewModel.getHistoryCommand.Execute(this);
                        dateNow = DateTime.Now.ToLongDateString();

                    }, CancellationToken.None, TaskCreationOptions.None, uiContext);
                    
                }
            });
            */
        }
    }
}

