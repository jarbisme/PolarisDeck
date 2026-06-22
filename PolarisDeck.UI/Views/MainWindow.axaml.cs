using Avalonia.Controls;
using PolarisDeck.UI.ViewModels;

namespace PolarisDeck.UI.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Opened += (_, _) => (DataContext as MainWindowViewModel)?.LoadDisplays();
    }
}