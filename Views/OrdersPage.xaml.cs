using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ToxicBizBuddyWPF.Views
{
    public partial class OrdersPage : Page
    {
        public OrdersPage()
        {
            InitializeComponent();

            var sample = new List<OrderRow>
            {
                new("PED001","María García","2024-01-08","3 items","450.00","Completado"),
                new("PED002","Carlos López","2024-01-08","2 items","230.50","Pendiente"),
                new("PED003","Ana Rodríguez","2024-01-07","5 items","680.00","Pendiente"),
                new("PED004","Luis Martín","2024-01-07","2 items","320.75","Cancelado"),
            };

            DataContext = sample;
        }

        private void NewOrder_Click(object sender, RoutedEventArgs e) =>
            MessageBox.Show("Nuevo Pedido (visual)");

        private void Filters_Click(object sender, RoutedEventArgs e) =>
            MessageBox.Show("Abrir filtros (visual)");

        private static void ShowAction(object sender, string action)
        {
            if (sender is Button b && b.DataContext is OrderRow r)
                MessageBox.Show($"{action} {r.Pedido}", "Pedidos");
        }

        private void ViewOrder_Click(object sender, RoutedEventArgs e) => ShowAction(sender, "Ver");
        private void EditOrder_Click(object sender, RoutedEventArgs e) => ShowAction(sender, "Editar");
        private void DuplicateOrder_Click(object sender, RoutedEventArgs e) => ShowAction(sender, "Duplicar");
        private void DeleteOrder_Click(object sender, RoutedEventArgs e) => ShowAction(sender, "Eliminar");
    }

    public sealed class OrderRow
    {
        public string Pedido { get; }
        public string Cliente { get; }
        public string Fecha { get; }
        public string Items { get; }
        public string Total { get; }
        public string Estado { get; }

        public OrderRow(string pedido, string cliente, string fecha, string items, string total, string estado)
        {
            Pedido = pedido;
            Cliente = cliente;
            Fecha = fecha;
            Items = items;
            Total = total;
            Estado = estado;
        }
    }
}
