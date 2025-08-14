using System.Windows.Controls;

namespace ToxicBizBuddyWPF.Components
{
    public partial class PageWrapper : UserControl
    {
        public PageWrapper()
        {
            InitializeComponent(); // <- esto aparece si el XAML se compila con Build Action = Page
        }
    }
}
