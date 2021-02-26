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
        public string Add([FromForm] Image image)
        {

            try
            {
                if (image.ImageFile.Length > 0)
                {
                    string path = "C:\\Users\\Windows 8\\Desktop\\ChaTho The Programmer\\test\\web api\\";
                    Guid guid = Guid.NewGuid();
                    string ext = System.IO.Path.GetExtension(image.ImageFile.FileName);
                    string imageName = $"{guid}" + ext;

                    using (FileStream fileStream = System.IO.File.Create(path + imageName))
                    {
                        image.ImageFile.CopyTo(fileStream);
                        fileStream.Flush();
                        return "uploaded.";
                    }
                }
                else
                {
                    return "not uploaded";
                }
            }
            catch (Exception e)
            {

                return e.Message;
            }



            //var result = _tissueImageService.Add(tissueImage);
            //if (result.Success)
            //{
            //    return Ok(result);
            //}

            //return BadRequest(result);
        }
    }
}
