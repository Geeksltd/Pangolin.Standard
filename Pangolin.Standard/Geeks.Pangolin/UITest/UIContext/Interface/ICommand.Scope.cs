
namespace Geeks.Pangolin.Helper.UIContext
{
    public interface ICommandScope
    {
        #region [TargetType]

        #region [Any]

        #region [TargetPosition]

        #region [At]

        /// <summary>
        /// set at scope by That and Casing. default values are What.Equals and Casing.Ignore <para />
        /// Example: to set at scope "scope" on the page by exact match, use At(What.Equals, "scope").
        /// </summary>
        ICommand At(The the, What what, string locator, Casing casing = Casing.Ignore);
        ICommand At(The the, string locator, Casing casing = Casing.Ignore);
        ICommand At(What what, string locator, Casing casing = Casing.Ignore);
        ICommand At(string locator, Casing casing = Casing.Ignore);

        #endregion

        #region [Above]

        /// <summary>
        /// set above scope by That and Casing. default values are What.Equals and Casing.Ignore <para />
        /// Example: to set above scope "scope" on the page by exact match, use Above(What.Equals, "scope").
        /// </summary>
        ICommand Above(The the, What what, string locator, Casing casing = Casing.Ignore);
        ICommand Above(The the, string locator, Casing casing = Casing.Ignore);
        ICommand Above(What what, string locator, Casing casing = Casing.Ignore);
        ICommand Above(string locator, Casing casing = Casing.Ignore);

        #endregion

        #region [Below]

        /// <summary>
        /// set below scope by That and Casing. default values are What.Equals and Casing.Ignore <para />
        /// Example: to set below scope "scope" on the page by exact match, use Below(What.Equals, "scope").
        /// </summary>
        ICommand Below(The the, What what, string locator, Casing casing = Casing.Ignore);
        ICommand Below(The the, string locator, Casing casing = Casing.Ignore);
        ICommand Below(What what, string locator, Casing casing = Casing.Ignore);
        ICommand Below(string locator, Casing casing = Casing.Ignore);

        #endregion

        #region [LeftOf]

        /// <summary>
        /// set left of scope by That and Casing. default values are What.Equals and Casing.Ignore <para />
        /// Example: to set left of scope "scope" on the page by exact match, use LeftOf(What.Equals, "scope").
        /// </summary>
        ICommand LeftOf(The the, What what, string locator, Casing casing = Casing.Ignore);
        ICommand LeftOf(The the, string locator, Casing casing = Casing.Ignore);
        ICommand LeftOf(What what, string locator, Casing casing = Casing.Ignore);
        ICommand LeftOf(string locator, Casing casing = Casing.Ignore);

        #endregion

        #region [RightOf]

        /// <summary>
        /// set right of scope by That and Casing. default values are What.Equals and Casing.Ignore <para />
        /// Example: to set right of scope "scope" on the page by exact match, use RightOf(What.Equals, "scope").
        /// </summary>
        ICommand RightOf(The the, What what, string locator, Casing casing = Casing.Ignore);
        ICommand RightOf(The the, string locator, Casing casing = Casing.Ignore);
        ICommand RightOf(What what, string locator, Casing casing = Casing.Ignore);
        ICommand RightOf(string locator, Casing casing = Casing.Ignore);

        #endregion

        #region [Near]

        /// <summary>
        /// set near scope by That and Casing. default values are What.Equals and Casing.Ignore <para />
        /// Example: to set near scope "scope" on the page by exact match, use Near(What.Equals, "scope").
        /// </summary>
        ICommand Near(The the, What what, string locator, Casing casing = Casing.Ignore);
        ICommand Near(The the, string locator, Casing casing = Casing.Ignore);
        ICommand Near(What what, string locator, Casing casing = Casing.Ignore);
        ICommand Near(string locator, Casing casing = Casing.Ignore);

        #endregion

        #endregion

        #endregion

        #region [Text]

        #region [TargetPosition]

        #region [At]

