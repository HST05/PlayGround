using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Files;

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
                var tissueImages = _tissueImageService.GetImagesPerTissue(tissueId).Data;
                List<byte[]> byteImages = new List<byte[]>();

                foreach (var tissueImage in tissueImages)
                {
                    byteImages.Add(tissueImage.Image);
                }

                List<byte[]> images = new List<byte[]>();

                foreach (var byteImage in byteImages)
                {
                    var image = ImageConvert(Convert.ToBase64String(byteImage));
                    images.Add(image);
                }

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public byte[] ImageConvert(string s64String)
        {
            byte[] bytes = null;
            bytes = Convert.FromBase64String(s64String);
            return bytes;
        }
    }
}
