using System.Windows.Controls;
using ToxicBizBuddyWPF.Services;
using ToxicBizBuddyWPF.ViewModels;

namespace ToxicBizBuddyWPF.Views;

public partial class ClientsPage : Page
{
    public ClientsPage()
    {
        InitializeComponent();
        DataContext = new ClientsViewModel(new DialogService());
    }
}
