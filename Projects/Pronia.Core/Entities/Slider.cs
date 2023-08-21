namespace Pronia.Core.Entities;

public class Slider:BaseEntity
{
    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Discount { get; set; }

    public string ImageUrl { get; set; } = null!;
}
