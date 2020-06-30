using Geeks.Pangolin.Service.Dom;
using Geeks.Pangolin.Core.Exception;
using Geeks.Pangolin.Core.Helper.Targets;

namespace Geeks.Pangolin.Service.Commands
{
    partial class WebCommand
    {
        public override void ExecuteIFrame(ActionTarget target)
        {
            var singleElement = Scopes.FindSingleElement(TargetFinderFactory.CreateTargetFinder(Finder).Find(target, Scopes)) as WebElement;

            if (singleElement == null)
                throw new ElementNotFoundException($"Cannot find any '{target.Text}'");

            WebContext.Browser.SwitchTo().Frame(singleElement.DomElement);
            WebContext.Browser.CurrentFrame = singleElement.DomElement;
        }
    }
}
