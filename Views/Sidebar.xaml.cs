using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ToxicBizBuddyWPF.Views
{
    public partial class Sidebar : UserControl
    {
        public Sidebar()
        {
            InitializeComponent();
            // Al iniciar, dejamos Dashboard como activo
            SetActive(BtnDashboard);
        }

        private MainWindow Shell => Application.Current.MainWindow as MainWindow;

        private void SetActive(Button btn)
        {
            foreach (var b in MenuHost.Children.OfType<Button>())
                b.Tag = null;          // limpia estado activo

            btn.Tag = "active";         // activa el actual
        }

        private void Dashboard_Click(object sender, RoutedEventArgs e)
        {
            SetActive((Button)sender);
            Shell?.MainFrame?.Navigate(new Views.DashboardPage());
        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            SetActive((Button)sender);
            // Navegación a Orders si la tenés
        }

        private void Clients_Click(object sender, RoutedEventArgs e)
        {
            SetActive((Button)sender);
            Shell?.MainFrame?.Navigate(new Views.ClientsPage());
        }

        private void Products_Click(object sender, RoutedEventArgs e)
        {
            SetActive((Button)sender);
            Shell?.MainFrame?.Navigate(new Views.ProductsPage());
        }

        private void Providers_Click(object sender, RoutedEventArgs e)
        {
            SetActive((Button)sender);
            Shell?.MainFrame?.Navigate(new Views.ProvidersPage());
        }

        private void Caja_Click(object sender, RoutedEventArgs e)
        {
            SetActive((Button)sender);
            // Navegación a Caja si corresponde
        }

        private void Reports_Click(object sender, RoutedEventArgs e)
        {
            SetActive((Button)sender);
            // Navegación a Reportes si corresponde
        }
    }
}
