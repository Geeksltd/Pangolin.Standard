
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using Geeks.Pangolin.Core.Drivers.WebDriver;
using Geeks.Pangolin.Core.Exception;
using Geeks.Pangolin.Core.Helper;
using Geeks.Pangolin.Core.Helper.ClipboardManager;
using Geeks.Pangolin.Core.Helper.Context;
using Geeks.Pangolin.Core.Helper.FileProvider;
using Geeks.Pangolin.Core.Helper.Targets;
using Geeks.Pangolin.Service.Commands;
using Geeks.Pangolin.Service.Helper.FileFinder;
using Geeks.Pangolin.Core.Parameters;
using SchwabenCode.QuickIO;
using Geeks.Pangolin.Core.Drivers.WebDriver.Browsers;
using Geeks.Pangolin.Service.Helper.Extensions;
using System.Collections.ObjectModel;
using Geeks.Pangolin.Helper.UIContext;

namespace Geeks.Pangolin.Service.DriverService
{
    public class SeleniumWebDriverService
    {
        private Browser _browser;
        private string _baseUrl;

        #region [Constructor]

        internal SeleniumWebDriverService(Browser? browser, string baseUrl = null, bool autoDispose = false)
        {
            _browser = browser==null ? UISetting.Instance.Browser : browser.Value;
            baseUrl = string.IsNullOrWhiteSpace(baseUrl) ? UISetting.Instance.AppBaseUrl : baseUrl;
            if (string.IsNullOrWhiteSpace(baseUrl)) throw new ArgumentNullException(nameof(baseUrl));
            _baseUrl = baseUrl;
            AutoDispose = autoDispose;
        }

        #endregion

        #region [Property]
        internal readonly bool AutoDispose;

        private WebContext WebContext;
        private WebDriverManager DriverManager { get; set; }
        private SupportedBrowser _supportedBrowser;
        private SupportedBrowser SupportedBrowser
        {
            get
            {
                if (_supportedBrowser == null)
                    _supportedBrowser = GetSupportedBrowser();
                else
                    return _supportedBrowser;

                return _supportedBrowser;
            }
        }
        private FileFinder _fileFinder;
        private FileFinder FileFinder
        {
            get
            {
                if (_fileFinder == null)
                    _fileFinder = new FileFinder(UISetting.Instance.DownloadUrl?.AsDirectory().EnsureExists());
                else
                    return _fileFinder;

                return _fileFinder;
            }
        }


        private IExtendedRemoteWebDriver seleniumWebDriver;
        public IExtendedRemoteWebDriver Driver
        {
            get
            {
                if (seleniumWebDriver == null)
                    seleniumWebDriver = StartBrowser(_baseUrl);

                return seleniumWebDriver;
            }
        }

        #endregion

        
        #region [Public Methods]

        public void SetDefaultContent()
        {
            WebContext.Browser.SwitchTo().DefaultContent();
            WebContext.Browser.CurrentFrame = null;
        }

        public void InitDriver()
        {
            if (WebContext.Browser != null)
            {
                CloseTabs();
                AcceptAnyAlert();
            }
        }

        public bool HasAnyDialog()
        {
            try
            {
                return WebContext.Browser.SwitchTo() != null && WebContext.Browser.SwitchTo().Alert() != null;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }

        }

