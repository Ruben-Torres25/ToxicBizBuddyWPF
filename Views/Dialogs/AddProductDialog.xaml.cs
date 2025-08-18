using System;
using System.Windows;

namespace ToxicBizBuddyWPF.Views.Dialogs
{
    public partial class AddProductDialog : Window
    {
        public AddProductDialog()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // 🔜 acá podrías validar (nombre obligatorio, etc.)
            // Por ahora, cerramos como OK para que la página sepa que se “guardó”.
            DialogResult = true;
            Close();
        }

        private void NoExpiryCheck_Changed(object sender, RoutedEventArgs e)
        {
            // Habilita/Deshabilita el DatePicker según el checkbox
            if (ExpiryDatePicker != null)
            {
                bool noExpiry = NoExpiryCheck?.IsChecked == true;
                ExpiryDatePicker.IsEnabled = !noExpiry;
                if (noExpiry)
                {
                    ExpiryDatePicker.SelectedDate = null;
                }
            }
        }
    }
}
