using currency_rates.ViewsModel;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace currency_rates.Commands
{
    public class GetConvertCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public ConvertViewModel convertViewModel { get; set; }
        string source, target;

        public string Source { get => source; set => source = value; }
        public string Target { get => target; set => target = value; }

        public GetConvertCommand(ConvertViewModel convertViewModel)
        {
            this.convertViewModel = convertViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event Action<Currency> CurrencyAdded;
        public void Execute(object parameter)
        {
            try
            {
                Task myTask = Task.Factory.StartNew(() => CurrencyAdded(BL.Logic.Convert(Source, Target)));
                //convertViewModel.historyViewModel.getHistoryCommand.Source = source;
                convertViewModel.historyViewModel.getHistoryCommand.Target = target;
                convertViewModel.historyViewModel.getHistoryCommand.Execute(this);
            }

            catch
            {
                
            }
        }    

        
    }
}

