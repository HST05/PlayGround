using System.IO;
using Core.Abstract;

namespace Core.Utilities.Filing.Local
{
    public class ImageLocalFiling : LocalFileSystem
    {
        public string Path
        {
            get { return _path; }
        }

        static string _path = "C:\\Users\\Windows 8\\Desktop\\ChaTho The Programmer\\test\\web api\\";
        public override void Filing(IFile file, string guid)
        {
            string extension = System.IO.Path.GetExtension(file.File.FileName);
            string imageName = $"{guid}" + extension;

            using (FileStream fileStream = System.IO.File.Create(_path + imageName))
            {
                file.File.CopyTo(fileStream);
                fileStream.Flush();
            }
        }
    }
}
