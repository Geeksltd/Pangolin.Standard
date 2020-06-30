using OpenQA.Selenium;
using System.IO;
using Geeks.Pangolin.Core.Exception;
using Geeks.Pangolin.Core.Helper.Context;
using Geeks.Pangolin.Core.Helper.FileProvider;
using Geeks.Pangolin.Core.Helper;

namespace Geeks.Pangolin.Service.Dom
{
    public class FileInput : Field
    {
        #region [Property]

        IFileFullPathProvider FileFullPathProvider;

        #endregion

        #region [Constructor]

        public FileInput(IFileFullPathProvider fileFullPathProvider, IWebElement domElement, WebContext context, WebElementCache cache) : base(domElement, context, cache) => FileFullPathProvider = fileFullPathProvider;

        #endregion

        #region [Public Method]

        #endregion

        #region [Private Method]

        protected override void UnsafeSendKeys(string filename)
        {
            var fullPath = filename;
            if (!Path.IsPathRooted(filename))
                fullPath = (FileFullPathProvider.GetFullPath(filename)).FullName;

            if (fullPath.IsEmpty() || !File.Exists(fullPath))
                throw new DataFileNotFoundException($"file {filename} not found");

            DomElement.SendKeys(fullPath);
        }

        #endregion
    }
}
