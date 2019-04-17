using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CarSellingSystem.ApiResources;
using CarSellingSystem.Core.Models;
using CarSellingSystem.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarSellingSystem.Controllers
{
    [Route("/api/features")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly CarDbContext _context;
        private readonly IMapper _mapper;

        public FeaturesController(CarDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<KeyValuePairResource>> GetFeatures()
        {
            var features = await _context.Features.ToListAsync();
            return _mapper.Map<List<Feature>, List<KeyValuePairResource>>(features);
        }
    }
}
