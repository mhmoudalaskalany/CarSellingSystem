using System;
using System.Threading.Tasks;
using AutoMapper;
using CarSellingSystem.ApiResources;
using CarSellingSystem.Models;
using CarSellingSystem.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarSellingSystem.Controllers
{
    [Route("/api/vehicles")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly CarDbContext _context;

        public VehiclesController(IMapper mapper, CarDbContext conteext)
        {
            _mapper = mapper;
            _context = conteext;
        }
        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(modelState:ModelState);
            var vehicle = _mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<Vehicle, SaveVehicleResource>(vehicle);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(modelState: ModelState);
            var vehicle = await  _context.Vehicles.Include(v => v.Features).FirstOrDefaultAsync(v => v.Id == id);
            _mapper.Map(vehicleResource,vehicle);
            vehicle.LastUpdate = DateTime.Now;
            await _context.SaveChangesAsync();
            var result = _mapper.Map<Vehicle, SaveVehicleResource>(vehicle);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle =await  _context.Vehicles.FindAsync(id);
            if (vehicle == null)
                return NotFound();
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            try
            {
                var vehicle = await _context.Vehicles.Include(v => v.Features)
                    .ThenInclude(vf => vf.Feature)
                    .Include(m => m.Model)
                    .ThenInclude(m => m.Make)
                    .FirstOrDefaultAsync(v => v.Id == id);
                if (vehicle == null)
                    return NotFound();
                var result = _mapper.Map<Vehicle, VehicleResource>(vehicle);
                return Ok(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }
    }
}