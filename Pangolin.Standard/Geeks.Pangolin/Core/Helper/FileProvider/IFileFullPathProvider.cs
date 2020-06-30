using System.IO;

namespace Geeks.Pangolin.Core.Helper.FileProvider
{
    public interface IFileFullPathProvider
    {
        FileInfo GetFullPath(string name);
    }
}
