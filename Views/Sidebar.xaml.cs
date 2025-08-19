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
            SetActive(BtnDashboard); // activo por defecto
        }

        // Navegación: llamamos al método público del MainWindow
        private void Dashboard_Click(object sender, RoutedEventArgs e)
        {
            SetActive((Button)sender);
            (Application.Current.MainWindow as MainWindow)?.NavigateTo("Dashboard");
        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            SetActive((Button)sender);
            (Application.Current.MainWindow as MainWindow)?.NavigateTo("Orders");
        }

        private void Clients_Click(object sender, RoutedEventArgs e)
        {
            SetActive((Button)sender);
            (Application.Current.MainWindow as MainWindow)?.NavigateTo("Clients");
        }

        private void Products_Click(object sender, RoutedEventArgs e)
        {
            SetActive((Button)sender);
            (Application.Current.MainWindow as MainWindow)?.NavigateTo("Products");
        }

        private void Providers_Click(object sender, RoutedEventArgs e)
        {
            SetActive((Button)sender);
            (Application.Current.MainWindow as MainWindow)?.NavigateTo("Providers");
        }

        private void Cash_Click(object sender, RoutedEventArgs e)
        {
            SetActive((Button)sender);
            (Application.Current.MainWindow as MainWindow)?.NavigateTo("Cash");
        }

        private void Reports_Click(object sender, RoutedEventArgs e)
        {
            SetActive((Button)sender);
            (Application.Current.MainWindow as MainWindow)?.NavigateTo("Reports");
        }

        // Visual activo
        private void SetActive(Button activeButton)
        {
            foreach (var btn in MenuStack.Children.OfType<Button>())
                btn.Tag = null;

            activeButton.Tag = "active";
        }
    }
}
