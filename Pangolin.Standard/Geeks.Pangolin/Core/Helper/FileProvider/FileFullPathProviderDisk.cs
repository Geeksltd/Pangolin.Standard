using System.IO;
using System.Linq;
using System.Reflection;

namespace Geeks.Pangolin.Core.Helper.FileProvider
{
    public class FileFullPathProviderDisk : IFileFullPathProvider
    {
        #region [Property]

        private readonly Assembly _assembly;

        #endregion

        #region [Constructor]

        public FileFullPathProviderDisk(string dllPath)
        {
            _assembly = Assembly.LoadFile(dllPath);
        }

        #endregion

        #region [Public Method]

        public FileInfo GetFullPath(string name) => GetEmbeddedFilePath(name);


        #endregion

        #region [Private Method]

        private FileInfo GetEmbeddedFilePath(string name)
        {
            var fileDirectoryPath = (Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Uploadable.Files"))
                .AsDirectory().EnsureExists();

            var fullPath = Path.Combine(fileDirectoryPath.FullName, name);

            if (File.Exists(fullPath))
                File.Delete(fullPath);

            var resourceName = "." + "Uploadable.Files" + "." + name;
            var resourceFileName = _assembly.GetManifestResourceNames().FirstOrDefault(c => c.Contains(resourceName));

            if (!string.IsNullOrEmpty(resourceFileName))
            {
                using (var stream = _assembly.GetManifestResourceStream(resourceFileName))
                    if (stream != null)
                    {
                        using (var fileStream = new System.IO.FileStream(fullPath, System.IO.FileMode.Create))
                        {
                            for (var i = 0; i < stream.Length; i++)
                                fileStream.WriteByte((byte)stream.ReadByte());
                            fileStream.Close();
                        }
                    }
            }

            return fileDirectoryPath.GetFile(name);
        }


        private void DeleteFiles(string path)
        {
            if (Directory.Exists(path))
            {
                foreach (var file in Directory.GetFiles(path))
                    File.Delete(file);

                foreach (var directory in Directory.GetDirectories(path))
                    DeleteFiles(directory);
            }
        }

        #endregion

    }
}
