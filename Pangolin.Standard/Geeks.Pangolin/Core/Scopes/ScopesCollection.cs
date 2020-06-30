using System.Collections.Generic;
using System.Linq;
using Geeks.Pangolin.Core.Dom;
using Geeks.Pangolin.Core.Exception;
using Geeks.Pangolin.Core.Helper;
using Geeks.Pangolin.Core.Helper.TargetFinderFactory;
using Geeks.Pangolin.Core.Helper.Targets;

namespace Geeks.Pangolin.Core.Scopes
{
    public class ScopesCollection : List<ScopeBase>
    {
        #region [Property]

        protected static readonly string[] ScopeKeywords = new[] { "above", "below", "near", "at", "column", "left of", "right of" };
        protected static readonly string[] ScopeKeywordsFirstWords = ScopeKeywords.Select(w => w.Split(' ')[0]).ToArray();

        #endregion

        #region [Constructor]

        #endregion

        #region [Public Method]

        protected ScopeBase CreateScope(TargetPosition targetPosition, IScopeFactory scopeFactory) => scopeFactory.CreateScope(targetPosition);

        public override string ToString() => this.ToString(" and ");

        public void UpdateFinderArea(TargetFinder targetFinder)
        {
            NearBase previousNear = null;
            Area tableArea = null;

            foreach (var scope in this)
            {
                if ((scope.Target.TargetType == TargetType.Column) && tableArea != null)
                {
                    var currentArea = targetFinder.ElementFinder.Area;
                    targetFinder.ElementFinder.Area = tableArea;
                    scope.DetectDomElements(targetFinder);
                    targetFinder.ElementFinder.Area = currentArea;
                }
                else
                    scope.DetectDomElements(targetFinder);

                if (scope.TargetElements.None())
                    throw new ElementNotFoundException($"Cannot find the target element of scope. No '{scope.Target}' found in this area of the page");

                if (!scope.TargetElements.IsSingle() && previousNear != null)
                    scope.TargetElements = previousNear.ReduceElements(scope.TargetElements).ToList();

                if (!scope.TargetElements.IsSingle())
                    throw new MultipleElementsFoundException(scope.TargetElements, $"Target element of scope is not unique. More than one '{scope.Target}' found in this area of the page");

                if (scope.Target.TargetType == TargetType.Table || scope.Target.TargetType == TargetType.Row)
                    tableArea = GetTableArea(targetFinder.ElementFinder, scope.TargetElements.First());

                var near = scope as NearBase;
                if (near == null)
                    scope.UpdateArea(targetFinder.ElementFinder.Area);

                previousNear = near;
            }
        }

        public Element FindSingleElement(IEnumerable<Element> elements)
        {
            if (elements.None())
                return null;

            var lastScope = this.LastOrDefault() as NearBase;
            if (lastScope is NearBase)
                elements = lastScope.ReduceElements(elements);

            if (elements.None())
                return null;

            Element first;
            if (!elements.IsSingle(out first))
                throw new MultipleElementsFoundException(elements);

            return first;
        }

        public Area GetTableArea(IElementFinder finder, Element element)
        {
            var table = finder.GetWrappingTables(element).FirstOrDefault();

            if (table == null)
                return new Area();

            var location = table.Location;
            var size = table.Size;

            return new Area
            {
                Top = location.Y,
                Left = location.X,
                Bottom = location.Y + size.Height,
                Right = location.X + size.Width
            };
        }

        public static ScopesCollection Extract(List<ScopeTarget> scopeTargets, IScopeFactory scopeFactory)
        {
            var result = new ScopesCollection();
            foreach (var scopeTarget in scopeTargets)
            {
                var scope = result.CreateScope(scopeTarget.TargetPosition, scopeFactory);
                scope.ExtractTarget(scopeTarget);
                result.Add(scope);
            }

            return result;
        }

        #endregion

        #region [Private Method]

        #endregion
    }
}
