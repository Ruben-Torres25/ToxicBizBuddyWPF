using System.Windows;

namespace ToxicBizBuddyWPF.Views.Dialogs
{
    public partial class ConfirmDialog : Window
    {
        public bool Confirmed { get; private set; }

        public ConfirmDialog()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            Confirmed = true; // solo visual
            DialogResult = true;
            Close();
        }
    }
}
