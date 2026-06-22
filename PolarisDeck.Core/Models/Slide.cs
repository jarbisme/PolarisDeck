namespace PolarisDeck.Core.Models;

public class Slide
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public SlideType Type { get; set; }
    public string Label { get; set; } = string.Empty;
    public string? Content { get; set; }   // Text slides
    public string? FilePath { get; set; }  // Image / Video slides
    public TextStyle? TextStyle { get; set; }
}

public enum SlideType { Text, Image, Video }