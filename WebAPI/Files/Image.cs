using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Abstract;

namespace WebAPI.Files
{
    public class Image:IFile
    {
        public IFormFile File { get; set; }
    }
}
