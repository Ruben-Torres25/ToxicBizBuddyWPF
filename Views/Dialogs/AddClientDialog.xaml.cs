using System.Windows;

namespace ToxicBizBuddyWPF.Views.Dialogs
{
    public partial class AddClientDialog : DialogBase
    {
        public AddClientDialog()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // 🔜 acá validarías campos; por ahora cerramos con OK
            DialogResult = true;
            Close();
        }
    }
}
