using Geeks.Pangolin.Core.Dom;
using Geeks.Pangolin.Core.Exception;
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

        #region [Abstract Method]
        public abstract void ExecuteHoverOver(Element singleElement);

        #endregion

        #region [Private Method]

        private void HoverOver(ActionTarget target)
        {
            var singleElement = Scopes.FindSingleElement(TargetFinderFactory.CreateTargetFinder(Finder).Find(target, Scopes));

            if (singleElement == null)
                throw new ElementNotFoundException($"Cannot find any '{target.Text}'");

            ExecuteHoverOver(singleElement);
        }

        #endregion
    }
}

