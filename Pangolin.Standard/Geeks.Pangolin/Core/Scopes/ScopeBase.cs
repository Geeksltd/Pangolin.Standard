using Geeks.Pangolin.Core.Dom;
using System.Collections.Generic;
using System.Linq;
using Geeks.Pangolin.Core.Helper;
using Geeks.Pangolin.Core.Helper.Targets;

namespace Geeks.Pangolin.Core.Scopes
{
    public abstract class ScopeBase
    {
        public ScopeTarget Target { get; set; }
        public List<Element> TargetElements { get; set; }

        public override string ToString() => $"{GetType().Name} {Target}";

        public abstract void UpdateArea(Area area);

        public virtual void DetectDomElements(TargetFinder targetFinder) => TargetElements = targetFinder.Find(Target, scopes: null).ToList();

        public virtual void ExtractTarget(ScopeTarget target) => Target = target;
    }
}
