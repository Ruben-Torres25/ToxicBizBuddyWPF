namespace ToxicBizBuddyWPF.Services;

public interface IDialogService
{
    bool ShowAddClientDialog();
    bool ShowConfirmDialog(string message, string title);
    void ShowMessage(string message, string title);
}
