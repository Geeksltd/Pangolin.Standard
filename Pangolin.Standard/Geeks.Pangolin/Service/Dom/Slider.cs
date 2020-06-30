using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Geeks.Pangolin.Core.Helper.Context;

namespace Geeks.Pangolin.Service.Dom
{
    public class Slider : Field
    {
        #region [Property]

        #endregion

        #region [Constructor]

        public Slider(IWebElement domElement, WebContext context, WebElementCache cache) : base(domElement, context, cache)
        {
            if (domElement.GetAttribute("class") == "range-slider")
                Label = domElement.GetAttribute("id").Replace("_slider", "");

            if (DomElement.GetAttribute("data-control") == "slider")
                Label = DomElement.GetAttribute("name");
        }

        #endregion

        #region [Public Method]

        #endregion

        #region [Private Method]

        protected override Actions GetClearContentActions(Actions from) => from;

        protected override void UnsafeSendKeys(string keys) => SetByJavasctipt(keys);

        protected override void SetByJavasctipt(string value)
        {
            if (DomElement.GetAttribute("class") == "range-slider")
                Context.Browser.ExecuteScript(@"var sliderElement = $('#" + Id + "').slider();sliderElement.slider('setValue',[" + value + "], true, true);");

            if (DomElement.GetAttribute("data-control") == "slider")
                Context.Browser.ExecuteScript(@"var sliderElement = $('#" + Id + "').slider();sliderElement.slider('setValue'," + value + ", true, true);");
        }

        #endregion
    }
}
