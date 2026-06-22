using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PolarisDeck.Core.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace PolarisDeck.UI.ViewModels;

public partial class MainWindowViewModel(IDisplayService displayService) : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<DisplayInfo> _displays = [];
    [ObservableProperty]
    private DisplayInfo? _selectedDisplay;


    public void LoadDisplays()
    {
        Displays = [.. displayService.GetDisplays()];
    }

    [RelayCommand]
    private void SelectDisplay()
    {
        if (SelectedDisplay != null)
        {
            displayService.OpenOnDisplay(SelectedDisplay!);
        }
    }
}
