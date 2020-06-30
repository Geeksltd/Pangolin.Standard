using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using Geeks.Pangolin.Core.Commands;
using Geeks.Pangolin.Core.Helper;
using Geeks.Pangolin.Core.Helper.Context;
using Geeks.Pangolin.Core.Helper.TargetFinderFactory;
using Geeks.Pangolin.Core.Helper.Targets;
using Geeks.Pangolin.Service.Helper.Extensions;
using Geeks.Pangolin.Service.Helper.WebElementFinder;
using Geeks.Pangolin.Service.Scopes;
using Geeks.Pangolin.Service.Targets;

namespace Geeks.Pangolin.Service.Commands
{
    partial class WebCommand : Command, IElementFinderFactory, ITargetFinderFactory
    {
        #region [Property]

        WebContext WebContext;

        #endregion

        #region [Constructor]

        public WebCommand(Context context, ActionTarget target) : base(context, target, new WebScopeFactory(), null, null)
        {
            ElementFinderFactory = this;
            TargetFinderFactory = this;
            WebContext = context as WebContext;
            if (WebContext == null)
                throw new InvalidOperationException("Expected a WebContext");
        }

        #endregion

        #region [Public Method]

        public IElementFinder CreateElementFinder() => new WebElementFinder(WebContext);

        public TargetFinder CreateTargetFinder(IElementFinder finder) => new WebTargetFinder(finder);

        protected override void OnBeforeRetryFind()
        {
            WebContext.Browser.SwitchToIframeIfNecessary();
        }

        protected override void RememberCurrentPageState()
        {
            WebContext.HtmlElementBeforeLastCommand = WebContext.Browser.FindElement(By.TagName("html"));
            WebContext.MainElemetnBeforeLastCommand = WebContext.Browser.FindElements(By.TagName("main")).FirstOrDefault();
        }

        protected override void ExecuteWaitForPopup()
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

                isModalOpened.RepeatUntilTrue(Context.Config.Timeout);
            }
            catch (TimeoutException)
            {
                throw new TimeoutException($"Waited {Context.Config.Timeout} but no popup appeared");
            }
        }

        protected override void ExecuteWaitForNewPage()
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

                isMainOrHtmlUpdated.RepeatUntilTrue(Context.Config.Timeout);
            }
            catch (TimeoutException)
            {
                throw new ApplicationException($"Waited {Context.Config.Timeout} but no new page appeared");
            }
        }

        #endregion

        #region [Private Method]

        #endregion
    }
}
