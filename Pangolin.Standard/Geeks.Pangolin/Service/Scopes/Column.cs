using System.Linq;
using Geeks.Pangolin.Core.Helper;
using Geeks.Pangolin.Core.Scopes;
using Geeks.Pangolin.Service.Dom;

namespace Geeks.Pangolin.Service.Scopes
{
    public class Column : ColumnBase
    {
        public override void UpdateArea(Area area)
        {
            var dom = (TargetElements.First() as WebElement).DomElement;
            area.Left = dom.Location.X;
            area.Right = area.Left + dom.Size.Width;
        }
    }
}
