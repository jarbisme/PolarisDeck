using System.Collections.Generic;

namespace PolarisDeck.Core.Services;

public record DisplayInfo(int Index, string Name, bool IsPrimary, int Width, int Height);

public interface IDisplayService
{
    IReadOnlyList<DisplayInfo> GetDisplays();
    void OpenOnDisplay(DisplayInfo displayIndex);
    void CloseDisplay();
}