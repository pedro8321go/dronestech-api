namespace DronesTechAPI.Models;

public class Medicine
{
    //TODO: is necessary validate the fields
    
    public string Name { get; set; }
    public int Weight { get; set; }  // this value is in grams
    public string Code { get; set; }
    public string Image { get; set; }
}