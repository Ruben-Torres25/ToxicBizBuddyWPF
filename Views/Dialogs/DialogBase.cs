using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace ToxicBizBuddyWPF.Views.Dialogs
{
    public class DialogBase : Window
    {
        private readonly Grid _root;
        private readonly ContentPresenter _contentPresenter;

        public DialogBase()
        {
            WindowStyle = WindowStyle.None;
            ResizeMode = ResizeMode.NoResize;
            AllowsTransparency = true;
            Background = Brushes.Transparent;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            WindowState = WindowState.Maximized;
            ShowInTaskbar = false;
            Topmost = true;

            _root = new Grid { Background = new SolidColorBrush(Color.FromArgb(128, 0, 0, 0)) };

            var border = new Border
            {
                Style = (Style)Application.Current.FindResource("CardStyle"),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            border.SetBinding(Border.WidthProperty, new Binding(nameof(CardWidth)) { Source = this });

            var stack = new StackPanel();

            var header = new Grid { Margin = new Thickness(0, 0, 0, 12) };
            header.ColumnDefinitions.Add(new ColumnDefinition());
            header.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            var title = new TextBlock
            {
                Style = (Style)Application.Current.FindResource("H1"),
                FontSize = 20,
                VerticalAlignment = VerticalAlignment.Center
            };
            title.SetBinding(TextBlock.TextProperty, new Binding(nameof(Title)) { Source = this });

            var closeBtn = new Button
            {
                Content = "✕",
                Width = 34,
                Height = 34,
                Background = Brushes.Transparent,
                BorderThickness = new Thickness(0),
                Cursor = System.Windows.Input.Cursors.Hand,
                HorizontalAlignment = HorizontalAlignment.Right,
                ToolTip = "Cerrar"
            };
            closeBtn.Click += Close_Click;
            Grid.SetColumn(closeBtn, 1);

            header.Children.Add(title);
            header.Children.Add(closeBtn);

            _contentPresenter = new ContentPresenter();

            stack.Children.Add(header);
            stack.Children.Add(_contentPresenter);

            border.Child = stack;
            _root.Children.Add(border);
            base.Content = _root;
        }

        public static readonly DependencyProperty CardWidthProperty =
            DependencyProperty.Register(nameof(CardWidth), typeof(double), typeof(DialogBase), new PropertyMetadata(640.0));

        public double CardWidth
        {
            get => (double)GetValue(CardWidthProperty);
            set => SetValue(CardWidthProperty, value);
        }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            if (!ReferenceEquals(newContent, _root))
            {
                _contentPresenter.Content = newContent;
                base.Content = _root;
            }
            else
            {
                base.OnContentChanged(oldContent, newContent);
            }
        }

        protected void Close_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
