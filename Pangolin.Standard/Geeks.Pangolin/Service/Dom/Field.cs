using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Linq;
using Geeks.Pangolin.Core.Exception;
using Geeks.Pangolin.Core.Helper;
using Geeks.Pangolin.Core.Helper.Context;

namespace Geeks.Pangolin.Service.Dom
{
    public class Field : WebElement
    {
        #region [Property]

        protected WebContext Context;

        #endregion

        #region [Constructor]

        public Field(IWebElement domElement, WebContext context, WebElementCache cache) : base(domElement, cache) => Context = context;

        #endregion

        #region [Public Method]

        public virtual void SendKeys(string keys)
        {
            if (Context.Config.UseJavascriptSet && CanSetByJavasctipt())
                SetByJavasctipt(keys);
            else
            {
                var id = this.Id; 
                try
                {
                    UnsafeSendKeys(keys);
                }
                catch (OpenQA.Selenium.StaleElementReferenceException)
                {
                    if (id.HasValue())
                    {
                        var elements = Context.Browser.FindElements(By.Id(id)).ToArray();
                        if (elements.None())
                            throw new ElementNotFoundException("Element went stale during Set (most probably due to complexity of the page) but using its Id to finding it again did not return any result");

                        if (!elements.IsSingle())
                            throw new ElementNotFoundException("Element went stale during Set (most probably due to complexity of the page) trying to find it by its Id returned more than one result");

                        DomElement = elements.First();
                        UnsafeSendKeys(keys);
                    }
                    else
                    {
                        throw new ElementNotFoundException("Element went stale during Set (most probably due to complexity of the page) but it has no Id to allow finding it again");
                    }
                }
            }

            WaitForSetResultCompletion();
        }

        #endregion

        #region [Private Method]

        protected virtual void UnsafeSendKeys(string keys)
        {
            var attempts = 0;
            while (attempts < 3)
            {
                try
                {
                    GetFocusableElement()
                    .SendKeys("");
                    break;
                }
                catch (Exception e)
                {
                    if (attempts == 2)
                        throw e;
                }
                attempts++;
            }

            var actions = GetClearContentActions(new Actions(Context.Browser));

            if (keys.HasValue())
                actions = actions.SendKeys(keys.Replace("\n", OpenQA.Selenium.Keys.Enter));

            actions.SendKeys(OpenQA.Selenium.Keys.Tab) 
                   .Build()
                   .Perform();
        }

        protected virtual IWebElement GetFocusableElement() => DomElement;

        protected virtual Actions GetClearContentActions(Actions from) => from
                .KeyDown(OpenQA.Selenium.Keys.Control)
                .SendKeys(OpenQA.Selenium.Keys.End)
                .KeyDown(OpenQA.Selenium.Keys.Shift)
                .SendKeys(OpenQA.Selenium.Keys.Home)
                .KeyUp(OpenQA.Selenium.Keys.Shift)
                .KeyUp(OpenQA.Selenium.Keys.Control)
                .SendKeys(OpenQA.Selenium.Keys.Delete);


        protected virtual void WaitForSetResultCompletion()
        {
            try
            {
                long? uncompletedResponses = null;
                for (var i = 0; i < 100; i++)
                {
                    uncompletedResponses = (long?)Context.Browser.ExecuteScript(@"return typeof page !== 'undefined' ? page.awaitingAutocompleteResponses : 0;");
                    if (uncompletedResponses == null)
                        return;
                    if (uncompletedResponses <= 0)
                        return;
                    System.Threading.Thread.Sleep(100);
                }
            }
            catch (Exception err) when (err.Message.Contains("document unloaded while waiting for result")
                                        // this happens during modal close
                                        || err.Message.Contains("Cannot find execution context with given id")
                                        || err.Message.Contains("Cannot find context with specified id"))
            {}
        }

        protected virtual bool CanSetByJavasctipt() => true;

        protected virtual void SetByJavasctipt(string value)
        {
            if (Id.IsEmpty())
                throw new ApplicationException("Cannot set this field. It has no Id and UseJavascriptSet is enabled in the Sanity configurations");

            Context.Browser.ExecuteScript(@"
                if ($) {
                var e$ = $('#[#ID#]'); e$.val('[#VALUE#]'); e$.trigger('blur');
                } else {
                var element = document.getElementById('[#ID#]');
                element.value = '[#VALUE#]';
                element.blur(); }"

                .Replace("[#ID#]", Id.EscapeForJs())
                .Replace("[#VALUE#]", value.EscapeForJs())
                );
        }

        #endregion
    }
}

