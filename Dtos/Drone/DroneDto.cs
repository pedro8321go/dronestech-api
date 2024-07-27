using System.ComponentModel.DataAnnotations;

namespace DronesTechAPI.Dtos.Drone;

public class DroneDto
{
    [Required(ErrorMessage = "Serial number is required.")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Serial number size must be in range 0 to 100.")]
    public string SerialNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Device model is required")]
    [RegularExpression("^(peso ligero|peso medio|peso crucero|peso pesado)$",
        ErrorMessage = "Model unknown. Please insert valid one.")]
    public string DeviceModel { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Max weight value is required.")]
    [Range(1, 500, ErrorMessage = "Limit weight value must be in range 1 to 500 grams")]
    public int LimitWeight { get; set; }
    
    [Required(ErrorMessage = "Battery capacity is required.")]
    [Range(0, 100, ErrorMessage = "Battery capacity value must be in range 0 to 100%")]
    public int BatteryCapacity { get; set; }

    [Required(ErrorMessage = "State is required")]
    [RegularExpression("^(INACTIVO|CARGANDO|CARGADO|ENTREGANDO CARGA|CARGA ENTREGADA|REGRESANDO)$",
        ErrorMessage = "State unknown. Please insert valid one.")]
    public string State { get; set; } = string.Empty;

}