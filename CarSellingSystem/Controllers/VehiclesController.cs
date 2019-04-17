﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CarSellingSystem.ApiResources;
using CarSellingSystem.Core;
using CarSellingSystem.Core.Models;
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

        public VehiclesController(IMapper mapper , IVehicleRepository repository , IUnitOfWork unitOfWork)
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
                await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
                vehicle = await _repository.GetVehicleAsync(vehicle.Id).ConfigureAwait(false);
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
            var vehicle = await _repository.GetVehicleAsync(id).ConfigureAwait(false);
            _mapper.Map(vehicleResource,vehicle);
            vehicle.LastUpdate = DateTime.Now;
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
            var result = _mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle =await  _repository.GetVehicleAsync(id).ConfigureAwait(false);
            if (vehicle == null)
                return NotFound();
            _repository.Remove(vehicle);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            try
            {
                var vehicle = await _repository.GetVehicleAsync(id).ConfigureAwait(false);
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

        [HttpGet]
        public async Task<IEnumerable<VehicleResource>> GetVehicles()
        {
            var vehicles =await  _repository.GetVehiclesAsync().ConfigureAwait(false);
            return _mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleResource>>(vehicles);
        }
    }
}