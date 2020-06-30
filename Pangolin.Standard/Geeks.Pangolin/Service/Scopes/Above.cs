using System.Linq;
using Geeks.Pangolin.Core.Helper;
using Geeks.Pangolin.Core.Scopes;
using Geeks.Pangolin.Service.Dom;

namespace Geeks.Pangolin.Service.Scopes
{
    public class Above : AboveBase
    {
        public override void UpdateArea(Area area) => area.Bottom = (TargetElements.First() as WebElement).DomElement.Location.Y;
    }
}
