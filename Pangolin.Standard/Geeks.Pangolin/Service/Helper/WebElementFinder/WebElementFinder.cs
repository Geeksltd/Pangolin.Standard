using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Geeks.Pangolin.Core.Drivers;
using Geeks.Pangolin.Core.Drivers.WebDriver;
using Geeks.Pangolin.Core.Helper;
using Geeks.Pangolin.Core.Helper.Context;
using Geeks.Pangolin.Core.Helper.TargetFinderFactory;
using Geeks.Pangolin.Core.Helper.Targets;
using Geeks.Pangolin.Service.Dom;
using Geeks.Pangolin.Service.Helper.Extensions;
using Element = Geeks.Pangolin.Core.Dom.Element;

namespace Geeks.Pangolin.Service.Helper.WebElementFinder
{
    public class WebElementFinder : IElementFinder
    {
        #region [Property]

        public Area Area { get; set; } = new Area();
        public IExtendedRemoteWebDriver Browser { get; private set; }
        private WebContext Context;
        private WebDriverWait Wait;
        static readonly Dictionary<TargetType, string> TargetTypeToQuerySelector = new Dictionary<TargetType, string>
        {
            [TargetType.Button] = "self::input[@type='submit'] or self::input[@type='image'] or self::a[contains(@class,'btn')] or self::button or @role='button'",
            [TargetType.Link] = "self::a[not(contains(@class,'btn')) and not(@role='button')]",
            [TargetType.Field] = "self::input[not(@type='submit' or @type='hidden' or @type='image')] or self::select or self::textarea or self::table[@id][not(contains(@class, 'grid'))] or self::div[contains(@class, 'radio-list')]",
            [TargetType.Header] = "self::h1 or self::h2 or self::h3 or self::h4 or self::h5 or self::h6",
            [TargetType.Label] = "self::label or self::div[contains(concat(' ', normalize-space(@class), ' '), ' label ')]",
            [TargetType.Item] = "self::div[@class='tt-suggestion'] or self:option",
            [TargetType.Checkbox] = "self::input[@type='checkbox']",
            [TargetType.Radiobox] = "self::input[@type='radio']",
            [TargetType.Row] = "self::tr",
            [TargetType.Tick] = "self::i[contains(@class,'fa-check')] or self::img[contains(@src,'tick.')] or self::div[contains(@aria-label,'tick')]",
            [TargetType.Column] = "self::th or self::div[contains(@class,'r-grid-head-cell')]",
            [TargetType.Table] = "self::thead or self::tr[@class='header-row']",
        };
        static readonly TargetType[] Clickables = new[] {
            TargetType.Clickable,
            TargetType.Button,
            TargetType.Link,
            TargetType.Radiobox,
            TargetType.Checkbox,
            TargetType.Item };
        const string FindPathJs = @"function getPathTo(element) {
                if (element === document.body)
                    return element.tagName;

                var ix = 0;
                var siblings = element.parentNode.childNodes;
                for (var i = 0; i < siblings.length; i++)
                {
                    var sibling = siblings[i];
                    if (sibling === element)
                        return getPathTo(element.parentNode) + '/' + element.tagName + '[' + (ix + 1) + ']';
                    if (sibling.nodeType === 1 && sibling.tagName === element.tagName)
                        ix++;
                }
            }";

        #endregion

        #region [Constructor]

        static WebElementFinder() => TargetTypeToQuerySelector[TargetType.Any] = TargetTypeToQuerySelector.Values.ToString(" or ");

        public WebElementFinder(WebContext context)
        {
            Context = context;
            Browser = context.Browser;
            Wait = new WebDriverWait(this.Browser, TimeSpan.FromSeconds(5));
        }

        #endregion

        #region [Public Method]

        public IEnumerable<Element> FindTableRowsByPosition(int position) => Wait.Until(x => x.FindElements(By.XPath($"//tr[not(@class='header-row') and parent::tbody][position()={position}]")))
                .Where(e => e.IsInside(Area))
                .Select(t => new WebElement(t));

