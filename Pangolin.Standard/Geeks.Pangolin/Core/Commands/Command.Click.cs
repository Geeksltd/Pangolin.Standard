using Geeks.Pangolin.Core.Dom;
using Geeks.Pangolin.Core.Exception;
using Geeks.Pangolin.Core.Helper;
using Geeks.Pangolin.Core.Helper.Enums;
using Geeks.Pangolin.Core.Helper.Targets;

namespace Geeks.Pangolin.Core.Commands
{
    public abstract partial class Command
    {
        #region [Property]

        #endregion

        #region [Constructor]

        #endregion

        #region [Public Method]

        #endregion

        #region [Protected Method]

        protected abstract ClickOutcome ExecuteClick(Element element);
     
        #endregion

        #region [Private Method]

        private void Click(ActionTarget target)
        {
            RememberCurrentPageState();

            var clickables = TargetFinderFactory.CreateTargetFinder(Finder).Find(target, Scopes);
            var singleElement = Scopes.FindSingleElement(clickables);
            if (singleElement == null)
                throw new ElementNotFoundException($"Cannot find any '{target.Text}' {target.TargetType.ToString().OnlyWhen(target.TargetType != TargetType.Any)}");

            var outcome = ExecuteClick(singleElement);
            WaitIfNecessary(outcome);
        }

        private void WaitIfNecessary(ClickOutcome outcome)
        {
            if (outcome == ClickOutcome.OpenModal)
            {
                ExecuteWaitForPopup();
            }
            else if (outcome == ClickOutcome.CloseModal)
            {
                ExecuteWaitForNewPage();
            }
            else if (outcome == ClickOutcome.Navigate || outcome == ClickOutcome.PartialUpdate)
            {
                ExecuteWaitForNewPage();
            }
        }

        #endregion
    }
}
