using System.IO;
using Geeks.Pangolin.Core.Exception;
using Geeks.Pangolin.Core.Helper;
using Geeks.Pangolin.Core.Helper.Targets;

namespace Geeks.Pangolin.Service.Helper.FileFinder
{
    public class FileFinder
    {
        #region [Property]

        readonly DirectoryInfo _downloadFolder;

        #endregion

        #region [Constructor]

        public FileFinder(DirectoryInfo downloadFolder) => _downloadFolder = downloadFolder;

        #endregion

        #region [Public Method]

        public FileInfo[] FindFiles(ActionTarget target)
        {
            var pattern = string.Empty;
            var hasWildcard = target.Text.ContainsAny(new char[] { '*', '?' });
            if (hasWildcard && (target.SearchType != SearchType.EqualityExact || target.SearchType != SearchType.EqualityIgnore))
                throw new SyntaxErrorException("File-system wild-cards are supported only in Equality mode (i.e. not inside quotation mark or [])");

            if (target.SearchType == SearchType.EqualityExact || target.SearchType == SearchType.EqualityIgnore)
            {
                if (hasWildcard)
                    throw new SyntaxErrorException("File-system wild-cards are not supported in case-sensitive [Exact] pattern");

                pattern = target.Text;
            }
            else if (target.SearchType == SearchType.ContainsIgnore || target.SearchType == SearchType.ContainsExact)
            {
                if (hasWildcard)
                    throw new SyntaxErrorException("File-system wild-cards are not supported in case-sensitive [contains] pattern");
                pattern = "*" + target.Text + "*";
            }

            return _downloadFolder.GetFiles(pattern);
        }

        public FileInfo FindFile(string fileName) => _downloadFolder.GetFile(fileName);

        #endregion

        #region [Private Method]

        #endregion
    }
}
