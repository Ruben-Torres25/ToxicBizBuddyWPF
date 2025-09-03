using System.Windows;

namespace ToxicBizBuddyWPF.Views.Dialogs
{
    public partial class DialogBase : Window
    {
        public DialogBase()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty CardWidthProperty =
            DependencyProperty.Register("CardWidth", typeof(double), typeof(DialogBase), new PropertyMetadata(640.0));

        public double CardWidth
        {
            get => (double)GetValue(CardWidthProperty);
            set => SetValue(CardWidthProperty, value);
        }

        public void Close_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
