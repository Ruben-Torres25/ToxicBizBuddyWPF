using System.Windows.Controls;

namespace ToxicBizBuddyWPF.Components
{
    public partial class PageHeader : UserControl
    {
        public PageHeader()
        {
            InitializeComponent();
        }

        public string Title
        {
            get => TitleText.Text;
            set => TitleText.Text = value;
        }

        public string Subtitle
        {
            get => SubtitleText.Text;
            set => SubtitleText.Text = value;
        }
    }
}
