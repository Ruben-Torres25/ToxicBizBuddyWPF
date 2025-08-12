using System.Windows;
using ToxicBizBuddyWPF.Views;

namespace ToxicBizBuddyWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new DashboardPage());
        }

        public void NavigateTo(string target)
        {
            switch (target)
            {
                case "Dashboard": MainFrame.Navigate(new DashboardPage()); break;
                case "Productos": MainFrame.Navigate(new ProductsPage()); break;
                case "Clientes": MainFrame.Navigate(new ClientsPage()); break;
            }
        }
    }
}
