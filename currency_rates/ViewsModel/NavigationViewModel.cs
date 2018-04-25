using currency_rates.Commands;
using currency_rates.ViewsModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace currency_rates.ViewsModel
{
    class NavigationViewModel : INotifyPropertyChanged
    {
        public ICommand LiveCommand { get; set; }
        public ICommand ConvertCommand { get; set; }
        public ICommand HistoryCommand { get; set; }
        
        private object selectedViewModel;

        public object SelectedViewModel
        {
            get { return selectedViewModel; }

            set { selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); }
        }
       
        public NavigationViewModel()
        {
            LiveCommand = new BaseCommand(OpenLive);
            ConvertCommand = new BaseCommand(OpenConvert);
            HistoryCommand = new BaseCommand(OpenHistory);
        }

        private void OpenLive(object obj)
        {
            SelectedViewModel = new CurrencyViewModel();
        }

        private void OpenConvert(object obj)
        {
            SelectedViewModel = new ConvertViewModel();
        }

        private void OpenHistory(object obj)
        {
            SelectedViewModel = new CurrencyHistoryViewModel();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
