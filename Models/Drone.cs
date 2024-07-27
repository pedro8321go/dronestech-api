using System.ComponentModel.DataAnnotations;
namespace DronesTechAPI.Models;

public class Drone
{
    public string SerialNumber { get; set; } = string.Empty;
    public string DeviceModel { get; set; } = string.Empty;
    public int LimitWeight { get; set; } 
    public int BatteryCapacity { get; set; }
    public string State { get; set; } = string.Empty;
    public List<Medicine> Medicines { get; set; } = new List<Medicine>();

}