        /// <summary>
        /// set at scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set at scope "scope" on the page by exact match, use AtText(That.Equals, "scope").
        /// </summary>
        ICommand AtText(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AtText(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand AtText(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AtText(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Above]

        /// <summary>
        /// set above scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set above scope "scope" on the page by exact match, use AboveText(That.Equals, "scope").
        /// </summary>
        ICommand AboveText(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveText(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveText(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveText(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Below]

        /// <summary>
        /// set below scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set below scope "scope" on the page by exact match, use BelowText(That.Equals, "scope").
        /// </summary>
        ICommand BelowText(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowText(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowText(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowText(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [LeftOf]

        /// <summary>
        /// set left of scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set left of scope "scope" on the page by exact match, use LeftOfText(That.Equals, "scope").
        /// </summary>
        ICommand LeftOfText(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfText(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfText(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfText(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [RightOf]

        /// <summary>
        /// set right of scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set right of scope "scope" on the page by exact match, use RightOfText(That.Equals, "scope").
        /// </summary>
        ICommand RightOfText(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfText(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfText(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfText(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Near]

        /// <summary>
        /// set near scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set near scope "scope" on the page by exact match, use NearText(That.Equals, "scope").
        /// </summary>
        ICommand NearText(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearText(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearText(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearText(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #endregion

        #endregion

        #region [CSS]

        #region [TargetPosition]

        #region [At]

        /// <summary>
        /// set at scope by CSS <para />
        /// Example: to set at scope "scope" on the page by CSS, use AtCSS("scope").
        /// </summary>
        ICommand AtCSS(The the, string locator);
        ICommand AtCSS(string locator);

        #endregion

        #region [Above]

        /// <summary>
        /// set above scope by CSS <para />
        /// Example: to set above scope "scope" on the page by CSS, use AboveCSS("scope").
        /// </summary>
        ICommand AboveCSS(The the, string locator);
        ICommand AboveCSS(string locator);

        #endregion

        #region [Below]

        /// <summary>
        /// set below scope by CSS <para />
        /// Example: to set below scope "scope" on the page by CSS, use BelowCSS("scope").
        /// </summary>
        ICommand BelowCSS(The the, string locator);
        ICommand BelowCSS(string locator);

        #endregion

        #region [LeftOf]

        /// <summary>
        /// set left of scope by CSS <para />
        /// Example: to set left of scope "scope" on the page by CSS, use LeftOfCSS("scope").
        /// </summary>
        ICommand LeftOfCSS(The the, string locator);
        ICommand LeftOfCSS(string locator);

        #endregion

        #region [RightOf]

        /// <summary>
        /// set right of scope by CSS <para />
        /// Example: to set right of scope "scope" on the page by CSS, use RightOfCSS("scope").
        /// </summary>
        ICommand RightOfCSS(The the, string locator);
        ICommand RightOfCSS(string locator);

        #endregion

        #region [Near]

        /// <summary>
        /// set near scope by CSS <para />
        /// Example: to set near scope "scope" on the page by CSS, use NearCSS("scope").
        /// </summary>
        ICommand NearCSS(The the, string locator);
        ICommand NearCSS(string locator);

        #endregion

        #endregion

        #endregion

        #region [XPath]

        #region [TargetPosition]

        #region [At]

        /// <summary>
        /// set at scope by XPath <para />
        /// Example: to set at scope "scope" on the page by xpath, use AtXPath("scope").
        /// </summary>
        ICommand AtXPath(The the, string locator);
        ICommand AtXPath(string locator);

        #endregion

        #region [Above]

        /// <summary>
        /// set above scope by XPath <para />
        /// Example: to set above scope "scope" on the page by xpath, use AboveXPath("scope").
        /// </summary>
        ICommand AboveXPath(The the, string locator);
        ICommand AboveXPath(string locator);

        #endregion

        #region [Below]

        /// <summary>
        /// set below scope by XPath <para />
        /// Example: to set below scope "scope" on the page by xpath, use BelowXPath("scope").
        /// </summary>
        ICommand BelowXPath(The the, string locator);
        ICommand BelowXPath(string locator);

        #endregion

        #region [LeftOf]

        /// <summary>
        /// set left of scope by XPath <para />
        /// Example: to set left of scope "scope" on the page by xpath, use LeftOfXPath("scope").
        /// </summary>
        ICommand LeftOfXPath(The the, string locator);
        ICommand LeftOfXPath(string locator);

        #endregion

        #region [RightOf]

        /// <summary>
        /// set right of scope by XPath <para />
        /// Example: to set right of scope "scope" on the page by xpath, use RightOfXPath("scope").
        /// </summary>
        ICommand RightOfXPath(The the, string locator);
        ICommand RightOfXPath(string locator);

        #endregion

        #region [Near]

        /// <summary>
        /// set near scope by XPath <para />
        /// Example: to set near scope "scope" on the page by xpath, use NearXPath("scope").
        /// </summary>
        ICommand NearXPath(The the, string locator);
        ICommand NearXPath(string locator);

        #endregion

        #endregion

        #endregion

        #region [Button]

        #region [TargetPosition]

        //#region [At]

        ///// <summary>
        ///// set at button scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        ///// Example: to set at button scope "scope" on the page by exact match, use AtButton(That.Equals, "scope").
        ///// </summary>
        //ICommand AtButton(The the, That that, string locator, Casing casing);
        //ICommand AtButton(The the, That that, string locator);
        //ICommand AtButton(The the, string locator, Casing casing);
        //ICommand AtButton(The the, string locator);
        //ICommand AtButton(The the);
        //ICommand AtButton(That that, string locator, Casing casing);
        //ICommand AtButton(That that, string locator);
        //ICommand AtButton(string locator, Casing casing);
        //ICommand AtButton(string locator);
        //ICommand AtButton();

        //#endregion

        #region [Above]

        /// <summary>
        /// set above button scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set above button scope "scope" on the page by exact match, use AboveButton(That.Equals, "scope").
        /// </summary>
        ICommand AboveButton(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveButton(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveButton(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveButton(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Below]

        /// <summary>
        /// set below button scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set below button scope "scope" on the page by exact match, use BelowButton(That.Equals, "scope").
        /// </summary>
        ICommand BelowButton(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowButton(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowButton(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowButton(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [LeftOf]

        /// <summary>
        /// set left of button scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set left of button scope "scope" on the page by exact match, use LeftOfButton(That.Equals, "scope").
        /// </summary>
        ICommand LeftOfButton(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfButton(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfButton(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfButton(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [RightOf]

        /// <summary>
        /// set right of button scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set right of button scope "scope" on the page by exact match, use RightOfButton(That.Equals, "scope").
        /// </summary>
        ICommand RightOfButton(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfButton(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfButton(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfButton(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Near]

        /// <summary>
        /// set near button scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set near button scope "scope" on the page by exact match, use NearButton(That.Equals, "scope").
        /// </summary>
        ICommand NearButton(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearButton(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearButton(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearButton(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #endregion

        #endregion

        #region [Link]

        #region [TargetPosition]

        //#region [At]

        ///// <summary>
        ///// set at Link scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        ///// Example: to set at Link scope "scope" on the page by exact match, use AtLink(That.Equals, "scope").
        ///// </summary>
        //ICommand AtLink(The the, That that, string locator, Casing casing);
        //ICommand AtLink(The the, That that, string locator);
        //ICommand AtLink(The the, string locator, Casing casing);
        //ICommand AtLink(The the, string locator);
        //ICommand AtLink(The the);
        //ICommand AtLink(That that, string locator, Casing casing);
        //ICommand AtLink(That that, string locator);
        //ICommand AtLink(string locator, Casing casing);
        //ICommand AtLink(string locator);
        //ICommand AtLink();

        //#endregion

        #region [Above]

        /// <summary>
        /// set above Link scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set above Link scope "scope" on the page by exact match, use AboveLink(That.Equals, "scope").
        /// </summary>
        ICommand AboveLink(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveLink(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveLink(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveLink(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Below]

        /// <summary>
        /// set below Link scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set below Link scope "scope" on the page by exact match, use BelowLink(That.Equals, "scope").
        /// </summary>
        ICommand BelowLink(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowLink(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowLink(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowLink(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [LeftOf]

        /// <summary>
        /// set left of Link scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set left of Link scope "scope" on the page by exact match, use LeftOfLink(That.Equals, "scope").
        /// </summary>
        ICommand LeftOfLink(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfLink(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfLink(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfLink(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [RightOf]

        /// <summary>
        /// set right of Link scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set right of Link scope "scope" on the page by exact match, use RightOfLink(That.Equals, "scope").
        /// </summary>
        ICommand RightOfLink(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfLink(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfLink(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfLink(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Near]

        /// <summary>
        /// set near Link scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set near Link scope "scope" on the page by exact match, use NearLink(That.Equals, "scope").
        /// </summary>
        ICommand NearLink(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearLink(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearLink(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearLink(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #endregion

        #endregion

        #region [Field]

        #region [TargetPosition]

        #region [At]

        /// <summary>
        /// set at Field scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set at Field scope "scope" on the page by exact match, use AtField(That.Equals, "scope").
        /// </summary>
        ICommand AtField(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AtField(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand AtField(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AtField(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Above]

        /// <summary>
        /// set above Field scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set above Field scope "scope" on the page by exact match, use AboveField(That.Equals, "scope").
        /// </summary>
        ICommand AboveField(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveField(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveField(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveField(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Below]

        /// <summary>
        /// set below Field scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set below Field scope "scope" on the page by exact match, use BelowField(That.Equals, "scope").
        /// </summary>
        ICommand BelowField(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowField(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowField(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowField(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [LeftOf]

        /// <summary>
        /// set left of Field scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set left of Field scope "scope" on the page by exact match, use LeftOfField(That.Equals, "scope").
        /// </summary>
        ICommand LeftOfField(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfField(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfField(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfField(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [RightOf]

        /// <summary>
        /// set right of Field scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set right of Field scope "scope" on the page by exact match, use RightOfField(That.Equals, "scope").
        /// </summary>
        ICommand RightOfField(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfField(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfField(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfField(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Near]

        /// <summary>
        /// set near Field scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set near Field scope "scope" on the page by exact match, use NearField(That.Equals, "scope").
        /// </summary>
        ICommand NearField(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearField(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearField(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearField(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #endregion

        #endregion

        #region [Header]

        #region [TargetPosition]

        #region [At]

        /// <summary>
        /// set at Header scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set at Header scope "scope" on the page by exact match, use AtHeader(That.Equals, "scope").
        /// </summary>
        ICommand AtHeader(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AtHeader(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand AtHeader(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AtHeader(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Above]

        /// <summary>
        /// set above Header scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set above Header scope "scope" on the page by exact match, use AboveHeader(That.Equals, "scope").
        /// </summary>
        ICommand AboveHeader(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveHeader(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveHeader(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveHeader(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Below]

        /// <summary>
        /// set below Header scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set below Header scope "scope" on the page by exact match, use BelowHeader(That.Equals, "scope").
        /// </summary>
        ICommand BelowHeader(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowHeader(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowHeader(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowHeader(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [LeftOf]

        /// <summary>
        /// set left of Header scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set left of Header scope "scope" on the page by exact match, use LeftOfHeader(That.Equals, "scope").
        /// </summary>
        ICommand LeftOfHeader(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfHeader(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfHeader(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfHeader(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [RightOf]

        /// <summary>
        /// set right of Header scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set right of Header scope "scope" on the page by exact match, use RightOfHeader(That.Equals, "scope").
        /// </summary>
        ICommand RightOfHeader(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfHeader(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfHeader(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfHeader(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Near]

        /// <summary>
        /// set near Header scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set near Header scope "scope" on the page by exact match, use NearHeader(That.Equals, "scope").
        /// </summary>
        ICommand NearHeader(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearHeader(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearHeader(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearHeader(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #endregion

        #endregion

        #region [Label]

        #region [TargetPosition]

        #region [At]

        /// <summary>
        /// set at Label scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set at Label scope "scope" on the page by exact match, use AtLabel(That.Equals, "scope").
        /// </summary>
        ICommand AtLabel(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AtLabel(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand AtLabel(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AtLabel(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Above]

        /// <summary>
        /// set above Label scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set above Label scope "scope" on the page by exact match, use AboveLabel(That.Equals, "scope").
        /// </summary>
        ICommand AboveLabel(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveLabel(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveLabel(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveLabel(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Below]

        /// <summary>
        /// set below Label scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set below Label scope "scope" on the page by exact match, use BelowLabel(That.Equals, "scope").
        /// </summary>
        ICommand BelowLabel(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowLabel(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowLabel(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowLabel(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [LeftOf]

        /// <summary>
        /// set left of Label scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set left of Label scope "scope" on the page by exact match, use LeftOfLabel(That.Equals, "scope").
        /// </summary>
        ICommand LeftOfLabel(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfLabel(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfLabel(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfLabel(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [RightOf]

        /// <summary>
        /// set right of Label scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set right of Label scope "scope" on the page by exact match, use RightOfLabel(That.Equals, "scope").
        /// </summary>
        ICommand RightOfLabel(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfLabel(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfLabel(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfLabel(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Near]

        /// <summary>
        /// set near Label scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set near Label scope "scope" on the page by exact match, use NearLabel(That.Equals, "scope").
        /// </summary>
        ICommand NearLabel(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearLabel(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearLabel(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearLabel(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #endregion

        #endregion

        #region [Checkbox]

        #region [TargetPosition]

        //#region [At]

        ///// <summary>
        ///// set at Checkbox scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        ///// Example: to set at Checkbox scope "scope" on the page by exact match, use AtCheckbox(That.Equals, "scope").
        ///// </summary>
        //ICommand AtCheckbox(The the, That that, string locator, Casing casing);
        //ICommand AtCheckbox(The the, That that, string locator);
        //ICommand AtCheckbox(The the, string locator, Casing casing);
        //ICommand AtCheckbox(The the, string locator);
        //ICommand AtCheckbox(The the);
        //ICommand AtCheckbox(That that, string locator, Casing casing);
        //ICommand AtCheckbox(That that, string locator);
        //ICommand AtCheckbox(string locator, Casing casing);
        //ICommand AtCheckbox(string locator);
        //ICommand AtCheckbox();

        //#endregion

        #region [Above]

        /// <summary>
        /// set above Checkbox scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set above Checkbox scope "scope" on the page by exact match, use AboveCheckbox(That.Equals, "scope").
        /// </summary>
        ICommand AboveCheckbox(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveCheckbox(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveCheckbox(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveCheckbox(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Below]

        /// <summary>
        /// set below Checkbox scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set below Checkbox scope "scope" on the page by exact match, use BelowCheckbox(That.Equals, "scope").
        /// </summary>
        ICommand BelowCheckbox(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowCheckbox(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowCheckbox(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowCheckbox(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [LeftOf]

        /// <summary>
        /// set left of Checkbox scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set left of Checkbox scope "scope" on the page by exact match, use LeftOfCheckbox(That.Equals, "scope").
        /// </summary>
        ICommand LeftOfCheckbox(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfCheckbox(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfCheckbox(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfCheckbox(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [RightOf]

        /// <summary>
        /// set right of Checkbox scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set right of Checkbox scope "scope" on the page by exact match, use RightOfCheckbox(That.Equals, "scope").
        /// </summary>
        ICommand RightOfCheckbox(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfCheckbox(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfCheckbox(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfCheckbox(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Near]

        /// <summary>
        /// set near Checkbox scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set near Checkbox scope "scope" on the page by exact match, use NearCheckbox(That.Equals, "scope").
        /// </summary>
        ICommand NearCheckbox(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearCheckbox(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearCheckbox(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearCheckbox(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #endregion

        #endregion

        #region [Radiobox]

        #region [TargetPosition]

        //#region [At]

        ///// <summary>
        ///// set at Radiobox scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        ///// Example: to set at Radiobox scope "scope" on the page by exact match, use AtRadiobox(That.Equals, "scope").
        ///// </summary>
        //ICommand AtRadiobox(The the, That that, string locator, Casing casing);
        //ICommand AtRadiobox(The the, That that, string locator);
        //ICommand AtRadiobox(The the, string locator, Casing casing);
        //ICommand AtRadiobox(The the, string locator);
        //ICommand AtRadiobox(The the);
        //ICommand AtRadiobox(That that, string locator, Casing casing);
        //ICommand AtRadiobox(That that, string locator);
        //ICommand AtRadiobox(string locator, Casing casing);
        //ICommand AtRadiobox(string locator);
        //ICommand AtRadiobox();

        //#endregion

        #region [Above]

        /// <summary>
        /// set above Radiobox scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set above Radiobox scope "scope" on the page by exact match, use AboveRadiobox(That.Equals, "scope").
        /// </summary>
        ICommand AboveRadiobox(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveRadiobox(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveRadiobox(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveRadiobox(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Below]

        /// <summary>
        /// set below Radiobox scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set below Radiobox scope "scope" on the page by exact match, use BelowRadiobox(That.Equals, "scope").
        /// </summary>
        ICommand BelowRadiobox(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowRadiobox(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowRadiobox(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowRadiobox(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [LeftOf]

        /// <summary>
        /// set left of Radiobox scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set left of Radiobox scope "scope" on the page by exact match, use LeftOfRadiobox(That.Equals, "scope").
        /// </summary>
        ICommand LeftOfRadiobox(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfRadiobox(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfRadiobox(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfRadiobox(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [RightOf]

        /// <summary>
        /// set right of Radiobox scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set right of Radiobox scope "scope" on the page by exact match, use RightOfRadiobox(That.Equals, "scope").
        /// </summary>
        ICommand RightOfRadiobox(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfRadiobox(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfRadiobox(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfRadiobox(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Near]

        /// <summary>
        /// set near Radiobox scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set near Radiobox scope "scope" on the page by exact match, use NearRadiobox(That.Equals, "scope").
        /// </summary>
        ICommand NearRadiobox(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearRadiobox(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearRadiobox(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearRadiobox(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #endregion

        #endregion

        #region [Row]

        #region [TargetPosition]

        #region [At]

        /// <summary>
        /// set row scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set row scope "scope" on the page by exact match, use Row(That.Equals, "scope").
        /// </summary>
        ICommand Row(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand Row(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand Row(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand Row(string locator = null, Casing casing = Casing.Ignore);
        ICommand Row(int position);
        ICommand Row(The the, int position);

        /// <summary>
        /// set at Row scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set at Row scope "scope" on the page by exact match, use AtRow(That.Equals, "scope").
        /// </summary>
        ICommand AtRow(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AtRow(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand AtRow(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AtRow(string locator = null, Casing casing = Casing.Ignore);
        ICommand AtRow(int position);
        ICommand AtRow(The the, int position);

        #endregion

        #region [Above]

        /// <summary>
        /// set above Row scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set above Row scope "scope" on the page by exact match, use AboveRow(That.Equals, "scope").
        /// </summary>
        ICommand AboveRow(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveRow(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveRow(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveRow(string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveRow(int position);
        ICommand AboveRow(The the, int position);

        #endregion

        #region [Below]

        /// <summary>
        /// set below Row scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set below Row scope "scope" on the page by exact match, use BelowRow(That.Equals, "scope").
        /// </summary>
        ICommand BelowRow(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowRow(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowRow(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowRow(string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowRow(int position);
        ICommand BelowRow(The the, int position);

        #endregion

        #region [LeftOf]

        /// <summary>
        /// set left of Row scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set left of Row scope "scope" on the page by exact match, use LeftOfRow(That.Equals, "scope").
        /// </summary>
        ICommand LeftOfRow(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfRow(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfRow(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfRow(string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfRow(int position);
        ICommand LeftOfRow(The the, int position);

        #endregion

        #region [RightOf]

        /// <summary>
        /// set right of Row scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set right of Row scope "scope" on the page by exact match, use RightOfRow(That.Equals, "scope").
        /// </summary>
        ICommand RightOfRow(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfRow(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfRow(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfRow(string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfRow(int position);
        ICommand RightOfRow(The the, int position);

        #endregion

        #region [Near]

        /// <summary>
        /// set near Row scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set near Row scope "scope" on the page by exact match, use NearRow(That.Equals, "scope").
        /// </summary>
        ICommand NearRow(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearRow(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearRow(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearRow(string locator = null, Casing casing = Casing.Ignore);
        ICommand NearRow(int position);
        ICommand NearRow(The the, int position);

        #endregion

        #endregion

        #endregion

        #region [RowColumns]

        #region [TargetPosition]

        #region [At]

        ///// <summary>
        ///// set row columns scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        ///// Example: to set row columns scope "scope" on the page by exact match, use RowColumns(That.Equals, "scope").
        ///// </summary>
        //ICommand RowColumns(The the, That that, Casing casing, params string[] locator);
        //ICommand RowColumns(The the, That that, params string[] locator);
        //ICommand RowColumns(The the, Casing casing, params string[] locator);
        //ICommand RowColumns(The the, params string[] locator);
        //ICommand RowColumns(The the);
        //ICommand RowColumns(That that, Casing casing, params string[] locator);
        //ICommand RowColumns(That that, params string[] locator);
        //ICommand RowColumns(Casing casing, params string[] locator);
        //ICommand RowColumns(params string[] locator);
        //ICommand RowColumns();

        /// <summary>
        /// set at row columns scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set at row columns scope "scope" on the page by exact match, use AtRowColumns(That.Equals, "scope").
        /// </summary>
        ICommand AtRowColumns(The the, That that, Casing casing, params string[] locator);
        ICommand AtRowColumns(The the, That that, params string[] locator);
        ICommand AtRowColumns(The the, Casing casing, params string[] locator);
        ICommand AtRowColumns(The the, params string[] locator);
        ICommand AtRowColumns(The the);
        ICommand AtRowColumns(That that, Casing casing, params string[] locator);
        ICommand AtRowColumns(That that, params string[] locator);
        ICommand AtRowColumns(Casing casing, params string[] locator);
        ICommand AtRowColumns(params string[] locator);
        ICommand AtRowColumns();

        #endregion

        #region [Above]

        /// <summary>
        /// set above row columns scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set above row columns scope "scope" on the page by exact match, use AboveRowColumns(That.Equals, "scope").
        /// </summary>
        ICommand AboveRowColumns(The the, That that, Casing casing, params string[] locator);
        ICommand AboveRowColumns(The the, That that, params string[] locator);
        ICommand AboveRowColumns(The the, Casing casing, params string[] locator);
        ICommand AboveRowColumns(The the, params string[] locator);
        ICommand AboveRowColumns(The the);
        ICommand AboveRowColumns(That that, Casing casing, params string[] locator);
        ICommand AboveRowColumns(That that, params string[] locator);
        ICommand AboveRowColumns(Casing casing, params string[] locator);
        ICommand AboveRowColumns(params string[] locator);
        ICommand AboveRowColumns();

        #endregion

        #region [Below]

        /// <summary>
        /// set below row columns scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set below row columns scope "scope" on the page by exact match, use BelowRowColumns(That.Equals, "scope").
        /// </summary>
        ICommand BelowRowColumns(The the, That that, Casing casing, params string[] locator);
        ICommand BelowRowColumns(The the, That that, params string[] locator);
        ICommand BelowRowColumns(The the, Casing casing, params string[] locator);
        ICommand BelowRowColumns(The the, params string[] locator);
        ICommand BelowRowColumns(The the);
        ICommand BelowRowColumns(That that, Casing casing, params string[] locator);
        ICommand BelowRowColumns(That that, params string[] locator);
        ICommand BelowRowColumns(Casing casing, params string[] locator);
        ICommand BelowRowColumns(params string[] locator);
        ICommand BelowRowColumns();

        #endregion

        #region [LeftOf]

        /// <summary>
        /// set left of row columns scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set left of row columns scope "scope" on the page by exact match, use LeftOfRowColumns(That.Equals, "scope").
        /// </summary>
        ICommand LeftOfRowColumns(The the, That that, Casing casing, params string[] locator);
        ICommand LeftOfRowColumns(The the, That that, params string[] locator);
        ICommand LeftOfRowColumns(The the, Casing casing, params string[] locator);
        ICommand LeftOfRowColumns(The the, params string[] locator);
        ICommand LeftOfRowColumns(The the);
        ICommand LeftOfRowColumns(That that, Casing casing, params string[] locator);
        ICommand LeftOfRowColumns(That that, params string[] locator);
        ICommand LeftOfRowColumns(Casing casing, params string[] locator);
        ICommand LeftOfRowColumns(params string[] locator);
        ICommand LeftOfRowColumns();

        #endregion

        #region [RightOf]

        /// <summary>
        /// set right of row columns scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set right of row columns scope "scope" on the page by exact match, use RightOfRowColumns(That.Equals, "scope").
        /// </summary>
        ICommand RightOfRowColumns(The the, That that, Casing casing, params string[] locator);
        ICommand RightOfRowColumns(The the, That that, params string[] locator);
        ICommand RightOfRowColumns(The the, Casing casing, params string[] locator);
        ICommand RightOfRowColumns(The the, params string[] locator);
        ICommand RightOfRowColumns(The the);
        ICommand RightOfRowColumns(That that, Casing casing, params string[] locator);
        ICommand RightOfRowColumns(That that, params string[] locator);
        ICommand RightOfRowColumns(Casing casing, params string[] locator);
        ICommand RightOfRowColumns(params string[] locator);
        ICommand RightOfRowColumns();

        #endregion

        #region [Near]

        /// <summary>
        /// set near row columns scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set near row columns scope "scope" on the page by exact match, use NearRowColumns(That.Equals, "scope").
        /// </summary>
        ICommand NearRowColumns(The the, That that, Casing casing, params string[] locator);
        ICommand NearRowColumns(The the, That that, params string[] locator);
        ICommand NearRowColumns(The the, Casing casing, params string[] locator);
        ICommand NearRowColumns(The the, params string[] locator);
        ICommand NearRowColumns(The the);
        ICommand NearRowColumns(That that, Casing casing, params string[] locator);
        ICommand NearRowColumns(That that, params string[] locator);
        ICommand NearRowColumns(Casing casing, params string[] locator);
        ICommand NearRowColumns(params string[] locator);
        ICommand NearRowColumns();

        #endregion

        #endregion

        #endregion

        #region [Item]

        #region [TargetPosition]

        //#region [At]

        ///// <summary>
        ///// set at Item scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        ///// Example: to set at Item scope "scope" on the page by exact match, use AtItem(That.Equals, "scope").
        ///// </summary>
        //ICommand AtItem(The the, That that, string locator, Casing casing);
        //ICommand AtItem(The the, That that, string locator);
        //ICommand AtItem(The the, string locator, Casing casing);
        //ICommand AtItem(The the, string locator);
        //ICommand AtItem(The the);
        //ICommand AtItem(That that, string locator, Casing casing);
        //ICommand AtItem(That that, string locator);
        //ICommand AtItem(string locator, Casing casing);
        //ICommand AtItem(string locator);
        //ICommand AtItem();

        //#endregion

        #region [Above]

        /// <summary>
        /// set above Item scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set above Item scope "scope" on the page by exact match, use AboveItem(That.Equals, "scope").
        /// </summary>
        ICommand AboveItem(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveItem(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveItem(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveItem(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Below]

        /// <summary>
        /// set below Item scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set below Item scope "scope" on the page by exact match, use BelowItem(That.Equals, "scope").
        /// </summary>
        ICommand BelowItem(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowItem(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowItem(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowItem(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [LeftOf]

        /// <summary>
        /// set left of Item scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set left of Item scope "scope" on the page by exact match, use LeftOfItem(That.Equals, "scope").
        /// </summary>
        ICommand LeftOfItem(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfItem(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfItem(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfItem(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [RightOf]

        /// <summary>
        /// set right of Item scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set right of Item scope "scope" on the page by exact match, use RightOfItem(That.Equals, "scope").
        /// </summary>
        ICommand RightOfItem(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfItem(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfItem(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfItem(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Near]

        /// <summary>
        /// set near Item scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set near Item scope "scope" on the page by exact match, use NearItem(That.Equals, "scope").
        /// </summary>
        ICommand NearItem(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearItem(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearItem(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearItem(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #endregion

        #endregion

        #region [Value]

        #region [TargetPosition]

        //#region [At]

        ///// <summary>
        ///// set at Value scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        ///// Example: to set at Value scope "scope" on the page by exact match, use AtValue(That.Equals, "scope").
        ///// </summary>
        //ICommand AtValue(The the, That that, string locator, Casing casing);
        //ICommand AtValue(The the, That that, string locator);
        //ICommand AtValue(The the, string locator, Casing casing);
        //ICommand AtValue(The the, string locator);
        //ICommand AtValue(The the);
        //ICommand AtValue(That that, string locator, Casing casing);
        //ICommand AtValue(That that, string locator);
        //ICommand AtValue(string locator, Casing casing);
        //ICommand AtValue(string locator);
        //ICommand AtValue();

        //#endregion

        #region [Above]

        /// <summary>
        /// set above Value scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set above Value scope "scope" on the page by exact match, use AboveValue(That.Equals, "scope").
        /// </summary>
        ICommand AboveValue(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveValue(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveValue(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveValue(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Below]

        /// <summary>
        /// set below Value scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set below Value scope "scope" on the page by exact match, use BelowValue(That.Equals, "scope").
        /// </summary>
        ICommand BelowValue(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowValue(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowValue(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowValue(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [LeftOf]

        /// <summary>
        /// set left of Value scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set left of Value scope "scope" on the page by exact match, use LeftOfValue(That.Equals, "scope").
        /// </summary>
        ICommand LeftOfValue(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfValue(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfValue(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfValue(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [RightOf]

        /// <summary>
        /// set right of Value scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set right of Value scope "scope" on the page by exact match, use RightOfValue(That.Equals, "scope").
        /// </summary>
        ICommand RightOfValue(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfValue(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfValue(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfValue(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Near]

        /// <summary>
        /// set near Value scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set near Value scope "scope" on the page by exact match, use NearValue(That.Equals, "scope").
        /// </summary>
        ICommand NearValue(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearValue(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearValue(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearValue(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #endregion

        #endregion

        #region [File]

        #region [TargetPosition]

        #region [Above]

        /// <summary>
        /// set above File scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set above File scope "scope" on the page by exact match, use AboveFile(That.Equals, "scope").
        /// </summary>
        ICommand AboveFile(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveFile(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveFile(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveFile(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Below]

        /// <summary>
        /// set below File scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set below File scope "scope" on the page by exact match, use BelowFile(That.Equals, "scope").
        /// </summary>
        ICommand BelowFile(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowFile(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowFile(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowFile(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [LeftOf]

        /// <summary>
        /// set left of File scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set left of File scope "scope" on the page by exact match, use LeftOfFile(That.Equals, "scope").
        /// </summary>
        ICommand LeftOfFile(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfFile(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfFile(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfFile(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [RightOf]

        /// <summary>
        /// set right of File scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set right of File scope "scope" on the page by exact match, use RightOfFile(That.Equals, "scope").
        /// </summary>
        ICommand RightOfFile(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfFile(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfFile(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfFile(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Near]

        /// <summary>
        /// set near File scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set near File scope "scope" on the page by exact match, use NearFile(That.Equals, "scope").
        /// </summary>
        ICommand NearFile(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearFile(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearFile(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearFile(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #endregion

        #endregion

        #region [Tick]

        #region [TargetPosition]

        //#region [At]

        ///// <summary>
        ///// set at Tick scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        ///// Example: to set at Tick scope "scope" on the page by exact match, use AtTick(That.Equals, "scope").
        ///// </summary>
        //ICommand AtTick(The the, That that, string locator, Casing casing);
        //ICommand AtTick(The the, That that, string locator);
        //ICommand AtTick(The the, string locator, Casing casing);
        //ICommand AtTick(The the, string locator);
        //ICommand AtTick(The the);
        //ICommand AtTick(That that, string locator, Casing casing);
        //ICommand AtTick(That that, string locator);
        //ICommand AtTick(string locator, Casing casing);
        //ICommand AtTick(string locator);
        //ICommand AtTick();

        //#endregion

        #region [Above]

        /// <summary>
        /// set above Tick scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set above Tick scope "scope" on the page by exact match, use AboveTick(That.Equals, "scope").
        /// </summary>
        ICommand AboveTick(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveTick(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveTick(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveTick(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Below]

        /// <summary>
        /// set below Tick scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set below Tick scope "scope" on the page by exact match, use BelowTick(That.Equals, "scope").
        /// </summary>
        ICommand BelowTick(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowTick(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowTick(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowTick(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [LeftOf]

        /// <summary>
        /// set left of Tick scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set left of Tick scope "scope" on the page by exact match, use LeftOfTick(That.Equals, "scope").
        /// </summary>
        ICommand LeftOfTick(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfTick(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfTick(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfTick(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [RightOf]

        /// <summary>
        /// set right of Tick scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set right of Tick scope "scope" on the page by exact match, use RightOfTick(That.Equals, "scope").
        /// </summary>
        ICommand RightOfTick(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfTick(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfTick(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfTick(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Near]

        /// <summary>
        /// set near Tick scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set near Tick scope "scope" on the page by exact match, use NearTick(That.Equals, "scope").
        /// </summary>
        ICommand NearTick(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearTick(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearTick(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearTick(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #endregion

        #endregion

        #region [Table]

        #region [TargetPosition]

        //#region [At]

        ///// <summary>
        ///// set at Table scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        ///// Example: to set at Table scope "scope" on the page by exact match, use AtTable(That.Equals, "scope").
        ///// </summary>
        //ICommand AtTable(The the, That that, string locator, Casing casing);
        //ICommand AtTable(The the, That that, string locator);
        //ICommand AtTable(The the, string locator, Casing casing);
        //ICommand AtTable(The the, string locator);
        //ICommand AtTable(The the);
        //ICommand AtTable(That that, string locator, Casing casing);
        //ICommand AtTable(That that, string locator);
        //ICommand AtTable(string locator, Casing casing);
        //ICommand AtTable(string locator);
        //ICommand AtTable();

        //#endregion

        #region [Above]

        /// <summary>
        /// set above Table scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set above Table scope "scope" on the page by exact match, use AboveTable(That.Equals, "scope").
        /// </summary>
        ICommand AboveTable(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveTable(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveTable(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveTable(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Below]

        /// <summary>
        /// set below Table scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set below Table scope "scope" on the page by exact match, use BelowTable(That.Equals, "scope").
        /// </summary>
        ICommand BelowTable(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowTable(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowTable(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowTable(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [LeftOf]

        /// <summary>
        /// set left of Table scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set left of Table scope "scope" on the page by exact match, use LeftOfTable(That.Equals, "scope").
        /// </summary>
        ICommand LeftOfTable(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfTable(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfTable(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfTable(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [RightOf]

        /// <summary>
        /// set right of Table scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set right of Table scope "scope" on the page by exact match, use RightOfTable(That.Equals, "scope").
        /// </summary>
        ICommand RightOfTable(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfTable(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfTable(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfTable(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Near]

        /// <summary>
        /// set near Table scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set near Table scope "scope" on the page by exact match, use NearTable(That.Equals, "scope").
        /// </summary>
        ICommand NearTable(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearTable(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearTable(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearTable(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #endregion

        #endregion

        #region [Column]

        #region [TargetPosition]

        #region [At]

        /// <summary>
        /// set Column scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set Column scope "scope" on the page by exact match, use Column(That.Equals, "scope").
        /// </summary>
        ICommand Column(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand Column(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand Column(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand Column(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// set at Column scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set at Column scope "scope" on the page by exact match, use AtColumn(That.Equals, "scope").
        /// </summary>
        ICommand AtColumn(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AtColumn(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand AtColumn(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AtColumn(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Above]

        /// <summary>
        /// set above Column scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set above Column scope "scope" on the page by exact match, use AboveColumn(That.Equals, "scope").
        /// </summary>
        ICommand AboveColumn(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveColumn(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveColumn(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand AboveColumn(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Below]

        /// <summary>
        /// set below Column scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set below Column scope "scope" on the page by exact match, use BelowColumn(That.Equals, "scope").
        /// </summary>
        ICommand BelowColumn(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowColumn(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowColumn(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand BelowColumn(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [LeftOf]

        /// <summary>
        /// set left of Column scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set left of Column scope "scope" on the page by exact match, use LeftOfColumn(That.Equals, "scope").
        /// </summary>
        ICommand LeftOfColumn(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfColumn(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfColumn(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand LeftOfColumn(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [RightOf]

        /// <summary>
        /// set right of Column scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set right of Column scope "scope" on the page by exact match, use RightOfColumn(That.Equals, "scope").
        /// </summary>
        ICommand RightOfColumn(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfColumn(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfColumn(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand RightOfColumn(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Near]

        /// <summary>
        /// set near Column scope by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set near Column scope "scope" on the page by exact match, use NearColumn(That.Equals, "scope").
        /// </summary>
        ICommand NearColumn(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearColumn(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearColumn(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommand NearColumn(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #endregion

        #endregion

        #region [Frame]

        /// <summary>
        /// set frame scope. <para />
        /// Example: to set frame scope on the page by its title "title", use IFrame("title").
        /// </summary>
        //WindowContext IFrame(string locator);
        //WindowContext IFrame();

        WindowContext IFrame(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        WindowContext IFrame(The the, string locator = null, Casing casing = Casing.Ignore);
        WindowContext IFrame(That that, string locator = null, Casing casing = Casing.Ignore);
        WindowContext IFrame(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #endregion
    }
}
