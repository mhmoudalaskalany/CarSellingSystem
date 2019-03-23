using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace CarSellingSystem.Controllers.BaseController
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private readonly IMapper _mapper;

        public BaseApiController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}