using System.Windows;
using System.Windows.Controls;

namespace ToxicBizBuddyWPF.Components
{
    public partial class PrimaryButton : UserControl
    {
        public PrimaryButton()
        {
            InitializeComponent();
        }

        public string Text
        {
            get => InnerButton.Content.ToString();
            set => InnerButton.Content = value;
        }

        public RoutedEventHandler OnClick
        {
            set => InnerButton.Click += value;
        }
    }
}
