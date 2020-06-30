using System.IO;
using SchwabenCode.QuickIO;
using OpenQA.Selenium;

namespace Geeks.Pangolin.Service.Helper.ScreenshotHelper
{
    public class ScreenshotService
    {
        #region [Property]

        private const string Ext = ".jpg";
        private readonly string _screenshotPath;

        #endregion

        #region [Constructor]

        public ScreenshotService(string screenshotPath) => _screenshotPath = screenshotPath;

        #endregion

        #region [Public Method]

        public void Delete(string unitTestName)
        {
            var path = GetPath(unitTestName);
            if (File.Exists(path))
                QuickIOFile.Delete(path);
        }

        public void Create(Screenshot screenshot, string unitTestName)
        {
            Delete(unitTestName);
            screenshot.SaveAsFile(GetPath(unitTestName));
        }
        
        #endregion

        #region [Private Method]

        private string GetPath(string unitTestName) => Path.Combine(_screenshotPath, unitTestName + Ext);

        #endregion
    }
}
