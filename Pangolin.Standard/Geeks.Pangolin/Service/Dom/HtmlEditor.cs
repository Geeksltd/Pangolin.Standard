using System;
using OpenQA.Selenium;
using System.Drawing;
using OpenQA.Selenium.Interactions;
using Geeks.Pangolin.Core.Helper.Context;
using Geeks.Pangolin.Service.Helper.Extensions;

namespace Geeks.Pangolin.Service.Dom
{
    public class HtmlEditor : Field
    {
        #region [Property]

        IWebElement CKEditorIframe;
        public override Size Size
        {
            get
            {
                if (_Size == null)
                    _Size = CKEditorIframe.Size;

                return _Size.Value;
            }
        }
        public override Point Location
        {
            get
            {
                if (_Location == null)
                    _Location = CKEditorIframe.Location;

                return _Location.Value;
            }
        }

        #endregion

        #region [Constructor]

        public HtmlEditor(IWebElement domElement, IWebElement ckeditorIframe, WebContext context, WebElementCache cache) : base(domElement, context, cache) => CKEditorIframe = ckeditorIframe;

        #endregion

        #region [Public Method]

        public override Rectangle GetRect() => new Rectangle(CKEditorIframe.Location.X, CKEditorIframe.Location.Y, CKEditorIframe.Size.Width, CKEditorIframe.Size.Height);

        #endregion

        #region [Private Method]

        protected override IWebElement GetFocusableElement() => CKEditorIframe;

        protected override void UnsafeSendKeys(string keys)
        {
            try
            {
                CKEditorIframe.Click();
                var attempts = 0;
                while (attempts < 3)
                {
                    try
                    {
                        CKEditorIframe
                            .SendKeys("");
                        Context.Browser.SwitchTo().Frame(CKEditorIframe);
                        ((IJavaScriptExecutor)Context.Browser).ExecuteScript("document.body.innerHTML=''");
                        Context.Browser.SwitchToIframeIfNecessary();

                        break;
                    }
                    catch (Exception e)
                    {
                        if (attempts == 2)
                            throw e;
                    }
                    attempts++;
                }
                CKEditorIframe.Click();
            }
            catch (InvalidElementStateException)
            {
            } // Non user-editable elements (file inputs) - chrome/IE
            catch (InvalidOperationException)
            {
            } // Non user-editable elements (file inputs) - firefox
            var actions = GetClearContentActions(new Actions(Context.Browser)).MoveToElement(CKEditorIframe);
            actions = actions.SendKeys(keys.Replace("\n", OpenQA.Selenium.Keys.Enter));
            actions.SendKeys(OpenQA.Selenium.Keys.Tab) // to make sure change/blur events trigger
                .Build()
                .Perform();
        }

        #endregion
    }
}
