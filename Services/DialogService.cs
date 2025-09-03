using System.Windows;
using ToxicBizBuddyWPF.Views.Dialogs;

namespace ToxicBizBuddyWPF.Services;

public class DialogService : IDialogService
{
    public bool ShowAddClientDialog()
    {
        var dlg = new AddClientDialog { Owner = Application.Current.MainWindow };
        return dlg.ShowDialog() == true;
    }

    public bool ShowConfirmDialog(string message, string title)
    {
        var dlg = new ConfirmDialog { Owner = Application.Current.MainWindow, Title = title };
        return dlg.ShowDialog() == true;
    }

    public void ShowMessage(string message, string title)
        => MessageBox.Show(message, title);
}
