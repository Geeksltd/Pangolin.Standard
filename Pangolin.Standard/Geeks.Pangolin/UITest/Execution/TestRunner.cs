using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using AngleSharp.Html;
using Geeks.Pangolin.Core.Helper;
using Geeks.Pangolin.Core.Parameters;
using Geeks.Pangolin.Service.Helper.ScreenshotHelper;

namespace Geeks.Pangolin.Helper.Execution
{
    public class TestRunner : IDisposable
    {
        #region [Property]
        public bool Disposing { get; private set; }
        private readonly UITest _uiTest;
        private readonly ScreenshotService ScreenshotService;
        public readonly string CurrentFullTestName;
        public readonly DateTime StartDateTime;
        public bool IsTestFailed { get; set; } = false;
        public string TestFailedMsg { get; set; } = string.Empty;

        #endregion

        #region [Constructor]

        public TestRunner(UITest uiTest, string testName = null)
        {
            _uiTest = uiTest;
            StartDateTime = DateTime.Now;
            CurrentFullTestName = string.IsNullOrWhiteSpace(testName) ? GetUnitTestFullName() : testName;
            ScreenshotService = new ScreenshotService(Path.Combine(AppConstants.ProjectPath, "Screenshots").AsDirectory().EnsureExists().FullName);
            IsTestFailed = false;
            TestFailedMsg = string.Empty;
        }

        #endregion

        #region [Public Method]
        public void Dispose()
        {
            if (Disposing) return;
            try
            {
                Disposing = true;
                if (IsTestFailed) TakeScreenshot();
            }
            finally
            {
                Disposing = false;
            }
        }

        public void TakeScreenshot(string testCaseName = null)
        {
            if (string.IsNullOrWhiteSpace(testCaseName)) testCaseName = CurrentFullTestName;
            ScreenshotService.Create(_uiTest.WebDriverService.GetScreenshot(), testCaseName);
        }


        public void DisposeService()
        {
        }

        #endregion

        #region [Private Method]
        public static string GetUnitTestName()
        {
            return GetTestDetail().testName;
        }

        public static string GetUnitTestFullName()
        {
            string result = null;
            var testDetail = GetTestDetail();
            if (!string.IsNullOrEmpty(testDetail.className) && !string.IsNullOrEmpty(testDetail.testName))
            {
                result = testDetail.className + "." + testDetail.testName;
            }
            return result;
        }

        private static (string className, string testName) GetTestDetail()
        {
            var frames = new StackTrace(true).GetFrames();
            //The following line needs to be last or default otherwise it can return a delegate action within a UI.Test method and not the method itself
            var testClassType = frames?.LastOrDefault(c => c.GetMethod()?.DeclaringType?.BaseType == typeof(UITest));
            var method = testClassType?.GetMethod();
            return (method?.DeclaringType?.Name, method?.Name);
        }

        #endregion

    }
}
