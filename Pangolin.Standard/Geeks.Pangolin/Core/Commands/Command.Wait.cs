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

        protected void Wait(ActionTarget target) => ExecuteWaitUntil(target, target.ActionType == TargetActionType.WaitToSeeNo);
        protected abstract void ExecuteWaitUntil(ActionTarget target, bool disapears);

        #endregion

        #region [Private Method]

        #endregion
    }
}

