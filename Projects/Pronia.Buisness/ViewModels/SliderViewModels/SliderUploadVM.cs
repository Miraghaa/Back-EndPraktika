using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Pronia.Buisness.ViewModels.SliderViewModels;

public class SliderUploadVM
{

    public int Id { get; set; }
    [Required, MaxLength(30), MinLength(5)]
    public string Title { get; set; } = null!;

    [Required, MaxLength(80)]
    public string Description { get; set; } = null!;

    public int Discount { get; set; }

    public IFormFile? Image { get; set; } 

    public string? ImageUrl { get; set; }
}
