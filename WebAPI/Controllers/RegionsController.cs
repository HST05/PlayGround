using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private IRegionService _regionService;

        public RegionsController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _regionService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
    }
}
