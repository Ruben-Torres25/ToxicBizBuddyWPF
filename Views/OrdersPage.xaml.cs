<<<<<<< HEAD
﻿using System.Collections.Generic;
=======
﻿using System;
using System.Collections.Generic;
using System.Globalization;
>>>>>>> a329dd8124ab2afba73f0c06f64a303217b0fb93
using System.Windows;
using System.Windows.Controls;

namespace ToxicBizBuddyWPF.Views
{
    public partial class OrdersPage : Page
    {
        public OrdersPage()
        {
            InitializeComponent();
<<<<<<< HEAD

            // Datos de ejemplo (idéntico a la maqueta)
            var sample = new List<OrderRow>
            {
                new("PED001","María García","2024-01-08","3 items","450.00","Completado"),
                new("PED002","Carlos López","2024-01-08","2 items","230.50","Pendiente"),
                new("PED003","Ana Rodríguez","2024-01-07","5 items","680.00","Pendiente"),
                new("PED004","Luis Martín","2024-01-07","2 items","320.75","Cancelado"),
            };

            DataContext = sample;
        }

        // ---- Clicks (placeholders)
        private void NewOrder_Click(object sender, RoutedEventArgs e) =>
            MessageBox.Show("Nuevo Pedido (visual)");

        private void Filters_Click(object sender, RoutedEventArgs e) =>
            MessageBox.Show("Abrir filtros (visual)");

        private void ViewOrder_Click(object sender, RoutedEventArgs e) =>
            ShowAction(sender, "Ver");

        private void EditOrder_Click(object sender, RoutedEventArgs e) =>
            ShowAction(sender, "Editar");

        private void DuplicateOrder_Click(object sender, RoutedEventArgs e) =>
            ShowAction(sender, "Duplicar");

        private void DeleteOrder_Click(object sender, RoutedEventArgs e) =>
            ShowAction(sender, "Eliminar");

        private static void ShowAction(object sender, string action)
        {
=======
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
>>>>>>> a329dd8124ab2afba73f0c06f64a303217b0fb93
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

<<<<<<< HEAD
        public OrderRow(string pedido, string cliente, string fecha, string items, string total, string estado)
        {
            Pedido = pedido;
            Cliente = cliente;
            Fecha = fecha;
            Items = items;
            Total = total;
            Estado = estado;
=======
        public OrderRow(string pedido, string cliente, DateTime fecha, int items, decimal total, string estado)
        {
            Pedido = pedido;
            Cliente = cliente;
            Fecha = fecha.ToString("yyyy-MM-dd");
            Items = items == 1 ? "1 item" : $"{items} items";
            Total = total.ToString("$0.00", CultureInfo.InvariantCulture);
            Estado = estado; // "Completado" | "Pendiente" | "Cancelado"
>>>>>>> a329dd8124ab2afba73f0c06f64a303217b0fb93
        }
    }
}
