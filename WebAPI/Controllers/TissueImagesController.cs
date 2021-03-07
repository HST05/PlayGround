using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core.Concrete.Files;

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

        [HttpPost("addimage")]
        public IActionResult Add([FromForm] Image file, [FromForm] int tissueId)
        {
            try
            {
                var result = _tissueImageService.Add(file, tissueId);

                if (result.Success)
                {
                    return Ok("Uploaded");
                }

                return BadRequest(result.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getimage")]
        public IActionResult Get(int tissueId)
        {
            try
            {
                var result = _tissueImageService.GetImagesPerTissue(tissueId);

                if (result.Success)
                {
                    return Ok(result.Data);
                }

                return BadRequest(result.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
