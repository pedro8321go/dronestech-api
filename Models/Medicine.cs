using System.ComponentModel.DataAnnotations;
namespace DronesTechAPI.Models;

public class Medicine
{
    [Required(ErrorMessage = "Name is required")]
    [RegularExpression("^[a-zA-Z0-9-_]+$", ErrorMessage = "The name can only contain letters, numbers, hyphens and underscores.")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "Weight value is required.")]
    [Range(1, 500, ErrorMessage = "Limit weight value must be in range 1 to 500 grams")]
    public int Weight { get; set; }  // this value is in grams
    [Required(ErrorMessage = "Code is required")]
    [RegularExpression("^[A-Z0-9_]+$", ErrorMessage = "The code can only contain uppercase letters, numbers and underscores")]
    public string? Code { get; set; }
    [Required(ErrorMessage = "Image URL is required")]
    public string? Image { get; set; }
}