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

        public abstract bool IsElementOnPage(ActionTarget target);

        #endregion

        #region [Protected Method]

        #endregion

        #region [Private Method]

        private void Expect(ActionTarget target)
        {

            var found = IsElementOnPage(target);

            if (target.ActionType == TargetActionType.ExpectNo && found)
                throw new ExpectationFailedException($"Found {target.Text}");

            if (target.ActionType == TargetActionType.Expect && !found)
                throw new ExpectationFailedException($"Found no {target.Text}");
        }

        #endregion
    }
}
