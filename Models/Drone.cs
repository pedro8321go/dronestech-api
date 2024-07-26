namespace DronesTechAPI.Models;

public class Drone
{
    //TODO: is necessary validate the fields
    
    public string SerialNumber { get; set; }
    public string DeviceModel { get; set; }
    public int LimitWeight { get; set; }
    public int BatteryCapacity { get; set; }
    public string State { get; set; }
    public List<Medicine> Medicines { get; set; } = new List<Medicine>();
}