        public IEnumerable<Element> GetWrappingTables(Element tableElement) => (tableElement as WebElement).DomElement.FindElements(By.XPath("ancestor::table")).Select(e => new WebElement(e));

        public IEnumerable<Element> FindElementsByTargetType(TargetType targetType, string label, Func<string, bool> labelCheck, bool isCaseSensetive)
        {
            if (Clickables.Contains(targetType))
                return FetchClickables(targetType, labelCheck, isCaseSensetive);

            if (targetType == TargetType.Field)
                return GetAllFields(label, labelCheck);

            if (targetType == TargetType.Editor)
                return GetAllFields(label, labelCheck).OfType<HtmlEditor>();

            if (targetType == TargetType.Row && label.Contains("\n"))
                return GetMultiColumnRow(label);

            if (targetType == TargetType.IFrame)
                return FindElementsByIFrame(label, labelCheck);

            string selector;
            switch (targetType)
            {
                case TargetType.Header: selector = "h1,h2,h3,h4,h5,h6"; break;
                case TargetType.Row: selector = "tr,div.r-grid-row"; break;
                case TargetType.Label: selector = "label,.label"; break;
                case TargetType.Any: selector = "*"; break;
                default: selector = null; break;
            }

            if (selector.HasValue())
                return GetAllElements(labelCheck, label, selector);

            var result = Wait.Until(x => x.FindElements(By.XPath($"//*[{TargetTypeToQuerySelector[targetType]}]")));
            return result
                .Where(e =>
                    e.HasSize() &&
                    e.IsInside(Area) &&
                    (e.TagName == "i" || e.Displayed)) // 'i' for bootstrap icons
                .Select(e => new WebElement(e));
        }

