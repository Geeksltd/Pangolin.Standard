using System;
using System.Collections.Generic;
using Geeks.Pangolin.Core.Dom;
using Geeks.Pangolin.Core.Helper;

namespace Geeks.Pangolin.Core.Scopes
{
    public abstract class NearBase : ScopeBase
    {
        internal Element[] ReduceElements(IEnumerable<Element> elements) => new Element[] { elements.WithMin(e => DistanceTo(e)) };

        public override void UpdateArea(Area area) => throw new InvalidOperationException("Near cannot be used to update an area");

        public abstract int DistanceTo(Element element);
    }
}
