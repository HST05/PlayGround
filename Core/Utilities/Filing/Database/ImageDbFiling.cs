using System.IO;
using Core.Abstract;

namespace Core.Utilities.Filing.Database
{
    public class ImageDbFiling : DatabaseFileSytem
    {
        public override byte[] Filing(IFile file)
        {
            using (var memory = new MemoryStream())
            {
                file.File.CopyTo(memory);
                var fileBytes = memory.ToArray();
                return fileBytes;
            }
        }
    }
}
