using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using PolarisDeck.Core.Services;
using PolarisDeck.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PolarisDeck.UI.Services;

public class DisplayService : IDisplayService
{
    private PresentationView? _contentView;
    public void CloseDisplay()
    {
        throw new System.NotImplementedException();
    }

    public IReadOnlyList<DisplayInfo> GetDisplays()
    {
        var screens = (Application.Current?.ApplicationLifetime
            as IClassicDesktopStyleApplicationLifetime)?.MainWindow?.Screens;

        if (screens is null) return [];

        return screens.All
            .Select((screen, index) => new DisplayInfo(
                Index: index,
                Name: $"Display {index + 1} - {screen.DisplayName}",
                IsPrimary: screen.IsPrimary,
                Width: screen.Bounds.Width,
                Height: screen.Bounds.Height))
            .ToList();
    }

    public void OpenOnDisplay(DisplayInfo displayInfo)
    {
        Debug.WriteLine($"Opening on display: {displayInfo.Name}");
        _contentView = new PresentationView { DataContext = new PresentationViewModel() };

        _contentView.Position = new PixelPoint(displayInfo.Width, displayInfo.Height);
        _contentView.WindowState = WindowState.Maximized;

        _contentView.Show();
    }


}