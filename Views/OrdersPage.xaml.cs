using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ToxicBizBuddyWPF.Views
{
    public partial class OrdersPage : Page
    {
        public ObservableCollection<OrderItem> Orders { get; } = new();

        public OrdersPage()
        {
            InitializeComponent();
            DataContext = this;

            // Mock data
            Orders.Add(new OrderItem { Pedido = "PED001", Cliente = "María García", Fecha = "2024-01-08", Items = "3 items", Total = "$450.00", Estado = "Completado" });
            Orders.Add(new OrderItem { Pedido = "PED002", Cliente = "Carlos López", Fecha = "2024-01-08", Items = "2 items", Total = "$230.50", Estado = "Pendiente" });
            Orders.Add(new OrderItem { Pedido = "PED003", Cliente = "Ana Rodríguez", Fecha = "2024-01-07", Items = "5 items", Total = "$680.00", Estado = "Pendiente" });
            Orders.Add(new OrderItem { Pedido = "PED004", Cliente = "Luis Martín", Fecha = "2024-01-07", Items = "2 items", Total = "$320.75", Estado = "Cancelado" });
        }

        private void NewOrder_Click(object sender, RoutedEventArgs e) =>
            MessageBox.Show("Nuevo pedido (visual)", "Pedidos");

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e) { /* TODO: filtro */ }

        private void OpenFilters_Click(object sender, RoutedEventArgs e) =>
            MessageBox.Show("Abrir filtros (visual)", "Pedidos");

        private void OrderLink_Click(object sender, MouseButtonEventArgs e)
        {
            if (sender is TextBlock tb && tb.DataContext is OrderItem oi)
                MessageBox.Show($"Abrir {oi.Pedido}", "Pedidos");
        }

        // ==== Acciones (instancia, no static) ====
        private void ViewOrder_Click(object sender, RoutedEventArgs e) => ShowAction(sender, "Ver");
        private void EditOrder_Click(object sender, RoutedEventArgs e) => ShowAction(sender, "Editar");
        private void DuplicateOrder_Click(object sender, RoutedEventArgs e) => ShowAction(sender, "Duplicar");
        private void DeleteOrder_Click(object sender, RoutedEventArgs e) => ShowAction(sender, "Eliminar");

        private void ShowAction(object sender, string action)
        {
            if (sender is FrameworkElement fe && fe.DataContext is OrderItem oi)
                MessageBox.Show($"{action} {oi.Pedido}", "Pedidos");
        }
    }

    public class OrderItem
    {
        public string Pedido { get; set; } = "";
        public string Cliente { get; set; } = "";
        public string Fecha { get; set; } = "";
        public string Items { get; set; } = "";
        public string Total { get; set; } = "";
        /// <summary>Completado | Pendiente | Cancelado</summary>
        public string Estado { get; set; } = "Pendiente";
    }
}
