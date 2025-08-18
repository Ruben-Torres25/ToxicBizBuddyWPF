using System.Windows;
using System.Windows.Controls;
using ToxicBizBuddyWPF.Views.Dialogs;

namespace ToxicBizBuddyWPF.Views
{
    public partial class ClientsPage : Page
    {
        public ClientsPage()
        {
            InitializeComponent();
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new AddClientDialog
            {
                Owner = Application.Current.MainWindow
            };

            // Abre modal. Si el usuario “Guarda”, devolvemos true
            if (dlg.ShowDialog() == true)
            {
                MessageBox.Show("Cliente agregado correctamente (visual).");
                // 🔜 acá refrescarías la grilla con los datos reales
            }
        }

        private void OpenFilters_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Abrir filtros (visual)", "Clientes");
        }

        private void ViewClient_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ver cliente (visual)", "Clientes");
        }

        private void EditClient_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Editar cliente (visual)", "Clientes");
        }

        private void HistoryClient_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Historial del cliente (visual)", "Clientes");
        }

        private void DeleteClient_Click(object sender, RoutedEventArgs e)
        {
            var confirm = new ConfirmDialog { Owner = Application.Current.MainWindow };
            if (confirm.ShowDialog() == true)
            {
                MessageBox.Show("Cliente eliminado (simulado)", "Clientes");
            }
        }
    }
}
