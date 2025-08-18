using System.Windows;

namespace ToxicBizBuddyWPF.Views.Dialogs
{
    public partial class AddClientDialog : Window
    {
        public AddClientDialog()
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
            // 🔜 acá validarías campos; por ahora cerramos con OK
            DialogResult = true;
            Close();
        }
    }
}
