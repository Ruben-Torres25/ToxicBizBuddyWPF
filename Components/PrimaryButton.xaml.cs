using System.Windows;
using System.Windows.Controls;

namespace ToxicBizBuddyWPF.Components
{
    public partial class PrimaryButton : UserControl
    {
        public PrimaryButton() => InitializeComponent();

        public string Text
        {
            get => (string)((ContentPresenter)InnerButton.Content).Content;
            set => ((ContentPresenter)InnerButton.Content).Content = value;
        }

        public event RoutedEventHandler Click
        {
            add { InnerButton.Click += value; }
            remove { InnerButton.Click -= value; }
        }
    }
}
