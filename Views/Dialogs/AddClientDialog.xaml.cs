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
    }
}