        public void ExpectAlertText(string text, SearchType searchType, bool expect = true)
        {
            try
            {
                if (HasAnyDialog())
                {
                    bool GetLabelCheckFunction(string txt)
                    {
                        if (text.HasValue())
                        {
                            if (searchType == SearchType.EqualityExact)
                                return text == txt;

                            if (searchType == SearchType.EqualityIgnore)
                                return txt?.Trim().Equals(text.Trim(), StringComparison.InvariantCultureIgnoreCase) == true;

                            if (searchType == SearchType.Wildcard)
                            {
                                text = "^" + text.Replace("{digit}", "[0-9]{1}").Replace("{letter}", "[a-zA-Z]{1}") + "$";
                                return Regex.IsMatch(text, txt);
                            }

                            if (searchType == SearchType.ContainsIgnore)
                                return txt?.IndexOf(text, StringComparison.InvariantCultureIgnoreCase) >= 0;

                            if (searchType == SearchType.ContainsExact)
                                return txt?.IndexOf(text, StringComparison.InvariantCulture) >= 0;
                        }

                        return true;
                    }

                    var alert = new List<IAlert>() { WebContext.Browser.SwitchTo().Alert() };
                    if (text.HasValue())
                    {
                        alert.RemoveAll(r => GetLabelCheckFunction(r.Text) == false);

                        if (!expect && alert.Any())
                            throw new ExpectationFailedException($"Found {text}");

                        if (expect && !alert.Any())
                            throw new ExpectationFailedException($"Found no {text}");
                    }
                }
                else
                {
                    if (expect)
                    {
                        Error($"Found no alert {text}");
                    }

                }
            }
            catch (UnhandledAlertException)
            {
                IAlert alert = WebContext.Browser.SwitchTo().Alert();
                alert?.Accept(); // or alert.Dismiss(); depends on your needs
            }
            catch (WebDriverException)
            {
            }
            catch (KeyNotFoundException)
            {
            } // Chrome
            catch (InvalidOperationException)
            {
            }
            catch (IndexOutOfRangeException)
            {
            } // No window handles
            catch (ArgumentOutOfRangeException)
            {
            }
        }

        public void AcceptAnyAlert()
        {
            try
            {
                if (HasAnyDialog())
                    WebContext.Browser.SwitchTo().Alert().Accept();
            }
            catch (UnhandledAlertException)
            {
                IAlert alert = WebContext.Browser.SwitchTo().Alert();
                alert?.Accept(); // or alert.Dismiss(); depends on your needs
            }
            catch (WebDriverException)
            {
            }
            catch (KeyNotFoundException)
            {
            } // Chrome
            catch (InvalidOperationException)
            {
            }
            catch (IndexOutOfRangeException)
            {
            } // No window handles
            catch (ArgumentOutOfRangeException)
            {
            }
        }

        public void CancelAnyAlert()
        {
            try
            {
                if (HasAnyDialog())
                    WebContext.Browser.SwitchTo().Alert().Dismiss();
            }
            catch (UnhandledAlertException)
            {
                IAlert alert = WebContext.Browser.SwitchTo().Alert();
                alert?.Accept(); // or alert.Dismiss(); depends on your needs
            }
            catch (WebDriverException)
            {
            }
            catch (KeyNotFoundException)
            {
            } // Chrome
            catch (InvalidOperationException)
            {
            }
            catch (IndexOutOfRangeException)
            {
            } // No window handles
            catch (ArgumentOutOfRangeException)
            {
            }
        }

        public void Initialize()
        {
            try
            {
                Func<bool> isInit = () =>
                {
                    try
                    {
                        ResetContext();
                        InitDriver();
                        Goto("/");
                        Logout();
                    }
                    catch (Exception ex)
                    {
                        if (ex is WebDriverException)
                        {
                            DisposeService();
                        }
                        return false;
                    }
                    return true;
                };

                isInit.RepeatUntilCount(3);
            }
            catch (CountExceededException)
            {
                throw new ApplicationException($"Initialize failed");
            }
        }

        public void Logout() => WebContext.Browser.Manage().Cookies.DeleteAllCookies();

        public OpenQA.Selenium.Cookie GetCookie(string name) => WebContext.Browser.Manage().Cookies.GetCookieNamed(name);

        public void DeleteCookie(string name) => WebContext.Browser.Manage().Cookies.DeleteCookieNamed(name);

        public void AddCookie(OpenQA.Selenium.Cookie cookie) => WebContext.Browser.Manage().Cookies.AddCookie(cookie);

        public ReadOnlyCollection<OpenQA.Selenium.Cookie> GetCookies() => WebContext.Browser.Manage().Cookies.AllCookies;

