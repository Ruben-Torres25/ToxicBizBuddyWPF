using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ToxicBizBuddyWPF.Views
{
    public partial class OrdersPage : Page
    {
        private DataGrid? _ordersGridCache;

        public OrdersPage()
        {
            InitializeComponent();
            Loaded += OrdersPage_Loaded;
        }

        private void OrdersPage_Loaded(object? sender, RoutedEventArgs e)
        {
            _ordersGridCache ??= FindOrdersGrid(this);
            if (_ordersGridCache != null)
                _ordersGridCache.ItemsSource = GetSampleOrders();
        }

        // Evita resaltado/selección visual
        private void OrdersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DataGrid dg)
                dg.SelectedIndex = -1;
        }

        private static DataGrid? FindOrdersGrid(DependencyObject root)
        {
            if (root is DataGrid dg && (dg.Tag as string) == "OrdersGridRef")
                return dg;

            int count = VisualTreeHelper.GetChildrenCount(root);
            for (int i = 0; i < count; i++)
            {
                var found = FindOrdersGrid(VisualTreeHelper.GetChild(root, i));
                if (found != null) return found;
            }
            return null;
        }

        private static List<OrderRow> GetSampleOrders() => new()
        {
            new("PED001","María García", new DateTime(2024,1,8), 3, 450000.00m, "Completado"),
            new("PED002","Carlos López", new DateTime(2024,1,8), 2, 230.50m, "Pendiente"),
            new("PED003","Ana Rodríguez", new DateTime(2024,1,7), 5, 680.00m, "Pendiente"),
            new("PED0004","Luis Martín", new DateTime(2024,1,7), 42, 3200000.75m, "Cancelado")
        };

        private void NewOrder_Click(object sender, RoutedEventArgs e)
            => MessageBox.Show("Nuevo pedido (visual)", "Pedidos");

        private void OpenFilters_Click(object sender, RoutedEventArgs e)
            => MessageBox.Show("Abrir filtros (visual)", "Pedidos");

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

    public sealed class OrderRow(string pedido, string cliente, DateTime fecha, int items, decimal total, string estado)
    {
        public string Pedido { get; } = pedido;
        public string Cliente { get; } = cliente;
        public DateTime Fecha { get; } = fecha;
        public int Items { get; } = items;
        public decimal Total { get; } = total;
        public string Estado { get; } = estado; // "Completado" | "Pendiente" | "Cancelado"
    }
}
