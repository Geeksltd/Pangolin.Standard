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

        public abstract void ExecuteIFrame(ActionTarget target);

        #endregion

        #region [Protected Method]

        protected void IFrame(ActionTarget target) => ExecuteIFrame(target);

        #endregion

        #region [Private Method]

        #endregion
    }
}

