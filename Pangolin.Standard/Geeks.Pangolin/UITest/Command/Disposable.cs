using System;

namespace Geeks.Pangolin.Helper.Command
{
    public class Disposable : IDisposable
    {
        #region [Property]

        private bool isDisposed;

        #endregion

        #region [Constructor & DeConstructor]

        ~Disposable()
        {
            Dispose(false);
        }

        #endregion

        #region [Protected Method]

        protected virtual void DisposeCore(){}

        #endregion

        #region [Public Method]

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region [Private Method]

        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
                DisposeCore();
            isDisposed = true;
        }

        #endregion
    }
}
