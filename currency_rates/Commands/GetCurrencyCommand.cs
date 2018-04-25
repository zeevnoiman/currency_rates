using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BL;
using Data;

namespace currency_rates.Commands
{
    class GetCurrencyCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        string currency;
        public string Currency { get => currency; set => currency = value; }

        public GetCurrencyCommand(string currency)
        {
            Currency = currency;            
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event Action<List<Currency>> CurrencyAdded;
        public void Execute(object parameter)
        {
             Task myTask = Task.Factory.StartNew(() => CurrencyAdded(BL.Logic.GetLive(Currency)));
        }
    }
}
