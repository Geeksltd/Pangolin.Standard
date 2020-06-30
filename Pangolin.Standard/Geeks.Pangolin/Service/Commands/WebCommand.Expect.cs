using System.Linq;
using Geeks.Pangolin.Core.Exception;
using Geeks.Pangolin.Core.Helper;
using Geeks.Pangolin.Core.Helper.Targets;
using Geeks.Pangolin.Service.Dom;

namespace Geeks.Pangolin.Service.Commands
{
    partial class WebCommand
    {
        public override bool IsElementOnPage(ActionTarget target)
        {
            bool found;
            try
            {
                var elements = TargetFinderFactory.CreateTargetFinder(Finder).Find(target, Scopes);
                if (target.TargetType.In(TargetType.Field, TargetType.Radiobox, TargetType.Checkbox) &&  target.Value.IsAnyOf("checked", "unchecked", "selected"))
                {

                    if (target.Value.IsAnyOf("checked", "unchecked"))
                        elements = elements.Where(f => f.IsCheckbox);
                    else if (target.Value == "selected")
                        elements = elements.Where(f => f.IsRadio);

                    var field = Scopes.FindSingleElement(elements) as WebElement;
                    if (field==null)
                        return false;
                    if (target.Value== "checked")
                        return field.DomElement.Selected;
                    if (target.Value == "unchecked")
                        return !field.DomElement.Selected;
                    if (target.Value == "selected")
                        return field.DomElement.Selected;
                }

                found = elements.Any();
            }
            catch (ElementNotFoundException)
            {
                found = false;
            }
            catch (MultipleElementsFoundException)
            {
                found = true;
            }

            return found;
        }
    }
}
