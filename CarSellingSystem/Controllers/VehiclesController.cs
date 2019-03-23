using System;
using System.Threading.Tasks;
using AutoMapper;
using CarSellingSystem.ApiResources;
using CarSellingSystem.Models;
using CarSellingSystem.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace CarSellingSystem.Controllers
{
    [Route("/api/vehicles")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly CarDbContext _conteext;

        public VehiclesController(IMapper mapper, CarDbContext conteext)
        {
            _mapper = mapper;
            _conteext = conteext;
        }
        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleResource vehicleResource)
        {
            var vehicle = _mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;
            _conteext.Vehicles.Add(vehicle);
            await _conteext.SaveChangesAsync();
            var result = _mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }
    }
}