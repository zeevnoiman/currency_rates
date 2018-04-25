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
using System.Threading.Tasks;
using System.Windows.Data;

namespace currency_rates.ViewsModel
{
    class CurrencyHistoryViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<CurrencyHistory> currencys { get; set; }
        public HistoryModel currentModel { get; set; }
        public GetHistoryCommand getHistoryCommand { get; set; }
        private static object _lock = new object();

        public CurrencyHistoryViewModel()
        {
            currentModel = new HistoryModel();
            currencys = new ObservableCollection<CurrencyHistory>();
            //currencys.CollectionChanged += Currency_CollectionChanged;
            getHistoryCommand = new GetHistoryCommand("original");
            getHistoryCommand.HistoryAdded += AddCureency_HistoryAdded;
            BindingOperations.EnableCollectionSynchronization(currencys, _lock);
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void AddCureency_HistoryAdded(List<CurrencyHistory> curr)
        {
            foreach (var currency in curr)
            {
                currencys.Add(currency);
            }
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("currencys"));
            }

        }

        private void Currency_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {

            var x = e.Action;
            if (x == NotifyCollectionChangedAction.Add)
            {

                foreach (CurrencyHistory c in e.NewItems)
                {
                    try
                    {
                        currentModel.CurrHistory.Add(c);
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

    }
}

