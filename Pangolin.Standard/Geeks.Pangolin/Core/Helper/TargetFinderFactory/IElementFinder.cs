using System;
using System.Collections.Generic;
using Geeks.Pangolin.Core.Dom;
using Geeks.Pangolin.Core.Helper.Targets;

namespace Geeks.Pangolin.Core.Helper.TargetFinderFactory
{
    public interface IElementFinder
    {
        Area Area { get; set; }
        IEnumerable<Element> FindTableRowsByPosition(int position);
        IEnumerable<Element> FindElementsByTargetType(TargetType targetType, string label, Func<string, bool> labelCheck, bool isCaseSensetive);
        IEnumerable<Element> FindElementsContainingText(string text, TargetType targetType);
        IEnumerable<Element> FindElementsByText(string text, TargetType targetType);
        IEnumerable<Element> FindElementsByCSS(string text);
        IEnumerable<Element> FindElementsByXPath(string text);
        IEnumerable<Element> FindWebElementsBasedOnRegex(string text);
        IEnumerable<Element> FindElementsContainingValue(string text);
        IEnumerable<Element> GetWrappingTables(Element element);
    }
}
