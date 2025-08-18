using System.Windows;
using System.Windows.Controls;

namespace ToxicBizBuddyWPF.Components
{
    public partial class Pagination : UserControl
    {
        private int _current = 1;
        private int _total = 1;

        public Pagination()
        {
            InitializeComponent();
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            if (PageInfo != null)
                PageInfo.Text = $"Página {_current} de {_total}";
            if (PrevBtn != null)
                PrevBtn.IsEnabled = _current > 1;
            if (NextBtn != null)
                NextBtn.IsEnabled = _current < _total;
        }

        private void PrevBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_current > 1)
            {
                _current--;
                UpdateInfo();
            }
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_current < _total)
            {
                _current++;
                UpdateInfo();
            }
        }
    }
}
