using System.Windows;

namespace ToxicBizBuddyWPF.Views.Dialogs
{
    public partial class ConfirmDialog : Window
    {
        public ConfirmDialog()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            // Cerrar con Cancelar (false)
            DialogResult = false;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Botón "Cancelar"
            DialogResult = false;
            Close();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            // Botón "Eliminar" (Aceptar)
            DialogResult = true;
            Close();
        }
    }
}
