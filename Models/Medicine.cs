using System.ComponentModel.DataAnnotations;
namespace DronesTechAPI.Models;

public class Medicine
{
    public string Name { get; set; } = string.Empty;
    public int? Weight { get; set; }
    public string Code { get; set; } = string.Empty;
    public string? Image { get; set; } = string.Empty;
}