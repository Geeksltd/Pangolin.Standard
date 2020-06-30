using Geeks.Pangolin.Core.Helper.Targets;

namespace Geeks.Pangolin.Core.Scopes
{
    public interface IScopeFactory
    {
        ScopeBase CreateScope(TargetPosition targetPosition);
    }
}
