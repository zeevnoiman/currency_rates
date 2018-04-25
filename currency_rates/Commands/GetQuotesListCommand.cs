using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using currency_rates.ViewsModel;
using Data;

namespace currency_rates.Commands
{
    class GetQuotesListCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        QuotesViewModel quotesVM;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public GetQuotesListCommand(QuotesViewModel currentVM)
        {
            quotesVM = currentVM;
        }

        public event Action<List<Quote>> QuoteAdded;

        public void Execute(object parameter)
        {
            List<Quote> myList = new List<Quote>(quotesVM.currentModel.Quotes);
            QuoteAdded(myList);

            //Task myTask = Task.Factory.StartNew(() => QuoteAdded(BL.Logic.GetQuotes()));


        }
    }
}
