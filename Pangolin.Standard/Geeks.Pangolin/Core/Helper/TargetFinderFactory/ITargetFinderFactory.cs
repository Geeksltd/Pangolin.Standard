using Geeks.Pangolin.Core.Helper.Targets;

namespace Geeks.Pangolin.Core.Helper.TargetFinderFactory
{
    public interface ITargetFinderFactory
    {
        TargetFinder CreateTargetFinder(IElementFinder finder);
    }
}
