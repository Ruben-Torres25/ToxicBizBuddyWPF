using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ToxicBizBuddyWPF.Views
{
    public partial class Sidebar : UserControl
    {
        public Sidebar()
        {
            InitializeComponent();
            SetActive(BtnDashboard); // activo por defecto
        }

        // Navegación: llamamos al método público del MainWindow
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            if (button.Tag is string route)
                (Application.Current.MainWindow as MainWindow)?.NavigateTo(route);
            SetActive(button);
        }

        // Visual activo
        private void SetActive(Button activeButton)
        {
            foreach (var btn in MenuStack.Children.OfType<Button>())
                btn.Uid = null;

            activeButton.Uid = "active";
        }
    }
}
