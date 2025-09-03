using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ToxicBizBuddyWPF.Views
{
    public partial class NewOrderPage : Page
    {
        public NewOrderViewModel VM { get; } = new();

        public NewOrderPage()
        {
            InitializeComponent();
            DataContext = VM;
        }

        // Solo números enteros
        private void NumberOnly(object sender, TextCompositionEventArgs e)
            => e.Handled = !e.Text.All(char.IsDigit);

        private void AddItem_Click(object sender, RoutedEventArgs e) => VM.AddEditorItem();

        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button b && b.Tag is OrderLine line) VM.Items.Remove(line);
        }

        private void CreateOrder_Click(object sender, RoutedEventArgs e)
        {
            if (!VM.Items.Any())
            {
                MessageBox.Show("Agrega al menos un producto.", "Nuevo Pedido", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            MessageBox.Show($"Pedido creado para: {VM.SelectedClient}\nTotal: {VM.Total:C2}", "Nuevo Pedido");
            NavigationService?.GoBack();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) => NavigationService?.GoBack();
    }

    #region VM y modelos

    public class NewOrderViewModel : INotifyPropertyChanged
    {
        // Datos auxiliares de ejemplo
        public ObservableCollection<string> Clients { get; } = new()
        {
            "María García - Calle 45 #67",
            "Carlos López - Av. Central 120",
            "Ana Rodríguez - Ruta 5 Km 10"
        };

        public ObservableCollection<string> SaleConditions { get; } = new()
        {
            "Contado",
            "Con Descuento (10%)",
            "Cuenta Corriente 30 días"
        };

        public ObservableCollection<Product> Products { get; } = new()
        {
            new Product{ Id="DES-1L", Name="Desengrasante 1L", Price=95m },
            new Product{ Id="LAV-5L", Name="Lavandina 5L", Price=95m },
            new Product{ Id="JAB-500", Name="Jabón 500ml", Price=3.5m }
        };

        // Editor (Agregar Producto)
        private Product _editorSelectedProduct;
        public Product EditorSelectedProduct { get => _editorSelectedProduct; set { _editorSelectedProduct = value; OnPropertyChanged(); } }

        private int _editorQuantity = 1;
        public int EditorQuantity { get => _editorQuantity; set { _editorQuantity = Math.Max(1, value); OnPropertyChanged(); } }

        private int _editorDiscountPercent = 0;
        public int EditorDiscountPercent { get => _editorDiscountPercent; set { _editorDiscountPercent = Math.Clamp(value, 0, 100); OnPropertyChanged(); } }

        // Cabecera
        public string SelectedClient { get => _selectedClient; set { _selectedClient = value; OnPropertyChanged(); } }
        private string _selectedClient;

        public string SelectedSaleCondition { get => _selectedSaleCondition; set { _selectedSaleCondition = value; OnPropertyChanged(); Recalc(); } }
        private string _selectedSaleCondition = "Con Descuento (10%)";

        public DateTime? DeliveryDate { get => _deliveryDate; set { _deliveryDate = value; OnPropertyChanged(); } }
        private DateTime? _deliveryDate = DateTime.Today.AddDays(1);

        // Líneas y totales
        public ObservableCollection<OrderLine> Items { get; } = new();

        public decimal Subtotal { get => _subtotal; private set { _subtotal = value; OnPropertyChanged(); } }
        private decimal _subtotal;

        public decimal GeneralDiscount { get => _generalDiscount; private set { _generalDiscount = value; OnPropertyChanged(); } }
        private decimal _generalDiscount;

        public decimal Total { get => _total; private set { _total = value; OnPropertyChanged(); } }
        private decimal _total;

        public NewOrderViewModel()
        {
            Items.CollectionChanged += (_, __) => Recalc();
        }

        public void AddEditorItem()
        {
            if (EditorSelectedProduct is null) return;

            // Si ya existe el mismo producto, acumula cantidad y descuento del editor (promedio simple).
            var existing = Items.FirstOrDefault(i => i.Product?.Id == EditorSelectedProduct.Id);
            if (existing != null)
            {
                existing.Quantity += EditorQuantity;
                existing.DiscountPercent = (existing.DiscountPercent + EditorDiscountPercent) / 2m;
            }
            else
            {
                var line = new OrderLine
                {
                    Product = EditorSelectedProduct,
                    Quantity = EditorQuantity,
                    UnitPrice = EditorSelectedProduct.Price,
                    DiscountPercent = EditorDiscountPercent
                };
                line.PropertyChanged += (_, __) => Recalc();
                Items.Add(line);
            }

            // Reset mínimos del editor
            EditorQuantity = 1;
            EditorDiscountPercent = 0;

            Recalc();
        }

        private void Recalc()
        {
            foreach (var l in Items)
                l.Recalc();

            Subtotal = Items.Sum(l => l.LineTotal);

            var hasGeneralDiscount = (SelectedSaleCondition ?? "").Contains("Descuento");
            GeneralDiscount = hasGeneralDiscount ? Math.Round(Subtotal * 0.10m, 2) : 0m;

            Total = Subtotal - GeneralDiscount;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public override string ToString() => Name;
    }

    public class OrderLine : INotifyPropertyChanged
    {
        private Product _product;
        public Product Product { get => _product; set { _product = value; OnPropertyChanged(); Recalc(); } }

        private int _quantity = 1;
        public int Quantity { get => _quantity; set { _quantity = Math.Max(1, value); OnPropertyChanged(); Recalc(); } }

        private decimal _unitPrice;
        public decimal UnitPrice { get => _unitPrice; set { _unitPrice = Math.Max(0, value); OnPropertyChanged(); Recalc(); } }

        private decimal _discountPercent;
        public decimal DiscountPercent { get => _discountPercent; set { _discountPercent = Math.Clamp(value, 0, 100); OnPropertyChanged(); Recalc(); } }

        private decimal _lineTotal;
        public decimal LineTotal { get => _lineTotal; private set { _lineTotal = value; OnPropertyChanged(); } }

        public void Recalc()
        {
            var gross = Quantity * UnitPrice;
            var disc = Math.Round(gross * (DiscountPercent / 100m), 2);
            LineTotal = gross - disc;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

    #endregion
}
