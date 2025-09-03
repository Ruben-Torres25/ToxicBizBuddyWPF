using System.Windows;

namespace ToxicBizBuddyWPF.Views.Dialogs
{
    public partial class ConfirmDialog : DialogBase
    {
        public ConfirmDialog()
        {
            InitializeComponent();
            CardWidth = 440;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            // Botón "Eliminar" (Aceptar)
            DialogResult = true;
            Close();
        }
    }
}
