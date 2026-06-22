namespace PolarisDeck.Core.Models;

public class ServicePlan
{
    public string Name { get; set; } = string.Empty;
    public List<Slide> Slides { get; set; } = [];
}