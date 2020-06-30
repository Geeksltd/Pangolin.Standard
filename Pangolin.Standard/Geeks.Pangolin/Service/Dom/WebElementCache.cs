using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Geeks.Pangolin.Core.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Geeks.Pangolin.Service.Dom
{
    public class WebElementCache
    {
        #region [Property]

        private IElement Node;
        private string _TagName;
        public string TagName => _TagName ?? (_TagName = Node?.NodeName?.ToLower());
        private string _Text;
        public string Text => _Text ?? (_Text = WebUtility.HtmlDecode(Node?.TextContent));
        private string _Role;
        public string Role => _Role ?? (_Role = Node?.GetAttribute("role"));
        private string _Title;
        public string Title => _Title ?? (_Title = Node?.GetAttribute("title"));
        private string _Name;
        public string Name => _Name ?? (_Name = Node?.GetAttribute("name"));
        private string _Id;
        public string Id => _Id ?? (_Id = Node?.GetAttribute("id"));
        private string _Type;
        public string Type => _Type ?? (_Type = Node?.GetAttribute("type"));
        private string _Alt;
        public string Alt => _Alt ?? (_Alt = Node?.GetAttribute("alt"));
        private string _Value;
        public string Value => _Value ?? (_Value = Node?.GetAttribute("value"));
        private string _Placeholder;
        public string Placeholder => _Placeholder ?? (_Placeholder = Node?.GetAttribute("placeholder"));
        private string[] _Classes;
        public string[] Classes => _Classes ?? (_Classes = Node?.GetAttribute("class").OrEmpty().Split(' ').Where(c => c.HasValue()).ToArray());
        private string _ItemText;
        public string ItemText => _ItemText ?? (_ItemText = Node?.GetAttribute("itemtext"));
        private string _AriaLabel;
        public string AriaLabel => _AriaLabel ?? (_AriaLabel = Node?.GetAttribute("aria-label"));

        #endregion

        #region [Constructor]

        public WebElementCache(string html)
        {
            var parser = new HtmlParser();
            if (html.StartsWith("<td"))
            {
                // In AngleSharp <td> cannot be parsed without a wrapping <table>
                html = "<table><tr>" + html + "</tr></table>";
                var doc = parser.ParseFragment(html, null);
                Node = doc[0].ChildNodes.OfType<IHtmlBodyElement>()
                    .First() // body
                    .FirstElementChild // table
                    .FirstElementChild // tbody
                    .FirstElementChild // tr
                    .FirstElementChild; // td
            }
            else
            {
                var doc = parser.ParseFragment(html, null);
                Node = doc[0].ChildNodes.OfType<IHtmlBodyElement>().FirstOrDefault()?.FirstElementChild;
            }
        }

        public WebElementCache(IElement element) => Node = element;

        #endregion

        #region [Public Method]
        public IEnumerable<IElement> FindElementsByTagName(string tagName) => Node.Children.Where(c => string.Compare(c.TagName, tagName, ignoreCase: true) == 0);

        #endregion

        #region [Private Method]

        #endregion
    }
}
