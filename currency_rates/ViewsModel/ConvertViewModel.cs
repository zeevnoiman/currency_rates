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

namespace currency_rates.ViewsModel
{
    public class ConvertViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Currency> currencys { get; set; }
        public CurrencyModel CurrentModel { get; set; }
        public GetConvertCommand GetConvertCommand { get; set; }
        public HistoryViewModel historyViewModel { get; set; }
        private string value;
        public string Value
        {
            get => value;
            set
            {
                this.value = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Value"));
            }
        }

        public ConvertViewModel()
        {
            CurrentModel = new CurrencyModel();
            historyViewModel = new HistoryViewModel();
            currencys = new ObservableCollection<Currency>();
            currencys.CollectionChanged += Currency_CollectionChanged;
            GetConvertCommand = new GetConvertCommand(this);
            GetConvertCommand.CurrencyAdded += AddCureency_CurrencyAdded;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void AddCureency_CurrencyAdded(Currency curr)
        {
            Value = "";

            currencys.Add(curr);
            Value += curr.Value;

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
                        CurrentModel.Currencies.Add(c);
                        CurrentModel.SaveChanges();
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




