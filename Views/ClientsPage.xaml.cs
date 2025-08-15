using System.Windows;
using System.Windows.Controls;
using ToxicBizBuddyWPF.Views.Dialogs;

namespace ToxicBizBuddyWPF.Views
{
    public partial class ClientsPage : Page
    {
        public ClientsPage()
        {
            InitializeComponent();
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            // Solo visual: abre el diálogo de alta de cliente si ya lo tenés creado
            var dlg = new AddClientDialog { Owner = Application.Current.MainWindow };
            dlg.ShowDialog();
        }

        private void DeleteClient_Click(object sender, RoutedEventArgs e)
        {
            // Solo visual: confirma eliminación
            var confirm = new ConfirmDialog { Owner = Application.Current.MainWindow };
            confirm.ShowDialog();
        }
    }
}
