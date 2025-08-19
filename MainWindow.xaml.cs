using System.Windows;
using System.Windows.Controls;
using ToxicBizBuddyWPF.Views;

namespace ToxicBizBuddyWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Arranca en Dashboard (si tenés otra inicial, cambiala aquí)
            NavigateTo("Dashboard");
        }

        // Navegación centralizada
        public void NavigateTo(string route)
        {
            Page page = route switch
            {
                "Dashboard" => new DashboardPage(),
                "Orders" => new OrdersPage(),   // <-- Pedidos
                "Clients" => new ClientsPage(),
                "Products" => new ProductsPage(),
                "Providers" => new ProvidersPage(),
                "Cash" => new CashPage(),
                "Reports" => new ReportsPage(),
                _ => new DashboardPage(),
            };

            MainFrame.Navigate(page);
        }
    }
}
