using System.Windows;

namespace ToxicBizBuddyWPF.Views.Dialogs
{
    public partial class AddProviderDialog : Window
    {
        public AddProviderDialog()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            // Solo visual por ahora
            DialogResult = true; // o false si querés distinguir Cancelar
            Close();
        }
    }
}
