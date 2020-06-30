namespace Geeks.Pangolin.Helper.UIContext
{
    public interface ICommandAct
    {
        #region [Act]

        /// <summary>
        /// Sign out current user and delete browser cookies <para />
        /// Example: to sign out current user, use Logout();
        /// </summary>
        void Logout();

        /// <summary>
        /// go to the url. <para />
        /// Example: to go to the url  "http://url", use Goto("http://url");
        /// </summary>
        void Goto(string url);

        /// <summary>
        /// switch to another tab by name. <para />
        /// Example: to switch to the another tab with name "tab name", use SwitchToTab("tab name");
        /// </summary>
        void SwitchToTab(string tabName);

        /// <summary>
        /// close tab by name. <para />
        /// Example: to close the tab with name "tab name", use CloseTab("tab name");
        /// </summary>
        void CloseTab(string tabName);

        /// <summary>
        /// close pop up by ifram. <para />
        /// Example: to close the current pop up, use ClosePopup();
        /// </summary>
        void ClosePopup();

        /// <summary>
        /// wait for pop up. <para />
        /// Example: to wait for pop up, use WaitForPopup();
        /// </summary>
        void WaitForPopup();

        /// <summary>
        /// Wait for new page. <para />
        /// Example: to wait for new page use WaitForNewPage();
        /// </summary>
        void WaitForNewPage();

        /// <summary>
        /// refresh browser page. <para />
        /// Example: to refresh browser page, use RefreshPage();
        /// </summary>
        void RefreshPage();

        /// <summary>
        /// execute press keys: Tab, Enter, Escape, ArrowUp, ArrowDown, ArrowLeft,
        /// ArrowRight, Backspace, Delete, End, Home, Space <para />
        /// Example: to press Enter and Tab on the page use Press(Keys.Enter, Keys.Tab);
        /// </summary>
        void Press(params Keys[] keys);

        /// <summary>
        /// open downloaded file in the specified folder from key "Download.Url" in "app.config". <para />
        /// Example: to open a "file.jpg" that has been downloaded to "sample folder" from key "Download.Url" in "app.config" use Open("file.jpg");
        /// </summary>
        void Open(string target);

        /// <summary>
        /// copy current browser url to the clipboard. <para />
        /// Example: to copy current url use CopyUrl();
        /// </summary>
        void CopyUrl();

        /// <summary>
        /// to go to the page that has been copied by CopyUrl command. <para />
        /// Example: to go to the copied url use GotoCopiedUrl();
        /// </summary>
        void GotoCopiedUrl();

        /// <summary>
        /// to accept an alert of the page. <para />
        /// Example: to accept an alert use AcceptAlert();
        /// </summary>
        void AcceptAlert();

        /// <summary>
        /// to cancel an alert of the page. <para />
        /// Example: to cancel an alert use CancelAlert();
        /// </summary>
        void CancelAlert();

        /// <summary>
        /// Expect current browser url <para />
        /// Example: to find that browser url is match to "http://url" use ExpectUrl("http://url");
        /// </summary>
        void ExpectUrl(string locator);

        /// <summary>
        /// type in the focues element on the page <para />
        /// Example: to type "type" in the element use Type("type");
        /// </summary>
        void Type(string text);


        #endregion
    }
}
