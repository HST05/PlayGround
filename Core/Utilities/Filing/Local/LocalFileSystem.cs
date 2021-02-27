using Core.Abstract;

namespace Core.Utilities.Filing.Local
{
    public class LocalFileSystem : IFileSytem
    {
        public string Path { get; }
        public virtual void Filing(IFile file, string guid)
        {
        }
    }
}
