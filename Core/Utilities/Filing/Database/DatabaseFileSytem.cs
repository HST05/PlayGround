using Core.Abstract;

namespace Core.Utilities.Filing.Database
{
    public abstract class DatabaseFileSytem : IFileSytem
    {
        public abstract byte[] FileToBytes(IFile file);

    }
}
