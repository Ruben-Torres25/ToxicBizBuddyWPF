using System.Windows;
using System.Windows.Controls;
using ToxicBizBuddyWPF.Views.Dialogs;

namespace ToxicBizBuddyWPF.Views
{
    public partial class ProductsPage : Page
    {
        public ProductsPage()
        {
            InitializeComponent();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new AddProductDialog
            {
                Owner = Application.Current.MainWindow
            };
            dlg.ShowDialog(); // solo visual
        }
    }
}
