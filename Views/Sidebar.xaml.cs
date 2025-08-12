using System.Windows;
using System.Windows.Controls;

namespace ToxicBizBuddyWPF.Views
{
    public partial class Sidebar : UserControl
    {
        public Sidebar()
        {
            InitializeComponent();
            // Activo inicial
            SetActive(BtnDashboard);
        }

        private void Dashboard_Click(object sender, RoutedEventArgs e)
        {
            Navigate("Dashboard");
            SetActive(BtnDashboard);
        }

        private void Products_Click(object sender, RoutedEventArgs e)
        {
            Navigate("Productos");
            SetActive(BtnProductos);
        }

        private void Clients_Click(object sender, RoutedEventArgs e)
        {
            Navigate("Clientes");
            SetActive(BtnClientes);
        }

        private void Navigate(string target)
        {
            if (Window.GetWindow(this) is MainWindow win)
            {
                win.NavigateTo(target);
            }
        }

        private void SetActive(params Button[] active)
        {
            // limpiar
            BtnDashboard.Tag = null;
            BtnProductos.Tag = null;
            BtnClientes.Tag = null;

            foreach (var b in active)
                b.Tag = "active";
        }
    }
}
