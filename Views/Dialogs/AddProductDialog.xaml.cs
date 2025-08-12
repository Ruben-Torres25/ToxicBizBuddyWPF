using System;
using System.Windows;

namespace ToxicBizBuddyWPF.Views.Dialogs
{
    public partial class AddProductDialog : Window
    {
        public AddProductDialog()
        {
            InitializeComponent();

            // No permitir fechas pasadas para el vencimiento:
            ExpiryDatePicker.DisplayDateStart = DateTime.Today;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // solo visual
            Close();
        }

        // Habilita/Deshabilita el DatePicker si marcan "Sin vencimiento"
        private void NoExpiryCheck_Changed(object sender, RoutedEventArgs e)
        {
            if (ExpiryDatePicker == null) return;
            bool noExpiry = NoExpiryCheck.IsChecked == true;
            ExpiryDatePicker.IsEnabled = !noExpiry;
            if (noExpiry) ExpiryDatePicker.SelectedDate = null;
        }
    }
}
