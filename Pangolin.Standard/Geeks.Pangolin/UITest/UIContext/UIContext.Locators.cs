using Geeks.Pangolin.Core.Helper.Targets;
using Geeks.Pangolin.Core.Helper;

namespace Geeks.Pangolin.Helper.UIContext
{
    public partial class UIContext
    {
        #region [Locator]

        #region [Set]

        #region [Any]

        private ICommandSet Set(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.Set;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Field;
            Target.Value = string.Empty;

            return this;
        }

        public ICommandSet Set(The the, That that, string locator = null, Casing casing = Casing.Ignore) => Set(the.ToLimiterType(), that, locator, casing);
        public ICommandSet Set(The the, string locator = null, Casing casing = Casing.Ignore) => Set(the, That.Equals, locator, casing);
        public ICommandSet Set(That that, string locator = null, Casing casing = Casing.Ignore) => Set(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommandSet Set(string locator = null, Casing casing = Casing.Ignore) => Set(That.Equals, locator, casing);


        public void ClearField(The the, That that, string locator = null, Casing casing = Casing.Ignore) => Set(the.ToLimiterType(), that, locator, casing).To(string.Empty);
        public void ClearField(The the, string locator = null, Casing casing = Casing.Ignore) => ClearField(the, That.Equals, locator, casing);
        public void ClearField(That that, string locator = null, Casing casing = Casing.Ignore) => Set(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing).To(string.Empty);
        public void ClearField(string locator = null, Casing casing = Casing.Ignore) => ClearField(That.Equals, locator, casing);

        #endregion

        #region [CSS]

        private ICommandSet SetCSS(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.Set;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.CSS;
            Target.Value = string.Empty;

            return this;
        }

        public ICommandSet SetCSS(The the, string locator) => SetCSS(the.ToLimiterType(), That.Equals, locator, Casing.Exact);
        public ICommandSet SetCSS(string locator) => SetCSS(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, That.Equals, locator, Casing.Exact);

        #endregion

        #region [XPath]

        private ICommandSet SetXPath(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.Set;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.XPath;
            Target.Value = string.Empty;

            return this;
        }

        public ICommandSet SetXPath(The the, string locator) => SetXPath(the.ToLimiterType(), That.Equals, locator, Casing.Exact);
        public ICommandSet SetXPath(string locator) => SetXPath(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, That.Equals, locator, Casing.Exact);

        #endregion

        #endregion

        #region [Click]

        #region [TargetType]

        #region [Any]
        private void Click(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.Click;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Clickable;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void Click(The the, What what, string locator, Casing casing = Casing.Ignore) => Click(the.ToLimiterType(), what.ToThat(), locator, casing);
        public void Click(The the, string locator, Casing casing = Casing.Ignore) => Click(the, What.Equals, locator, casing);
        public void Click(What what, string locator, Casing casing = Casing.Ignore) => Click(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, what.ToThat(), locator, casing);
        public void Click(string locator, Casing casing = Casing.Ignore) => Click(What.Equals, locator, casing);

        #endregion

        #region [Text]

        private void ClickText(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.Click;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Text;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void ClickText(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ClickText(the.ToLimiterType(), that, locator, casing);
        public void ClickText(The the, string locator = null, Casing casing = Casing.Ignore) => ClickText(the, That.Equals, locator, casing);
        public void ClickText(That that, string locator = null, Casing casing = Casing.Ignore) => ClickText(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void ClickText(string locator = null, Casing casing = Casing.Ignore) => ClickText(That.Equals, locator, casing);

        #endregion

        #region [CSS]

        private void ClickCSS(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.Click;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.CSS;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void ClickCSS(The the, string locator) => ClickCSS(the.ToLimiterType(), That.Equals, locator, Casing.Exact);
        public void ClickCSS(string locator) => ClickCSS(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, That.Equals, locator, Casing.Exact);

        #endregion

        #region [XPath]

        private void ClickXPath(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.Click;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.XPath;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void ClickXPath(The the, string locator) => ClickXPath(the.ToLimiterType(), That.Equals, locator, Casing.Exact);
        public void ClickXPath(string locator) => ClickXPath(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, That.Equals, locator, Casing.Exact);

        #endregion

        #region [Button]

        private void ClickButton(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.Click;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Button;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void ClickButton(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ClickButton(the.ToLimiterType(), that, locator, casing);
        public void ClickButton(The the, string locator = null, Casing casing = Casing.Ignore) => ClickButton(the, That.Equals, locator, casing);
        public void ClickButton(That that, string locator = null, Casing casing = Casing.Ignore) => ClickButton(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void ClickButton(string locator = null, Casing casing = Casing.Ignore) => ClickButton(That.Equals, locator, casing);

        #endregion

        #region [Link]

        private void ClickLink(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.Click;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Link;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void ClickLink(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ClickLink(the.ToLimiterType(), that, locator, casing);
        public void ClickLink(The the, string locator = null, Casing casing = Casing.Ignore) => ClickLink(the, That.Equals, locator, casing);
        public void ClickLink(That that, string locator = null, Casing casing = Casing.Ignore) => ClickLink(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void ClickLink(string locator = null, Casing casing = Casing.Ignore) => ClickLink(That.Equals, locator, casing);

        #endregion

        #region [Field]

        private void ClickField(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.Click;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Field;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void ClickField(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ClickField(the.ToLimiterType(), that, locator, casing);
        public void ClickField(The the, string locator = null, Casing casing = Casing.Ignore) => ClickField(the, That.Equals, locator, casing);
        public void ClickField(That that, string locator = null, Casing casing = Casing.Ignore) => ClickField(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void ClickField(string locator = null, Casing casing = Casing.Ignore) => ClickField(That.Equals, locator, casing);

        #endregion

        #region [Header]

        private void ClickHeader(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.Click;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Header;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void ClickHeader(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ClickHeader(the.ToLimiterType(), that, locator, casing);
        public void ClickHeader(The the, string locator = null, Casing casing = Casing.Ignore) => ClickHeader(the, That.Equals, locator, casing);
        public void ClickHeader(That that, string locator = null, Casing casing = Casing.Ignore) => ClickHeader(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void ClickHeader(string locator = null, Casing casing = Casing.Ignore) => ClickHeader(That.Equals, locator, casing);

        #endregion

        #region [Label]

        private void ClickLabel(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.Click;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Label;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void ClickLabel(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ClickLabel(the.ToLimiterType(), that, locator, casing);
        public void ClickLabel(The the, string locator = null, Casing casing = Casing.Ignore) => ClickLabel(the, That.Equals, locator, casing);
        public void ClickLabel(That that, string locator = null, Casing casing = Casing.Ignore) => ClickLabel(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void ClickLabel(string locator = null, Casing casing = Casing.Ignore) => ClickLabel(That.Equals, locator, casing);

        #endregion

        #region [Checkbox]

        private void ClickCheckbox(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.Click;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Checkbox;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void ClickCheckbox(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ClickCheckbox(the.ToLimiterType(), that, locator, casing);
        public void ClickCheckbox(The the, string locator = null, Casing casing = Casing.Ignore) => ClickCheckbox(the, That.Equals, locator, casing);
        public void ClickCheckbox(That that, string locator = null, Casing casing = Casing.Ignore) => ClickCheckbox(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void ClickCheckbox(string locator = null, Casing casing = Casing.Ignore) => ClickCheckbox(That.Equals, locator, casing);

        #endregion

        #region [Radiobox]

        private void ClickRadiobox(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.Click;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Radiobox;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void ClickRadiobox(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ClickRadiobox(the.ToLimiterType(), that, locator, casing);
        public void ClickRadiobox(The the, string locator = null, Casing casing = Casing.Ignore) => ClickRadiobox(the, That.Equals, locator, casing);
        public void ClickRadiobox(That that, string locator = null, Casing casing = Casing.Ignore) => ClickRadiobox(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void ClickRadiobox(string locator = null, Casing casing = Casing.Ignore) => ClickRadiobox(That.Equals, locator, casing);

        #endregion

        #region [Row]

        private void ClickRow(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.Click;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Row;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void ClickRow(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ClickRow(the.ToLimiterType(), that, locator, casing);
        public void ClickRow(The the, string locator = null, Casing casing = Casing.Ignore) => ClickRow(the, That.Equals, locator, casing);
        public void ClickRow(That that, string locator = null, Casing casing = Casing.Ignore) => ClickRow(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void ClickRow(string locator = null, Casing casing = Casing.Ignore) => ClickRow(That.Equals, locator, casing);

        private void ClickRow(Limiter limiter, int position)
        {
            Target.Text = position.ToString();
            Target.ActionType = TargetActionType.Click;
            Target.Limiter = limiter;
            Target.SearchType = SearchType.Position;
            Target.TargetType = TargetType.Row;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void ClickRow(The the, int position) => ClickRow(the.ToLimiterType(), position);
        public void ClickRow(int position) => ClickRow(Limiter.Everything, position);

        #endregion

        #region [Item]

        private void ClickItem(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.Click;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Item;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void ClickItem(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ClickItem(the.ToLimiterType(), that, locator, casing);
        public void ClickItem(The the, string locator = null, Casing casing = Casing.Ignore) => ClickItem(the, That.Equals, locator, casing);
        public void ClickItem(That that, string locator = null, Casing casing = Casing.Ignore) => ClickItem(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void ClickItem(string locator = null, Casing casing = Casing.Ignore) => ClickItem(That.Equals, locator, casing);


        #endregion

        #region [Value]

        private void ClickValue(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.Click;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Value;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void ClickValue(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ClickValue(the.ToLimiterType(), that, locator, casing);
        public void ClickValue(The the, string locator = null, Casing casing = Casing.Ignore) => ClickValue(the, That.Equals, locator, casing);
        public void ClickValue(That that, string locator = null, Casing casing = Casing.Ignore) => ClickValue(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void ClickValue(string locator = null, Casing casing = Casing.Ignore) => ClickValue(That.Equals, locator, casing);

        #endregion

        #region [File]

        private void ClickFile(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.Click;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.File;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void ClickFile(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ClickFile(the.ToLimiterType(), that, locator, casing);
        public void ClickFile(The the, string locator = null, Casing casing = Casing.Ignore) => ClickFile(the, That.Equals, locator, casing);
        public void ClickFile(That that, string locator = null, Casing casing = Casing.Ignore) => ClickFile(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void ClickFile(string locator = null, Casing casing = Casing.Ignore) => ClickFile(That.Equals, locator, casing);

        #endregion

        #region [Tick]

        private void ClickTick(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.Click;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Tick;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void ClickTick(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ClickTick(the.ToLimiterType(), that, locator, casing);
        public void ClickTick(The the, string locator = null, Casing casing = Casing.Ignore) => ClickTick(the, That.Equals, locator, casing);
        public void ClickTick(That that, string locator = null, Casing casing = Casing.Ignore) => ClickTick(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void ClickTick(string locator = null, Casing casing = Casing.Ignore) => ClickTick(That.Equals, locator, casing);

        #endregion

        #region [Table]

        private void ClickTable(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.Click;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Table;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void ClickTable(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ClickTable(the.ToLimiterType(), that, locator, casing);
        public void ClickTable(The the, string locator = null, Casing casing = Casing.Ignore) => ClickTable(the, That.Equals, locator, casing);
        public void ClickTable(That that, string locator = null, Casing casing = Casing.Ignore) => ClickTable(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void ClickTable(string locator = null, Casing casing = Casing.Ignore) => ClickTable(That.Equals, locator, casing);

        #endregion

        #region [Column]

        private void ClickColumn(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.Click;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Column;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void ClickColumn(The the, That that, string locator = null, Casing casing = Casing.Ignore) => ClickColumn(the.ToLimiterType(), that, locator, casing);
        public void ClickColumn(The the, string locator = null, Casing casing = Casing.Ignore) => ClickColumn(the, That.Equals, locator, casing);
        public void ClickColumn(That that, string locator = null, Casing casing = Casing.Ignore) => ClickColumn(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void ClickColumn(string locator = null, Casing casing = Casing.Ignore) => ClickColumn(That.Equals, locator, casing);

        #endregion

        #endregion

        #endregion

        #region [HoverOver]

        #region [TargetType]

        #region [Any]
        private void HoverOver(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.HoverOver;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Any;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void HoverOver(The the, What what, string locator, Casing casing = Casing.Ignore) => HoverOver(the.ToLimiterType(), what.ToThat(), locator, casing);
        public void HoverOver(The the, string locator, Casing casing = Casing.Ignore) => HoverOver(the, What.Equals, locator, casing);
        public void HoverOver(What what, string locator, Casing casing = Casing.Ignore) => HoverOver(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, what.ToThat(), locator, casing);
        public void HoverOver(string locator, Casing casing = Casing.Ignore) => HoverOver(What.Equals, locator, casing);

        #endregion

        #region [Text]

        private void HoverOverText(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.HoverOver;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Text;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void HoverOverText(The the, That that, string locator = null, Casing casing = Casing.Ignore) => HoverOverText(the.ToLimiterType(), that, locator, casing);
        public void HoverOverText(The the, string locator = null, Casing casing = Casing.Ignore) => HoverOverText(the, That.Equals, locator, casing);
        public void HoverOverText(That that, string locator = null, Casing casing = Casing.Ignore) => HoverOverText(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void HoverOverText(string locator = null, Casing casing = Casing.Ignore) => HoverOverText(That.Equals, locator, casing);

        #endregion

        #region [CSS]

        private void HoverOverCSS(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.HoverOver;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.CSS;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void HoverOverCSS(The the, string locator) => HoverOverCSS(the.ToLimiterType(), That.Equals, locator, Casing.Exact);
        public void HoverOverCSS(string locator) => HoverOverCSS(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, That.Equals, locator, Casing.Exact);

        #endregion

        #region [XPath]

        private void HoverOverXPath(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.HoverOver;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.XPath;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void HoverOverXPath(The the, string locator) => HoverOverXPath(the.ToLimiterType(), That.Equals, locator, Casing.Exact);
        public void HoverOverXPath(string locator) => HoverOverXPath(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, That.Equals, locator, Casing.Exact);

        #endregion

        #region [Button]

        private void HoverOverButton(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.HoverOver;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Button;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void HoverOverButton(The the, That that, string locator = null, Casing casing = Casing.Ignore) => HoverOverButton(the.ToLimiterType(), that, locator, casing);
        public void HoverOverButton(The the, string locator = null, Casing casing = Casing.Ignore) => HoverOverButton(the, That.Equals, locator, casing);
        public void HoverOverButton(That that, string locator = null, Casing casing = Casing.Ignore) => HoverOverButton(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void HoverOverButton(string locator = null, Casing casing = Casing.Ignore) => HoverOverButton(That.Equals, locator, casing);

        #endregion

        #region [Link]

        private void HoverOverLink(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.HoverOver;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Link;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void HoverOverLink(The the, That that, string locator = null, Casing casing = Casing.Ignore) => HoverOverLink(the.ToLimiterType(), that, locator, casing);
        public void HoverOverLink(The the, string locator = null, Casing casing = Casing.Ignore) => HoverOverLink(the, That.Equals, locator, casing);
        public void HoverOverLink(That that, string locator = null, Casing casing = Casing.Ignore) => HoverOverLink(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void HoverOverLink(string locator = null, Casing casing = Casing.Ignore) => HoverOverLink(That.Equals, locator, casing);

        #endregion

        #region [Field]

        private void HoverOverField(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.HoverOver;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Field;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void HoverOverField(The the, That that, string locator = null, Casing casing = Casing.Ignore) => HoverOverField(the.ToLimiterType(), that, locator, casing);
        public void HoverOverField(The the, string locator = null, Casing casing = Casing.Ignore) => HoverOverField(the, That.Equals, locator, casing);
        public void HoverOverField(That that, string locator = null, Casing casing = Casing.Ignore) => HoverOverField(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void HoverOverField(string locator = null, Casing casing = Casing.Ignore) => HoverOverField(That.Equals, locator, casing);

        #endregion

        #region [Header]

        private void HoverOverHeader(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.HoverOver;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Header;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void HoverOverHeader(The the, That that, string locator = null, Casing casing = Casing.Ignore) => HoverOverHeader(the.ToLimiterType(), that, locator, casing);
        public void HoverOverHeader(The the, string locator = null, Casing casing = Casing.Ignore) => HoverOverHeader(the, That.Equals, locator, casing);
        public void HoverOverHeader(That that, string locator = null, Casing casing = Casing.Ignore) => HoverOverHeader(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void HoverOverHeader(string locator = null, Casing casing = Casing.Ignore) => HoverOverHeader(That.Equals, locator, casing);

        #endregion

        #region [Label]

        private void HoverOverLabel(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.HoverOver;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Label;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void HoverOverLabel(The the, That that, string locator = null, Casing casing = Casing.Ignore) => HoverOverLabel(the.ToLimiterType(), that, locator, casing);
        public void HoverOverLabel(The the, string locator = null, Casing casing = Casing.Ignore) => HoverOverLabel(the, That.Equals, locator, casing);
        public void HoverOverLabel(That that, string locator = null, Casing casing = Casing.Ignore) => HoverOverLabel(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void HoverOverLabel(string locator = null, Casing casing = Casing.Ignore) => HoverOverLabel(That.Equals, locator, casing);

        #endregion

        #region [Checkbox]

        private void HoverOverCheckbox(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.HoverOver;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Checkbox;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void HoverOverCheckbox(The the, That that, string locator = null, Casing casing = Casing.Ignore) => HoverOverCheckbox(the.ToLimiterType(), that, locator, casing);
        public void HoverOverCheckbox(The the, string locator = null, Casing casing = Casing.Ignore) => HoverOverCheckbox(the, That.Equals, locator, casing);
        public void HoverOverCheckbox(That that, string locator = null, Casing casing = Casing.Ignore) => HoverOverCheckbox(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void HoverOverCheckbox(string locator = null, Casing casing = Casing.Ignore) => HoverOverCheckbox(That.Equals, locator, casing);

        #endregion

        #region [Radiobox]

        private void HoverOverRadiobox(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.HoverOver;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Radiobox;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void HoverOverRadiobox(The the, That that, string locator = null, Casing casing = Casing.Ignore) => HoverOverRadiobox(the.ToLimiterType(), that, locator, casing);
        public void HoverOverRadiobox(The the, string locator = null, Casing casing = Casing.Ignore) => HoverOverRadiobox(the, That.Equals, locator, casing);
        public void HoverOverRadiobox(That that, string locator = null, Casing casing = Casing.Ignore) => HoverOverRadiobox(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void HoverOverRadiobox(string locator = null, Casing casing = Casing.Ignore) => HoverOverRadiobox(That.Equals, locator, casing);

        #endregion

        #region [Row]

        private void HoverOverRow(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.HoverOver;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Row;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void HoverOverRow(The the, That that, string locator = null, Casing casing = Casing.Ignore) => HoverOverRow(the.ToLimiterType(), that, locator, casing);
        public void HoverOverRow(The the, string locator = null, Casing casing = Casing.Ignore) => HoverOverRow(the, That.Equals, locator, casing);
        public void HoverOverRow(That that, string locator = null, Casing casing = Casing.Ignore) => HoverOverRow(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void HoverOverRow(string locator = null, Casing casing = Casing.Ignore) => HoverOverRow(That.Equals, locator, casing);

        private void HoverOverRow(Limiter limiter, int position)
        {
            Target.Text = position.ToString();
            Target.ActionType = TargetActionType.HoverOver;
            Target.Limiter = limiter;
            Target.SearchType = SearchType.Position;
            Target.TargetType = TargetType.Row;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void HoverOverRow(The the, int position) => HoverOverRow(the.ToLimiterType(), position);
        public void HoverOverRow(int position) => HoverOverRow(Limiter.Everything, position);

        #endregion

        #region [Item]

        private void HoverOverItem(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.HoverOver;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Item;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void HoverOverItem(The the, That that, string locator = null, Casing casing = Casing.Ignore) => HoverOverItem(the.ToLimiterType(), that, locator, casing);
        public void HoverOverItem(The the, string locator = null, Casing casing = Casing.Ignore) => HoverOverItem(the, That.Equals, locator, casing);
        public void HoverOverItem(That that, string locator = null, Casing casing = Casing.Ignore) => HoverOverItem(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void HoverOverItem(string locator = null, Casing casing = Casing.Ignore) => HoverOverItem(That.Equals, locator, casing);


        #endregion

        #region [Value]

        private void HoverOverValue(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.HoverOver;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Value;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void HoverOverValue(The the, That that, string locator = null, Casing casing = Casing.Ignore) => HoverOverValue(the.ToLimiterType(), that, locator, casing);
        public void HoverOverValue(The the, string locator = null, Casing casing = Casing.Ignore) => HoverOverValue(the, That.Equals, locator, casing);
        public void HoverOverValue(That that, string locator = null, Casing casing = Casing.Ignore) => HoverOverValue(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void HoverOverValue(string locator = null, Casing casing = Casing.Ignore) => HoverOverValue(That.Equals, locator, casing);

        #endregion

        #region [File]

        private void HoverOverFile(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.HoverOver;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.File;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void HoverOverFile(The the, That that, string locator = null, Casing casing = Casing.Ignore) => HoverOverFile(the.ToLimiterType(), that, locator, casing);
        public void HoverOverFile(The the, string locator = null, Casing casing = Casing.Ignore) => HoverOverFile(the, That.Equals, locator, casing);
        public void HoverOverFile(That that, string locator = null, Casing casing = Casing.Ignore) => HoverOverFile(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void HoverOverFile(string locator = null, Casing casing = Casing.Ignore) => HoverOverFile(That.Equals, locator, casing);

        #endregion

        #region [Tick]

        private void HoverOverTick(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.HoverOver;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Tick;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void HoverOverTick(The the, That that, string locator = null, Casing casing = Casing.Ignore) => HoverOverTick(the.ToLimiterType(), that, locator, casing);
        public void HoverOverTick(The the, string locator = null, Casing casing = Casing.Ignore) => HoverOverTick(the, That.Equals, locator, casing);
        public void HoverOverTick(That that, string locator = null, Casing casing = Casing.Ignore) => HoverOverTick(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void HoverOverTick(string locator = null, Casing casing = Casing.Ignore) => HoverOverTick(That.Equals, locator, casing);

        #endregion

        #region [Table]

        private void HoverOverTable(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.HoverOver;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Table;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void HoverOverTable(The the, That that, string locator = null, Casing casing = Casing.Ignore) => HoverOverTable(the.ToLimiterType(), that, locator, casing);
        public void HoverOverTable(The the, string locator = null, Casing casing = Casing.Ignore) => HoverOverTable(the, That.Equals, locator, casing);
        public void HoverOverTable(That that, string locator = null, Casing casing = Casing.Ignore) => HoverOverTable(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void HoverOverTable(string locator = null, Casing casing = Casing.Ignore) => HoverOverTable(That.Equals, locator, casing);

        #endregion

        #region [Column]

        private void HoverOverColumn(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.HoverOver;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Column;
            Target.Value = string.Empty;

            RunTargetCommand();
        }

        public void HoverOverColumn(The the, That that, string locator = null, Casing casing = Casing.Ignore) => HoverOverColumn(the.ToLimiterType(), that, locator, casing);
        public void HoverOverColumn(The the, string locator = null, Casing casing = Casing.Ignore) => HoverOverColumn(the, That.Equals, locator, casing);
        public void HoverOverColumn(That that, string locator = null, Casing casing = Casing.Ignore) => HoverOverColumn(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void HoverOverColumn(string locator = null, Casing casing = Casing.Ignore) => HoverOverColumn(That.Equals, locator, casing);

        #endregion

        #endregion

        #endregion

        #region [Check]

        private void Check(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.Set;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Field;
            Target.Value = "checked";

            RunTargetCommand();
        }

        public void Check(The the, That that, string locator = null, Casing casing = Casing.Ignore) => Check(the.ToLimiterType(), that, locator, casing);
        public void Check(The the, string locator = null, Casing casing = Casing.Ignore) => Check(the, That.Equals, locator, casing);
        public void Check(That that, string locator = null, Casing casing = Casing.Ignore) => Check(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void Check(string locator = null, Casing casing = Casing.Ignore) => Check(That.Equals, locator, casing);


        #endregion

        #region [CSS]

        private void CheckCSS(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.Set;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.CSS;
            Target.Value = "checked";

            RunTargetCommand();
        }

        public void CheckCSS(The the, string locator) => CheckCSS(the.ToLimiterType(), That.Equals, locator, Casing.Exact);
        public void CheckCSS(string locator) => CheckCSS(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, That.Equals, locator, Casing.Exact);

        #endregion

        #region [XPath]

        private void CheckXPath(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.Set;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.XPath;
            Target.Value = "checked";

            RunTargetCommand();
        }

        public void CheckXPath(The the, string locator) => CheckXPath(the.ToLimiterType(), That.Equals, locator, Casing.Exact);
        public void CheckXPath(string locator) => CheckXPath(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, That.Equals, locator, Casing.Exact);

        #endregion

        #region [UnCheck]

        private void UnCheck(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.Set;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Field;
            Target.Value = "unUnChecked";

            RunTargetCommand();
        }

        public void UnCheck(The the, That that, string locator = null, Casing casing = Casing.Ignore) => UnCheck(the.ToLimiterType(), that, locator, casing);
        public void UnCheck(The the, string locator = null, Casing casing = Casing.Ignore) => UnCheck(the, That.Equals, locator, casing);
        public void UnCheck(That that, string locator = null, Casing casing = Casing.Ignore) => UnCheck(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void UnCheck(string locator = null, Casing casing = Casing.Ignore) => UnCheck(That.Equals, locator, casing);

        #endregion

        #region [CSS]

        private void UnCheckCSS(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.Set;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.CSS;
            Target.Value = "unUnChecked";

            RunTargetCommand();
        }

        public void UnCheckCSS(The the, string locator) => UnCheckCSS(the.ToLimiterType(), That.Equals, locator, Casing.Exact);
        public void UnCheckCSS(string locator) => UnCheckCSS(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, That.Equals, locator, Casing.Exact);

        #endregion

        #region [XPath]

        private void UnCheckXPath(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.Set;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.XPath;
            Target.Value = "unUnChecked";

            RunTargetCommand();
        }

        public void UnCheckXPath(The the, string locator) => UnCheckXPath(the.ToLimiterType(), That.Equals, locator, Casing.Exact);
        public void UnCheckXPath(string locator) => UnCheckXPath(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, That.Equals, locator, Casing.Exact);

        #endregion

        #region [Choose]

        private void Choose(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.Set;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.Field;
            Target.Value = "selected";

            RunTargetCommand();
        }

        public void Choose(The the, That that, string locator = null, Casing casing = Casing.Ignore) => Choose(the.ToLimiterType(), that, locator, casing);
        public void Choose(The the, string locator = null, Casing casing = Casing.Ignore) => Choose(the, That.Equals, locator, casing);
        public void Choose(That that, string locator = null, Casing casing = Casing.Ignore) => Choose(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public void Choose(string locator = null, Casing casing = Casing.Ignore) => Choose(That.Equals, locator, casing);

        #region [XPath]

        private void ChooseXPath(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.Set;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.XPath;
            Target.Value = "selected";

            RunTargetCommand();
        }

        public void ChooseXPath(The the, string locator) => ChooseXPath(the.ToLimiterType(), That.Equals, locator, Casing.Exact);
        public void ChooseXPath(string locator) => ChooseXPath(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, That.Equals, locator, Casing.Exact);

        #endregion

        #endregion

        #endregion

        #region [Set]

        public void To(string value)
        {
            To(values: value);
        }
        public void To(params string[] values)
        {
            Target.Value = string.Join("\n", values);

            RunTargetCommand();
        }

        #endregion
    }
}