        public IEnumerable<Element> FindWebElementsBasedOnRegex(string text)
        {
            var escapedText = text.ToLower().Replace("'", "\\'");

            var items = Browser.ExecuteScript(@"
                return Array.prototype.slice.call(document.querySelectorAll('div'))
                .filter(function(e) { return (e.offsetWidth>0 || e.offsetHeight>0) && e.innerText !=null  && e.classList.contains('group-control')})
                .map(function(e) { 
                    return { element: e, value: e.outerText }; })
                .filter(function(item) { 
                var re = new RegExp('" + escapedText + @"');
                if(typeof item.value !== 'undefined' && item.value != null && re.test(item.value.toLowerCase()))
                    return item;
                })") as ReadOnlyCollection<object>;

            foreach (Dictionary<string, object> item in items)
            {
                var element = item["element"] as IWebElement;
                var value = item["value"] as string;

                if (element.IsInside(Area))
                    yield return new WebElement(element) { Label = value };
            }
        }

        public IEnumerable<Element> FindElementsContainingText(string text, TargetType targetType) => (FindWebElementsContainingText(text, targetType: targetType))
            .Where(e => e.HasSize() && e.Displayed &&
            e.Text.Or(e.GetAttribute("value")).Or(e.GetAttribute("name")).Or(e.GetAttribute("aria-label")).OrEmpty().IndexOf(text, StringComparison.InvariantCultureIgnoreCase) >= 0)
            .Select(e => new WebElement(e) { Label = e.Text.Or(e.GetAttribute("value")).Or(e.GetAttribute("name")).Or(e.GetAttribute("aria-label")) });

        public IEnumerable<Element> FindElementsByText(string text, TargetType targetType) => (FindWebElementsByText(text, targetType: targetType))
            .Where(e => e.HasSize() && e.Displayed &&
            (
                (e.Text.OrEmpty().IndexOf(text, StringComparison.InvariantCultureIgnoreCase) >= 0)
                ||
                (e.GetAttribute("value").OrEmpty().IndexOf(text, StringComparison.InvariantCultureIgnoreCase) >= 0)
                ||
                (e.GetAttribute("placeholder").OrEmpty().IndexOf(text, StringComparison.InvariantCultureIgnoreCase) >= 0)
            ))
            .Select(e => new WebElement(e) { Label = e.Text.Or(text) }).ToList();
        public IEnumerable<Element> FindElementsByCSS(string text) => (FindWebElementsByCSS(text))
   .Where(e => e.HasSize() && e.Displayed)
   .Select(e => new WebElement(e)).ToList();
        public IEnumerable<Element> FindElementsByXPath(string text) => (FindWebElementsByXPath(text))
           .Where(e => e.HasSize() && e.Displayed)
           .Select(e => new WebElement(e)).ToList();

        public IEnumerable<Element> FindElementsByIFrame(string text, Func<string, bool> labelCheck)
        {
            var result = FindIFrame(text).Where(e => e.HasSize() && e.Displayed &&
             (
             (e.GetAttribute("name").OrEmpty().IndexOf(text, StringComparison.InvariantCultureIgnoreCase) >= 0)
             ||
             (e.GetAttribute("title").OrEmpty().IndexOf(text, StringComparison.InvariantCultureIgnoreCase) >= 0)
             ||
             (e.GetAttribute("id").OrEmpty().IndexOf(text, StringComparison.InvariantCultureIgnoreCase) >= 0)
             ||
             (e.GetAttribute("aria-label").OrEmpty().IndexOf(text, StringComparison.InvariantCultureIgnoreCase) >= 0)
             )).ToList();

            return result.Where(c => labelCheck.Invoke(text)).Select(e => new WebElement(e) { Label = text });
        }

        public IEnumerable<Element> FindElementsContainingValue(string text)
        {
            var escapedText = text.ToLower().Replace("'", "\\'");

            var items = Browser.ExecuteScript(@"
                return Array.prototype.slice.call(document.querySelectorAll('input,select,textarea'))
                .filter(function(e) { return e.offsetWidth>0 || e.offsetHeight>0  })
                .map(function(e) { 
                    var text = e.value; 
                    if (e.tagName.toLowerCase()=='select' && e.selectedIndex>=0) {
                       text = e.options[e.selectedIndex].textContent;
                    }
                    return { element: e, value: text }; })
                .filter(function(item) { return typeof item.value !== 'undefined' && item.value != null && item.value.toLowerCase().indexOf('" + escapedText + @"')>=0 })") as ReadOnlyCollection<object>;

            foreach (Dictionary<string, object> item in items)
            {
                var element = item["element"] as IWebElement;
                var value = item["value"] as string;
                if (element.IsInside(Area))
                    yield return new WebElement(element) { Label = value };
            }
        }

        public IEnumerable<Field> FindRadioGroupOptions(Field container, string label)
        {
            var query = new StringBuilder($".//*[{TargetTypeToQuerySelector[TargetType.Radiobox]}]");
            query.Append("[@id=");
            query.Append($"//label[{XPathRemoveColonStar(XPathToLower("normalize-space(.)"))}={NormalizeLabel(label.EscapeForXPath()).ToLower()}]/@for");
            query.Append("]");

            return container.DomElement.FindElements(By.XPath(query.ToString())).Select(e => new Field(e, Context, cache: null) { Label = label });
        }

        public IEnumerable<Field> FindChosenOptions(Field container, string label) => container.DomElement.FindElements(By.XPath($"//li[{XPathToLower("normalize-space(.)")}={NormalizeLabel(label.EscapeForXPath()).ToLower()}]")).Select(e => new Field(e, Context, cache: null) { Label = label });

        public IEnumerable<string> FindFieldOptions(Field field) => field.DomElement.Text.ToLines();

        public IEnumerable<Field> GetAllFields(string label, Func<string, bool> labelCheck)
        {
            var escapedLabel = label.OrEmpty().ToLower().Replace("'", "\\'");

            var items = Browser.ExecuteScript(@"
                var escapedLabel = '" + escapedLabel + @"';
                var labels = Array.prototype.slice.call(document.querySelectorAll('label[for],legend[for]'))
                    .map(function(e) { return { 'for': e.getAttribute('for'), 'text': (e.textContent || '')}; })
                    .reduce(function(hash, obj) { hash[obj.for] = obj.text; return hash;}, {});
                return Array.prototype.slice.call(document.querySelectorAll('input:not([type=hidden]):not([type=submit]):not([type=image]),[data-control=slider],[class=range-slider],select,textarea,div.input>table[id]:not(.grid),div.radio-list,div.chosen-container'))
                    .filter(function(e) { return e.tagName == 'TEXTAREA' || e.offsetWidth > 0 || e.offsetHeight > 0 || e.getAttribute('data-control') == 'slider' || e.getAttribute('class') == 'range-slider'  })
                    .filter(function(e) {
                                if (escapedLabel.length == 0) return true;

                if ((e.getAttribute('aria-label') || '').toLowerCase().indexOf(escapedLabel) >= 0)
                    return true;
                 var chosenStr='_chosen';    
                var id = e.getAttribute('controlid') || e.getAttribute('id');
                var chosenId='';
                if(id && id.toLowerCase().indexOf(chosenStr) >= 0){
                    chosenId = id.substring(0, id.length - chosenStr.length);
                } 
                
                var captionStr='_Caption';
                return (id && labels[id] && (labels[id].toLowerCase().indexOf(escapedLabel) >= 0)
                    || (id && labels[id + captionStr] && labels[id + captionStr].toLowerCase().indexOf(escapedLabel) >= 0)
                    || (chosenId && labels[chosenId] && labels[chosenId].toLowerCase().indexOf(escapedLabel) >= 0))
                    || (id && id.toLowerCase().indexOf(escapedLabel) >= 0)
                    || ((e.getAttribute('placeholder') || '').toLowerCase().indexOf(escapedLabel) >= 0)
                    || ((e.getAttribute('name') || '').toLowerCase().indexOf(escapedLabel) >= 0)
                    || ((e.getAttribute('class') || '').toLowerCase().indexOf(escapedLabel) >= 0)
                ;
            })
            .map(function(e) {
                        var id = e.getAttribute('controlid') || e.getAttribute('id');
                        var chosenStr='_chosen';    
                        var chosenId='';
                        if(id && id.toLowerCase().indexOf(chosenStr) >= 0){
                            chosenId = id.substring(0, id.length - chosenStr.length);
                        } 
                        var captionStr='_Caption';
                        return { element: e, html: e.outerHTML, label: (id == null ? null : (labels[id] || labels[id + captionStr] || labels[chosenId] || null))};
                    }); ") as ReadOnlyCollection<object>;

            var fields = new List<Field>();

            foreach (Dictionary<string, object> item in items)
            {
                var element = item["element"] as IWebElement;
                var html = item["html"] as string;
                var matchedLabel = NormalizeLabel(item["label"] as string);
                var field = ConvertWebElement2Field(element, html, matchedLabel);
                if (field != null && field.Label.HasValue() && labelCheck.Invoke(field.Label) && element.IsInside(Area) && (field is HtmlEditor || element.HasSize()))
                    fields.Add(field);
            }

            if (fields.Count > 1 && fields.Any(c => c.IsChosenField))
                fields.RemoveAll(c => c.TagName == "select" && fields.Any(d => d.IsChosenField && c.Id + "_chosen" == d.Id));

            return fields;
        }

        public IWebElement GetLabelFor(string id) => Wait.Until(x => x.FindElements(By.XPath($"//label[@for={id.EscapeForXPath()}]"))).FirstOrDefault();

        public string SuggestLabelForField(Element element, WebElementCache cache)
        {
            if (cache.AriaLabel.HasValue())
                return cache.AriaLabel;

            var label = GetLabelFor(element.Id);

            if (label != null)
            {
                var text = label.Text.Trim();
                if (text.IsEmpty() && (!label.HasSize() || label.Displayed == false))
                    text = label.GetAttribute("innerText");

                if (text.HasValue())
                    return NormalizeLabel(text);
            }
            else if (element.IsChosenField && element.Id.EndsWith("_chosen"))
                return element.Id.Substring(0, element.Id.LastIndexOf("_chosen"));

            return NormalizeLabel(cache.Placeholder
                .Or(cache.Name.EverythingAfter('$').TrimInputTypePrefixes())
                .Or(cache.Id.EverythingAfter('_').TrimInputTypePrefixes())
                .Or(cache.Classes.FirstOrDefault())
                .OrEmpty());
        }

        #endregion

        #region [Private Method]

        internal Element GetWrappingFormItem(WebElement labelElement) => GetElementsByJsSelector(".form-group,.item")
                .Where(x => labelElement.DomPath.StartsWith(x.DomPath))
                .OrderByDescending(x => x.DomPath.Count(c => c == '/'))
                .FirstOrDefault();

        private IEnumerable<WebElement> GetElementsByJsSelector(string selector)
        {
            var items = Browser.ExecuteScript(FindPathJs +
                    @"return Array.prototype.slice.call(document.querySelectorAll('" + selector + @"'))
                    .map(function(e) { return { element: e, text: e.innerText || '', path: getPathTo(e)}; });") as ReadOnlyCollection<object>;

            foreach (Dictionary<string, object> item in items)
            {
                var webElement = item["element"] as IWebElement;
                var innerText = item["text"] as string;
                var path = item["path"] as string;

                yield return new WebElement(webElement)
                {
                    Label = innerText,
                    DomPath = path
                };
            }
        }

        private List<WebElement> GetAllElements(Func<string, bool> labelCheck, string text, string selector)
        {
            var escapedText = text.OrEmpty().ToLower().EscapeForJs();

            var items = Browser.ExecuteScript(FindPathJs +
                    @"return Array.prototype.slice.call(document.querySelectorAll('" + selector + @"'))
                    .filter(function(e) { return e.offsetWidth>0 || e.offsetHeight>0  })
                    .filter(function(e) { return (e.innerText || '').toLowerCase().indexOf('" + escapedText + @"')>=0 })
                    .map(function(e) { return { element: e, text: e.innerText || '', path: getPathTo(e)}; });") as ReadOnlyCollection<object>;

            var result = new List<WebElement>();

            foreach (Dictionary<string, object> item in items)
            {
                var webElement = item["element"] as IWebElement;
                var innerText = item["text"] as string;
                var path = item["path"] as string;

                var element = new WebElement(webElement)
                {
                    Label = innerText,
                    DomPath = path
                };

                if (labelCheck.Invoke(element.Label) && webElement.IsInside(Area))
                    result.Add(element);
            }

            RemoveNestedRepeats(result);
            return result;
        }

        private void RemoveNestedRepeats(List<WebElement> elements)
        {
            for (var i = 0; i < elements.Count; i++)
            {
                var item = elements[i];
                var duplicates = elements.Except(item).Where(x => x.Label == item.Label && item.DomPath.StartsWith(x.DomPath));
                if (duplicates.None())
                    continue;

                var toRemove = duplicates.Union(item).OrderByDescending(e => e.DomPath.Count(c => c == '/')).Skip(1);
                elements.Remove(toRemove);
                i = Math.Min(0, i - toRemove.Count());
            }
        }

        private IEnumerable<Element> GetMultiColumnRow(string label)
        {
            var query = new StringBuilder();
            var xpathDot = XPathToLower("normalize-space()");
            var columns = label.Split(new[] { "\n" }, StringSplitOptions.None);
            for (var i = 0; i < columns.Length; i++)
            {
                var literal = columns[i].EscapeForXPath().ToLower();
                if (i == 0)
                    query.Append($"//td[contains({xpathDot},{literal})]");
                else
                    query.Append($"/following-sibling::td[contains({xpathDot},{literal})]");
            }

            query.Append("/ancestor::tr");
            return Wait.Until(x => x.FindElements(By.XPath(query.ToString())))
                .Where(e => e.HasSize() && e.IsInside(Area))
                .Select(e => new WebElement(e) { Label = ExtractRowText(e) });
        }

        private string ExtractRowText(IWebElement domElement) => domElement.FindElements(By.TagName("td")).Select(e => e.Text).ToString("\n");

        private IEnumerable<IWebElement> FindWebElementsContainingText(string text, TargetType targetType)
        {
            var literal = text.EscapeForXPath().ToLower();
            var xpathDot = XPathToLower(".");
            var searchClause = $"[text()[contains({xpathDot},{literal})] or @value[contains({xpathDot},{literal})] or @name[contains({xpathDot},{literal})] or @aria-label[contains({xpathDot},{literal})]]";
            var query = new StringBuilder();
            query.Append("//*");

            if (targetType == TargetType.Any)
                query.Append(searchClause);
            else
            {
                query.Append("[");
                query.Append(TargetTypeToQuerySelector[targetType]);
                query.Append("]");
                query.Append("/descendant-or-self::*");
                query.Append(searchClause);
                query.Append("/ancestor-or-self::*");
                query.Append("[");
                query.Append(TargetTypeToQuerySelector[targetType]);
                query.Append("]");
            }

            if (text.IsEmpty())
                query.Append("/td[string-length(normalize-space(text())) = 0]");

            return Wait.Until(x => x.FindElements(By.XPath(query.ToString())))
                .Where(e => e.IsInside(Area));
        }

        private IEnumerable<IWebElement> FindIFrame(string text)
        {
            var query = new StringBuilder();
            query.Append("//*");
            query.Append("[");
            query.Append("(name() = \"iframe\" or name() = \"frame\")");

            if (!text.IsEmpty())
            {
                var literal = text.EscapeForXPath().ToLower();
                var xpathDot = XPathToLower(".");
                var searchClause = $" and (@name[contains({xpathDot},{literal})]  or @title[contains({xpathDot},{literal})] or @id[contains({xpathDot},{literal})] or @aria-label[contains({xpathDot},{literal})])";
                query.Append(searchClause);
            }
            query.Append("]");
            return Wait.Until(x => x.FindElements(By.XPath(query.ToString())))
                .Where(e => e.IsInside(Area));
        }

        private IEnumerable<IWebElement> FindWebElementsByText(string text, TargetType targetType)
        {
            var txtQuery = Html.Instance.Text(text, Options.Substring);
            var literal = text.EscapeForXPath().ToLower();
            var xpathDot = XPathToLower(".");
            var searchClause = $"[text()[contains({xpathDot},{literal})] or @value[contains({xpathDot},{literal})] or @placeholder[contains({xpathDot},{literal})]]";
            var query = new StringBuilder();
            query.Append("//*");
            if (targetType == TargetType.Any)
                query.Append(searchClause);
            else
            {
                query.Append("[");
                query.Append(TargetTypeToQuerySelector[targetType]);
                query.Append("]");
                query.Append("/descendant-or-self::*");
                query.Append(searchClause);
                query.Append("/ancestor-or-self::*");
                query.Append("[");
                query.Append(TargetTypeToQuerySelector[targetType]);
                query.Append("]");
            }

            if (text.IsEmpty())
                query.Append("/td[string-length(normalize-space(text())) = 0]");

            return Browser
                .FindElements(By.XPath(txtQuery + " | " + query))
                .Where(e => e.IsInside(Area));
        }

        private IEnumerable<IWebElement> FindWebElementsByCSS(string xpath) => Browser
        .FindElements(By.CssSelector(xpath))
        .Where(e => e.IsInside(Area));

        private IEnumerable<IWebElement> FindWebElementsByXPath(string xpath) => Browser
                .FindElements(By.XPath(xpath))
                .Where(e => e.IsInside(Area));

        #region XPATH 1.0 substitutes for XPATH 2 functions
        private string XPathToLower(string str) => $"translate({str}, 'ABCDEFGHJIKLMNOPQRSTUVWXYZ', 'abcdefghjiklmnopqrstuvwxyz')";

        private string XPathRemoveColonStar(string str) => $"translate({str}, ':*', '')";
        #endregion

        private string NormalizeLabel(string raw) => (raw.IsEmpty()) ? null : raw.Trim().TrimEnd(":").Trim('*').Trim();

        private Field ConvertWebElement2Field(IWebElement element, string html, string matchedLabel)
        {
            var cache = new WebElementCache(html);
            var field = new Field(element, Context, cache);
            if (matchedLabel.HasValue())
                field.Label = matchedLabel;
            else
                field.Label = SuggestLabelForField(field, cache);

            if (field.Label == "SelectedIds")
                return null;

            if (field.Label == "form-control")
                return null;

            if (field.Label == "chosen-search-input")
                return null;

            if (cache.Type == "text")// && cache.Classes.Contains("file-id")) // M#VC
            {
                var elements = element.FindElements(By.XPath("./ancestor::div[@class='file-upload']/input[@type='file']"));
                if (elements.Any())
                {
                    element = elements.First();
                    return new FileInput(Context.FileFullPathProvider, element, Context, cache)
                    {
                        Label = field.Label
                    };
                }
            }

            if (cache.Type == "file")  // normal file input
            {
                return new FileInput(Context.FileFullPathProvider, element, Context, cache)
                {
                    Label = field.Label
                };
            }

            if (cache.Type == "text" && cache.Id.None() && cache.Classes.Contains("auto-complete"))
                return null;

            if (cache.TagName == "textarea")
            {
                var ckeditor = GetRelatedCKEditorIframe(element);
                if (ckeditor != null)
                {
                    var textArea = new HtmlEditor(element, ckeditor, Context, cache);
                    textArea.Label = SuggestLabelForField(textArea, cache);
                    return textArea;
                }
            }

            if (IsSlider(element))
                return new Slider(element, Context, cache);

            return field;
        }

        private bool IsSlider(IWebElement element) => (element.GetAttribute("data-control") == "slider" || element.GetAttribute("class") == "range-slider");

        private IWebElement GetRelatedCKEditorIframe(IWebElement textarea)
        {
            if (textarea.HasSize() && textarea.Displayed)
                return null;

            var id = textarea.GetAttribute("id");
            if (id.IsEmpty())
                return null;
            var div = Browser.FindElements(By.Id("cke_" + id)).FirstOrDefault();
            if (div == null) return null;
            return div.FindElement(By.TagName("iframe"));
        }

        private IEnumerable<WebElement> FetchClickables(TargetType type, Func<string, bool> labelCheck, bool isCaseSensetive)
        {
            string selector;
            switch (type)
            {
                case TargetType.Button: selector = "button,[role=button],input[type=submit],input[type=image]"; break;
                case TargetType.Link: selector = "a:not([role=button])"; break;
                case TargetType.Item: selector = "div.tt-suggestion,div.selection-container>div.item,div.multiselect-dropdown>input,div.item[itemvalue],select>option,div.chosen-container-multi>ul>li>a.search-choice-close,div.chosen-container-multi>div>ul>li.active-result,div.chosen-container-single>div>ul>li.active-result"; break;
                case TargetType.Radiobox: selector = "input[type=radio]"; break;
                case TargetType.Checkbox: selector = "input[type=checkbox]"; break;
                default:
                    selector = "a,input[type=submit],input[type=image],input[type=button],input[type=checkbox],input[type=radio],button,[role=button],div.tt-suggestion,div.selection-container>div.item,div.multiselect-dropdown > input";
                    break;
            }

            var items = Browser.ExecuteScript(@"
return Array.prototype.slice.call(document.querySelectorAll('" + selector + @"'))
.filter(function(e) { return e.offsetWidth>0 || e.offsetHeight>0 || e.tagName == 'OPTION' || e.className == 'tt-suggestion'} || e.className == 'active-result' || e.className == 'search-choice-close')
.map(function(e) { return { element: e, html: e.outerHTML}; });") as ReadOnlyCollection<object>;

            var fields = new List<WebElement>();

            foreach (Dictionary<string, object> item in items)
            {
                var element = item["element"] as IWebElement;
                var html = item["html"] as string;
                var parent = element.GetParent();
                if (parent == null || parent.Displayed)
                {
                    var cache = new WebElementCache(html);

                    var clickable = new WebElement(element, cache);
                    clickable.Label = SuggestTextForButton(clickable, new WebElementCache(html), isCaseSensetive);

                    if (labelCheck.Invoke(clickable.Label) && element.IsInside(Area, cache))
                        fields.Add(clickable);
                }
            }

            if (fields.Count > 1 && fields.Any(c => c.IsChosenItem))
                fields.RemoveAll(c => c.TagName == "option" && fields.Any(d => d.IsChosenItem && c.Label == d.Label));

            return fields;
        }

        private string SuggestTextForButton(WebElement element, WebElementCache cache, bool isCaseSensetive)
        {
            var elementText = cache.Text.OrEmpty().Trim();
            if (elementText.HasValue())
            {
                if (isCaseSensetive)
                    return elementText.ApplyTextTransform(element.DomElement.GetCssValue("text-transform"));

                return elementText;
            }

            if (cache.AriaLabel.HasValue())
                return cache.AriaLabel;

            if (element.TagName.IsAnyOf("a") && element.Classes.Contains("search-choice-close"))
            {
                var result = element.DomElement.GetParent()?.FindElement(By.TagName("span"))?.Text;
                if (!result.IsEmpty())
                    return result;
            }

            if (element.TagName.IsAnyOf("li") && element.Classes.Contains("active-result"))
            {
                var result = element.DomElement.Text;
                if (!result.IsEmpty())
                    return result;
            }

            if (cache.TagName.IsAnyOf("a", "button", "div") || cache.Role == "button")
            {
                var text = cache.ItemText;
                if (text.HasValue())
                    return text;

                text = cache.Text.OrEmpty().Trim();
                if (text.HasValue())
                {
                    if (isCaseSensetive)
                        return text.ApplyTextTransform(element.DomElement.GetCssValue("text-transform"));

                    return text;
                }

                var title = cache.Title;
                if (title.HasValue())
                    return title;

                var name = cache.Name;
                if (name.HasValue())
                    return name;

                var img = cache.FindElementsByTagName("img").FirstOrDefault();
                if (img != null)
                    return new WebElementCache(img)?.Alt;

                var classes = cache.Classes;
                if (classes.Length > 0)
                    return classes[0];

                return null;
            }

            if (cache.TagName == "input")
            {
                if (cache.Type == "image")
                    return cache.Alt;

                if (cache.Type == "checkbox")
                {
                    var gridSelector = SuggestLabelForGridSelect(cache);
                    if (gridSelector.HasValue())
                        return gridSelector;

                    return element.DomElement.GetParent()?.Text.Or(SuggestLabelForField(element, cache));
                }
                else
                {
                    var value = cache.Value;
                    if (value.IsEmpty())
                        return null;

                    if (!isCaseSensetive)
                        return value;

                    return value.ApplyTextTransform(element.DomElement.GetCssValue("text-transform"));
                }
            }

            if (cache.TagName == "option")
                return cache.Text;

            throw new NotImplementedException($"Unknown tag {cache.TagName}");
        }

        private string SuggestLabelForGridSelect(WebElementCache cache)
        {
            if (cache == null)
                return null;

            if (cache.Name?.EndsWith("$chkSelectAll") == true)
                return "SelectAll";

            if (cache.Name?.EndsWith("$chkSelect") == true || cache.Name?.EndsWith("SelectedIds") == true)
                return "Select";

            if (cache.Title == "select / deselect all")
                return cache.Title;

            return null;
        }

        #endregion
    }
}
