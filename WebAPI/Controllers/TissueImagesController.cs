using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Files;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TissueImagesController : ControllerBase
    {
        private ITissueImageService _tissueImageService;
        public static IWebHostEnvironment _webHostEnvironment;
        public TissueImagesController(ITissueImageService tissueImageService, IWebHostEnvironment webHostEnvironment)
        {
            _tissueImageService = tissueImageService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("imageadd")]
        public IActionResult Add([FromForm] Image imageFile, [FromForm] int tissueId)
        {
            try
            {
                if (imageFile.ImageFile.Length > 0)
                {
                    TissueImage tissueImage = new TissueImage { TissueId = tissueId };
                    var result = _tissueImageService.Add(tissueImage);

                    if (result.Success)
                    {
                        string path = "C:\\Users\\Windows 8\\Desktop\\ChaTho The Programmer\\test\\web api\\";
                        tissueImage.ImagePath = path;

                        Guid guid = Guid.NewGuid();
                        string extension = System.IO.Path.GetExtension(imageFile.ImageFile.FileName);
                        string imageName = $"{guid}" + extension;

                        using (FileStream fileStream = System.IO.File.Create(path + imageName))
                        {
                            imageFile.ImageFile.CopyTo(fileStream);
                            fileStream.Flush();

                            _tissueImageService.Update(tissueImage);
                            return Ok("Uploaded");
                        }
                    }
                    else
                    {
                        return BadRequest(result.Message);
                    }
                }
                else
                {
                    return BadRequest("Not Uploaded");
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
