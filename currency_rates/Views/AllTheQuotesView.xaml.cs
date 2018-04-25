using currency_rates.ViewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for AllTheQuotesView.xaml
    /// </summary>
    public partial class AllTheQuotesView : UserControl
    {
        QuotesViewModel currentVM;
        public AllTheQuotesView()
        {
            InitializeComponent();
            currentVM = new QuotesViewModel();
            this.DataContext = currentVM;
        }

        private void ComboBox_quotes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string item = e.AddedItems[0].ToString();
            string newString = item.Substring(6, 3);
            SelectedItem = newString;
            
        }
        


        public object SelectedItem
        {
            get { return (string)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for itemsl.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(object), typeof(AllTheQuotesView), new PropertyMetadata(0));



    }
}
