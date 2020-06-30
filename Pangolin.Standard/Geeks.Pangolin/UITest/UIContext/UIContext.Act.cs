using Geeks.Pangolin.Service.DriverService;
using Geeks.Pangolin.Helper.Execution;

namespace Geeks.Pangolin.Helper.UIContext
{
    public partial class UIContext
    {
        #region [Act]

        public void Logout() => RunCommand(this,() => WebDriverService.Logout());

        public void Goto(string url) => RunCommand(this, () => WebDriverService.Goto(url));

        public void SwitchToTab(string tabName) => RunCommand(this, () => WebDriverService.SwitchToTab(tabName));

        public void CloseTab(string tabName) => RunCommand(this, () => WebDriverService.CloseTab(tabName));

        public void ClosePopup() => RunCommand(this, () => WebDriverService.ClosePopup());

        public void WaitForPopup() => RunCommand(this, () => WebDriverService.WaitForPopup());

        public void WaitForNewPage() => RunCommand(this, () => WebDriverService.WaitForNewPage());

        public void RefreshPage() => RunCommand(this, () => WebDriverService.RefreshPage());

        public void Press(params Keys[] keys) => RunCommand(this, () => WebDriverService.Press(keys));

        public void Open(string target) => RunCommand(this, () => WebDriverService.Open(target));

        public void CopyUrl() => RunCommand(this, () => WebDriverService.CopyUrl());

        public void CopyUrl(string key) => RunCommand(this, () => WebDriverService.CopyUrl(key));

        public void GotoCopiedUrl() => RunCommand(this, () => WebDriverService.GotoCopiedUrl());

        public void GotoCopiedUrl(string key) => RunCommand(this, () => WebDriverService.GotoCopiedUrl(key));

        public void AcceptAlert() => RunCommand(this, () => WebDriverService.AcceptAnyAlert());

        public void CancelAlert() => RunCommand(this, () => WebDriverService.CancelAnyAlert());

        public void ExpectUrl(string locator) => RunCommand(this, () => WebDriverService.ExpectUrl(locator));

        public void Type(string text) => RunCommand(this, () => WebDriverService.Type(text));

        public void TakeScreenshot(string name) => RunCommand(this, () => TestRunner.TakeScreenshot(name));


        #endregion
    }
}
