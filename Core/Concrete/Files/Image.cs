using Core.Abstract;
using Microsoft.AspNetCore.Http;

namespace Core.Concrete.Files
{
    public class Image:IFile
    {
        public IFormFile File { get; set; }
    }
}
