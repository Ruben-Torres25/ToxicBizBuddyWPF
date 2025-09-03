using System.Windows;

namespace ToxicBizBuddyWPF.Views.Dialogs
{
    public partial class AddProviderDialog : DialogBase
    {
        public AddProviderDialog()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true; // o false si querés distinguir Cancelar
            Close();
        }
    }
}
