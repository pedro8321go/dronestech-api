using DronesTechAPI.Models;
using DronesTechAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DronesTechAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DronesController: ControllerBase
{
    // register new drone
    [HttpPost]
    public IActionResult RegisterDrone(Drone drone)
    {
        var tmpDrone = DroneService.Get(drone.SerialNumber);
        if (tmpDrone != null)
            return BadRequest("A drone with this serial number exist. Please change this parameters");
        if (drone.BatteryCapacity < 25 && drone.State == "CARGANDO")
            return BadRequest("The battery is below 25%. The state can't be CARGANDO");
        DroneService.Register(drone);
        return Ok(drone);
    }
    
    // Load drone with medicine
    [HttpPost("{serialNumber}/load")]
    public IActionResult LoadDrone(string serialNumber, List<Medicine> medicines)
    {
        var drone = DroneService.Get(serialNumber);
        if (drone == null)
            return NotFound("Drone not found");
        if (drone.State != "CARGANDO" && drone.State != "INACTIVO")
            return BadRequest("Drone is busy. You can't load medicine.");
        if (drone.State != "CARGANDO" && drone.BatteryCapacity < 25)
            return BadRequest("The battery level must be above 25%");
        var totalWeight = drone.Medicines.Sum(m => m.Weight) + medicines.Sum(m => m.Weight);
        if (totalWeight > drone.LimitWeight)
            return BadRequest("The weight of the load exceeds the permitted limit");
        
        drone.Medicines.AddRange(medicines);
        DroneService.Update(drone); // Update drone in the list
        return NoContent();
    }
    
    // Get all drones
    [HttpGet]
    public ActionResult<List<Drone>> GetAll() => DroneService.GetAll();
    
    // Get available drones
    [HttpGet("available")] 
    public ActionResult<List<Drone>> GetAvailable() => DroneService.GetAvailable();
    
    // Get battery level of a drone
    [HttpGet("{serialNumber}/battery")]
    public IActionResult GetBatteryLevel(string serialNumber)
    {
        var drone = DroneService.Get(serialNumber);
        if (drone == null)
            return NotFound("Drone not found");
        return Ok(drone.BatteryCapacity);
    }
    
    // Check load medicine weight 
    [HttpGet("{serialNumber}/weight")]
    public IActionResult CheckMedicinesWeight(string serialNumber)
    {
        var drone = DroneService.Get(serialNumber);
        if (drone == null)
            return NotFound("Drone not found");
        var totalWeight = drone.Medicines.Sum(m => m.Weight);
        return Ok(totalWeight);
    }
    
}