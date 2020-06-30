using OpenQA.Selenium.Interactions;
using Geeks.Pangolin.Service.Dom;
using System;
using Geeks.Pangolin.Core.Dom;
using Geeks.Pangolin.Core.Exception;
using OpenQA.Selenium;

namespace Geeks.Pangolin.Service.Commands
{
    partial class WebCommand
    {
        public override void ExecuteHoverOver(Element singleElement)
        {
            var webElement = singleElement as WebElement;
            try
            {
                ((IJavaScriptExecutor)WebContext.Browser).ExecuteScript("arguments[0].scrollIntoView(true);", webElement.DomElement);
                new Actions(WebContext.Browser).MoveToElement(webElement.DomElement).Perform();
            }
            catch (InvalidOperationException err)
            {
                try
                {
                    if (err.Message.Contains("tt-suggestion"))
                    {
                        webElement.DomElement.SendKeys(OpenQA.Selenium.Keys.Escape);
                        new Actions(WebContext.Browser).MoveToElement(webElement.DomElement).Perform();
                    }
                    else throw;
                }
                catch (InvalidOperationException ex)
                {
                    if (ex.Message.Contains("Element is not clickable at point"))
                        throw new ElementIsMaskedException("Element is not accessible. Another element is masking it.");
                    else throw;
                }
            }
        }
    }
}

