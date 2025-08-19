using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ToxicBizBuddyWPF.Views
{
    public partial class OrdersPage : Page
    {
        public OrdersPage()
        {
            InitializeComponent();
            // Datos de ejemplo para ver el layout como en el mock
            OrdersGrid.ItemsSource = GetSampleOrders();
        }

        private static IList<OrderRow> GetSampleOrders() => new List<OrderRow>
        {
            new OrderRow("PED001","María García", new DateTime(2024,1,8), 3, 450.00m, "Completado"),
            new OrderRow("PED002","Carlos López", new DateTime(2024,1,8), 2, 230.50m, "Pendiente"),
            new OrderRow("PED003","Ana Rodríguez", new DateTime(2024,1,7), 5, 680.00m, "Pendiente"),
            new OrderRow("PED004","Luis Martín", new DateTime(2024,1,7), 2, 320.75m, "Cancelado")
        };

        // ===== Botones =====
        private void NewOrder_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Nuevo pedido (visual)", "Pedidos");
        }

        private void OpenFilters_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Abrir filtros (visual)", "Pedidos");
        }

        private void OpenOrderLink_Click(object sender, MouseButtonEventArgs e)
        {
            if (sender is TextBlock tb && tb.DataContext is OrderRow row)
                MessageBox.Show($"Abrir detalle de {row.Pedido}", "Pedidos");
        }

        private void ViewOrder_Click(object sender, RoutedEventArgs e) => ShowAction(sender, "Ver");
        private void EditOrder_Click(object sender, RoutedEventArgs e) => ShowAction(sender, "Editar");
        private void DuplicateOrder_Click(object sender, RoutedEventArgs e) => ShowAction(sender, "Duplicar");
        private void DeleteOrder_Click(object sender, RoutedEventArgs e) => ShowAction(sender, "Eliminar");

        private static void ShowAction(object sender, string action)
        {
            if (sender is Button btn && btn.DataContext is OrderRow row)
                MessageBox.Show($"{action} {row.Pedido}", "Pedidos");
        }
    }

    public sealed class OrderRow
    {
        public string Pedido { get; }
        public string Cliente { get; }
        public string Fecha { get; }
        public string Items { get; }
        public string Total { get; }
        public string Estado { get; }

        public OrderRow(string pedido, string cliente, DateTime fecha, int items, decimal total, string estado)
        {
            Pedido = pedido;
            Cliente = cliente;
            Fecha = fecha.ToString("yyyy-MM-dd");
            Items = items == 1 ? "1 item" : $"{items} items";
            Total = total.ToString("$0.00", CultureInfo.InvariantCulture);
            Estado = estado; // "Completado" | "Pendiente" | "Cancelado"
        }
    }
}
