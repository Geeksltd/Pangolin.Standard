namespace Geeks.Pangolin.Core.Helper.Targets
{
    public class TargetBase
    {
        public TargetType TargetType { get; set; } = TargetType.Any;
        public SearchType SearchType { get; set; } = SearchType.EqualityIgnore;
        public Limiter Limiter { get; set; } = Limiter.Everything;
        public string Text { get; set; }
    }
}
