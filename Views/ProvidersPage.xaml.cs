using System.Windows;
using System.Windows.Controls;
using ToxicBizBuddyWPF.Views.Dialogs;

namespace ToxicBizBuddyWPF.Views
{
    public partial class ProvidersPage : Page
    {
        public ProvidersPage()
        {
            InitializeComponent();
        }

        // Header
        private void RegisterStock_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Registrar Mercadería (visual)", "Proveedores");
        }

        private void AddProvider_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new AddProviderDialog
            {
                Owner = Application.Current.MainWindow
            };
            dlg.ShowDialog();
        }

        // Filtros
        private void OpenFilters_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Abrir filtros (visual)", "Proveedores");
        }

        // Acciones de la grilla
        private void ViewProvider_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ver proveedor (visual)", "Proveedores");
        }

        private void EditProvider_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new AddProviderDialog
            {
                Owner = Application.Current.MainWindow
            };
            dlg.ShowDialog();
        }

        private void HistoryProvider_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Historial del proveedor (visual)", "Proveedores");
        }

        private void DeleteProvider_Click(object sender, RoutedEventArgs e)
        {
            var confirm = new ConfirmDialog
            {
                Owner = Application.Current.MainWindow,
                Title = "Confirmar" // tu XAML muestra el encabezado propio
            };

            if (confirm.ShowDialog() == true)
            {
                MessageBox.Show("Proveedor eliminado (simulado).", "Proveedores");
            }
        }
    }
}
