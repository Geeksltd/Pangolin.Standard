namespace Geeks.Pangolin.Core.Helper.Targets
{
    public enum SearchType
    {
        Wildcard, // e.g: {digit}{digit}{letter}-{digit}
        EqualityExact,
        EqualityIgnore,
        ContainsExact, // ""
        ContainsIgnore, // ""
        Position  // for cases like: at row 1
    }
}