        public void WaitForNewPage()
        {
            try
            {
                Func<bool> isMainOrHtmlUpdated = () =>
                {
                    try
                    {
                        var tags = WebContext.Browser.ExecuteScript("return {'main':document.getElementsByTagName('main')[0] || null,'html':document.getElementsByTagName('html')[0] || null}") as Dictionary<string, object>;

                        if (WebContext.MainElemetnBeforeLastCommand != null)
                        {
                            var main = tags["main"];
                            if (main == null)
                                return true;

                            return !main.Equals(WebContext.MainElemetnBeforeLastCommand);
                        }
                        else
                        {
                            var html = tags["html"];
                            return !html.Equals(WebContext.HtmlElementBeforeLastCommand);
                        }
                    }
                    catch (NoSuchElementException)
                    {
                        // html tag is not still there 
                        return false;
                    }
                    catch (OpenQA.Selenium.StaleElementReferenceException)
                    {
                        // old html tag is now stale, it's safe to continue
                        return true;
                    }
                    catch (InvalidOperationException err) when (err.Message.Contains("Cannot find execution context with given id"))
                    {
                        // e.x. the close modal case when the current DOM element is removed
                        if (WebContext.Browser.CurrentFrame == null)
                            WebContext.Browser.SwitchTo().DefaultContent();
                        return true;
                    }
                };

                isMainOrHtmlUpdated.RepeatUntilTrue(WebContext.Config.Timeout);
            }
            catch (TimeoutException)
            {
                throw new ApplicationException($"Waited {WebContext.Config.Timeout} but no new page appeared");
            }
        }

        public void RefreshPage()
        {
            RememberCurrentPageState();
            WebContext.Browser.SwitchToIframeIfNecessary();
            WebContext.Browser.Navigate().Refresh();
            ExecuteWaitForNewPage();
        }

        public void SwitchToTab(string target) => (new WebDriverManager()).SwitchToTab(WebContext.Browser, target);

        public void CloseTab(string target)
        {
            var currentHandle = WebContext.Browser.CurrentWindowHandle;
            WebContext.Browser.SwitchTo().Window(target);
            WebContext.Browser.Close();
            WebContext.Browser.SwitchTo().Window(currentHandle);
        }

