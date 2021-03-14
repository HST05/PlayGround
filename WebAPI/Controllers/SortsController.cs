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
    public class SortsController : ControllerBase
    {
        private ISortService _sortService;

        public SortsController(ISortService sortService)
        {
            _sortService = sortService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _sortService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
    }
}
