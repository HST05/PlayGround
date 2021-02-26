using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Files
{
    public class Image
    {
        public IFormFile ImageFile { get; set; }
    }
}
