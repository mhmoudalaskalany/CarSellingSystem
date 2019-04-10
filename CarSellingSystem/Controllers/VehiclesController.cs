using System;
using System.Threading.Tasks;
using AutoMapper;
using CarSellingSystem.ApiResources;
using CarSellingSystem.Core;
using CarSellingSystem.Core.Models;
using CarSellingSystem.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace CarSellingSystem.Controllers
{
    [Route("/api/vehicles")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVehicleRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public VehiclesController(IMapper mapper, CarDbContext conteext , IVehicleRepository repository , IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleResource vehicleResource)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(modelState: ModelState);
                var vehicle = _mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
                vehicle.LastUpdate = DateTime.Now;
                _repository.Add(vehicle);
                await _unitOfWork.SaveChangesAsync();
                vehicle = await _repository.GetVehicle(vehicle.Id);
                var result = _mapper.Map<Vehicle, VehicleResource>(vehicle);
                return Ok(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(modelState: ModelState);
            var vehicle = await _repository.GetVehicle(id);
            _mapper.Map(vehicleResource,vehicle);
            vehicle.LastUpdate = DateTime.Now;
            await _unitOfWork.SaveChangesAsync();
            var result = _mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle =await  _repository.GetVehicle(id);
            if (vehicle == null)
                return NotFound();
            _repository.Remove(vehicle);
            await _unitOfWork.SaveChangesAsync();
            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            try
            {
                var vehicle = await _repository.GetVehicle(id);
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