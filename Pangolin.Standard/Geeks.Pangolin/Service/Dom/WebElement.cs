using OpenQA.Selenium;
using System;
using System.Linq;
using System.Drawing;
using Geeks.Pangolin.Core.Dom;
using Geeks.Pangolin.Core.Helper;

namespace Geeks.Pangolin.Service.Dom
{
    public class WebElement : Element
    {
        #region [Property]
        public IWebElement DomElement { get; protected set; }
        private string _Id;
        public override string Id => _Id ?? (_Id = DomElement.GetAttribute("id").OrEmpty());
        private string _Name;
        public override string Name => _Name ?? (_Name = DomElement.GetAttribute("name").OrEmpty());
        private string _TagName;
        public override string TagName => _TagName ?? (_TagName = DomElement.TagName);
        private string[] _Classes;
        public override string[] Classes => _Classes ?? (_Classes = DomElement.GetAttribute("class").OrEmpty().Split(' ').Where(c => c.HasValue()).ToArray());
        public string DomPath { get; set; }
        protected Size? _Size;
        public override Size Size
        {
            get
            {
                if (_Size == null)
                    _Size = DomElement.Size;

                return _Size.Value;
            }
        }
        protected Point? _Location;
        public override Point Location
        {
            get
            {
                if (_Location == null)
                    _Location = DomElement.Location;

                return _Location.Value;
            }
        }
        public override string VisualText => DomElement.Text;
        private string _Type;
        public override string Type => _Type ?? (_Type = DomElement.GetAttribute("type").OrEmpty().ToLower());
        public override string Label { get; set; }
        public override bool IsCheckbox => Type == "checkbox";
        public override bool IsColour => Type == "color";
        public override bool IsRadio => Type == "radio";
        public override bool IsRadioGroup => TagName == "table" || (TagName == "div" && Classes.Contains("radio-list"));
        public override bool IsChosenField => (TagName == "div" && Classes.Contains("chosen-container"));
        public override bool IsChosenItem => (TagName == "li" && DomElement.GetParent().GetParent().GetAttribute("class").OrEmpty().Split(' ').Where(c => c.HasValue()).ToArray().Contains("chosen-drop"))
                                            ||
                                             (TagName == "a" && DomElement.GetParent().GetParent().GetAttribute("class").OrEmpty().Split(' ').Where(c => c.HasValue()).ToArray().Contains("chosen-choices"));

        #endregion

        #region [Constructor]

        public WebElement(IWebElement domElement, WebElementCache cache = null)
        {
            this.DomElement = domElement;

            if (cache != null)
            {
                _Id = cache.Id;
                _Name = cache.Name;
                _TagName = cache.TagName;
                _Type = cache.Type;
                _Classes = cache.Classes;
            }
        }

        #endregion

        #region [Public Method]
        public override bool HasSize()
        {
            if (TagName.IsAnyOf("option", "div")) return true;
            var size = DomElement.Size;
            return size.Width != 0 || size.Height != 0;
        }

        public override Rectangle GetRect() => new Rectangle(DomElement.Location.X, DomElement.Location.Y, DomElement.Size.Width, DomElement.Size.Height);

        #endregion

        #region [Private Method]

        #endregion
    }
}
