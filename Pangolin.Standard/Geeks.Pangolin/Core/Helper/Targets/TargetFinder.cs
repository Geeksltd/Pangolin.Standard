using System;
using System.Collections.Generic;
using System.Linq;
using Geeks.Pangolin.Core.Dom;
using Geeks.Pangolin.Core.Scopes;
using Geeks.Pangolin.Core.Exception;
using Geeks.Pangolin.Core.Helper.TargetFinderFactory;

namespace Geeks.Pangolin.Core.Helper.Targets
{
    public abstract class TargetFinder
    {
        #region [Property]

        public IElementFinder ElementFinder { get; protected set; }

        #endregion

        #region [Constructor]

        protected TargetFinder(IElementFinder elementFinder)
        {
            ElementFinder = elementFinder;
        }

        #endregion

        #region [Public Method]

        public abstract IEnumerable<Element> Find(TargetBase target, ScopesCollection scopes);

        #endregion

        #region [Protected Method]

        protected virtual IEnumerable<Element> DoFind(TargetBase target, ScopesCollection scopes)
        {
            var result = new List<Element>();

            var labelCheck = GetLabelCheckFunction(target);

            if (target.TargetType == TargetType.Any && target.SearchType != SearchType.Wildcard)
            {
                result.AddRange(ElementFinder.FindElementsContainingText(target.Text, TargetType.Any));
            }
            else if (target.TargetType == TargetType.Text && target.SearchType != SearchType.Wildcard)
            {
                result.AddRange(ElementFinder.FindElementsByText(target.Text, TargetType.Any));
            }
            else if (target.TargetType == TargetType.CSS)
            {
                result.AddRange(ElementFinder.FindElementsByCSS(target.Text));
            }
            else if (target.TargetType == TargetType.XPath)
            {
                result.AddRange(ElementFinder.FindElementsByXPath(target.Text));
            }
            else if (target.TargetType == TargetType.Value && target.SearchType != SearchType.Wildcard)
            {
                result.AddRange(ElementFinder.FindElementsContainingValue(target.Text));
            }
            else if (target.TargetType == TargetType.Row && target.SearchType == SearchType.Position)
            {
                result.AddRange(ElementFinder.FindTableRowsByPosition(target.Text.TryParseAs<int>().Value));
            }
            else if (target.SearchType == SearchType.Wildcard)
            {
                result.AddRange(ElementFinder.FindWebElementsBasedOnRegex(target.Text));
            }
            else
            {
                result.AddRange(ElementFinder.FindElementsByTargetType(target.TargetType, target.Text, labelCheck, isCaseSensetive: (target.SearchType == SearchType.EqualityExact || target.SearchType == SearchType.ContainsExact)));
            }

            if (target.Text.HasValue() && target.TargetType != TargetType.XPath && target.TargetType != TargetType.CSS)
                result.RemoveAll(r => labelCheck(r.Label.Or(r.VisualText)) == false);

            if (result.None())
                throw new ElementNotFoundException($"Cannot find any {target.Text}'");

            if (result.Count == 1)
                return result;

            if (target.Limiter == Limiter.Everything)
                return result;

            if (target.Limiter == Limiter.Single)
            {
                var isLastScopeNear = scopes?.LastOrDefault() is NearBase;
                if (result.HasMany() && !isLastScopeNear)
                    throw new MultipleElementsFoundException(result, $"More than one '{target.Text}' found");

                return result;
            }

            if (target.Limiter == Limiter.Topmost)
            {
                result = result.AllWithMin(r => r.Location.Y).ToList();
                if (result.HasMany())
                    throw new MultipleElementsFoundException(result, $"More than one '{target.Text}' found with aligned top");
            }
            else if (target.Limiter == Limiter.Lowest)
            {
                result = result.AllWithMax(r => r.Location.Y).ToList();
                if (result.HasMany())
                    throw new MultipleElementsFoundException(result, $"More than one '{target.Text}' found with aligned top");
            }
            else if (target.Limiter == Limiter.Leftmost)
            {
                result = result.AllWithMin(r => r.Location.X).ToList();
                if (result.HasMany())
                    throw new MultipleElementsFoundException(result, $"More than one '{target.Text}' found with aligned left");
            }
            else if (target.Limiter == Limiter.Rightmost)
            {
                result = result.AllWithMax(r => r.Location.X).ToList();
                if (result.HasMany())
                    throw new MultipleElementsFoundException(result, $"More than one '{target.Text}' found with aligned left");
            }

            return result;
        }


        protected virtual void OnBeforeRetryFind(){}

        #endregion

        #region [Private Method]

        private Func<string, bool> GetLabelCheckFunction(TargetBase target)
        {
            if (target.Text.HasValue())
            {
                if (target.SearchType == SearchType.EqualityExact)
                {
                    if (target.TargetType == TargetType.Row)
                        return s => s.Split('\t').Any(d => d == target.Text);
                    return s => s == target.Text;
                }

                if (target.SearchType == SearchType.EqualityIgnore)
                {
                    if (target.TargetType == TargetType.Row)
                        return s => s?.Trim().Split('\t').Any(d => d.Trim().Equals(target.Text.Trim(), StringComparison.InvariantCultureIgnoreCase)) ?? false;
                    return s => s?.Trim().Equals(target.Text.Trim(), StringComparison.InvariantCultureIgnoreCase) == true;
                }

                if (target.SearchType == SearchType.Wildcard)
                {
                    target.Text = "^" + target.Text.Replace("{digit}", "[0-9]{1}").Replace("{letter}", "[a-zA-Z]{1}") + "$";
                    return s => System.Text.RegularExpressions.Regex.IsMatch(s, target.Text);
                }

                if (target.SearchType == SearchType.ContainsIgnore)
                {
                    if (target.TargetType == TargetType.Row)
                        return s => s?.Trim().Split('\t').Any(d => d.Trim().IndexOf(target.Text.Trim(), StringComparison.InvariantCultureIgnoreCase) >= 0) ?? false;
                    return s => s?.IndexOf(target.Text, StringComparison.InvariantCultureIgnoreCase) >= 0;
                }

                if (target.SearchType == SearchType.ContainsExact)
                {
                    if (target.TargetType == TargetType.Row)
                        return s => s?.Trim().Split('\t').Any(d => d.Trim().Equals(target.Text.Trim(), StringComparison.InvariantCulture)) ?? false;
                    return s => s?.IndexOf(target.Text, StringComparison.InvariantCulture) >= 0;
                }
            }

            return s => true;
        }

        #endregion
    }
}
