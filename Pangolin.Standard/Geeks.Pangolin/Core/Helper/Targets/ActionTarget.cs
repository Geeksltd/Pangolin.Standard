using System.Collections.Generic;

namespace Geeks.Pangolin.Core.Helper.Targets
{
    public class ActionTarget: TargetBase
    {
        public TargetActionType ActionType { get; set; }
        public string Value { get; set; }
        public List<ScopeTarget> Scopes { get; set; } = new List<ScopeTarget>();
    }
}
