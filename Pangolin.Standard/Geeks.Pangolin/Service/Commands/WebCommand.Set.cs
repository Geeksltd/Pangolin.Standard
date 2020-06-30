using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Geeks.Pangolin.Service.Dom;
using System;
using System.Linq;
using Geeks.Pangolin.Core.Exception;
using Geeks.Pangolin.Core.Helper.Targets;
using Geeks.Pangolin.Service.Helper.WebElementFinder;
using Geeks.Pangolin.Core.Helper;
using System.Collections.Generic;

namespace Geeks.Pangolin.Service.Commands
{
    partial class WebCommand
    {
        public override void ExecuteSet(ActionTarget target)
        {
            var fields = TargetFinderFactory.CreateTargetFinder(Finder).Find(target, Scopes).OfType<WebElement>();
            if (target.Value.IsAnyOf("checked", "unchecked"))
                fields = fields.Where(f => f.IsCheckbox);
            else if (target.Value == "selected")
                fields = fields.Where(f => f.IsRadio);

            var webElement = Scopes.FindSingleElement(fields) as WebElement;

            if (webElement == null)
                throw new ElementNotFoundException($"Cannot find any {target.ActionType} with label '{target.Text}'");

            var field = webElement as Field;
            if (field == null && target.TargetType.In(TargetType.XPath, TargetType.CSS))
                field = new Field(webElement.DomElement, WebContext, null);

            if (field.TagName != "select" && target.Value?.Split(new[] { "\n" }, StringSplitOptions.None).Length > 1)
                throw new ElementNotFoundException($"Field '{target.Text}' is not a multi drop down, please pass only one value");

            ((IJavaScriptExecutor)WebContext.Browser).ExecuteScript("arguments[0].scrollIntoView(true);", webElement.DomElement);

            if (field.TagName == "select")
            {
                try
                {
                    var select = new SelectElement(field.DomElement);
                    var ddValues = target.Value.Split(new[] { "\n" }, StringSplitOptions.None).Where(c => !string.IsNullOrEmpty(c)).ToList();
                    if (select.IsMultiple)
                    {
                        select.DeselectAll();
                        foreach (var ddValue in ddValues)
                            select.SelectByText(ddValue);
                    }
                    else
                    {
                        if (ddValues.Count == 1)
                            select.SelectByText(ddValues.First());
                        else if (ddValues.Count == 0)
                            select.SelectByIndex(0);
                        else if (ddValues.Count > 1)
                            throw new ElementNotFoundException($"Field '{target.Text}' is not a multi drop down, please pass only one value");
                    }
                }
                catch (NoSuchElementException)
                {
                    throw new ElementNotFoundException($"Drop down '{target.Text}' does not have option '{target.Value}'");
                }
                catch (Exception ex)
                {
                    throw new ElementNotFoundException($"Drop down '{target.Text}' does not have option '{target.Value}'");
                }
            }
            else if (field.IsCheckbox)
            {
                var isAlreadyChecked = field.DomElement.Selected;
                var setToCheck = target.Value == "checked";

                if ((!isAlreadyChecked && setToCheck) || (isAlreadyChecked && !setToCheck))
                    field.DomElement.Click();
            }
            else if (field.IsRadio)
            {
                field.DomElement.Click();
            }
            else if (field.IsRadioGroup)
            {
                var options = (Finder as WebElementFinder).FindRadioGroupOptions(field, target.Value);
                Field option;

                if (!options.IsSingle(out option))
                {
                    if (option == null)
                        throw new ElementNotFoundException($"Field '{target.Text}' has not option with label '{target.Value}'");
                    else
                        throw new MultipleElementsFoundException(options, $"Field '{target.Text}' has more than one option with label '{target.Value}'");
                }

                var radioGroupClasses = new List<string> { "form-check-inline", "radio-inline" };
                if (option.DomElement.Displayed == false && option.DomElement.GetParent().GetAttribute("class").OrEmpty().Split(' ').Where(c => c.HasValue()).ToArray().Any(c => radioGroupClasses.Any(a => a == c)))
                    option.DomElement.GetParent().Click();
                else
                    option.DomElement.Click();
            }
            else if (field.IsChosenField)
            {
                field.DomElement.Click();
                try
                {
                    var options = (Finder as WebElementFinder).FindChosenOptions(field, target.Value);
                    Field option;
                    if (!options.IsSingle(out option))
                    {
                        if (option == null)
                            throw new ElementNotFoundException($"Field '{target.Text}' has not option with label '{target.Value}'");
                        else
                            throw new MultipleElementsFoundException(options, $"Field '{target.Text}' has more than one option with label '{target.Value}'");
                    }
                    option.DomElement.Click();
                }
                catch (NoSuchElementException)
                {
                    throw new ElementNotFoundException($"Drop down '{target.Text}' does not have option '{target.Value}'");
                }
            }
            else if (field.IsColour)
            {
                WebContext.Browser.ExecuteScript($"arguments[0].value = '{target.Value}'", field.DomElement);
            }
            else
                field.SendKeys(target.Value.Replace("\\\"", "\""));
        }
    }
}
