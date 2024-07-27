using DronesTechAPI.Models;
namespace DronesTechAPI.Services;

public class DroneService
{
    private static List<Drone> Drones { get; }
    private static List<Medicine> Medicines { get; }

    static DroneService()
    {
        Medicines = new List<Medicine>
        {
            new Medicine
            {
                Code = "ADS-345",
                Name = "Paracetamol",
                Weight = 24,
                Image = "paracetamol.jpg"
            },
            new Medicine
            {
                Code = "ADS-346",
                Name = "Naproxeno",
                Weight = 100,
                Image = "naproxenp.jpg"
            },
            new Medicine
            {
                Code = "ADS-347",
                Name = "Diclofenaco",
                Weight = 10,
                Image = "diclofenaco.jpg"
            },
        };
        
        Drones = new List<Drone>
        {
            new Drone
            {
                SerialNumber = "ADF-456-DS",
                DeviceModel = "peso ligero",
                LimitWeight = 345,
                BatteryCapacity = 46,
                State = "CARGANDO",
                Medicines = Medicines
            },
            new Drone
            {
                SerialNumber = "ADF-456-DA",
                DeviceModel = "peso crucero",
                LimitWeight = 500,
                BatteryCapacity = 45,
                State = "INACTIVO"
            },
            new Drone
            {
                SerialNumber = "ADF-456-DB",
                DeviceModel = "peso medio",
                LimitWeight = 400,
                BatteryCapacity = 69,
                State = "REGRESANDO"
            }
        };
    }

    public static List<Drone> GetAll() => Drones;

    public static Drone? Get(string serialNumber) => Drones.FirstOrDefault(d => d.SerialNumber == serialNumber);

    public static void Register(Drone drone)
    {
        Drones.Add(drone);
    }

    public static List<Drone> GetAvailable() => Drones.Where(d => d.State == "INACTIVO").ToList();

    public static void Update(Drone drone)
    {
        var index = Drones.FindIndex(d => d.SerialNumber == drone.SerialNumber);
        if (index == -1)
            return;
        Drones[index] = drone;
    }
}