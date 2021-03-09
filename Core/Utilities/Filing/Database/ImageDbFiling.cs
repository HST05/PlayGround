using System;
using System.IO;
using Core.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Core.Utilities.Filing.Database
{
    public class ImageDbFiling : DatabaseFileSytem
    {
        public override byte[] FileToBytes(IFile file)
        {
            using (var memory = new MemoryStream())
            {
                file.File.CopyTo(memory);
                var fileBytes = memory.ToArray();
                return fileBytes;
            }
        }

        public string BytesToImage(byte[] bytes)
        {
            using (var memory = new MemoryStream(bytes))
            {
                
                //return new FileContentResult(bytes, "image/png");
                return Convert.ToBase64String(bytes);
                //System.IO.File.WriteAllBytes("path",bytes);
            }
        }
    }
}
