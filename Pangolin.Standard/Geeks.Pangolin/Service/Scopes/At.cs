using System.Linq;
using Geeks.Pangolin.Core.Helper;
using Geeks.Pangolin.Core.Helper.Targets;
using Geeks.Pangolin.Core.Scopes;
using Geeks.Pangolin.Service.Dom;
using Geeks.Pangolin.Service.Helper.WebElementFinder;

namespace Geeks.Pangolin.Service.Scopes
{
    public class At : AtBase
    {
        public override void DetectDomElements(TargetFinder targetFinder)
        {
            base.DetectDomElements(targetFinder);
            if (Target.TargetType == TargetType.Label)
            {
                TargetElements = TargetElements
                    .Select(e => (targetFinder.ElementFinder as WebElementFinder).GetWrappingFormItem(e as WebElement))
                    .ExceptNull()
                    .ToList();
            }
        }

        public override void UpdateArea(Area area)
        {
            var dom = (TargetElements.First() as WebElement).DomElement;
            var location = dom.Location;
            area.Top = location.Y;
            area.Left = location.X;
            area.Bottom = area.Top + dom.Size.Height;
        }
    }
}
