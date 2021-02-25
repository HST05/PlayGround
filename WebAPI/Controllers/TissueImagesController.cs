using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TissueImagesController : ControllerBase
    {
        private ITissueImageService _tissueImageService;

        public TissueImagesController(ITissueImageService tissueImageService)
        {
            _tissueImageService = tissueImageService;
        }

        [HttpPost("imageadd")]
        public IActionResult Add(TissueImage tissueImage)
        {
            var result = _tissueImageService.Add(tissueImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
