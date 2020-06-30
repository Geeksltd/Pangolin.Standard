namespace Geeks.Pangolin.Helper.UIContext
{
    public interface ICommandLocator
    {
        #region [Locator]

        #region [Set]

        #region [Any]

        /// <summary>
        /// set field on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set a "field" on the page by exact match use Set(That.Equals, "field").
        /// </summary>
        ICommandSet Set(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        ICommandSet Set(The the, string locator = null, Casing casing = Casing.Ignore);
        ICommandSet Set(That that, string locator = null, Casing casing = Casing.Ignore);
        ICommandSet Set(string locator = null, Casing casing = Casing.Ignore);


        /// <summary>
        /// Only applied on Textbox, Dropdown, MultiDropdown, Checkbox
        /// clear field on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to set a "field" on the page by exact match use Set(That.Equals, "field").
        /// </summary>
        void ClearField(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ClearField(The the, string locator = null, Casing casing = Casing.Ignore);
        void ClearField(That that, string locator = null, Casing casing = Casing.Ignore);
        void ClearField(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [CSS]

        /// <summary>
        /// set CSS on the page <para />
        /// Example: to set an element with CSS "CSS" on the page use SetCSS("CSS");
        /// </summary>
        ICommandSet SetCSS(The the, string locator);
        ICommandSet SetCSS(string locator = null);

        #endregion

        #region [XPath]

        /// <summary>
        /// set XPath on the page <para />
        /// Example: to set an element with XPath "xpath" on the page use SetXPath("xpath");
        /// </summary>
        ICommandSet SetXPath(The the, string locator);
        ICommandSet SetXPath(string locator = null);

        #endregion

        #endregion

        #region [Click]

        #region [TargetType]

        #region [Any]

        /// <summary>
        /// click field on the page by That and Casing. default values are What.Equals and Casing.Ignore <para />
        /// Example: to click "field" on the page by exact match use Click(What.Equals, "field");
        /// </summary>
        void Click(The the, What what, string locator, Casing casing = Casing.Ignore);
        void Click(The the, string locator, Casing casing = Casing.Ignore);
        void Click(What what, string locator, Casing casing = Casing.Ignore);
        void Click(string locator, Casing casing = Casing.Ignore);

        #endregion

        #region [Text]

        /// <summary>
        /// click text on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to click "text" on the page by exact match use HoverOver(That.Equals, "text");
        /// </summary>
        void ClickText(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ClickText(The the, string locator = null, Casing casing = Casing.Ignore);
        void ClickText(That that, string locator = null, Casing casing = Casing.Ignore);
        void ClickText(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [CSS]

        /// <summary>
        /// click CSS on the page <para />
        /// Example: to click an element with CSS "CSS" on the page use ClickCSS("CSS");
        /// </summary>
        void ClickCSS(The the, string locator);
        void ClickCSS(string locator = null);

        #endregion

        #region [XPath]

        /// <summary>
        /// click XPath on the page <para />
        /// Example: to click an element with XPath "xpath" on the page use ClickXPath("xpath");
        /// </summary>
        void ClickXPath(The the, string locator);
        void ClickXPath(string locator = null);

        #endregion

        #region [Button]

        /// <summary>
        /// click button on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to click "button" on the page by exact match use ClickButton(That.Equals, "button");
        /// </summary>
        void ClickButton(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ClickButton(The the, string locator = null, Casing casing = Casing.Ignore);
        void ClickButton(That that, string locator = null, Casing casing = Casing.Ignore);
        void ClickButton(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Link]

        /// <summary>
        /// click link on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to click "link" on the page by exact match use ClickLink(That.Equals, "link");
        /// </summary>
        void ClickLink(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ClickLink(The the, string locator = null, Casing casing = Casing.Ignore);
        void ClickLink(That that, string locator = null, Casing casing = Casing.Ignore);
        void ClickLink(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Field]

        /// <summary>
        /// click field on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to click "field" on the page by exact match use ClickField(That.Equals, "field");
        /// </summary>
        void ClickField(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ClickField(The the, string locator = null, Casing casing = Casing.Ignore);
        void ClickField(That that, string locator = null, Casing casing = Casing.Ignore);
        void ClickField(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Header]

        /// <summary>
        /// click header on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to click "header" on the page by exact match use ClickHeader(That.Equals, "header");
        /// </summary>
        void ClickHeader(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ClickHeader(The the, string locator = null, Casing casing = Casing.Ignore);
        void ClickHeader(That that, string locator = null, Casing casing = Casing.Ignore);
        void ClickHeader(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Label]

        /// <summary>
        /// click label on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to click "label" on the page by exact match use ClickLabel(That.Equals, "label");
        /// </summary>
        void ClickLabel(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ClickLabel(The the, string locator = null, Casing casing = Casing.Ignore);
        void ClickLabel(That that, string locator = null, Casing casing = Casing.Ignore);
        void ClickLabel(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Checkbox]

        /// <summary>
        /// click checkbox on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to click "checkbox" on the page by exact match use ClickCheckbox(That.Equals, "checkbox");
        /// </summary>
        void ClickCheckbox(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ClickCheckbox(The the, string locator = null, Casing casing = Casing.Ignore);
        void ClickCheckbox(That that, string locator = null, Casing casing = Casing.Ignore);
        void ClickCheckbox(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Radiobox]

        /// <summary>
        /// click radiobox on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to click "radiobox" on the page by exact match use ClickRadiobox(That.Equals, "radiobox");
        /// </summary>
        void ClickRadiobox(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ClickRadiobox(The the, string locator = null, Casing casing = Casing.Ignore);
        void ClickRadiobox(That that, string locator = null, Casing casing = Casing.Ignore);
        void ClickRadiobox(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Row]

        /// <summary>
        /// click row on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to click "row" on the page by exact match use ClickRow(That.Equals, "row");
        /// </summary>
        void ClickRow(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ClickRow(The the, string locator = null, Casing casing = Casing.Ignore);
        void ClickRow(That that, string locator = null, Casing casing = Casing.Ignore);
        void ClickRow(string locator = null, Casing casing = Casing.Ignore);
        void ClickRow(The the, int position);
        void ClickRow(int position);

        #endregion

        #region [Item]

        /// <summary>
        /// click item on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to click "item" on the page by exact match use ClickItem(That.Equals, "item");
        /// </summary>
        void ClickItem(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ClickItem(The the, string locator = null, Casing casing = Casing.Ignore);
        void ClickItem(That that, string locator = null, Casing casing = Casing.Ignore);
        void ClickItem(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Value]

        /// <summary>
        /// click value on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to click "value" on the page by exact match use ClickValue(That.Equals, "value");
        /// </summary>
        void ClickValue(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ClickValue(The the, string locator = null, Casing casing = Casing.Ignore);
        void ClickValue(That that, string locator = null, Casing casing = Casing.Ignore);
        void ClickValue(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [File]

        /// <summary>
        /// click file on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to click "file" on the page by exact match use ClickFile(That.Equals, "file");
        /// </summary>
        void ClickFile(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ClickFile(The the, string locator = null, Casing casing = Casing.Ignore);
        void ClickFile(That that, string locator = null, Casing casing = Casing.Ignore);
        void ClickFile(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Tick]

        /// <summary>
        /// click tick on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to click "tick" on the page by exact match use ClickTick(That.Equals, "tick");
        /// </summary>
        void ClickTick(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ClickTick(The the, string locator = null, Casing casing = Casing.Ignore);
        void ClickTick(That that, string locator = null, Casing casing = Casing.Ignore);
        void ClickTick(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Table]

        /// <summary>
        /// click table on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to click "table" on the page by exact match use ClickTable(That.Equals, "table");
        /// </summary>
        void ClickTable(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ClickTable(The the, string locator = null, Casing casing = Casing.Ignore);
        void ClickTable(That that, string locator = null, Casing casing = Casing.Ignore);
        void ClickTable(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Column]

        /// <summary>
        /// click column on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to click "column" on the page by exact match use ClickColumn(That.Equals, "column");
        /// </summary>
        void ClickColumn(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ClickColumn(The the, string locator = null, Casing casing = Casing.Ignore);
        void ClickColumn(That that, string locator = null, Casing casing = Casing.Ignore);
        void ClickColumn(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #endregion

        #endregion

        #region [HoverOver]

        #region [TargetType]

        #region [Any]

        /// <summary>
        /// hover over field on the page by That and Casing. default values are What.Equals and Casing.Ignore <para />
        /// Example: to hover over "field" on the page by exact match use HoverOver(What.Equals, "field");
        /// </summary>
        void HoverOver(The the, What what, string locator, Casing casing = Casing.Ignore);
        void HoverOver(The the, string locator, Casing casing = Casing.Ignore);
        void HoverOver(What what, string locator, Casing casing = Casing.Ignore);
        void HoverOver(string locator, Casing casing = Casing.Ignore);

        #endregion

        #region [Text]

        /// <summary>
        /// hover over field on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to hover over "field" on the page by exact match use HoverOver(That.Equals, "field");
        /// </summary>
        void HoverOverText(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverText(The the, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverText(That that, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverText(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [CSS]

        /// <summary>
        /// hover over CSS on the page <para />
        /// Example: to hover over an element with CSS "CSS" on the page use HoverOverCSS("CSS");
        /// </summary>
        void HoverOverCSS(The the, string locator);
        void HoverOverCSS(string locator);

        #endregion

        #region [XPath]

        /// <summary>
        /// hover over XPath on the page <para />
        /// Example: to hover over an element with XPath "xpath" on the page use HoverOverXPath("XPath");
        /// </summary>
        void HoverOverXPath(The the, string locator);
        void HoverOverXPath(string locator);

        #endregion

        #region [Button]

        /// <summary>
        /// HoverOver button on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to HoverOver "button" on the page by exact match use HoverOverButton(That.Equals, "button");
        /// </summary>
        void HoverOverButton(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverButton(The the, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverButton(That that, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverButton(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Link]

        /// <summary>
        /// HoverOver link on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to HoverOver "link" on the page by exact match use HoverOverLink(That.Equals, "link");
        /// </summary>
        void HoverOverLink(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverLink(The the, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverLink(That that, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverLink(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Field]

        /// <summary>
        /// HoverOver field on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to HoverOver "field" on the page by exact match use HoverOverField(That.Equals, "field");
        /// </summary>
        void HoverOverField(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverField(The the, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverField(That that, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverField(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Header]

        /// <summary>
        /// HoverOver header on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to HoverOver "header" on the page by exact match use HoverOverHeader(That.Equals, "header");
        /// </summary>
        void HoverOverHeader(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverHeader(The the, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverHeader(That that, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverHeader(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Label]

        /// <summary>
        /// HoverOver label on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to HoverOver "label" on the page by exact match use HoverOverLabel(That.Equals, "label");
        /// </summary>
        void HoverOverLabel(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverLabel(The the, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverLabel(That that, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverLabel(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Checkbox]

        /// <summary>
        /// HoverOver checkbox on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to HoverOver "checkbox" on the page by exact match use HoverOverCheckbox(That.Equals, "checkbox");
        /// </summary>
        void HoverOverCheckbox(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverCheckbox(The the, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverCheckbox(That that, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverCheckbox(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Radiobox]

        /// <summary>
        /// HoverOver radiobox on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to HoverOver "radiobox" on the page by exact match use HoverOverRadiobox(That.Equals, "radiobox");
        /// </summary>
        void HoverOverRadiobox(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverRadiobox(The the, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverRadiobox(That that, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverRadiobox(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Row]

        /// <summary>
        /// HoverOver row on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to HoverOver "row" on the page by exact match use HoverOverRow(That.Equals, "row");
        /// </summary>
        void HoverOverRow(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverRow(The the, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverRow(That that, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverRow(string locator = null, Casing casing = Casing.Ignore);
        void HoverOverRow(The the, int position);
        void HoverOverRow(int position);

        #endregion

        #region [Item]

        /// <summary>
        /// HoverOver item on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to HoverOver "item" on the page by exact match use HoverOverItem(That.Equals, "item");
        /// </summary>
        void HoverOverItem(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverItem(The the, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverItem(That that, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverItem(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Value]

        /// <summary>
        /// HoverOver value on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to HoverOver "value" on the page by exact match use HoverOverValue(That.Equals, "value");
        /// </summary>
        void HoverOverValue(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverValue(The the, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverValue(That that, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverValue(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [File]

        /// <summary>
        /// HoverOver file on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to HoverOver "file" on the page by exact match use HoverOverFile(That.Equals, "file");
        /// </summary>
        void HoverOverFile(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverFile(The the, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverFile(That that, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverFile(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Tick]

        /// <summary>
        /// HoverOver tick on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to HoverOver "tick" on the page by exact match use HoverOverTick(That.Equals, "tick");
        /// </summary>
        void HoverOverTick(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverTick(The the, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverTick(That that, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverTick(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Table]

        /// <summary>
        /// HoverOver table on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to HoverOver "table" on the page by exact match use HoverOverTable(That.Equals, "table");
        /// </summary>
        void HoverOverTable(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverTable(The the, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverTable(That that, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverTable(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Column]

        /// <summary>
        /// HoverOver column on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to HoverOver "column" on the page by exact match use HoverOverColumn(That.Equals, "column");
        /// </summary>
        void HoverOverColumn(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverColumn(The the, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverColumn(That that, string locator = null, Casing casing = Casing.Ignore);
        void HoverOverColumn(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #endregion

        #endregion

        #region [Check]

        /// <summary>
        /// check field on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to check a "field" on the page by exact match use Check(That.Equals, "field").
        /// </summary>
        void Check(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void Check(The the, string locator = null, Casing casing = Casing.Ignore);
        void Check(That that, string locator = null, Casing casing = Casing.Ignore);
        void Check(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [CSS]

        /// <summary>
        /// check CSS on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to check a "CSS" on the page by exact match use CheckCSS(That.Equals, "CSS").
        /// </summary>
        void CheckCSS(The the, string locator);
        void CheckCSS(string locator);

        #endregion

        #region [XPath]

        /// <summary>
        /// check xpath on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to check a "xpath" on the page by exact match use CheckXPath(That.Equals, "xpath").
        /// </summary>
        void CheckXPath(The the, string locator);
        void CheckXPath(string locator);

        #endregion


        #region [UnCheck]

        /// <summary>
        /// unCheck field on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to unCheck a "field" on the page by exact match use UnCheck(That.Equals, "field").
        /// </summary>
        void UnCheck(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void UnCheck(The the, string locator = null, Casing casing = Casing.Ignore);
        void UnCheck(That that, string locator = null, Casing casing = Casing.Ignore);
        void UnCheck(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [CSS]

        /// <summary>
        /// unCheck CSS on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to unCheck a "CSS" on the page by exact match use UnCheckCSS(That.Equals, "CSS").
        /// </summary>
        void UnCheckCSS(The the, string locator);
        void UnCheckCSS(string locator);

        #endregion

        #region [XPath]

        /// <summary>
        /// unCheck xpath on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to unCheck a "xpath" on the page by exact match use UnCheckXPath(That.Equals, "xpath").
        /// </summary>
        void UnCheckXPath(The the, string locator);
        void UnCheckXPath(string locator);

        #endregion

        #region [Choose]

        /// <summary>
        /// choose field on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to choose a "field" on the page by exact match use Choose(That.Equals, "field").
        /// </summary>
        void Choose(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void Choose(The the, string locator = null, Casing casing = Casing.Ignore);
        void Choose(That that, string locator = null, Casing casing = Casing.Ignore);
        void Choose(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #endregion
    }
}
