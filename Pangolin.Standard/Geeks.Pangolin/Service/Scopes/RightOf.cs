
using Geeks.Pangolin.Core.Helper;
using Geeks.Pangolin.Core.Scopes;
using Geeks.Pangolin.Service.Dom;
using System.Linq;

namespace Geeks.Pangolin.Service.Scopes
{
    public class RightOf : RightOfBase
    {
        public override void UpdateArea(Area area) => area.Left = (TargetElements.First() as WebElement).DomElement.Location.X;
    }
}
