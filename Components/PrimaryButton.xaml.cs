using System.Windows;
using System.Windows.Controls;

namespace ToxicBizBuddyWPF.Components
{
    public partial class PrimaryButton : UserControl
    {
        public PrimaryButton() => InitializeComponent();

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                nameof(Text),
                typeof(string),
                typeof(PrimaryButton),
                new PropertyMetadata(string.Empty));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public event RoutedEventHandler Click
        {
            add { InnerButton.Click += value; }
            remove { InnerButton.Click -= value; }
        }
    }
}
