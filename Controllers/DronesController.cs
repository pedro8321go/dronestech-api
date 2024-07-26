using DronesTechAPI.Models;
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
        // link to the DroneService
    }
    
    // Load drone with medicine
    [HttpPost("{serialNumber}/load")]
    public IActionResult LoadDrone(string serialNumber, List<Medicine> medicines)
    {
        // link to the DroneService
    }
    
    // Get available drones
    [HttpGet("available")]
    public IActionResult GetAvailableDrones()
    {
        
    }
    
    // Get battery level of a drone
    [HttpGet("{serialNumber}/battery")]
    public IActionResult GetBatteryLevel(string serialNumber)
    {
        
    }
    
    // Check load medicine weight 
    [HttpGet("{serialNumber}/weight")]
    public IActionResult CheckMedicinesWeight(string serialNumber)
    {
        
    }
    
}