using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace ToxicBizBuddyWPF.Views
{
    public partial class OrdersPage : Page
    {
        public ObservableCollection<Pedido> Orders { get; set; }

        public OrdersPage()
        {
            InitializeComponent();

            Orders = new ObservableCollection<Pedido>
            {
                new Pedido { Codigo = "PED001", Cliente = "María García", Fecha = "2024-01-08", Items = "3 items", Total = "$450.00", Estado = "✔ Completado", EstadoColor = new SolidColorBrush(Color.FromRgb(198, 246, 213)) },
                new Pedido { Codigo = "PED002", Cliente = "Carlos López", Fecha = "2024-01-08", Items = "2 items", Total = "$230.50", Estado = "⏳ Pendiente", EstadoColor = new SolidColorBrush(Color.FromRgb(255, 236, 179)) },
                new Pedido { Codigo = "PED003", Cliente = "Ana Rodríguez", Fecha = "2024-01-07", Items = "5 items", Total = "$680.00", Estado = "⏳ Pendiente", EstadoColor = new SolidColorBrush(Color.FromRgb(255, 236, 179)) },
                new Pedido { Codigo = "PED004", Cliente = "Luis Martín", Fecha = "2024-01-07", Items = "2 items", Total = "$320.75", Estado = "❌ Cancelado", EstadoColor = new SolidColorBrush(Color.FromRgb(255, 205, 210)) }
            };

            this.DataContext = this;
        }
    }

    public class Pedido
    {
        public string Codigo { get; set; } = string.Empty;
        public string Cliente { get; set; } = string.Empty;
        public string Fecha { get; set; } = string.Empty;
        public string Items { get; set; } = string.Empty;
        public string Total { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public Brush EstadoColor { get; set; } = Brushes.Transparent;
    }

    public class BoolToVisibilityConverter : IValueConverter
    {
        public bool Invert { get; set; } = false;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isVisible = System.Convert.ToBoolean(value);
            if (Invert)
                isVisible = !isVisible;

            return isVisible ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is Visibility visibility) && visibility == Visibility.Visible;
        }
    }
}
