using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Abstract
{
    public interface IFile
    {
        IFormFile File { get; set; }
    }
}
