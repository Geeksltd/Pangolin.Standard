using Geeks.Pangolin.Core.Scopes;
using Geeks.Pangolin.Service.Dom;
using System.Collections.Generic;
using System.Linq;
using Geeks.Pangolin.Core.Dom;
using Geeks.Pangolin.Core.Helper;

namespace Geeks.Pangolin.Service.Scopes
{
    public class Near : NearBase
    {
        internal Element[] ReduceElements(IEnumerable<Element> elements) => new Element[] { elements.WithMin(e => DistanceTo(e)) };

        public override int DistanceTo(Element element)
        {
            var location1 = (TargetElements.First() as WebElement).DomElement.Location;
            var location2 = (element as WebElement).DomElement.Location;

            var x1 = location1.X;
            var y1 = location1.Y;
            var x2 = location2.X;
            var y2 = location2.Y;

            return (x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2);
        }
    }
}
