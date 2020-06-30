using Geeks.Pangolin.Core.Helper;
using Geeks.Pangolin.Helper.Execution;
using OpenQA.Selenium;
using Geeks.Pangolin.Service.DriverService;
using Geeks.Pangolin.Helper.UIContext;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace Geeks.Pangolin
{
    public class UITest : UIContext, IDisposable
    {
        /// <summary>
        /// Use this constructor when using OneTimeSetup or no Setup in this class to create WebDriverService for all tests in this TestFixture class only
        /// </summary>
        public UITest() : base()
        {

        }

        /// <summary>
        /// Use this constructor when NOT Using OneTimeSetup to create a WebDriverService for all tests in this TestFixture class only
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="baseUrl"></param>
        public UITest(Browser browser, string baseUrl) : base()
        {
            SetupTests(browser, baseUrl);
        }

        public void Dispose()
        {
            if (Disposing) return;
            try
            {
                Disposing = true;
                TestRunner?.Dispose();
                TestRunner = null;

                if (WebDriverService!=null && WebDriverService.AutoDispose) { 
                    WebDriverService.DisposeService();
                    WebDriverService = null;
                }
            }
            finally
            {
                Disposing = false;
            }
        }

        /// <summary>
        /// Use this constructur when using SetupFixture to share WebDriverService between all tests in many TestFixture classes
        /// </summary>
        /// <param name="seleniumWebDriverService">The WebDriverService from previous call to UITest.SetupWebDriverService()</param>
        public UITest(SeleniumWebDriverService seleniumWebDriverService)
        {
            WebDriverService = seleniumWebDriverService;
        }

        #region [Property]
        internal bool Disposing { get; private set; }
        internal bool TearingDownTest { get; private set; }

        public string BaseUrl { get; protected set; }
        public IWebDriver WebDriver => WebDriverService.Driver;
        #endregion

        #region [Public Method]

        /// <summary>
        /// One time setup for a group of tests
        /// </summary>
        /// <param name="appBaseUrl"></param>
        public void SetupTests(Browser? browser=null, string baseUrl = null)
        {
            WebDriverService = SetupWebDriverService(browser, baseUrl);
        }

        public new static SeleniumWebDriverService SetupWebDriverService(Browser? browser = null, string baseUrl = null) => UIContext.SetupWebDriverService(browser, baseUrl);

        public void TeardownTests()
        {
            WebDriverService?.DisposeService();
        }

        public void SetupTest(string testName=null)
        {
            TestRunner = new TestRunner(this, testName);
        }

        public void TeardownTest()
        {
            if (TearingDownTest) return;
            try
            {
                TearingDownTest = true;

                TestRunner?.Dispose();
                TestRunner = null;
            }
            finally
            {
                TearingDownTest = false;
            }
        }

        /// <summary>
        /// Tries to execute multiple action delegates and rethrows all exceptions thrown in aggregate
        /// </summary>
        /// <param name="actions">One or more delegate actions to execute</param>
        public void Try(params Action[] actions)
        {
            var exceptions = new List<Exception>();
            foreach (var action in actions)
            {
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }
            if (exceptions.Count == 1) throw exceptions[0];
            if (exceptions.Count > 1) throw new AggregateException(exceptions);
        }
        #endregion

        #region [Private Method]

        #endregion
    }
}
