using currency_rates.Commands;
using currency_rates.Models;
using currency_rates.Views;
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
    class QuotesViewModel : INotifyPropertyChanged
    {         
        public ObservableCollection<Quote> quotes { get; set; }
        public QuotesModel currentModel { get; set; }
        public GetQuotesListCommand getQuotesListCommand { get; set; }
        public LiveCurrencyView CurrencyView { get; set; }
        private static object _lock = new object();
        public QuotesViewModel()
        {
            quotes = new ObservableCollection<Quote>();
            currentModel = new QuotesModel();
            quotes.CollectionChanged += Quotes_CollectionChanged;
            getQuotesListCommand = new GetQuotesListCommand(this);
            getQuotesListCommand.QuoteAdded += GetQuotesListCommand_QuoteAdded;
            CurrencyView = null;
            BindingOperations.EnableCollectionSynchronization(quotes, _lock);
            getQuotesListCommand.Execute(this);
        }

        private void GetQuotesListCommand_QuoteAdded(List<Quote> quote)
        {
            
            foreach (var quo in quote)
            {
                quotes.Add(quo);
            }
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("quotes"));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Quotes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var x = e.Action;
            if (x == NotifyCollectionChangedAction.Add)
            {

                foreach (Quote c in e.NewItems)
                {
                    try
                    {
                        currentModel.Quotes.Add(c);
                        currentModel.SaveChanges();
                    }
                    catch (Exception)
                    {
                        // the currency already is in the table
                    }
                }

            }
        }

        public override string ToString()
        {
            return quotes.ToString();
        }

    }
}
