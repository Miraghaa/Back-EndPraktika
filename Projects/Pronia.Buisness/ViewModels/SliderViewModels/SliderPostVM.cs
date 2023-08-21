using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Pronia.Buisness.ViewModels.SliderViewModels;

public class SliderPostVM
{
    [Required,MaxLength(30),MinLength(5)]
    public string Title { get; set; } = null!;
    
    [Required,MaxLength(80)]
    public string Description { get; set; } = null!;
    
    [Required]
    public int Discount { get; set; }

    [Required]
    public IFormFile ImageUrl { get; set; } = null!;
}
