using System.Windows;

namespace ToxicBizBuddyWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Views.DashboardPage());
        }
    }
}
