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

        public abstract void ExecuteSet(ActionTarget target);

        #endregion

        #region [Protected Method]

        #endregion

        #region [Private Method]

        private void Set(ActionTarget target) => ExecuteSet(target);

        #endregion
    }
}
