using System.Collections.ObjectModel;
using System.Windows.Input;
using ToxicBizBuddyWPF.Models;
using ToxicBizBuddyWPF.Services;

namespace ToxicBizBuddyWPF.ViewModels;

public class ClientsViewModel : ViewModelBase
{
    private readonly IDialogService _dialogService;

    public ObservableCollection<Client> Clients { get; } = new();

    public ICommand AddClientCommand { get; }
    public ICommand OpenFiltersCommand { get; }
    public ICommand ViewClientCommand { get; }
    public ICommand EditClientCommand { get; }
    public ICommand HistoryClientCommand { get; }
    public ICommand DeleteClientCommand { get; }

    public ClientsViewModel(IDialogService dialogService)
    {
        _dialogService = dialogService;

        AddClientCommand = new RelayCommand(_ => AddClient());
        OpenFiltersCommand = new RelayCommand(_ => _dialogService.ShowMessage("Abrir filtros (visual)", "Clientes"));
        ViewClientCommand = new RelayCommand(_ => _dialogService.ShowMessage("Ver cliente (visual)", "Clientes"));
        EditClientCommand = new RelayCommand(_ => _dialogService.ShowMessage("Editar cliente (visual)", "Clientes"));
        HistoryClientCommand = new RelayCommand(_ => _dialogService.ShowMessage("Historial del cliente (visual)", "Clientes"));
        DeleteClientCommand = new RelayCommand(_ => DeleteClient());
    }

    private void AddClient()
    {
        if (_dialogService.ShowAddClientDialog())
        {
            _dialogService.ShowMessage("Cliente agregado correctamente (visual).", "Clientes");
        }
    }

    private void DeleteClient()
    {
        if (_dialogService.ShowConfirmDialog(string.Empty, "Clientes"))
        {
            _dialogService.ShowMessage("Cliente eliminado (simulado)", "Clientes");
        }
    }
}
