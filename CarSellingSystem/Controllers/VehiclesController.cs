using AutoMapper;
using CarSellingSystem.ApiResources;
using CarSellingSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarSellingSystem.Controllers
{
    [Route("/api/vehicles")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IMapper _mapper;

        public VehiclesController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult CreateVehicle([FromBody] VehicleResource vehicleResource)
        {
            var vehicle = _mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            return Ok(vehicle);
        }
    }
}