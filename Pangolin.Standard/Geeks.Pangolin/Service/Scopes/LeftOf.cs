
using Geeks.Pangolin.Core.Helper;
using Geeks.Pangolin.Core.Scopes;
using Geeks.Pangolin.Service.Dom;
using System.Linq;

namespace Geeks.Pangolin.Service.Scopes
{
    public class LeftOf : LeftOfBase
    {
        public override void UpdateArea(Area area) => area.Right = (TargetElements.First() as WebElement).DomElement.Location.X;
    }
}