        public void ClosePopup()
        {
            RememberCurrentPageState();
            if (WebContext.Browser.CurrentFrame == null)
                WebContext.Browser.SwitchTo().DefaultContent();
            WebContext.Browser.ExecuteScript(@"
                if (typeof page !== 'undefined') page.closeModal();
                else if (typeof parent !== 'undefined' && parent.CloseModal) parent.CloseModal();
                else CloseModal();");
        }

        public void WaitForPopup()
        {
            try
            {
                Func<bool> isModalOpened = () =>
                {
                    try
                    {
                        if (WebContext.Browser.CurrentFrame == null)
                            WebContext.Browser.SwitchTo().DefaultContent();
                        return WebContext.Browser.FindElements(By.XPath("//*[self::span[@class='modal-wrapper6'] or self::div[@role='dialog']]")).Any();
                    }
                    catch (Exception err) when (err.Message.Contains("result in WebElement"))
                    {
                        return false;
                    }
                };

                isModalOpened.RepeatUntilTrue(WebContext.Config.Timeout);
            }
            catch (TimeoutException)
            {
                throw new TimeoutException($"Waited {WebContext.Config.Timeout} but no popup appeared");
            }
        }

        public void Goto(string target)
        {
            RememberCurrentPageState();
            Uri uri;
            if (target.StartsWithAny("http://", "https://"))
                uri = new Uri(target);
            else
            {
                var currentUri = GetCurrentUrl();
                var baseUrl = new Uri(currentUri.Scheme + "://" + currentUri.Authority);
                uri = new Uri(baseUrl, target);
            }

            WebContext.Browser.Navigate().GoToUrl(uri);
        }

        public void Press(params Keys[] keys)
        {
            RememberCurrentPageState();

            var RETRY_COMMAND_EXECUTION = 5;
            var seleniumKeys = new Dictionary<Keys, string>
            {
                [Keys.Tab] = OpenQA.Selenium.Keys.Tab,
                [Keys.Enter] = OpenQA.Selenium.Keys.Enter,
                [Keys.Escape] = OpenQA.Selenium.Keys.Escape,
                [Keys.ArrowUp] = OpenQA.Selenium.Keys.ArrowUp,
                [Keys.ArrowDown] = OpenQA.Selenium.Keys.ArrowDown,
                [Keys.ArrowLeft] = OpenQA.Selenium.Keys.ArrowLeft,
                [Keys.ArrowRight] = OpenQA.Selenium.Keys.ArrowRight,
                [Keys.Backspace] = OpenQA.Selenium.Keys.Backspace,
                [Keys.Delete] = OpenQA.Selenium.Keys.Delete,
                [Keys.End] = OpenQA.Selenium.Keys.End,
                [Keys.Home] = OpenQA.Selenium.Keys.Home,
                [Keys.Space] = OpenQA.Selenium.Keys.Space,
                [Keys.CtrlA] = Convert.ToString("\u0001"),
                [Keys.CtrlC] = Convert.ToString("\u0003"),
                [Keys.CtrlV] = Convert.ToString("\u0016")
            };

            foreach (var key in keys)
            {
                for (var attempt = 0; attempt < RETRY_COMMAND_EXECUTION; attempt++)
                {
                    try
                    {
                        WebContext.Browser.SwitchTo().ActiveElement().SendKeys(seleniumKeys[key]);
                        break;
                    }
                    catch (OpenQA.Selenium.StaleElementReferenceException e)
                    {
                        if (attempt == RETRY_COMMAND_EXECUTION - 1)
                            throw e;
                    }
                }
            }
        }

        public Screenshot GetScreenshot() => WebContext.Browser.GetScreenshot();

        public void Type(string text)
        {
            RememberCurrentPageState();
            WebContext.Browser.SwitchTo().ActiveElement().SendKeys(text);
        }

        public void ExpectDownloadedFile(ActionTarget target)
        {
            if (FileFinder.FindFiles(target).Length == 0)
                Error($"Found no file {target.Text}");
        }

        public void ClearDownloadedFile(ActionTarget target)
        {
            foreach (var file in FileFinder.FindFiles(target))
                file.Delete();
        }

        public void Open(string locator)
        {
            RememberCurrentPageState();
            var file = FileFinder.FindFile(locator);
            if (!file.Exists())
                Error($"Found no file {locator}");

            WebContext.Browser.Navigate().GoToUrl(file.FullName);
        }

        public string GetBaseUrl()
        {
            return WebContext.BaseUrl;
        }

        public Uri GetCurrentUrl()
        {
            return new Uri(WebContext.Browser.Url);
        }

        public void ExpectUrl(string locator)
        {
            Uri toCheckUri;
            var found = false;
            var currentUri = GetCurrentUrl();
            var toCheck = locator.Replace("\"", "");
            if (toCheck.Contains("http") || toCheck.Contains("https"))
            {
                toCheckUri = new Uri(toCheck);
                found = toCheckUri.LocalPath.Equals(currentUri.LocalPath, StringComparison.InvariantCultureIgnoreCase);
            }

            if (!found)
                found = toCheck.Equals(currentUri.LocalPath, StringComparison.InvariantCultureIgnoreCase);

            if (!found)
                Error($"Not Found Url : {locator}");
        }

        public void CopyUrl() => CopyUrl("Default");

        public void CopyUrl(string key) => WebContext.ClipboardManager.SetText(key, GetCurrentUrl().ToString());

        public void GotoCopiedUrl() => GotoCopiedUrl("Default");

        public void GotoCopiedUrl(string key)
        {
            var url = WebContext.ClipboardManager.GetText(key);
            if (url.IsEmpty())
                throw new SyntaxErrorException("There is no Url in Clipboard");

            WebContext.Browser.Navigate().GoToUrl(url);
        }

        public void RunTestCase(UIContext uiContext, ActionTarget target) => (new WebCommand(WebContext, target)).Execute();


        public void DisposeService()
        {
            DriverManager?.Quit();
            seleniumWebDriver = null;
        }

        #endregion

        #region [Private Methods]

        private IExtendedRemoteWebDriver StartBrowser(string baseUrl)
        {
            DriverManager = new WebDriverManager();

            var driver = DriverManager.StartBrowser(SupportedBrowser);
            if (!driver.Url.StartsWithAny("http://", "https://"))
                driver.Navigate().GoToUrl(baseUrl);

            DriverManager.BringBrowserFront(SupportedBrowser.ServicePort);
            return driver;
        }

        private void RememberCurrentPageState()
        {
            WebContext.HtmlElementBeforeLastCommand = WebContext.Browser.FindElement(By.TagName("html"));
            WebContext.MainElemetnBeforeLastCommand = WebContext.Browser.FindElements(By.TagName("main")).FirstOrDefault();
        }

        private void Error(string message) => throw new Exception(message);


        private void ExecuteWaitForNewPage()
        {
            try
            {
                Func<bool> isMainOrHtmlUpdated = () =>
                {
                    try
                    {
                        var tags = WebContext.Browser.ExecuteScript("return {'main':document.getElementsByTagName('main')[0] || null,'html':document.getElementsByTagName('html')[0] || null}") as Dictionary<string, object>;
                        if (WebContext.MainElemetnBeforeLastCommand != null && tags.ContainsKey("main"))
                        {
                            var main = tags["main"];
                            if (main == null)
                                return true;

                            return !main.Equals(WebContext.MainElemetnBeforeLastCommand);
                        }
                        else
                        {
                            var html = tags["html"];
                            return !html.Equals(WebContext.HtmlElementBeforeLastCommand);
                        }
                    }
                    catch (NoSuchElementException)
                    {
                        return false;
                    }
                    catch (OpenQA.Selenium.StaleElementReferenceException)
                    {
                        return true;
                    }
                    catch (InvalidOperationException err) when (err.Message.Contains("Cannot find execution context with given id"))
                    {
                        if (WebContext.Browser.CurrentFrame == null)
                            WebContext.Browser.SwitchTo().DefaultContent();
                        return true;
                    }
                };

                isMainOrHtmlUpdated.RepeatUntilTrue(WebContext.Config.Timeout);
            }
            catch (TimeoutException)
            {
                throw new ApplicationException($"Waited {WebContext.Config.Timeout} but no new page appeared");
            }

        }

        private void ResetContext()
        {
            WebContext = new WebContext
            {
                Config = new Config
                {
                    DownloadFolder = UISetting.Instance.DownloadUrl?.AsDirectory().EnsureExists(),
                    UseJavascriptSet = false
                },
                Browser = Driver,
                FileFullPathProvider =  new FileFullPathProviderDisk(AppConstants.DllPath),
                BaseUrl = _baseUrl,
                ClipboardManager = new ClipboardManager(),
            };
            DeleteFiles(WebContext.Config.DownloadFolder.FullName);
        }

        private void DeleteFiles(string path)
        {
            if (Directory.Exists(path))
            {
                foreach (var file in Directory.GetFiles(path))
                    QuickIOFile.Delete(file);

                foreach (var directory in Directory.GetDirectories(path))
                    DeleteFiles(directory);
            }
        }

        private void CloseTabs()
        {
            var originalHandle = WebContext.Browser.CurrentWindowHandle;
            foreach (var handle in WebContext.Browser.WindowHandles)
            {
                if (!handle.Equals(originalHandle))
                {
                    WebContext.Browser.SwitchTo().Window(handle);
                    WebContext.Browser.Close();
                }
            }

            WebContext.Browser.SwitchTo().Window(originalHandle);
        }

        private SupportedBrowser GetSupportedBrowser()
        {
            switch (_browser)
            {
                case Browser.Chrome:
                    return new Chrome(AppConstants.ChromeServicePort);
                case Browser.Firefox:
                    return new Firefox(AppConstants.FirefoxServicePort);
                case Browser.IE:
                    return new IE(AppConstants.IEServicePort);
                default:
                    throw new ArgumentOutOfRangeException("Browser name is required");
            }
        }

        #endregion
    }
}