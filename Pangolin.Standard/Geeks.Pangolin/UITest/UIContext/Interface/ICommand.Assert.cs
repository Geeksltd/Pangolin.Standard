namespace Geeks.Pangolin.Helper.UIContext
{
    public interface ICommandAssert
    {
        #region [Assert]

        #region [Expect]

        #region [TargetType]

        #region [Any]

        /// <summary>
        /// Expect text on the page by That and Casing. default values are What.Equals and Casing.Ignore <para />
        /// Example: to expect a "text" on the page by exact match use Expect(What.Equals, "text", Casing.Exact);
        /// </summary>
        void Expect(The the, What what, string locator, Casing casing = Casing.Ignore);
        void Expect(The the, string locator, Casing casing = Casing.Ignore);
        void Expect(What what, string locator, Casing casing = Casing.Ignore);
        void Expect(string locator, Casing casing = Casing.Ignore);

        /// <summary>
        /// Expect no text on the page by That and Casing. default values are That.Equals and What.Ignore <para />
        /// Example: to expect that there is no "text" on the page by exact match use ExpectNo(What.Equals, "text", Casing.Exact);
        /// </summary>
        void ExpectNo(The the, What what, string locator, Casing casing = Casing.Ignore);
        void ExpectNo(The the, string locator, Casing casing = Casing.Ignore);
        void ExpectNo(What what, string locator, Casing casing = Casing.Ignore);
        void ExpectNo(string locator, Casing casing = Casing.Ignore);

        #endregion

        #region [Text]

        /// <summary>
        /// Expect text on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to expect a "text" on the page by exact match use ExpectText(That.Equals, "text", Casing.Exact);
        /// </summary>
        void ExpectText(The the, That that, string locator, Casing casing = Casing.Ignore);
        void ExpectText(The the, string locator, Casing casing = Casing.Ignore);
        void ExpectText(That that, string locator, Casing casing = Casing.Ignore);
        void ExpectText(string locator, Casing casing = Casing.Ignore);

        /// <summary>
        /// Expect no text on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to expect that there is no "text" on the page by exact match use ExpectNoText(That.Equals, "text", Casing.Exact);
        /// </summary>
        void ExpectNoText(The the, That that, string locator, Casing casing = Casing.Ignore);
        void ExpectNoText(The the, string locator, Casing casing = Casing.Ignore);
        void ExpectNoText(That that, string locator, Casing casing = Casing.Ignore);
        void ExpectNoText(string locator, Casing casing = Casing.Ignore);

        #endregion

        #region [CSS]

        /// <summary>
        /// Expect CSS on the page <para />
        /// Example: to expect an element with CSS "CSS" on the page use ExpectCSS("CSS");
        /// </summary>
        void ExpectCSS(The the, string locator);
        void ExpectCSS(string locator);

        /// <summary>
        /// Expect no CSS on the page <para />
        /// Example: to expect that there is no element with CSS "CSS" on the page use ExpectNoCSS("CSS");
        /// </summary>
        void ExpectNoCSS(The the, string locator);
        void ExpectNoCSS(string locator);

        #endregion

        #region [XPath]

        /// <summary>
        /// Expect XPath on the page <para />
        /// Example: to expect an element with XPath "xpath" on the page use ExpectXPath("xpath");
        /// </summary>
        void ExpectXPath(The the, string locator);
        void ExpectXPath(string locator);

        /// <summary>
        /// Expect no XPath on the page <para />
        /// Example: to expect that there is no element with XPath "xpath" on the page use ExpectNoXPath("xpath");
        /// </summary>
        void ExpectNoXPath(The the, string locator);
        void ExpectNoXPath(string locator);

        #endregion

        #region [Button]

        /// <summary>
        /// Expect "button", "submit", "image", "reset" tag on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to expect a "button" on the page by exact match use ExpectButton(That.Equals, "button", Casing.Exact);
        /// </summary>
        void ExpectButton(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectButton(The the, string locator = null, Casing casing = Casing.Ignore);
        void ExpectButton(That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectButton(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// Expect no "button", "submit", "image", "reset" tag on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to expect that there is no "button" on the page by exact match use ExpectNoButton(That.Equals, "label", Casing.Exact);
        /// </summary>
        void ExpectNoButton(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoButton(The the, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoButton(That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoButton(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Link]

        /// <summary>
        /// Expect "a" tag on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to expect a "link" on the page by exact match use ExpectLink(That.Equals, "link", Casing.Exact);
        /// </summary>
        void ExpectLink(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectLink(The the, string locator = null, Casing casing = Casing.Ignore);
        void ExpectLink(That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectLink(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// Expect no "a" tag on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to expect that there is no "link" on the page by exact match use ExpectNoLink(That.Equals, "link", Casing.Exact);
        /// </summary>
        void ExpectNoLink(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoLink(The the, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoLink(That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoLink(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Field]

        /// <summary>
        /// Expect "input", "select", "textarea", "text", "password", "radio", "checkbox", "file", "email", "tel", "url", "number", "datetime", "datetime-local", "date", "month", "week", "time", "color", "search" tag on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to expect a "input" on the page by exact match use ExpectField(That.Equals, "input", Casing.Exact);
        /// </summary>
        void ExpectField(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectField(The the, string locator = null, Casing casing = Casing.Ignore);
        void ExpectField(That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectField(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// Expect no "input", "select", "textarea", "text", "password", "radio", "checkbox", "file", "email", "tel", "url", "number", "datetime", "datetime-local", "date", "month", "week", "time", "color", "search" on the page tag by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to expect that there is no "input" on the page by exact match use ExpectNoField(That.Equals, "input", Casing.Exact);
        /// </summary>
        void ExpectNoField(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoField(The the, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoField(That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoField(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Header]

        /// <summary>
        /// Expect "h1", "h2", "h3", "h4", "h5", "h6" tag on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to expect a "header" on the page by exact match use ExpectHeader(That.Equals, "header", Casing.Exact);
        /// </summary>
        void ExpectHeader(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectHeader(The the, string locator = null, Casing casing = Casing.Ignore);
        void ExpectHeader(That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectHeader(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// Expect no "h1", "h2", "h3", "h4", "h5", "h6" tage on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to expect that there is no "header" by exact match use ExpectNoHeader(That.Equals, "header", Casing.Exact);
        /// </summary>
        void ExpectNoHeader(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoHeader(The the, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoHeader(That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoHeader(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Label]

        /// <summary>
        /// Expect "label", "strong" tag on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to expect a "label" on the page by exact match use ExpectLabel(That.Equals, "label", Casing.Exact);
        /// </summary>
        void ExpectLabel(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectLabel(The the, string locator = null, Casing casing = Casing.Ignore);
        void ExpectLabel(That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectLabel(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// Expect no "label", "strong" tag on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to expect that there is no "label" on the page by exact match use ExpectNoLabel(That.Equals, "label", Casing.Exact);
        /// </summary>
        void ExpectNoLabel(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoLabel(The the, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoLabel(That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoLabel(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Checkbox]

        /// <summary>
        /// Expect checkbox selected on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to expect a "checkbox" is selected on the page by exact match use ExpectCheck(That.Equals, "checkbox", Casing.Exact);
        /// </summary>
        void ExpectCheck(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectCheck(The the, string locator = null, Casing casing = Casing.Ignore);
        void ExpectCheck(That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectCheck(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// Expect checkbox unselected on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to expect that there is no "checkbox" selected by exact match on the page use ExpectNoCheck(That.Equals, "checkbox", Casing.Exact);
        /// </summary>
        void ExpectUnCheck(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectUnCheck(The the, string locator = null, Casing casing = Casing.Ignore);
        void ExpectUnCheck(That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectUnCheck(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// Expect "checkbox" on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to expect a "checkbox" is on the page by exact match use ExpectCheckbox(That.Equals, "checkbox", Casing.Exact);
        /// </summary>
        void ExpectCheckbox(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectCheckbox(The the, string locator = null, Casing casing = Casing.Ignore);
        void ExpectCheckbox(That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectCheckbox(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// Expect no "checkbox" on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to expect that there is no "checkbox" by exact match on the page use ExpectNoCheckbox(That.Equals,"checkbox", Casing.Exact);
        /// </summary>
        void ExpectNoCheckbox(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoCheckbox(The the, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoCheckbox(That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoCheckbox(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Radiobox]

        /// <summary>
        /// Expect radiobox selected on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to expect a "radiobox" is selected on the page by exact match use ExpectChoose(That.Equals, "radiobox", Casing.Exact);
        /// </summary>
        void ExpectChoose(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectChoose(The the, string locator = null, Casing casing = Casing.Ignore);
        void ExpectChoose(That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectChoose(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// Expect radiobox unselected on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to expect that there is no "radiobox" selected by exact match on the page use ExpectNoChoose(That.Equals, "radiobox", Casing.Exact);
        /// </summary>
        void ExpectNoChoose(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoChoose(The the, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoChoose(That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoChoose(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// Expect "radiobox" on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to expect a "radiobox" is selected on the page by exact match use ExpectRadiobox(That.Equals, "radiobox", Casing.Exact);
        /// </summary>
        void ExpectRadiobox(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectRadiobox(The the, string locator = null, Casing casing = Casing.Ignore);
        void ExpectRadiobox(That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectRadiobox(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// Expect no "radiobox" on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to expect that there is no "radiobox" by exact match on the page use ExpectNoRadiobox(That.Equals, "radiobox", Casing.Exact);
        /// </summary>
        void ExpectNoRadiobox(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoRadiobox(The the, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoRadiobox(That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoRadiobox(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Row]

        /// <summary>
        /// Expect "tr" tag inside the table on the page by That and Casing. default values are That.Equals and Casing.Ignore  <para />
        /// Example: to expect a "row" by exact match on the page use ExpectRow(That.Equals, "row", Casing.Exact);
        /// </summary>
        void ExpectRow(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectRow(The the, string locator = null, Casing casing = Casing.Ignore);
        void ExpectRow(That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectRow(string locator = null, Casing casing = Casing.Ignore);
        void ExpectRow(int position);
        void ExpectRow(The the, int position);

        /// <summary>
        /// Expect no "tr" tag inside the table on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to expect that there is no "row" on the page by exact match use ExpectNoRow(That.Equals, "row", Casing.Exact);
        /// </summary>
        void ExpectNoRow(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoRow(The the, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoRow(That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoRow(string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoRow(The the, int position);
        void ExpectNoRow(int position);

        #endregion

        #region [RowColumns]

        /// <summary>
        /// Expect "tr" tag inside the table on the page by That and Casing. default values are That.Equals and Casing.Ignore  <para />
        /// Example: to expect a "row columns" by exact match on the page use ExpectRowColumns(That.Equals, "row columns", Casing.Exact);
        /// </summary>
        void ExpectRowColumns(The the, That that, Casing casing, params string[] locator);
        void ExpectRowColumns(The the, That that, params string[] locator);
        void ExpectRowColumns(The the, Casing casing, params string[] locator);
        void ExpectRowColumns(The the, params string[] locator);
        void ExpectRowColumns(The the);
        void ExpectRowColumns(That that, Casing casing, params string[] locator);
        void ExpectRowColumns(Casing casing, params string[] locator);
        void ExpectRowColumns(That that, params string[] locator);
        void ExpectRowColumns(params string[] locator);

        /// <summary>
        /// Expect no "tr" tag inside the table on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to expect that there is no "row columns" on the page by exact match use ExpectNoRowColumns(That.Equals, "row columns", Casing.Exact);
        /// </summary>
        void ExpectNoRowColumns(The the, That that, Casing casing, params string[] locator);
        void ExpectNoRowColumns(The the, That that, params string[] locator);
        void ExpectNoRowColumns(The the, Casing casing, params string[] locator);
        void ExpectNoRowColumns(The the, params string[] locator);
        void ExpectNoRowColumns(The the);
        void ExpectNoRowColumns(That that, Casing casing, params string[] locator);
        void ExpectNoRowColumns(Casing casing, params string[] locator);
        void ExpectNoRowColumns(That that, params string[] locator);
        void ExpectNoRowColumns(params string[] locator);

        #endregion

        #region [Item]

        /// <summary>
        /// Expect item in Dropdown or Combobox on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to expect a "item" on the page by exact match use ExpectItem(That.Equals, "item", Casing.Exact);
        /// </summary>
        void ExpectItem(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectItem(The the, string locator = null, Casing casing = Casing.Ignore);
        void ExpectItem(That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectItem(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// Expect no item in Dropdown or Combobox on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to expect that there is no "item" on the page by exact match use ExpectNoItem(That.Equals, "item", Casing.Exact);
        /// </summary>
        void ExpectNoItem(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoItem(The the, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoItem(That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoItem(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Value]

        /// <summary>
        /// Expect value in the input tag on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to expect a value of "input" on the page by exact match use ExpectValue(That.Equals, "input", Casing.Exact);
        /// </summary>
        void ExpectValue(The the, That that, string locator, Casing casing = Casing.Ignore);
        void ExpectValue(The the, string locator, Casing casing = Casing.Ignore);
        void ExpectValue(That that, string locator, Casing casing = Casing.Ignore);
        void ExpectValue(string locator, Casing casing = Casing.Ignore);

        /// <summary>
        /// Expect no value in the input tag on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to expect that there is no value of "input" on the page by exact match use ExpectNoValue(That.Equals, "input", Casing.Exact);
        /// </summary>
        void ExpectNoValue(The the, That that, string locator, Casing casing = Casing.Ignore);
        void ExpectNoValue(The the, string locator, Casing casing = Casing.Ignore);
        void ExpectNoValue(That that, string locator, Casing casing = Casing.Ignore);
        void ExpectNoValue(string locator, Casing casing = Casing.Ignore);

        #endregion

        #region [Tick]

        /// <summary>
        /// Expect tick on the page. <para />
        /// Example: to expect a tick on the page use ExpectTick();
        /// </summary>
        void ExpectTick(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectTick(The the, string locator = null, Casing casing = Casing.Ignore);
        void ExpectTick(That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectTick(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// Expect no tick on the page. <para />
        /// Example: to expect that there is no tick on the page use ExpectNoTick();
        /// </summary>
        void ExpectNoTick(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoTick(The the, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoTick(That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoTick(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Table]

        /// <summary>
        /// Expect table inside the table on the page by That and Casing. default values are That.Equals and Casing.Ignore  <para />
        /// Example: to expect a "table" by exact match on the page use ExpectTable(That.Equals, "table", Casing.Exact);
        /// </summary>
        void ExpectTable(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectTable(The the, string locator = null, Casing casing = Casing.Ignore);
        void ExpectTable(That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectTable(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// Expect no table inside the table on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to expect that there is no "table" on the page by exact match use ExpectNoTable(That.Equals, "table", Casing.Exact);
        /// </summary>
        void ExpectNoTable(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoTable(The the, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoTable(That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoTable(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Column]

        /// <summary>
        /// Expect "td", "th" tags inside the table on the page by That and Casing. default values are That.Equals and Casing.Ignore  <para />
        /// Example: to expect a "column" by exact match on the page use ExpectColumn(That.Equals, "column", Casing.Exact);
        /// </summary>
        void ExpectColumn(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectColumn(The the, string locator = null, Casing casing = Casing.Ignore);
        void ExpectColumn(That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectColumn(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// Expect no "td", "th" tags inside the table on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to expect that there is no "column" on the page by exact match use ExpectNoColumn(That.Equals, "column", Casing.Exact);
        /// </summary>
        void ExpectNoColumn(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoColumn(The the, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoColumn(That that, string locator = null, Casing casing = Casing.Ignore);
        void ExpectNoColumn(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #endregion

        #endregion

        #region [WaitToSee]

        #region [TargetType]

        #region [Any]

        /// <summary>
        /// WaitToSee text on the page by That and Casing. default values are What.Equals and Casing.Ignore <para />
        /// Example: to wait to see a "text" on the page by exact match use WaitToSee(What.Equals, "text", Casing.Exact);
        /// </summary>
        void WaitToSee(The the, What what, string locator, Casing casing = Casing.Ignore);
        void WaitToSee(The the, string locator, Casing casing = Casing.Ignore);
        void WaitToSee(What what, string locator, Casing casing = Casing.Ignore);
        void WaitToSee(string locator, Casing casing = Casing.Ignore);

        /// <summary>
        /// WaitToSee no text on the page by That and Casing. default values are That.Equals and What.Ignore <para />
        /// Example: to wait to see that there is no "text" on the page by exact match use WaitToSeeNo(What.Equals, "text", Casing.Exact);
        /// </summary>
        void WaitToSeeNo(The the, What what, string locator, Casing casing = Casing.Ignore);
        void WaitToSeeNo(The the, string locator, Casing casing = Casing.Ignore);
        void WaitToSeeNo(What what, string locator, Casing casing = Casing.Ignore);
        void WaitToSeeNo(string locator, Casing casing = Casing.Ignore);

        #endregion

        #region [Text]

        /// <summary>
        /// WaitToSee text on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to wait to see a "text" on the page by exact match use WaitToSeeText(That.Equals, "text", Casing.Exact);
        /// </summary>
        void WaitToSeeText(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeText(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeText(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeText(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// WaitToSee no text on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to wait to see that there is no "text" on the page by exact match use WaitToSeeNoText(That.Equals, "text", Casing.Exact);
        /// </summary>
        void WaitToSeeNoText(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoText(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoText(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoText(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [CSS]

        /// <summary>
        /// WaitToSee CSS on the page <para />
        /// Example: to wait to see an element with CSS "CSS" on the page use WaitToSeeCSS("CSS");
        /// </summary>
        void WaitToSeeCSS(The the, string locator);
        void WaitToSeeCSS(string locator);

        /// <summary>
        /// WaitToSee no CSS on the page <para />
        /// Example: to wait to see that there is no element with CSS "CSS" on the page use WaitToSeeNoCSS("CSS");
        /// </summary>
        void WaitToSeeNoCSS(The the, string locator);
        void WaitToSeeNoCSS(string locator);

        #endregion

        #region [XPath]

        /// <summary>
        /// WaitToSee XPath on the page <para />
        /// Example: to wait to see an element with XPath "xpath" on the page use WaitToSeeXPath("xpath");
        /// </summary>
        void WaitToSeeXPath(The the, string locator);
        void WaitToSeeXPath(string locator);

        /// <summary>
        /// WaitToSee no XPath on the page <para />
        /// Example: to wait to see that there is no element with XPath "xpath" on the page use WaitToSeeNoXPath("xpath");
        /// </summary>
        void WaitToSeeNoXPath(The the, string locator);
        void WaitToSeeNoXPath(string locator);

        #endregion

        #region [Button]

        /// <summary>
        /// WaitToSee "button", "submit", "image", "reset" tag on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to wait to see a "button" on the page by exact match use WaitToSeeButton(That.Equals, "button", Casing.Exact);
        /// </summary>
        void WaitToSeeButton(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeButton(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeButton(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeButton(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// WaitToSee no "button", "submit", "image", "reset" tag on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to wait to see that there is no "button" on the page by exact match use WaitToSeeNoButton(That.Equals, "label", Casing.Exact);
        /// </summary>
        void WaitToSeeNoButton(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoButton(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoButton(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoButton(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Link]

        /// <summary>
        /// WaitToSee "a" tag on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to wait to see a "link" on the page by exact match use WaitToSeeLink(That.Equals, "link", Casing.Exact);
        /// </summary>
        void WaitToSeeLink(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeLink(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeLink(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeLink(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// WaitToSee no "a" tag on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to wait to see that there is no "link" on the page by exact match use WaitToSeeNoLink(That.Equals, "link", Casing.Exact);
        /// </summary>
        void WaitToSeeNoLink(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoLink(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoLink(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoLink(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Field]

        /// <summary>
        /// WaitToSee "input", "select", "textarea", "text", "password", "radio", "checkbox", "file", "email", "tel", "url", "number", "datetime", "datetime-local", "date", "month", "week", "time", "color", "search" tag on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to wait to see a "input" on the page by exact match use WaitToSeeField(That.Equals, "input", Casing.Exact);
        /// </summary>
        void WaitToSeeField(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeField(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeField(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeField(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// WaitToSee no "input", "select", "textarea", "text", "password", "radio", "checkbox", "file", "email", "tel", "url", "number", "datetime", "datetime-local", "date", "month", "week", "time", "color", "search" on the page tag by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to wait to see that there is no "input" on the page by exact match use WaitToSeeNoField(That.Equals, "input", Casing.Exact);
        /// </summary>
        void WaitToSeeNoField(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoField(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoField(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoField(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Header]

        /// <summary>
        /// WaitToSee "h1", "h2", "h3", "h4", "h5", "h6" tag on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to wait to see a "header" on the page by exact match use WaitToSeeHeader(That.Equals, "header", Casing.Exact);
        /// </summary>
        void WaitToSeeHeader(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeHeader(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeHeader(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeHeader(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// WaitToSee no "h1", "h2", "h3", "h4", "h5", "h6" tage on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to wait to see that there is no "header" by exact match use WaitToSeeNoHeader(That.Equals, "header", Casing.Exact);
        /// </summary>
        void WaitToSeeNoHeader(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoHeader(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoHeader(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoHeader(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Label]

        /// <summary>
        /// WaitToSee "label", "strong" tag on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to wait to see a "label" on the page by exact match use WaitToSeeLabel(That.Equals, "label", Casing.Exact);
        /// </summary>
        void WaitToSeeLabel(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeLabel(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeLabel(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeLabel(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// WaitToSee no "label", "strong" tag on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to wait to see that there is no "label" on the page by exact match use WaitToSeeNoLabel(That.Equals, "label", Casing.Exact);
        /// </summary>
        void WaitToSeeNoLabel(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoLabel(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoLabel(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoLabel(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Checkbox]

        /// <summary>
        /// WaitToSee checkbox selected on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to wait to see a "checkbox" is selected on the page by exact match use WaitToSeeCheck(That.Equals, "checkbox", Casing.Exact);
        /// </summary>
        void WaitToSeeCheck(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeCheck(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeCheck(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeCheck(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// WaitToSee checkbox unselected on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to wait to see that there is no "checkbox" selected by exact match on the page use WaitToSeeNoCheck(That.Equals, "checkbox", Casing.Exact);
        /// </summary>
        void WaitToSeeUnCheck(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeUnCheck(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeUnCheck(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeUnCheck(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// WaitToSee "checkbox" on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to wait to see a "checkbox" is on the page by exact match use WaitToSeeCheckbox(That.Equals, "checkbox", Casing.Exact);
        /// </summary>
        void WaitToSeeCheckbox(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeCheckbox(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeCheckbox(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeCheckbox(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// WaitToSee no "checkbox" on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to wait to see that there is no "checkbox" by exact match on the page use WaitToSeeNoCheckbox(That.Equals,"checkbox", Casing.Exact);
        /// </summary>
        void WaitToSeeNoCheckbox(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoCheckbox(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoCheckbox(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoCheckbox(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Radiobox]

        /// <summary>
        /// WaitToSee radiobox selected on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to wait to see a "radiobox" is selected on the page by exact match use WaitToSeeChoose(That.Equals, "radiobox", Casing.Exact);
        /// </summary>
        void WaitToSeeChoose(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeChoose(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeChoose(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeChoose(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// WaitToSee radiobox unselected on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to wait to see that there is no "radiobox" selected by exact match on the page use WaitToSeeNoChoose(That.Equals, "radiobox", Casing.Exact);
        /// </summary>
        void WaitToSeeNoChoose(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoChoose(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoChoose(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoChoose(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// WaitToSee "radiobox" on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to wait to see a "radiobox" is selected on the page by exact match use WaitToSeeRadiobox(That.Equals, "radiobox", Casing.Exact);
        /// </summary>
        void WaitToSeeRadiobox(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeRadiobox(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeRadiobox(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeRadiobox(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// WaitToSee no "radiobox" on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to wait to see that there is no "radiobox" by exact match on the page use WaitToSeeNoRadiobox(That.Equals, "radiobox", Casing.Exact);
        /// </summary>
        void WaitToSeeNoRadiobox(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoRadiobox(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoRadiobox(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoRadiobox(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Row]

        /// <summary>
        /// WaitToSee "tr" tag inside the table on the page by That and Casing. default values are That.Equals and Casing.Ignore  <para />
        /// Example: to wait to see a "row" by exact match on the page use WaitToSeeRow(That.Equals, "row", Casing.Exact);
        /// </summary>
        void WaitToSeeRow(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeRow(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeRow(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeRow(string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeRow(int position);
        void WaitToSeeRow(The the, int position);

        /// <summary>
        /// WaitToSee no "tr" tag inside the table on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to wait to see that there is no "row" on the page by exact match use WaitToSeeNoRow(That.Equals, "row", Casing.Exact);
        /// </summary>
        void WaitToSeeNoRow(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoRow(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoRow(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoRow(string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoRow(The the, int position);
        void WaitToSeeNoRow(int position);

        #endregion

        #region [RowColumns]

        /// <summary>
        /// WaitToSee "tr" tag inside the table on the page by That and Casing. default values are That.Equals and Casing.Ignore  <para />
        /// Example: to wait to see a "row columns" by exact match on the page use WaitToSeeRowColumns(That.Equals, "row columns", Casing.Exact);
        /// </summary>
        void WaitToSeeRowColumns(The the, That that, Casing casing, params string[] locator);
        void WaitToSeeRowColumns(The the, That that, params string[] locator);
        void WaitToSeeRowColumns(The the, Casing casing, params string[] locator);
        void WaitToSeeRowColumns(The the, params string[] locator);
        void WaitToSeeRowColumns(The the);
        void WaitToSeeRowColumns(That that, Casing casing, params string[] locator);
        void WaitToSeeRowColumns(Casing casing, params string[] locator);
        void WaitToSeeRowColumns(That that, params string[] locator);
        void WaitToSeeRowColumns(params string[] locator);

        /// <summary>
        /// WaitToSee no "tr" tag inside the table on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to wait to see that there is no "row columns" on the page by exact match use WaitToSeeNoRowColumns(That.Equals, "row columns", Casing.Exact);
        /// </summary>
        void WaitToSeeNoRowColumns(The the, That that, Casing casing, params string[] locator);
        void WaitToSeeNoRowColumns(The the, That that, params string[] locator);
        void WaitToSeeNoRowColumns(The the, Casing casing, params string[] locator);
        void WaitToSeeNoRowColumns(The the, params string[] locator);
        void WaitToSeeNoRowColumns(The the);
        void WaitToSeeNoRowColumns(That that, Casing casing, params string[] locator);
        void WaitToSeeNoRowColumns(Casing casing, params string[] locator);
        void WaitToSeeNoRowColumns(That that, params string[] locator);
        void WaitToSeeNoRowColumns(params string[] locator);

        #endregion

        #region [Item]

        /// <summary>
        /// WaitToSee item in Dropdown or Combobox on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to wait to see a "item" on the page by exact match use WaitToSeeItem(That.Equals, "item", Casing.Exact);
        /// </summary>
        void WaitToSeeItem(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeItem(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeItem(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeItem(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// WaitToSee no item in Dropdown or Combobox on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to wait to see that there is no "item" on the page by exact match use WaitToSeeNoItem(That.Equals, "item", Casing.Exact);
        /// </summary>
        void WaitToSeeNoItem(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoItem(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoItem(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoItem(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Value]

        /// <summary>
        /// WaitToSee value in the input tag on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to wait to see a value of "input" on the page by exact match use WaitToSeeValue(That.Equals, "input", Casing.Exact);
        /// </summary>
        void WaitToSeeValue(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeValue(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeValue(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeValue(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// WaitToSee no value in the input tag on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to wait to see that there is no value of "input" on the page by exact match use WaitToSeeNoValue(That.Equals, "input", Casing.Exact);
        /// </summary>
        void WaitToSeeNoValue(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoValue(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoValue(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoValue(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Tick]

        /// <summary>
        /// WaitToSee tick on the page. <para />
        /// Example: to wait to see a tick on the page use WaitToSeeTick();
        /// </summary>
        void WaitToSeeTick(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeTick(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeTick(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeTick(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// WaitToSee no tick on the page. <para />
        /// Example: to wait to see that there is no tick on the page use WaitToSeeNoTick();
        /// </summary>
        void WaitToSeeNoTick(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoTick(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoTick(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoTick(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Table]

        /// <summary>
        /// WaitToSee table inside the table on the page by That and Casing. default values are That.Equals and Casing.Ignore  <para />
        /// Example: to wait to see a "table" by exact match on the page use WaitToSeeTable(That.Equals, "table", Casing.Exact);
        /// </summary>
        void WaitToSeeTable(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeTable(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeTable(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeTable(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// WaitToSee no table inside the table on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to wait to see that there is no "table" on the page by exact match use WaitToSeeNoTable(That.Equals, "table", Casing.Exact);
        /// </summary>
        void WaitToSeeNoTable(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoTable(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoTable(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoTable(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #region [Column]

        /// <summary>
        /// WaitToSee "td", "th" tags inside the table on the page by That and Casing. default values are That.Equals and Casing.Ignore  <para />
        /// Example: to wait to see a "column" by exact match on the page use WaitToSeeColumn(That.Equals, "column", Casing.Exact);
        /// </summary>
        void WaitToSeeColumn(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeColumn(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeColumn(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeColumn(string locator = null, Casing casing = Casing.Ignore);

        /// <summary>
        /// WaitToSee no "td", "th" tags inside the table on the page by That and Casing. default values are That.Equals and Casing.Ignore <para />
        /// Example: to wait to see that there is no "column" on the page by exact match use WaitToSeeNoColumn(That.Equals, "column", Casing.Exact);
        /// </summary>
        void WaitToSeeNoColumn(The the, That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoColumn(The the, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoColumn(That that, string locator = null, Casing casing = Casing.Ignore);
        void WaitToSeeNoColumn(string locator = null, Casing casing = Casing.Ignore);

        #endregion

        #endregion

        #endregion

        #region [File]

        /// <summary>
        /// Expect downloaded file in the specified folder from key "Download.Url" in "app.config". default values are That.Equals and Casing.Ignore <para />
        /// Example: to expect a "file.jpg" that has been downloaded to the specified folder from key "Download.Url" in "app.config" use ExpectDownloadedFile(That.Equals, "file.jpg", Casing.Exact);
        /// </summary>
        void ExpectDownloadedFile(That that, string locator, Casing casing = Casing.Ignore);
        void ExpectDownloadedFile(string locator, Casing casing = Casing.Ignore);

        /// <summary>
        /// Delete downloaded file in the specified folder from key "Download.Url" in "app.config". default values are That.Equals and Casing.Ignore <para />
        /// Example: to delete a "file.jpg" that has been downloaded to the specified folder from key "Download.Url" in "app.config" use ClearDownloadedFile(That.Equals, "file.jpg", Casing.Exact);
        /// </summary>
        void ClearDownloadedFile(That that, string locator, Casing casing = Casing.Ignore);
        void ClearDownloadedFile(string locator, Casing casing = Casing.Ignore);

        #endregion

        #endregion
    }
}
