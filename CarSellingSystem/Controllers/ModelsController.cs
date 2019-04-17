using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CarSellingSystem.ApiResources;
using CarSellingSystem.Core;
using CarSellingSystem.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarSellingSystem.Controllers
{
    [Route("/api/models")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IModelRepository _repository;

        public ModelsController(IMapper mapper, IModelRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<KeyValuePairResource>> GetModels()
        {
            var models = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<Model>,IEnumerable<KeyValuePairResource>>(models);
        }
    }
}