using Geeks.Pangolin.Core.Helper.Targets;
using Geeks.Pangolin.Core.Helper;
using Geeks.Pangolin.Service.DriverService;

namespace Geeks.Pangolin.Helper.UIContext
{
    public partial class UIContext
    {
        #region [Assert]

        #region [Expect]

        #region [TargetType]

        #region [Any]

        private void Expect(Limiter limiter, That that, string locator, Casing casing, bool expect = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = expect ? TargetActionType.Expect : TargetActionType.ExpectNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Any;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void Expect(The the, What what, string locator, Casing casing = Casing.Ignore) => Expect(the.ToLimiterType(), what.ToThat(), locator, casing);
        public void Expect(The the, string locator, Casing casing = Casing.Ignore) => Expect(the, What.Equals, locator, casing);
        public void Expect(What what, string locator, Casing casing = Casing.Ignore) => Expect(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, what.ToThat(), locator, casing);
        public void Expect(string locator, Casing casing = Casing.Ignore) => Expect(What.Equals, locator, casing);

        public void ExpectNo(The the, What what, string locator, Casing casing = Casing.Ignore) => Expect(the.ToLimiterType(), what.ToThat(), locator, casing, false);
        public void ExpectNo(The the, string locator, Casing casing = Casing.Ignore) => ExpectNo(the, What.Equals, locator, casing);
        public void ExpectNo(What what, string locator, Casing casing = Casing.Ignore) => Expect(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, what.ToThat(), locator, casing, false);
        public void ExpectNo(string locator, Casing casing = Casing.Ignore) => ExpectNo(What.Equals, locator, casing);

        #endregion

        #region [Alert]

        private void ExpectAlertText(That that, string locator, Casing casing, bool expect = true)
        {
            RunCommand(this, () => WebDriverService.ExpectAlertText(locator ?? string.Empty, that.ToSearchType(casing), expect));
        }

        public void ExpectAlertText(That that, string locator, Casing casing = Casing.Ignore) => ExpectAlertText(that, locator, casing, true);
        public void ExpectAlertText(string locator, Casing casing = Casing.Ignore) => ExpectAlertText(That.Equals, locator, casing);

        public void ExpectNoAlertText(That that, string locator, Casing casing = Casing.Ignore) => ExpectAlertText(that, locator, casing, false);
        public void ExpectNoAlertText(string locator, Casing casing = Casing.Ignore) => ExpectNoAlertText(That.Equals, locator, casing);

        #endregion

        #region [Text]

        private void ExpectText(Limiter limiter, That that, string locator, Casing casing, bool expect = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = expect ? TargetActionType.Expect : TargetActionType.ExpectNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Text;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void ExpectText(The the, That that, string locator, Casing casing = Casing.Ignore) => ExpectText(the.ToLimiterType(), that, locator, casing);
        public void ExpectText(The the, string locator, Casing casing = Casing.Ignore) => ExpectText(the, That.Equals, locator, casing);
        public void ExpectText(That that, string locator, Casing casing = Casing.Ignore) => ExpectText(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void ExpectText(string locator, Casing casing = Casing.Ignore) => ExpectText(That.Equals, locator, casing);

        public void ExpectNoText(The the, That that, string locator, Casing casing = Casing.Ignore) => ExpectText(the.ToLimiterType(), that, locator, casing, false);
        public void ExpectNoText(The the, string locator, Casing casing = Casing.Ignore) => ExpectNoText(the, That.Equals, locator, casing);
        public void ExpectNoText(That that, string locator, Casing casing = Casing.Ignore) => ExpectText(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, false);
        public void ExpectNoText(string locator, Casing casing = Casing.Ignore) => ExpectNoText(That.Equals, locator, casing);

        #endregion

        #region [CSS]

        private void ExpectCSS(Limiter limiter, That that, string locator, Casing casing, bool expect = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = expect ? TargetActionType.Expect : TargetActionType.ExpectNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.CSS;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void ExpectCSS(The the, string locator) => ExpectCSS(the.ToLimiterType(), That.Equals, locator, Casing.Exact);
        public void ExpectCSS(string locator) => ExpectCSS(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, That.Equals, locator, Casing.Exact);

        public void ExpectNoCSS(The the, string locator) => ExpectCSS(the.ToLimiterType(), That.Equals, locator, Casing.Exact, false);
        public void ExpectNoCSS(string locator) => ExpectCSS(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, That.Equals, locator, Casing.Exact, false);

        #endregion

        #region [XPath]

        private void ExpectXPath(Limiter limiter, That that, string locator, Casing casing, bool expect = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = expect ? TargetActionType.Expect : TargetActionType.ExpectNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.XPath;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void ExpectXPath(The the, string locator) => ExpectXPath(the.ToLimiterType(), That.Equals, locator, Casing.Exact);
        public void ExpectXPath(string locator) => ExpectXPath(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, That.Equals, locator, Casing.Exact);

        public void ExpectNoXPath(The the, string locator) => ExpectXPath(the.ToLimiterType(), That.Equals, locator, Casing.Exact, false);
        public void ExpectNoXPath(string locator) => ExpectXPath(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, That.Equals, locator, Casing.Exact, false);

        #endregion

        #region [Button]

        private void ExpectButton(Limiter limiter, That that, string locator, Casing casing, bool expect = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = expect ? TargetActionType.Expect : TargetActionType.ExpectNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Button;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void ExpectButton(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ExpectButton(the.ToLimiterType(), that, locator, casing);
        public void ExpectButton(The the, string locator = null, Casing casing = Casing.Ignore) => ExpectButton(the, That.Equals, locator, casing);
        public void ExpectButton(That that, string locator = null, Casing casing = Casing.Ignore) => ExpectButton(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void ExpectButton(string locator = null, Casing casing = Casing.Ignore) => ExpectButton(That.Equals, locator, casing);

        public void ExpectNoButton(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ExpectButton(the.ToLimiterType(), that, locator, casing, false);
        public void ExpectNoButton(The the, string locator = null, Casing casing = Casing.Ignore) => ExpectNoButton(the, That.Equals, locator, casing);
        public void ExpectNoButton(That that, string locator = null, Casing casing = Casing.Ignore) => ExpectButton(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, false);
        public void ExpectNoButton(string locator = null, Casing casing = Casing.Ignore) => ExpectNoButton(That.Equals, locator, casing);

        #endregion

        #region [Link]

        private void ExpectLink(Limiter limiter, That that, string locator, Casing casing, bool expect = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = expect ? TargetActionType.Expect : TargetActionType.ExpectNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Link;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void ExpectLink(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ExpectLink(the.ToLimiterType(), that, locator, casing);
        public void ExpectLink(The the, string locator = null, Casing casing = Casing.Ignore) => ExpectLink(the, That.Equals, locator, casing);
        public void ExpectLink(That that, string locator = null, Casing casing = Casing.Ignore) => ExpectLink(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void ExpectLink(string locator = null, Casing casing = Casing.Ignore) => ExpectLink(That.Equals, locator, casing);

        public void ExpectNoLink(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ExpectLink(the.ToLimiterType(), that, locator, casing, false);
        public void ExpectNoLink(The the, string locator = null, Casing casing = Casing.Ignore) => ExpectNoLink(the, That.Equals, locator, casing);
        public void ExpectNoLink(That that, string locator = null, Casing casing = Casing.Ignore) => ExpectLink(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, false);
        public void ExpectNoLink(string locator = null, Casing casing = Casing.Ignore) => ExpectNoLink(That.Equals, locator, casing);

        #endregion

        #region [Field]

        private void ExpectField(Limiter limiter, That that, string locator, Casing casing, bool expect = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = expect ? TargetActionType.Expect : TargetActionType.ExpectNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Field;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void ExpectField(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ExpectField(the.ToLimiterType(), that, locator, casing);
        public void ExpectField(The the, string locator = null, Casing casing = Casing.Ignore) => ExpectField(the, That.Equals, locator, casing);
        public void ExpectField(That that, string locator = null, Casing casing = Casing.Ignore) => ExpectField(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void ExpectField(string locator = null, Casing casing = Casing.Ignore) => ExpectField(That.Equals, locator, casing);

        public void ExpectNoField(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ExpectField(the.ToLimiterType(), that, locator, casing, false);
        public void ExpectNoField(The the, string locator = null, Casing casing = Casing.Ignore) => ExpectNoField(the, That.Equals, locator, casing);
        public void ExpectNoField(That that, string locator = null, Casing casing = Casing.Ignore) => ExpectField(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, false);
        public void ExpectNoField(string locator = null, Casing casing = Casing.Ignore) => ExpectNoField(That.Equals, locator, casing);

        #endregion

        #region [Header]

        private void ExpectHeader(Limiter limiter, That that, string locator, Casing casing, bool expect = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = expect ? TargetActionType.Expect : TargetActionType.ExpectNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Header;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void ExpectHeader(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ExpectHeader(the.ToLimiterType(), that, locator, casing);
        public void ExpectHeader(The the, string locator = null, Casing casing = Casing.Ignore) => ExpectHeader(the, That.Equals, locator, casing);
        public void ExpectHeader(That that, string locator = null, Casing casing = Casing.Ignore) => ExpectHeader(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void ExpectHeader(string locator = null, Casing casing = Casing.Ignore) => ExpectHeader(That.Equals, locator, casing);

        public void ExpectNoHeader(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ExpectHeader(the.ToLimiterType(), that, locator, casing, false);
        public void ExpectNoHeader(The the, string locator = null, Casing casing = Casing.Ignore) => ExpectNoHeader(the, That.Equals, locator, casing);
        public void ExpectNoHeader(That that, string locator = null, Casing casing = Casing.Ignore) => ExpectHeader(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, false);
        public void ExpectNoHeader(string locator = null, Casing casing = Casing.Ignore) => ExpectNoHeader(That.Equals, locator, casing);

        #endregion

        #region [Label]

        private void ExpectLabel(Limiter limiter, That that, string locator, Casing casing, bool expect = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = expect ? TargetActionType.Expect : TargetActionType.ExpectNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Label;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void ExpectLabel(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ExpectLabel(the.ToLimiterType(), that, locator, casing);
        public void ExpectLabel(The the, string locator = null, Casing casing = Casing.Ignore) => ExpectLabel(the, That.Equals, locator, casing);
        public void ExpectLabel(That that, string locator = null, Casing casing = Casing.Ignore) => ExpectLabel(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void ExpectLabel(string locator = null, Casing casing = Casing.Ignore) => ExpectLabel(That.Equals, locator, casing);

        public void ExpectNoLabel(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ExpectLabel(the.ToLimiterType(), that, locator, casing, false);
        public void ExpectNoLabel(The the, string locator = null, Casing casing = Casing.Ignore) => ExpectNoLabel(the, That.Equals, locator, casing);
        public void ExpectNoLabel(That that, string locator = null, Casing casing = Casing.Ignore) => ExpectLabel(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, false);
        public void ExpectNoLabel(string locator = null, Casing casing = Casing.Ignore) => ExpectNoLabel(That.Equals, locator, casing);

        #endregion

        #region [Checkbox]

        private void ExpectCheck(Limiter limiter, That that, string locator, Casing casing, bool expect = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = expect ? TargetActionType.Expect : TargetActionType.ExpectNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Checkbox;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void ExpectCheck(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ExpectCheck(the.ToLimiterType(), that, locator, casing, true, "checked");
        public void ExpectCheck(The the, string locator = null, Casing casing = Casing.Ignore) => ExpectCheck(the, That.Equals, locator, casing);
        public void ExpectCheck(That that, string locator = null, Casing casing = Casing.Ignore) => ExpectCheck(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, true, "checked");
        public void ExpectCheck(string locator = null, Casing casing = Casing.Ignore) => ExpectCheck(That.Equals, locator, casing);

        public void ExpectUnCheck(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ExpectCheck(the.ToLimiterType(), that, locator, casing, true, "unchecked");
        public void ExpectUnCheck(The the, string locator = null, Casing casing = Casing.Ignore) => ExpectUnCheck(the, That.Equals, locator, casing);
        public void ExpectUnCheck(That that, string locator = null, Casing casing = Casing.Ignore) => ExpectCheck(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, true, "unchecked");
        public void ExpectUnCheck(string locator = null, Casing casing = Casing.Ignore) => ExpectUnCheck(That.Equals, locator, casing);

        public void ExpectCheckbox(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ExpectCheck(the.ToLimiterType(), that, locator, casing);
        public void ExpectCheckbox(The the, string locator = null, Casing casing = Casing.Ignore) => ExpectCheckbox(the, That.Equals, locator, casing);
        public void ExpectCheckbox(That that, string locator = null, Casing casing = Casing.Ignore) => ExpectCheck(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void ExpectCheckbox(string locator = null, Casing casing = Casing.Ignore) => ExpectCheckbox(That.Equals, locator, casing);

        public void ExpectNoCheckbox(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ExpectCheck(the.ToLimiterType(), that, locator, casing, false);
        public void ExpectNoCheckbox(The the, string locator = null, Casing casing = Casing.Ignore) => ExpectNoCheckbox(the, That.Equals, locator, casing);
        public void ExpectNoCheckbox(That that, string locator = null, Casing casing = Casing.Ignore) => ExpectCheck(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, false);
        public void ExpectNoCheckbox(string locator = null, Casing casing = Casing.Ignore) => ExpectNoCheckbox(That.Equals, locator, casing);

        #endregion

        #region [Radiobox]

        private void ExpectChoose(Limiter limiter, That that, string locator, Casing casing, bool expect = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = expect ? TargetActionType.Expect : TargetActionType.ExpectNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Radiobox;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void ExpectChoose(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ExpectChoose(the.ToLimiterType(), that, locator, casing, true, "selected");
        public void ExpectChoose(The the, string locator = null, Casing casing = Casing.Ignore) => ExpectChoose(the, That.Equals, locator, casing);
        public void ExpectChoose(That that, string locator = null, Casing casing = Casing.Ignore) => ExpectChoose(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, true, "selected");
        public void ExpectChoose(string locator = null, Casing casing = Casing.Ignore) => ExpectChoose(That.Equals, locator, casing);

        public void ExpectNoChoose(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ExpectChoose(the.ToLimiterType(), that, locator, casing, false, "selected");
        public void ExpectNoChoose(The the, string locator = null, Casing casing = Casing.Ignore) => ExpectNoChoose(the, That.Equals, locator, casing);
        public void ExpectNoChoose(That that, string locator = null, Casing casing = Casing.Ignore) => ExpectChoose(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, false, "selected");
        public void ExpectNoChoose(string locator = null, Casing casing = Casing.Ignore) => ExpectNoChoose(That.Equals, locator, casing);

        public void ExpectRadiobox(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ExpectChoose(the.ToLimiterType(), that, locator, casing);
        public void ExpectRadiobox(The the, string locator = null, Casing casing = Casing.Ignore) => ExpectRadiobox(the, That.Equals, locator, casing);
        public void ExpectRadiobox(That that, string locator = null, Casing casing = Casing.Ignore) => ExpectChoose(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void ExpectRadiobox(string locator = null, Casing casing = Casing.Ignore) => ExpectRadiobox(That.Equals, locator, casing);

        public void ExpectNoRadiobox(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ExpectChoose(the.ToLimiterType(), that, locator, casing, false);
        public void ExpectNoRadiobox(The the, string locator = null, Casing casing = Casing.Ignore) => ExpectNoRadiobox(the, That.Equals, locator, casing);
        public void ExpectNoRadiobox(That that, string locator = null, Casing casing = Casing.Ignore) => ExpectChoose(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, false);
        public void ExpectNoRadiobox(string locator = null, Casing casing = Casing.Ignore) => ExpectNoRadiobox(That.Equals, locator, casing);

        #endregion

        #region [Row]

        private void ExpectRow(Limiter limiter, That that, string locator, Casing casing, bool expect = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = expect ? TargetActionType.Expect : TargetActionType.ExpectNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Row;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void ExpectRow(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ExpectRow(the.ToLimiterType(), that, locator, casing);
        public void ExpectRow(The the, string locator = null, Casing casing = Casing.Ignore) => ExpectRow(the, That.Equals, locator, casing);
        public void ExpectRow(That that, string locator = null, Casing casing = Casing.Ignore) => ExpectRow(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void ExpectRow(string locator = null, Casing casing = Casing.Ignore) => ExpectRow(That.Equals, locator, casing);

        private void ExpectRow(Limiter limiter, int position, bool expect = true, string value = null)
        {
            Target.Text = position.ToString();
            Target.ActionType = expect ? TargetActionType.Expect : TargetActionType.ExpectNo;
            Target.Limiter = limiter;
            Target.SearchType = SearchType.Position;
            Target.TargetType = TargetType.Row;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void ExpectRow(The the, int position) => ExpectRow(the.ToLimiterType(), position);
        public void ExpectRow(int position) => ExpectRow(Limiter.Everything, position);

        public void ExpectNoRow(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ExpectRow(the.ToLimiterType(), that, locator, casing, false);
        public void ExpectNoRow(The the, string locator = null, Casing casing = Casing.Ignore) => ExpectNoRow(the, That.Equals, locator, casing);
        public void ExpectNoRow(That that, string locator = null, Casing casing = Casing.Ignore) => ExpectRow(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, false);
        public void ExpectNoRow(string locator = null, Casing casing = Casing.Ignore) => ExpectNoRow(That.Equals, locator, casing);

        public void ExpectNoRow(The the, int position) => ExpectRow(the.ToLimiterType(), position, false);
        public void ExpectNoRow(int position) => ExpectRow(Limiter.Everything, position, false);

        #endregion

        #region [RowColumns]

        private void ExpectRowColumns(Limiter limiter, That that, Casing casing, bool expect = true, string value = null, params string[] locator)
        {
            Target.Text = string.Join("\n", locator);
            Target.ActionType = expect ? TargetActionType.Expect : TargetActionType.ExpectNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Row;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void ExpectRowColumns(The the, That that, Casing casing, params string[] locator) => ExpectRowColumns(the.ToLimiterType(), that, casing, true, null, locator);
        public void ExpectRowColumns(The the, That that, params string[] locator) => ExpectRowColumns(the, that, Casing.Ignore, locator);
        public void ExpectRowColumns(The the, Casing casing, params string[] locator) => ExpectRowColumns(the, That.Equals, casing, locator);
        public void ExpectRowColumns(The the, params string[] locator) => ExpectRowColumns(the, That.Equals, locator);
        public void ExpectRowColumns(The the) => ExpectRowColumns(the, string.Empty);
        public void ExpectRowColumns(That that, Casing casing, params string[] locator) => ExpectRowColumns(Limiter.Everything, that, casing, true, null, locator);
        public void ExpectRowColumns(That that, params string[] locator) => ExpectRowColumns(that, Casing.Ignore, locator);
        public void ExpectRowColumns(Casing casing, params string[] locator) => ExpectRowColumns(That.Equals, casing, locator);
        public void ExpectRowColumns(params string[] locator) => ExpectRowColumns(That.Equals, locator);
        public void ExpectRowColumns() => ExpectRowColumns(string.Empty);

        public void ExpectNoRowColumns(The the, That that, Casing casing, params string[] locator) => ExpectRowColumns(the.ToLimiterType(), that, casing, false, null, locator);
        public void ExpectNoRowColumns(The the, That that, params string[] locator) => ExpectNoRowColumns(the, that, Casing.Ignore, locator);
        public void ExpectNoRowColumns(The the, Casing casing, params string[] locator) => ExpectNoRowColumns(the, That.Equals, casing, locator);
        public void ExpectNoRowColumns(The the, params string[] locator) => ExpectNoRowColumns(the, That.Equals, locator);
        public void ExpectNoRowColumns(The the) => ExpectNoRowColumns(the, string.Empty);
        public void ExpectNoRowColumns(That that, Casing casing, params string[] locator) => ExpectRowColumns(Limiter.Everything, that, casing, false, null, locator);
        public void ExpectNoRowColumns(That that, params string[] locator) => ExpectNoRowColumns(that, Casing.Ignore, locator);
        public void ExpectNoRowColumns(Casing casing, params string[] locator) => ExpectNoRowColumns(That.Equals, casing, locator);
        public void ExpectNoRowColumns(params string[] locator) => ExpectNoRowColumns(That.Equals, locator);
        public void ExpectNoRowColumns() => ExpectNoRowColumns(string.Empty);

        #endregion

        #region [Item]

        private void ExpectItem(Limiter limiter, That that, string locator, Casing casing, bool expect = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = expect ? TargetActionType.Expect : TargetActionType.ExpectNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Item;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void ExpectItem(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ExpectItem(the.ToLimiterType(), that, locator, casing);
        public void ExpectItem(The the, string locator = null, Casing casing = Casing.Ignore) => ExpectItem(the, That.Equals, locator, casing);
        public void ExpectItem(That that, string locator = null, Casing casing = Casing.Ignore) => ExpectItem(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void ExpectItem(string locator = null, Casing casing = Casing.Ignore) => ExpectItem(That.Equals, locator, casing);

        public void ExpectNoItem(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ExpectItem(the.ToLimiterType(), that, locator, casing, false);
        public void ExpectNoItem(The the, string locator = null, Casing casing = Casing.Ignore) => ExpectNoItem(the, That.Equals, locator, casing);
        public void ExpectNoItem(That that, string locator = null, Casing casing = Casing.Ignore) => ExpectItem(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, false);
        public void ExpectNoItem(string locator = null, Casing casing = Casing.Ignore) => ExpectNoItem(That.Equals, locator, casing);

        #endregion

        #region [Value]

        private void ExpectValue(Limiter limiter, That that, string locator, Casing casing, bool expect = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = expect ? TargetActionType.Expect : TargetActionType.ExpectNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Value;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void ExpectValue(The the, That that, string locator, Casing casing = Casing.Ignore) => ExpectValue(the.ToLimiterType(), that, locator, casing);
        public void ExpectValue(The the, string locator, Casing casing = Casing.Ignore) => ExpectValue(the, That.Equals, locator, casing);
        public void ExpectValue(That that, string locator, Casing casing = Casing.Ignore) => ExpectValue(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void ExpectValue(string locator, Casing casing = Casing.Ignore) => ExpectValue(That.Equals, locator, casing);

        public void ExpectNoValue(The the, That that, string locator, Casing casing = Casing.Ignore) => ExpectValue(the.ToLimiterType(), that, locator, casing, false);
        public void ExpectNoValue(The the, string locator, Casing casing = Casing.Ignore) => ExpectNoValue(the, That.Equals, locator, casing);
        public void ExpectNoValue(That that, string locator, Casing casing = Casing.Ignore) => ExpectValue(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, false);
        public void ExpectNoValue(string locator, Casing casing = Casing.Ignore) => ExpectNoValue(That.Equals, locator, casing);

        #endregion

        #region [Tick]

        private void ExpectTick(Limiter limiter, That that, string locator, Casing casing, bool expect = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = expect ? TargetActionType.Expect : TargetActionType.ExpectNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Tick;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void ExpectTick(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ExpectTick(the.ToLimiterType(), that, locator, casing);
        public void ExpectTick(The the, string locator = null, Casing casing = Casing.Ignore) => ExpectTick(the, That.Equals, locator, casing);
        public void ExpectTick(That that, string locator = null, Casing casing = Casing.Ignore) => ExpectTick(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void ExpectTick(string locator = null, Casing casing = Casing.Ignore) => ExpectTick(That.Equals, locator, casing);

        public void ExpectNoTick(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ExpectTick(the.ToLimiterType(), that, locator, casing, false);
        public void ExpectNoTick(The the, string locator = null, Casing casing = Casing.Ignore) => ExpectNoTick(the, That.Equals, locator, casing);
        public void ExpectNoTick(That that, string locator = null, Casing casing = Casing.Ignore) => ExpectTick(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, false);
        public void ExpectNoTick(string locator = null, Casing casing = Casing.Ignore) => ExpectNoTick(That.Equals, locator, casing);

        #endregion

        #region [Table]

        private void ExpectTable(Limiter limiter, That that, string locator, Casing casing, bool expect = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = expect ? TargetActionType.Expect : TargetActionType.ExpectNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Table;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void ExpectTable(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ExpectTable(the.ToLimiterType(), that, locator, casing);
        public void ExpectTable(The the, string locator = null, Casing casing = Casing.Ignore) => ExpectTable(the, That.Equals, locator, casing);
        public void ExpectTable(That that, string locator = null, Casing casing = Casing.Ignore) => ExpectTable(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void ExpectTable(string locator = null, Casing casing = Casing.Ignore) => ExpectTable(That.Equals, locator, casing);

        public void ExpectNoTable(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ExpectTable(the.ToLimiterType(), that, locator, casing, false);
        public void ExpectNoTable(The the, string locator = null, Casing casing = Casing.Ignore) => ExpectNoTable(the, That.Equals, locator, casing);
        public void ExpectNoTable(That that, string locator = null, Casing casing = Casing.Ignore) => ExpectTable(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, false);
        public void ExpectNoTable(string locator = null, Casing casing = Casing.Ignore) => ExpectNoTable(That.Equals, locator, casing);

        #endregion

        #region [Column]

        private void ExpectColumn(Limiter limiter, That that, string locator, Casing casing, bool expect = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = expect ? TargetActionType.Expect : TargetActionType.ExpectNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Column;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void ExpectColumn(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ExpectColumn(the.ToLimiterType(), that, locator, casing);
        public void ExpectColumn(The the, string locator = null, Casing casing = Casing.Ignore) => ExpectColumn(the, That.Equals, locator, casing);
        public void ExpectColumn(That that, string locator = null, Casing casing = Casing.Ignore) => ExpectColumn(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void ExpectColumn(string locator = null, Casing casing = Casing.Ignore) => ExpectColumn(That.Equals, locator, casing);

        public void ExpectNoColumn(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ExpectColumn(the.ToLimiterType(), that, locator, casing, false);
        public void ExpectNoColumn(The the, string locator = null, Casing casing = Casing.Ignore) => ExpectNoColumn(the, That.Equals, locator, casing);
        public void ExpectNoColumn(That that, string locator = null, Casing casing = Casing.Ignore) => ExpectColumn(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, false);
        public void ExpectNoColumn(string locator = null, Casing casing = Casing.Ignore) => ExpectNoColumn(That.Equals, locator, casing);

        #endregion

        #endregion

        #endregion

        #region [WaitToSee]

        #region [TargetType]

        #region [Any]

        private void WaitToSee(Limiter limiter, That that, string locator, Casing casing, bool waitTosee = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = waitTosee ? TargetActionType.WaitToSee : TargetActionType.WaitToSeeNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Any;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void WaitToSee(The the, What what, string locator, Casing casing = Casing.Ignore) => WaitToSee(the.ToLimiterType(), what.ToThat(), locator, casing);
        public void WaitToSee(The the, string locator, Casing casing = Casing.Ignore) => WaitToSee(the, What.Equals, locator, casing);
        public void WaitToSee(What what, string locator, Casing casing = Casing.Ignore) => WaitToSee(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, what.ToThat(), locator, casing);
        public void WaitToSee(string locator, Casing casing = Casing.Ignore) => WaitToSee(What.Equals, locator, casing);

        public void WaitToSeeNo(The the, What what, string locator, Casing casing = Casing.Ignore) => WaitToSee(the.ToLimiterType(), what.ToThat(), locator, casing, false);
        public void WaitToSeeNo(The the, string locator, Casing casing = Casing.Ignore) => WaitToSeeNo(the, What.Equals, locator, casing);
        public void WaitToSeeNo(What what, string locator, Casing casing = Casing.Ignore) => WaitToSee(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, what.ToThat(), locator, casing, false);
        public void WaitToSeeNo(string locator, Casing casing = Casing.Ignore) => WaitToSeeNo(What.Equals, locator, casing);

        #endregion

        #region [Text]

        private void WaitToSeeText(Limiter limiter, That that, string locator, Casing casing, bool waitTosee = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = waitTosee ? TargetActionType.WaitToSee : TargetActionType.WaitToSeeNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Text;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void WaitToSeeText(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeText(the.ToLimiterType(), that, locator, casing);
        public void WaitToSeeText(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeText(the, That.Equals, locator, casing);
        public void WaitToSeeText(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeText(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void WaitToSeeText(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeText(That.Equals, locator, casing);

        public void WaitToSeeNoText(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeText(the.ToLimiterType(), that, locator, casing, false);
        public void WaitToSeeNoText(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoText(the, That.Equals, locator, casing);
        public void WaitToSeeNoText(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeText(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, false);
        public void WaitToSeeNoText(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoText(That.Equals, locator, casing);

        #endregion

        #region [CSS]

        private void WaitToSeeCSS(Limiter limiter, That that, string locator, Casing casing, bool expect = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = expect ? TargetActionType.WaitToSee : TargetActionType.WaitToSeeNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.CSS;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void WaitToSeeCSS(The the, string locator) => WaitToSeeCSS(the.ToLimiterType(), That.Equals, locator, Casing.Exact);
        public void WaitToSeeCSS(string locator) => WaitToSeeCSS(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, That.Equals, locator, Casing.Exact);

        public void WaitToSeeNoCSS(The the, string locator) => WaitToSeeCSS(the.ToLimiterType(), That.Equals, locator, Casing.Exact, false);
        public void WaitToSeeNoCSS(string locator) => WaitToSeeCSS(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, That.Equals, locator, Casing.Exact, false);

        #endregion

        #region [XPath]

        private void WaitToSeeXPath(Limiter limiter, That that, string locator, Casing casing, bool expect = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = expect ? TargetActionType.WaitToSee : TargetActionType.WaitToSeeNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.XPath;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void WaitToSeeXPath(The the, string locator) => WaitToSeeXPath(the.ToLimiterType(), That.Equals, locator, Casing.Exact);
        public void WaitToSeeXPath(string locator) => WaitToSeeXPath(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, That.Equals, locator, Casing.Exact);

        public void WaitToSeeNoXPath(The the, string locator) => WaitToSeeXPath(the.ToLimiterType(), That.Equals, locator, Casing.Exact, false);
        public void WaitToSeeNoXPath(string locator) => WaitToSeeXPath(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, That.Equals, locator, Casing.Exact, false);

        #endregion

        #region [Editor]

        private void WaitToSeeEditor(Limiter limiter, That that, string locator, Casing casing, bool waitTosee = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = waitTosee ? TargetActionType.WaitToSee : TargetActionType.WaitToSeeNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Editor;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void WaitToSeeEditor(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeEditor(the.ToLimiterType(), that, locator, casing);
        public void WaitToSeeEditor(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeEditor(the, That.Equals, locator, casing);
        public void WaitToSeeEditor(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeEditor(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void WaitToSeeEditor(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeEditor(That.Equals, locator, casing);

        public void WaitToSeeNoEditor(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeEditor(the.ToLimiterType(), that, locator, casing, false);
        public void WaitToSeeNoEditor(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoEditor(the, That.Equals, locator, casing);
        public void WaitToSeeNoEditor(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeEditor(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, false);
        public void WaitToSeeNoEditor(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoEditor(That.Equals, locator, casing);

        #endregion

        #region [Button]

        private void WaitToSeeButton(Limiter limiter, That that, string locator, Casing casing, bool waitTosee = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = waitTosee ? TargetActionType.WaitToSee : TargetActionType.WaitToSeeNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Button;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void WaitToSeeButton(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeButton(the.ToLimiterType(), that, locator, casing);
        public void WaitToSeeButton(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeButton(the, That.Equals, locator, casing);
        public void WaitToSeeButton(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeButton(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void WaitToSeeButton(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeButton(That.Equals, locator, casing);

        public void WaitToSeeNoButton(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeButton(the.ToLimiterType(), that, locator, casing, false);
        public void WaitToSeeNoButton(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoButton(the, That.Equals, locator, casing);
        public void WaitToSeeNoButton(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeButton(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, false);
        public void WaitToSeeNoButton(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoButton(That.Equals, locator, casing);

        #endregion

        #region [Link]

        private void WaitToSeeLink(Limiter limiter, That that, string locator, Casing casing, bool waitTosee = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = waitTosee ? TargetActionType.WaitToSee : TargetActionType.WaitToSeeNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Link;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void WaitToSeeLink(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeLink(the.ToLimiterType(), that, locator, casing);
        public void WaitToSeeLink(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeLink(the, That.Equals, locator, casing);
        public void WaitToSeeLink(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeLink(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void WaitToSeeLink(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeLink(That.Equals, locator, casing);

        public void WaitToSeeNoLink(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeLink(the.ToLimiterType(), that, locator, casing, false);
        public void WaitToSeeNoLink(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoLink(the, That.Equals, locator, casing);
        public void WaitToSeeNoLink(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeLink(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, false);
        public void WaitToSeeNoLink(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoLink(That.Equals, locator, casing);

        #endregion

        #region [Field]

        private void WaitToSeeField(Limiter limiter, That that, string locator, Casing casing, bool waitTosee = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = waitTosee ? TargetActionType.WaitToSee : TargetActionType.WaitToSeeNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Field;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void WaitToSeeField(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeField(the.ToLimiterType(), that, locator, casing);
        public void WaitToSeeField(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeField(the, That.Equals, locator, casing);
        public void WaitToSeeField(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeField(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void WaitToSeeField(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeField(That.Equals, locator, casing);

        public void WaitToSeeNoField(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeField(the.ToLimiterType(), that, locator, casing, false);
        public void WaitToSeeNoField(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoField(the, That.Equals, locator, casing);
        public void WaitToSeeNoField(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeField(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, false);
        public void WaitToSeeNoField(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoField(That.Equals, locator, casing);

        #endregion

        #region [Header]

        private void WaitToSeeHeader(Limiter limiter, That that, string locator, Casing casing, bool waitTosee = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = waitTosee ? TargetActionType.WaitToSee : TargetActionType.WaitToSeeNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Header;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void WaitToSeeHeader(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeHeader(the.ToLimiterType(), that, locator, casing);
        public void WaitToSeeHeader(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeHeader(the, That.Equals, locator, casing);
        public void WaitToSeeHeader(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeHeader(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void WaitToSeeHeader(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeHeader(That.Equals, locator, casing);

        public void WaitToSeeNoHeader(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeHeader(the.ToLimiterType(), that, locator, casing, false);
        public void WaitToSeeNoHeader(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoHeader(the, That.Equals, locator, casing);
        public void WaitToSeeNoHeader(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeHeader(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, false);
        public void WaitToSeeNoHeader(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoHeader(That.Equals, locator, casing);

        #endregion

        #region [Label]

        private void WaitToSeeLabel(Limiter limiter, That that, string locator, Casing casing, bool waitTosee = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = waitTosee ? TargetActionType.WaitToSee : TargetActionType.WaitToSeeNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Label;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void WaitToSeeLabel(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeLabel(the.ToLimiterType(), that, locator, casing);
        public void WaitToSeeLabel(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeLabel(the, That.Equals, locator, casing);
        public void WaitToSeeLabel(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeLabel(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void WaitToSeeLabel(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeLabel(That.Equals, locator, casing);

        public void WaitToSeeNoLabel(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeLabel(the.ToLimiterType(), that, locator, casing, false);
        public void WaitToSeeNoLabel(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoLabel(the, That.Equals, locator, casing);
        public void WaitToSeeNoLabel(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeLabel(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, false);
        public void WaitToSeeNoLabel(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoLabel(That.Equals, locator, casing);

        #endregion

        #region [Checkbox]

        private void WaitToSeeCheck(Limiter limiter, That that, string locator, Casing casing, bool waitTosee = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = waitTosee ? TargetActionType.WaitToSee : TargetActionType.WaitToSeeNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Checkbox;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void WaitToSeeCheck(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeCheck(the.ToLimiterType(), that, locator, casing, true, "checked");
        public void WaitToSeeCheck(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeCheck(the, That.Equals, locator, casing);
        public void WaitToSeeCheck(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeCheck(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, true, "checked");
        public void WaitToSeeCheck(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeCheck(That.Equals, locator, casing);

        public void WaitToSeeUnCheck(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeCheck(the.ToLimiterType(), that, locator, casing, true, "unchecked");
        public void WaitToSeeUnCheck(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeUnCheck(the, That.Equals, locator, casing);
        public void WaitToSeeUnCheck(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeCheck(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, true, "unchecked");
        public void WaitToSeeUnCheck(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeUnCheck(That.Equals, locator, casing);

        public void WaitToSeeCheckbox(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeCheck(the.ToLimiterType(), that, locator, casing);
        public void WaitToSeeCheckbox(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeCheckbox(the, That.Equals, locator, casing);
        public void WaitToSeeCheckbox(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeCheck(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void WaitToSeeCheckbox(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeCheckbox(That.Equals, locator, casing);

        public void WaitToSeeNoCheckbox(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeCheck(the.ToLimiterType(), that, locator, casing, false);
        public void WaitToSeeNoCheckbox(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoCheckbox(the, That.Equals, locator, casing);
        public void WaitToSeeNoCheckbox(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeCheck(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, false);
        public void WaitToSeeNoCheckbox(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoCheckbox(That.Equals, locator, casing);

        #endregion

        #region [Radiobox]

        private void WaitToSeeChoose(Limiter limiter, That that, string locator, Casing casing, bool waitTosee = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = waitTosee ? TargetActionType.WaitToSee : TargetActionType.WaitToSeeNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Radiobox;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void WaitToSeeChoose(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeChoose(the.ToLimiterType(), that, locator, casing, true, "selected");
        public void WaitToSeeChoose(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeChoose(the, That.Equals, locator, casing);
        public void WaitToSeeChoose(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeChoose(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, true, "selected");
        public void WaitToSeeChoose(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeChoose(That.Equals, locator, casing);

        public void WaitToSeeNoChoose(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeChoose(the.ToLimiterType(), that, locator, casing, false, "selected");
        public void WaitToSeeNoChoose(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoChoose(the, That.Equals, locator, casing);
        public void WaitToSeeNoChoose(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeChoose(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, false, "selected");
        public void WaitToSeeNoChoose(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoChoose(That.Equals, locator, casing);

        public void WaitToSeeRadiobox(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeChoose(the.ToLimiterType(), that, locator, casing);
        public void WaitToSeeRadiobox(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeRadiobox(the, That.Equals, locator, casing);
        public void WaitToSeeRadiobox(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeChoose(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void WaitToSeeRadiobox(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeRadiobox(That.Equals, locator, casing);

        public void WaitToSeeNoRadiobox(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeChoose(the.ToLimiterType(), that, locator, casing, false);
        public void WaitToSeeNoRadiobox(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoRadiobox(the, That.Equals, locator, casing);
        public void WaitToSeeNoRadiobox(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeChoose(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, false);
        public void WaitToSeeNoRadiobox(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoRadiobox(That.Equals, locator, casing);

        #endregion

        #region [Row]

        private void WaitToSeeRow(Limiter limiter, That that, string locator, Casing casing, bool waitTosee = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = waitTosee ? TargetActionType.WaitToSee : TargetActionType.WaitToSeeNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Row;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void WaitToSeeRow(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeRow(the.ToLimiterType(), that, locator, casing);
        public void WaitToSeeRow(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeRow(the, That.Equals, locator, casing);
        public void WaitToSeeRow(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeRow(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void WaitToSeeRow(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeRow(That.Equals, locator, casing);

        private void WaitToSeeRow(Limiter limiter, int position, bool waitTosee = true, string value = null)
        {
            Target.Text = position.ToString();
            Target.ActionType = waitTosee ? TargetActionType.WaitToSee : TargetActionType.WaitToSeeNo;
            Target.Limiter = limiter;
            Target.SearchType = SearchType.Position;
            Target.TargetType = TargetType.Row;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void WaitToSeeRow(The the, int position) => WaitToSeeRow(the.ToLimiterType(), position);
        public void WaitToSeeRow(int position) => WaitToSeeRow(Limiter.Everything, position);

        public void WaitToSeeNoRow(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeRow(the.ToLimiterType(), that, locator, casing, false);
        public void WaitToSeeNoRow(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoRow(the, That.Equals, locator, casing);
        public void WaitToSeeNoRow(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeRow(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, false);
        public void WaitToSeeNoRow(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoRow(That.Equals, locator, casing);

        public void WaitToSeeNoRow(The the, int position) => WaitToSeeRow(the.ToLimiterType(), position, false);
        public void WaitToSeeNoRow(int position) => WaitToSeeRow(Limiter.Everything, position, false);

        #endregion

        #region [RowColumns]

        private void WaitToSeeRowColumns(Limiter limiter, That that, Casing casing, bool waitTosee = true, string value = null, params string[] locator)
        {
            Target.Text = string.Join("\n", locator);
            Target.ActionType = waitTosee ? TargetActionType.WaitToSee : TargetActionType.WaitToSeeNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Row;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void WaitToSeeRowColumns(The the, That that, Casing casing, params string[] locator) => WaitToSeeRowColumns(the.ToLimiterType(), that, casing, true, null, locator);
        public void WaitToSeeRowColumns(The the, That that, params string[] locator) => WaitToSeeRowColumns(the, that, Casing.Ignore, locator);
        public void WaitToSeeRowColumns(The the, Casing casing, params string[] locator) => WaitToSeeRowColumns(the, That.Equals, casing, locator);
        public void WaitToSeeRowColumns(The the, params string[] locator) => WaitToSeeRowColumns(the, That.Equals, locator);
        public void WaitToSeeRowColumns(The the) => WaitToSeeRowColumns(the, string.Empty);
        public void WaitToSeeRowColumns(That that, Casing casing, params string[] locator) => WaitToSeeRowColumns(Limiter.Everything, that, casing, true, null, locator);
        public void WaitToSeeRowColumns(That that, params string[] locator) => WaitToSeeRowColumns(that, Casing.Ignore, locator);
        public void WaitToSeeRowColumns(Casing casing, params string[] locator) => WaitToSeeRowColumns(That.Equals, casing, locator);
        public void WaitToSeeRowColumns(params string[] locator) => WaitToSeeRowColumns(That.Equals, locator);
        public void WaitToSeeRowColumns() => WaitToSeeRowColumns(string.Empty);

        public void WaitToSeeNoRowColumns(The the, That that, Casing casing, params string[] locator) => WaitToSeeRowColumns(the.ToLimiterType(), that, casing, false, null, locator);
        public void WaitToSeeNoRowColumns(The the, That that, params string[] locator) => WaitToSeeNoRowColumns(the, that, Casing.Ignore, locator);
        public void WaitToSeeNoRowColumns(The the, Casing casing, params string[] locator) => WaitToSeeNoRowColumns(the, That.Equals, casing, locator);
        public void WaitToSeeNoRowColumns(The the, params string[] locator) => WaitToSeeNoRowColumns(the, That.Equals, locator);
        public void WaitToSeeNoRowColumns(The the) => WaitToSeeNoRowColumns(the, string.Empty);
        public void WaitToSeeNoRowColumns(That that, Casing casing, params string[] locator) => WaitToSeeRowColumns(Limiter.Everything, that, casing, false, null, locator);
        public void WaitToSeeNoRowColumns(That that, params string[] locator) => WaitToSeeNoRowColumns(that, Casing.Ignore, locator);
        public void WaitToSeeNoRowColumns(Casing casing, params string[] locator) => WaitToSeeNoRowColumns(That.Equals, casing, locator);
        public void WaitToSeeNoRowColumns(params string[] locator) => WaitToSeeNoRowColumns(That.Equals, locator);
        public void WaitToSeeNoRowColumns() => WaitToSeeNoRowColumns(string.Empty);

        #endregion

        #region [Item]

        private void WaitToSeeItem(Limiter limiter, That that, string locator, Casing casing, bool waitTosee = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = waitTosee ? TargetActionType.WaitToSee : TargetActionType.WaitToSeeNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Item;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void WaitToSeeItem(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeItem(the.ToLimiterType(), that, locator, casing);
        public void WaitToSeeItem(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeItem(the, That.Equals, locator, casing);
        public void WaitToSeeItem(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeItem(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void WaitToSeeItem(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeItem(That.Equals, locator, casing);

        public void WaitToSeeNoItem(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeItem(the.ToLimiterType(), that, locator, casing, false);
        public void WaitToSeeNoItem(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoItem(the, That.Equals, locator, casing);
        public void WaitToSeeNoItem(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeItem(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, false);
        public void WaitToSeeNoItem(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoItem(That.Equals, locator, casing);

        #endregion

        #region [Value]

        private void WaitToSeeValue(Limiter limiter, That that, string locator, Casing casing, bool waitTosee = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = waitTosee ? TargetActionType.WaitToSee : TargetActionType.WaitToSeeNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Value;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void WaitToSeeValue(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeValue(the.ToLimiterType(), that, locator, casing);
        public void WaitToSeeValue(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeValue(the, That.Equals, locator, casing);
        public void WaitToSeeValue(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeValue(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void WaitToSeeValue(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeValue(That.Equals, locator, casing);

        public void WaitToSeeNoValue(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeValue(the.ToLimiterType(), that, locator, casing, false);
        public void WaitToSeeNoValue(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoValue(the, That.Equals, locator, casing);
        public void WaitToSeeNoValue(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeValue(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, false);
        public void WaitToSeeNoValue(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoValue(That.Equals, locator, casing);

        #endregion

        #region [Tick]

        private void WaitToSeeTick(Limiter limiter, That that, string locator, Casing casing, bool waitTosee = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = waitTosee ? TargetActionType.WaitToSee : TargetActionType.WaitToSeeNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Tick;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void WaitToSeeTick(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeTick(the.ToLimiterType(), that, locator, casing);
        public void WaitToSeeTick(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeTick(the, That.Equals, locator, casing);
        public void WaitToSeeTick(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeTick(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void WaitToSeeTick(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeTick(That.Equals, locator, casing);

        public void WaitToSeeNoTick(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeTick(the.ToLimiterType(), that, locator, casing, false);
        public void WaitToSeeNoTick(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoTick(the, That.Equals, locator, casing);
        public void WaitToSeeNoTick(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeTick(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, false);
        public void WaitToSeeNoTick(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoTick(That.Equals, locator, casing);

        #endregion

        #region [Table]

        private void WaitToSeeTable(Limiter limiter, That that, string locator, Casing casing, bool waitTosee = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = waitTosee ? TargetActionType.WaitToSee : TargetActionType.WaitToSeeNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Table;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void WaitToSeeTable(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeTable(the.ToLimiterType(), that, locator, casing);
        public void WaitToSeeTable(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeTable(the, That.Equals, locator, casing);
        public void WaitToSeeTable(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeTable(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void WaitToSeeTable(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeTable(That.Equals, locator, casing);

        public void WaitToSeeNoTable(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeTable(the.ToLimiterType(), that, locator, casing, false);
        public void WaitToSeeNoTable(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoTable(the, That.Equals, locator, casing);
        public void WaitToSeeNoTable(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeTable(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, false);
        public void WaitToSeeNoTable(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoTable(That.Equals, locator, casing);

        #endregion

        #region [Column]

        private void WaitToSeeColumn(Limiter limiter, That that, string locator, Casing casing, bool waitTosee = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = waitTosee ? TargetActionType.WaitToSee : TargetActionType.WaitToSeeNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Column;
            Target.Value = value ?? string.Empty;

            RunTargetCommand();
        }

        public void WaitToSeeColumn(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeColumn(the.ToLimiterType(), that, locator, casing);
        public void WaitToSeeColumn(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeColumn(the, That.Equals, locator, casing);
        public void WaitToSeeColumn(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeColumn(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void WaitToSeeColumn(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeColumn(That.Equals, locator, casing);

        public void WaitToSeeNoColumn(The the, That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeColumn(the.ToLimiterType(), that, locator, casing, false);
        public void WaitToSeeNoColumn(The the, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoColumn(the, That.Equals, locator, casing);
        public void WaitToSeeNoColumn(That that, string locator = null, Casing casing = Casing.Ignore) => WaitToSeeColumn(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing, false);
        public void WaitToSeeNoColumn(string locator = null, Casing casing = Casing.Ignore) => WaitToSeeNoColumn(That.Equals, locator, casing);

        #endregion

        #endregion

        #endregion

        #region [File]

        private void ExpectDownloadedFile(Limiter limiter, That that, string locator, Casing casing, bool expect = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = expect ? TargetActionType.Expect : TargetActionType.ExpectNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.File;
            Target.Value = value ?? string.Empty;

            RunCommand(this, () => WebDriverService.ExpectDownloadedFile(Target));
        }

        public void ExpectDownloadedFile(That that, string locator, Casing casing = Casing.Ignore) => ExpectDownloadedFile(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void ExpectDownloadedFile(string locator, Casing casing = Casing.Ignore) => ExpectDownloadedFile(That.Equals, locator, casing);

        private void ClearDownloadedFile(Limiter limiter, That that, string locator, Casing casing, bool expect = true, string value = null)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = expect ? TargetActionType.Expect : TargetActionType.ExpectNo;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.File;
            Target.Value = value ?? string.Empty;

            RunCommand(this, () => WebDriverService.ClearDownloadedFile(Target));
        }

        public void ClearDownloadedFile(That that, string locator, Casing casing = Casing.Ignore) => ClearDownloadedFile(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void ClearDownloadedFile(string locator, Casing casing = Casing.Ignore) => ClearDownloadedFile(That.Equals, locator, casing);

        #endregion

        #endregion
    }
}
