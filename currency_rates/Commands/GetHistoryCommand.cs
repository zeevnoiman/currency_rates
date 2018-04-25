using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace currency_rates.Commands
{
    public class GetHistoryCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        string source = "USD";
        string target;
        public string Source { get => source; set => source = value; }
        public string Target { get => target; set => target = value; }
        string Code { get; set; }
        
        public GetHistoryCommand(string source)
        {
            Code = source;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event Action<List<CurrencyHistory>> HistoryAdded;

        public void Execute(object parameter)
        {
            List<CurrencyHistory> myList = new List<CurrencyHistory>();            
            Task myTask= Task.Factory.StartNew(() => HistoryAdded(BL.Logic.GetCurrencyHistoryFromStartDate(source, target, Code)));
            //HistoryAdded(BL.Logic.GetCurrencyHistoryFromStartDate(source, target, Code));
        }
    }
}
