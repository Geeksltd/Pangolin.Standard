using Geeks.Pangolin.Core.Helper.Targets;
using Geeks.Pangolin.Helper.Command;
using Geeks.Pangolin.Helper.UIContext;
using System;

namespace Geeks.Pangolin
{
    public class WindowContext : Disposable
    {
        #region [Property]
        private readonly UIContext _uiContext;
        #endregion

        #region [Constructor]

        #endregion

        #region [Public Method]

        protected override void DisposeCore() => _uiContext.WebDriverService.SetDefaultContent();

        public WindowContext(UIContext uiContext, ActionTarget scopeTarget)
        {
            _uiContext = uiContext ?? throw new ArgumentNullException(nameof(uiContext));
            _uiContext.WebDriverService.RunTestCase(_uiContext, scopeTarget); 
        }

        #endregion

        #region [Private Method]

        #endregion
    }
}
