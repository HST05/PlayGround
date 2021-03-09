using System;
using Core.Abstract;

namespace Core.Utilities.Filing.Local
{
    public abstract class LocalFileSystem : IFileSytem
    {
        public abstract string Path { get; }
        public abstract void Filing(IFile file, string guid);

    }
}
