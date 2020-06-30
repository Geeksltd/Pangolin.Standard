using System;
using Geeks.Pangolin.Core.Helper.Targets;
using Geeks.Pangolin.Helper.Command;
using Geeks.Pangolin.Service.DriverService;
using Geeks.Pangolin.Core.Helper;
using Geeks.Pangolin.Helper.Execution;

namespace Geeks.Pangolin.Helper.UIContext
{
    public partial class UIContext : CommandBase, ICommand
    {
        private SeleniumWebDriverService _WebDriverService;
        public SeleniumWebDriverService WebDriverService 
        { 
            get=>_WebDriverService?? (_WebDriverService=SetupWebDriverService(autoDispose:true)); 
            protected set=> _WebDriverService=value; 
        }

        protected static SeleniumWebDriverService SetupWebDriverService(Browser? browser = null, string baseUrl = null, bool autoDispose=false)
        {
            browser = browser == null ? UISetting.Instance.Browser : browser.Value;
            baseUrl = string.IsNullOrWhiteSpace(baseUrl) ? UISetting.Instance.AppBaseUrl : baseUrl.GetWellFormedUrl();
            var seleniumWebDriverService = new SeleniumWebDriverService(browser, baseUrl,autoDispose);
            seleniumWebDriverService.Initialize();

            return seleniumWebDriverService;
        }

        private TestRunner _TestRunner;
        public TestRunner TestRunner 
        {
            get
            {
                
                var testMethodName = TestRunner.GetUnitTestName();
                var uiTest = this as UITest;
                if (_TestRunner != null && (uiTest.TearingDownTest || _TestRunner?.CurrentTestName != testMethodName))
                {
                    if (!_TestRunner.Disposing)_TestRunner.Dispose();
                    _TestRunner = null;
                }

                if (_TestRunner == null && !uiTest.Disposing && !uiTest.TearingDownTest) 
                    _TestRunner = new TestRunner(uiTest, testMethodName); 

                return _TestRunner;
            }
            set => _TestRunner = value;
        }
        #region [Property]

        public ActionTarget Target { get; set; } = new ActionTarget();
        #endregion

        #region [Override]

        protected override void Reset() => Target = new ActionTarget();

        #endregion

        #region [Private Method]

        private void RunTargetCommand() => RunCommand(this, () => WebDriverService.RunTestCase(this, Target));

        #endregion

        #region [Public Command]

        #region [TargetType]

        #region [Any]

        #region [TargetPosition]

        #region [At]

        private ICommand At(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Any,
                Limiter = limiter,
                TargetPosition = TargetPosition.At,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand At(The the, What what, string locator, Casing casing = Casing.Ignore) => At(the.ToLimiterType(), what.ToThat(), locator, casing);
        public ICommand At(The the, string locator, Casing casing = Casing.Ignore) => At(the, What.Equals, locator, casing);
        public ICommand At(What what, string locator, Casing casing = Casing.Ignore) => At(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, what.ToThat(), locator, casing);
        public ICommand At(string locator, Casing casing = Casing.Ignore) => At(What.Equals, locator, casing);

        #endregion

        #region [Above]

        private ICommand Above(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Any,
                Limiter = limiter,
                TargetPosition = TargetPosition.Above,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand Above(The the, What what, string locator, Casing casing = Casing.Ignore) => Above(the.ToLimiterType(), what.ToThat(), locator, casing);
        public ICommand Above(The the, string locator, Casing casing = Casing.Ignore) => Above(the, What.Equals, locator, casing);
        public ICommand Above(What what, string locator, Casing casing = Casing.Ignore) => Above(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, what.ToThat(), locator, casing);
        public ICommand Above(string locator, Casing casing = Casing.Ignore) => Above(What.Equals, locator, casing);

        #endregion

        #region [Below]

        private ICommand Below(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Any,
                Limiter = limiter,
                TargetPosition = TargetPosition.Below,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand Below(The the, What what, string locator, Casing casing = Casing.Ignore) => Below(the.ToLimiterType(), what.ToThat(), locator, casing);
        public ICommand Below(The the, string locator, Casing casing = Casing.Ignore) => Below(the, What.Equals, locator, casing);
        public ICommand Below(What what, string locator, Casing casing = Casing.Ignore) => Below(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, what.ToThat(), locator, casing);
        public ICommand Below(string locator, Casing casing = Casing.Ignore) => Below(What.Equals, locator, casing);

        #endregion

        #region [LeftOf]

        private ICommand LeftOf(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Any,
                Limiter = limiter,
                TargetPosition = TargetPosition.LeftOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand LeftOf(The the, What what, string locator, Casing casing = Casing.Ignore) => LeftOf(the.ToLimiterType(), what.ToThat(), locator, casing);
        public ICommand LeftOf(The the, string locator, Casing casing = Casing.Ignore) => LeftOf(the, What.Equals, locator, casing);
        public ICommand LeftOf(What what, string locator, Casing casing = Casing.Ignore) => LeftOf(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, what.ToThat(), locator, casing);
        public ICommand LeftOf(string locator, Casing casing = Casing.Ignore) => LeftOf(What.Equals, locator, casing);

        #endregion

        #region [RightOf]

        private ICommand RightOf(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Any,
                Limiter = limiter,
                TargetPosition = TargetPosition.RightOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand RightOf(The the, What what, string locator, Casing casing = Casing.Ignore) => RightOf(the.ToLimiterType(), what.ToThat(), locator, casing);
        public ICommand RightOf(The the, string locator, Casing casing = Casing.Ignore) => RightOf(the, What.Equals, locator, casing);
        public ICommand RightOf(What what, string locator, Casing casing = Casing.Ignore) => RightOf(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, what.ToThat(), locator, casing);
        public ICommand RightOf(string locator, Casing casing = Casing.Ignore) => RightOf(What.Equals, locator, casing);

        #endregion

        #region [Near]

        private ICommand Near(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Any,
                Limiter = limiter,
                TargetPosition = TargetPosition.Near,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand Near(The the, What what, string locator, Casing casing = Casing.Ignore) => Near(the.ToLimiterType(), what.ToThat(), locator, casing);
        public ICommand Near(The the, string locator, Casing casing = Casing.Ignore) => Near(the, What.Equals, locator, casing);
        public ICommand Near(What what, string locator, Casing casing = Casing.Ignore) => Near(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, what.ToThat(), locator, casing);
        public ICommand Near(string locator, Casing casing = Casing.Ignore) => Near(What.Equals, locator, casing);

        #endregion

        #endregion

        #endregion

        #region [Text]

        #region [TargetPosition]

        #region [At]

        private ICommand AtText(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Text,
                Limiter = limiter,
                TargetPosition = TargetPosition.At,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand AtText(The the, That that, string locator = null, Casing casing = Casing.Ignore) => AtText(the.ToLimiterType(), that, locator, casing);
        public ICommand AtText(The the, string locator = null, Casing casing = Casing.Ignore) => AtText(the, That.Equals, locator, casing);
        public ICommand AtText(That that, string locator = null, Casing casing = Casing.Ignore) => AtText(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand AtText(string locator = null, Casing casing = Casing.Ignore) => AtText(That.Equals, locator, casing);

        #endregion

        #region [Above]

        private ICommand AboveText(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Text,
                Limiter = limiter,
                TargetPosition = TargetPosition.Above,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand AboveText(The the, That that, string locator = null, Casing casing = Casing.Ignore) => AboveText(the.ToLimiterType(), that, locator, casing);
        public ICommand AboveText(The the, string locator = null, Casing casing = Casing.Ignore) => AboveText(the, That.Equals, locator, casing);
        public ICommand AboveText(That that, string locator = null, Casing casing = Casing.Ignore) => AboveText(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand AboveText(string locator = null, Casing casing = Casing.Ignore) => AboveText(That.Equals, locator, casing);

        #endregion

        #region [Below]

        private ICommand BelowText(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Text,
                Limiter = limiter,
                TargetPosition = TargetPosition.Below,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand BelowText(The the, That that, string locator = null, Casing casing = Casing.Ignore) => BelowText(the.ToLimiterType(), that, locator, casing);
        public ICommand BelowText(The the, string locator = null, Casing casing = Casing.Ignore) => BelowText(the, That.Equals, locator, casing);
        public ICommand BelowText(That that, string locator = null, Casing casing = Casing.Ignore) => BelowText(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand BelowText(string locator = null, Casing casing = Casing.Ignore) => BelowText(That.Equals, locator, casing);

        #endregion

        #region [LeftOf]

        private ICommand LeftOfText(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Text,
                Limiter = limiter,
                TargetPosition = TargetPosition.LeftOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand LeftOfText(The the, That that, string locator = null, Casing casing = Casing.Ignore) => LeftOfText(the.ToLimiterType(), that, locator, casing);
        public ICommand LeftOfText(The the, string locator = null, Casing casing = Casing.Ignore) => LeftOfText(the, That.Equals, locator, casing);
        public ICommand LeftOfText(That that, string locator = null, Casing casing = Casing.Ignore) => LeftOfText(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand LeftOfText(string locator = null, Casing casing = Casing.Ignore) => LeftOfText(That.Equals, locator, casing);

        #endregion

        #region [RightOf]

        private ICommand RightOfText(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Text,
                Limiter = limiter,
                TargetPosition = TargetPosition.RightOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand RightOfText(The the, That that, string locator = null, Casing casing = Casing.Ignore) => RightOfText(the.ToLimiterType(), that, locator, casing);
        public ICommand RightOfText(The the, string locator = null, Casing casing = Casing.Ignore) => RightOfText(the, That.Equals, locator, casing);
        public ICommand RightOfText(That that, string locator = null, Casing casing = Casing.Ignore) => RightOfText(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand RightOfText(string locator = null, Casing casing = Casing.Ignore) => RightOfText(That.Equals, locator, casing);

        #endregion

        #region [Near]

        private ICommand NearText(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Text,
                Limiter = limiter,
                TargetPosition = TargetPosition.Near,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand NearText(The the, That that, string locator = null, Casing casing = Casing.Ignore) => NearText(the.ToLimiterType(), that, locator, casing);
        public ICommand NearText(The the, string locator = null, Casing casing = Casing.Ignore) => NearText(the, That.Equals, locator, casing);
        public ICommand NearText(That that, string locator = null, Casing casing = Casing.Ignore) => NearText(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand NearText(string locator = null, Casing casing = Casing.Ignore) => NearText(That.Equals, locator, casing);

        #endregion

        #endregion

        #endregion

        #region [CSS]

        #region [TargetPosition]

        #region [At]

        private ICommand AtCSS(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.CSS,
                Limiter = limiter,
                TargetPosition = TargetPosition.At,
                SearchType = that.ToSearchType(casing)
            });

            return this;
        }
        public ICommand AtCSS(The the, string locator) => AtCSS(the.ToLimiterType(), That.Equals, locator, Casing.Exact);
        public ICommand AtCSS(string locator) => AtCSS(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, That.Equals, locator, Casing.Exact);

        #endregion

        #region [Above]

        private ICommand AboveCSS(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.CSS,
                Limiter = limiter,
                TargetPosition = TargetPosition.Above,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand AboveCSS(The the, string locator) => AboveCSS(the.ToLimiterType(), That.Equals, locator, Casing.Exact);
        public ICommand AboveCSS(string locator) => AboveCSS(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, That.Equals, locator, Casing.Exact);

        #endregion

        #region [Below]

        private ICommand BelowCSS(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.CSS,
                Limiter = limiter,
                TargetPosition = TargetPosition.Below,
                SearchType = that.ToSearchType(casing)
            });

            return this;
        }

        public ICommand BelowCSS(The the, string locator) => BelowCSS(the.ToLimiterType(), That.Equals, locator, Casing.Exact);
        public ICommand BelowCSS(string locator) => BelowCSS(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, That.Equals, locator, Casing.Exact);

        #endregion

        #region [LeftOf]

        private ICommand LeftOfCSS(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.CSS,
                Limiter = limiter,
                TargetPosition = TargetPosition.LeftOf,
                SearchType = that.ToSearchType(casing)
            });

            return this;
        }

        public ICommand LeftOfCSS(The the, string locator) => LeftOfCSS(the.ToLimiterType(), That.Equals, locator, Casing.Exact);
        public ICommand LeftOfCSS(string locator) => LeftOfCSS(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, That.Equals, locator, Casing.Exact);

        #endregion

        #region [RightOf]

        private ICommand RightOfCSS(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.CSS,
                Limiter = limiter,
                TargetPosition = TargetPosition.RightOf,
                SearchType = that.ToSearchType(casing)
            });

            return this;
        }

        public ICommand RightOfCSS(The the, string locator) => RightOfCSS(the.ToLimiterType(), That.Equals, locator, Casing.Exact);
        public ICommand RightOfCSS(string locator) => RightOfCSS(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, That.Equals, locator, Casing.Exact);

        #endregion

        #region [Near]

        private ICommand NearCSS(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.CSS,
                Limiter = limiter,
                TargetPosition = TargetPosition.Near,
                SearchType = that.ToSearchType(casing)
            });

            return this;
        }

        public ICommand NearCSS(The the, string locator) => NearCSS(the.ToLimiterType(), That.Equals, locator, Casing.Exact);
        public ICommand NearCSS(string locator) => NearCSS(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, That.Equals, locator, Casing.Exact);

        #endregion

        #endregion

        #endregion

        #region [XPath]

        #region [TargetPosition]

        #region [At]

        private ICommand AtXPath(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.XPath,
                Limiter = limiter,
                TargetPosition = TargetPosition.At,
                SearchType = that.ToSearchType(casing)
            });

            return this;
        }
        public ICommand AtXPath(The the, string locator) => AtXPath(the.ToLimiterType(), That.Equals, locator, Casing.Exact);
        public ICommand AtXPath(string locator) => AtXPath(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, That.Equals, locator, Casing.Exact);

        #endregion

        #region [Above]

        private ICommand AboveXPath(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.XPath,
                Limiter = limiter,
                TargetPosition = TargetPosition.Above,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand AboveXPath(The the, string locator) => AboveXPath(the.ToLimiterType(), That.Equals, locator, Casing.Exact);
        public ICommand AboveXPath(string locator) => AboveXPath(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, That.Equals, locator, Casing.Exact);

        #endregion

        #region [Below]

        private ICommand BelowXPath(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.XPath,
                Limiter = limiter,
                TargetPosition = TargetPosition.Below,
                SearchType = that.ToSearchType(casing)
            });

            return this;
        }

        public ICommand BelowXPath(The the, string locator) => BelowXPath(the.ToLimiterType(), That.Equals, locator, Casing.Exact);
        public ICommand BelowXPath(string locator) => BelowXPath(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, That.Equals, locator, Casing.Exact);

        #endregion

        #region [LeftOf]

        private ICommand LeftOfXPath(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.XPath,
                Limiter = limiter,
                TargetPosition = TargetPosition.LeftOf,
                SearchType = that.ToSearchType(casing)
            });

            return this;
        }

        public ICommand LeftOfXPath(The the, string locator) => LeftOfXPath(the.ToLimiterType(), That.Equals, locator, Casing.Exact);
        public ICommand LeftOfXPath(string locator) => LeftOfXPath(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, That.Equals, locator, Casing.Exact);

        #endregion

        #region [RightOf]

        private ICommand RightOfXPath(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.XPath,
                Limiter = limiter,
                TargetPosition = TargetPosition.RightOf,
                SearchType = that.ToSearchType(casing)
            });

            return this;
        }

        public ICommand RightOfXPath(The the, string locator) => RightOfXPath(the.ToLimiterType(), That.Equals, locator, Casing.Exact);
        public ICommand RightOfXPath(string locator) => RightOfXPath(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, That.Equals, locator, Casing.Exact);

        #endregion

        #region [Near]

        private ICommand NearXPath(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.XPath,
                Limiter = limiter,
                TargetPosition = TargetPosition.Near,
                SearchType = that.ToSearchType(casing)
            });

            return this;
        }

        public ICommand NearXPath(The the, string locator) => NearXPath(the.ToLimiterType(), That.Equals, locator, Casing.Exact);
        public ICommand NearXPath(string locator) => NearXPath(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, That.Equals, locator, Casing.Exact);

        #endregion

        #endregion

        #endregion

        #region [Button]

        #region [TargetPosition]

        #region [Above]

        private ICommand AboveButton(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Button,
                Limiter = limiter,
                TargetPosition = TargetPosition.Above,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand AboveButton(The the, That that, string locator = null, Casing casing = Casing.Ignore) => AboveButton(the.ToLimiterType(), that, locator, casing);
        public ICommand AboveButton(The the, string locator = null, Casing casing = Casing.Ignore) => AboveButton(the, That.Equals, locator, casing);
        public ICommand AboveButton(That that, string locator = null, Casing casing = Casing.Ignore) => AboveButton(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand AboveButton(string locator = null, Casing casing = Casing.Ignore) => AboveButton(That.Equals, locator, casing);

        #endregion

        #region [Below]

        private ICommand BelowButton(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Button,
                Limiter = limiter,
                TargetPosition = TargetPosition.Below,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand BelowButton(The the, That that, string locator = null, Casing casing = Casing.Ignore) => BelowButton(the.ToLimiterType(), that, locator, casing);
        public ICommand BelowButton(The the, string locator = null, Casing casing = Casing.Ignore) => BelowButton(the, That.Equals, locator, casing);
        public ICommand BelowButton(That that, string locator = null, Casing casing = Casing.Ignore) => BelowButton(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand BelowButton(string locator = null, Casing casing = Casing.Ignore) => BelowButton(That.Equals, locator, casing);

        #endregion

        #region [LeftOf]

        private ICommand LeftOfButton(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Button,
                Limiter = limiter,
                TargetPosition = TargetPosition.LeftOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand LeftOfButton(The the, That that, string locator = null, Casing casing = Casing.Ignore) => LeftOfButton(the.ToLimiterType(), that, locator, casing);
        public ICommand LeftOfButton(The the, string locator = null, Casing casing = Casing.Ignore) => LeftOfButton(the, That.Equals, locator, casing);
        public ICommand LeftOfButton(That that, string locator = null, Casing casing = Casing.Ignore) => LeftOfButton(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand LeftOfButton(string locator = null, Casing casing = Casing.Ignore) => LeftOfButton(That.Equals, locator, casing);

        #endregion

        #region [RightOf]

        private ICommand RightOfButton(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Button,
                Limiter = limiter,
                TargetPosition = TargetPosition.RightOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand RightOfButton(The the, That that, string locator = null, Casing casing = Casing.Ignore) => RightOfButton(the.ToLimiterType(), that, locator, casing);
        public ICommand RightOfButton(The the, string locator = null, Casing casing = Casing.Ignore) => RightOfButton(the, That.Equals, locator, casing);
        public ICommand RightOfButton(That that, string locator = null, Casing casing = Casing.Ignore) => RightOfButton(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand RightOfButton(string locator = null, Casing casing = Casing.Ignore) => RightOfButton(That.Equals, locator, casing);

        #endregion

        #region [Near]

        private ICommand NearButton(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Button,
                Limiter = limiter,
                TargetPosition = TargetPosition.Near,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand NearButton(The the, That that, string locator = null, Casing casing = Casing.Ignore) => NearButton(the.ToLimiterType(), that, locator, casing);
        public ICommand NearButton(The the, string locator = null, Casing casing = Casing.Ignore) => NearButton(the, That.Equals, locator, casing);
        public ICommand NearButton(That that, string locator = null, Casing casing = Casing.Ignore) => NearButton(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand NearButton(string locator = null, Casing casing = Casing.Ignore) => NearButton(That.Equals, locator, casing);

        #endregion

        #endregion

        #endregion

        #region [Link]

        #region [TargetPosition]

        #region [Above]

        private ICommand AboveLink(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Link,
                Limiter = limiter,
                TargetPosition = TargetPosition.Above,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand AboveLink(The the, That that, string locator = null, Casing casing = Casing.Ignore) => AboveLink(the.ToLimiterType(), that, locator, casing);
        public ICommand AboveLink(The the, string locator = null, Casing casing = Casing.Ignore) => AboveLink(the, That.Equals, locator, casing);
        public ICommand AboveLink(That that, string locator = null, Casing casing = Casing.Ignore) => AboveLink(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand AboveLink(string locator = null, Casing casing = Casing.Ignore) => AboveLink(That.Equals, locator, casing);

        #endregion

        #region [Below]

        private ICommand BelowLink(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Link,
                Limiter = limiter,
                TargetPosition = TargetPosition.Below,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand BelowLink(The the, That that, string locator = null, Casing casing = Casing.Ignore) => BelowLink(the.ToLimiterType(), that, locator, casing);
        public ICommand BelowLink(The the, string locator = null, Casing casing = Casing.Ignore) => BelowLink(the, That.Equals, locator, casing);
        public ICommand BelowLink(That that, string locator = null, Casing casing = Casing.Ignore) => BelowLink(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand BelowLink(string locator = null, Casing casing = Casing.Ignore) => BelowLink(That.Equals, locator, casing);

        #endregion

        #region [LeftOf]

        private ICommand LeftOfLink(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Link,
                Limiter = limiter,
                TargetPosition = TargetPosition.LeftOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand LeftOfLink(The the, That that, string locator = null, Casing casing = Casing.Ignore) => LeftOfLink(the.ToLimiterType(), that, locator, casing);
        public ICommand LeftOfLink(The the, string locator = null, Casing casing = Casing.Ignore) => LeftOfLink(the, That.Equals, locator, casing);
        public ICommand LeftOfLink(That that, string locator = null, Casing casing = Casing.Ignore) => LeftOfLink(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand LeftOfLink(string locator = null, Casing casing = Casing.Ignore) => LeftOfLink(That.Equals, locator, casing);

        #endregion

        #region [RightOf]

        private ICommand RightOfLink(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Link,
                Limiter = limiter,
                TargetPosition = TargetPosition.RightOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand RightOfLink(The the, That that, string locator = null, Casing casing = Casing.Ignore) => RightOfLink(the.ToLimiterType(), that, locator, casing);
        public ICommand RightOfLink(The the, string locator = null, Casing casing = Casing.Ignore) => RightOfLink(the, That.Equals, locator, casing);
        public ICommand RightOfLink(That that, string locator = null, Casing casing = Casing.Ignore) => RightOfLink(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand RightOfLink(string locator = null, Casing casing = Casing.Ignore) => RightOfLink(That.Equals, locator, casing);

        #endregion

        #region [Near]

        private ICommand NearLink(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Link,
                Limiter = limiter,
                TargetPosition = TargetPosition.Near,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand NearLink(The the, That that, string locator = null, Casing casing = Casing.Ignore) => NearLink(the.ToLimiterType(), that, locator, casing);
        public ICommand NearLink(The the, string locator = null, Casing casing = Casing.Ignore) => NearLink(the, That.Equals, locator, casing);
        public ICommand NearLink(That that, string locator = null, Casing casing = Casing.Ignore) => NearLink(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand NearLink(string locator = null, Casing casing = Casing.Ignore) => NearLink(That.Equals, locator, casing);

        #endregion

        #endregion

        #endregion

        #region [Field]

        #region [TargetPosition]

        #region [At]

        private ICommand AtField(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Field,
                Limiter = limiter,
                TargetPosition = TargetPosition.At,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand AtField(The the, That that, string locator = null, Casing casing = Casing.Ignore) => AtField(the.ToLimiterType(), that, locator, casing);
        public ICommand AtField(The the, string locator = null, Casing casing = Casing.Ignore) => AtField(the, That.Equals, locator, casing);
        public ICommand AtField(That that, string locator = null, Casing casing = Casing.Ignore) => AtField(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand AtField(string locator = null, Casing casing = Casing.Ignore) => AtField(That.Equals, locator, casing);

        #endregion

        #region [Above]

        private ICommand AboveField(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Field,
                Limiter = limiter,
                TargetPosition = TargetPosition.Above,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand AboveField(The the, That that, string locator = null, Casing casing = Casing.Ignore) => AboveField(the.ToLimiterType(), that, locator, casing);
        public ICommand AboveField(The the, string locator = null, Casing casing = Casing.Ignore) => AboveField(the, That.Equals, locator, casing);
        public ICommand AboveField(That that, string locator = null, Casing casing = Casing.Ignore) => AboveField(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand AboveField(string locator = null, Casing casing = Casing.Ignore) => AboveField(That.Equals, locator, casing);

        #endregion

        #region [Below]

        private ICommand BelowField(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Field,
                Limiter = limiter,
                TargetPosition = TargetPosition.Below,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand BelowField(The the, That that, string locator = null, Casing casing = Casing.Ignore) => BelowField(the.ToLimiterType(), that, locator, casing);
        public ICommand BelowField(The the, string locator = null, Casing casing = Casing.Ignore) => BelowField(the, That.Equals, locator, casing);
        public ICommand BelowField(That that, string locator = null, Casing casing = Casing.Ignore) => BelowField(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand BelowField(string locator = null, Casing casing = Casing.Ignore) => BelowField(That.Equals, locator, casing);

        #endregion

        #region [LeftOf]

        private ICommand LeftOfField(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Field,
                Limiter = limiter,
                TargetPosition = TargetPosition.LeftOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand LeftOfField(The the, That that, string locator = null, Casing casing = Casing.Ignore) => LeftOfField(the.ToLimiterType(), that, locator, casing);
        public ICommand LeftOfField(The the, string locator = null, Casing casing = Casing.Ignore) => LeftOfField(the, That.Equals, locator, casing);
        public ICommand LeftOfField(That that, string locator = null, Casing casing = Casing.Ignore) => LeftOfField(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand LeftOfField(string locator = null, Casing casing = Casing.Ignore) => LeftOfField(That.Equals, locator, casing);

        #endregion

        #region [RightOf]

        private ICommand RightOfField(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Field,
                Limiter = limiter,
                TargetPosition = TargetPosition.RightOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand RightOfField(The the, That that, string locator = null, Casing casing = Casing.Ignore) => RightOfField(the.ToLimiterType(), that, locator, casing);
        public ICommand RightOfField(The the, string locator = null, Casing casing = Casing.Ignore) => RightOfField(the, That.Equals, locator, casing);
        public ICommand RightOfField(That that, string locator = null, Casing casing = Casing.Ignore) => RightOfField(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand RightOfField(string locator = null, Casing casing = Casing.Ignore) => RightOfField(That.Equals, locator, casing);

        #endregion

        #region [Near]

        private ICommand NearField(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Field,
                Limiter = limiter,
                TargetPosition = TargetPosition.Near,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand NearField(The the, That that, string locator = null, Casing casing = Casing.Ignore) => NearField(the.ToLimiterType(), that, locator, casing);
        public ICommand NearField(The the, string locator = null, Casing casing = Casing.Ignore) => NearField(the, That.Equals, locator, casing);
        public ICommand NearField(That that, string locator = null, Casing casing = Casing.Ignore) => NearField(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand NearField(string locator = null, Casing casing = Casing.Ignore) => NearField(That.Equals, locator, casing);

        #endregion

        #endregion

        #endregion

        #region [Header]

        #region [TargetPosition]

        #region [At]

        private ICommand AtHeader(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Header,
                Limiter = limiter,
                TargetPosition = TargetPosition.At,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand AtHeader(The the, That that, string locator = null, Casing casing = Casing.Ignore) => AtHeader(the.ToLimiterType(), that, locator, casing);
        public ICommand AtHeader(The the, string locator = null, Casing casing = Casing.Ignore) => AtHeader(the, That.Equals, locator, casing);
        public ICommand AtHeader(That that, string locator = null, Casing casing = Casing.Ignore) => AtHeader(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand AtHeader(string locator = null, Casing casing = Casing.Ignore) => AtHeader(That.Equals, locator, casing);

        #endregion

        #region [Above]

        private ICommand AboveHeader(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Header,
                Limiter = limiter,
                TargetPosition = TargetPosition.Above,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand AboveHeader(The the, That that, string locator = null, Casing casing = Casing.Ignore) => AboveHeader(the.ToLimiterType(), that, locator, casing);
        public ICommand AboveHeader(The the, string locator = null, Casing casing = Casing.Ignore) => AboveHeader(the, That.Equals, locator, casing);
        public ICommand AboveHeader(That that, string locator = null, Casing casing = Casing.Ignore) => AboveHeader(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand AboveHeader(string locator = null, Casing casing = Casing.Ignore) => AboveHeader(That.Equals, locator, casing);

        #endregion

        #region [Below]

        private ICommand BelowHeader(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Header,
                Limiter = limiter,
                TargetPosition = TargetPosition.Below,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand BelowHeader(The the, That that, string locator = null, Casing casing = Casing.Ignore) => BelowHeader(the.ToLimiterType(), that, locator, casing);
        public ICommand BelowHeader(The the, string locator = null, Casing casing = Casing.Ignore) => BelowHeader(the, That.Equals, locator, casing);
        public ICommand BelowHeader(That that, string locator = null, Casing casing = Casing.Ignore) => BelowHeader(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand BelowHeader(string locator = null, Casing casing = Casing.Ignore) => BelowHeader(That.Equals, locator, casing);

        #endregion

        #region [LeftOf]

        private ICommand LeftOfHeader(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Header,
                Limiter = limiter,
                TargetPosition = TargetPosition.LeftOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand LeftOfHeader(The the, That that, string locator = null, Casing casing = Casing.Ignore) => LeftOfHeader(the.ToLimiterType(), that, locator, casing);
        public ICommand LeftOfHeader(The the, string locator = null, Casing casing = Casing.Ignore) => LeftOfHeader(the, That.Equals, locator, casing);
        public ICommand LeftOfHeader(That that, string locator = null, Casing casing = Casing.Ignore) => LeftOfHeader(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand LeftOfHeader(string locator = null, Casing casing = Casing.Ignore) => LeftOfHeader(That.Equals, locator, casing);

        #endregion

        #region [RightOf]

        private ICommand RightOfHeader(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Header,
                Limiter = limiter,
                TargetPosition = TargetPosition.RightOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand RightOfHeader(The the, That that, string locator = null, Casing casing = Casing.Ignore) => RightOfHeader(the.ToLimiterType(), that, locator, casing);
        public ICommand RightOfHeader(The the, string locator = null, Casing casing = Casing.Ignore) => RightOfHeader(the, That.Equals, locator, casing);
        public ICommand RightOfHeader(That that, string locator = null, Casing casing = Casing.Ignore) => RightOfHeader(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand RightOfHeader(string locator = null, Casing casing = Casing.Ignore) => RightOfHeader(That.Equals, locator, casing);

        #endregion

        #region [Near]

        private ICommand NearHeader(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Header,
                Limiter = limiter,
                TargetPosition = TargetPosition.Near,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand NearHeader(The the, That that, string locator = null, Casing casing = Casing.Ignore) => NearHeader(the.ToLimiterType(), that, locator, casing);
        public ICommand NearHeader(The the, string locator = null, Casing casing = Casing.Ignore) => NearHeader(the, That.Equals, locator, casing);
        public ICommand NearHeader(That that, string locator = null, Casing casing = Casing.Ignore) => NearHeader(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand NearHeader(string locator = null, Casing casing = Casing.Ignore) => NearHeader(That.Equals, locator, casing);

        #endregion

        #endregion

        #endregion

        #region [Label]

        #region [TargetPosition]

        #region [At]

        private ICommand AtLabel(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Label,
                Limiter = limiter,
                TargetPosition = TargetPosition.At,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand AtLabel(The the, That that, string locator = null, Casing casing = Casing.Ignore) => AtLabel(the.ToLimiterType(), that, locator, casing);
        public ICommand AtLabel(The the, string locator = null, Casing casing = Casing.Ignore) => AtLabel(the, That.Equals, locator, casing);
        public ICommand AtLabel(That that, string locator = null, Casing casing = Casing.Ignore) => AtLabel(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand AtLabel(string locator = null, Casing casing = Casing.Ignore) => AtLabel(That.Equals, locator, casing);

        #endregion

        #region [Above]

        private ICommand AboveLabel(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Label,
                Limiter = limiter,
                TargetPosition = TargetPosition.Above,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand AboveLabel(The the, That that, string locator = null, Casing casing = Casing.Ignore) => AboveLabel(the.ToLimiterType(), that, locator, casing);
        public ICommand AboveLabel(The the, string locator = null, Casing casing = Casing.Ignore) => AboveLabel(the, That.Equals, locator, casing);
        public ICommand AboveLabel(That that, string locator = null, Casing casing = Casing.Ignore) => AboveLabel(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand AboveLabel(string locator = null, Casing casing = Casing.Ignore) => AboveLabel(That.Equals, locator, casing);

        #endregion

        #region [Below]

        private ICommand BelowLabel(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Label,
                Limiter = limiter,
                TargetPosition = TargetPosition.Below,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand BelowLabel(The the, That that, string locator = null, Casing casing = Casing.Ignore) => BelowLabel(the.ToLimiterType(), that, locator, casing);
        public ICommand BelowLabel(The the, string locator = null, Casing casing = Casing.Ignore) => BelowLabel(the, That.Equals, locator, casing);
        public ICommand BelowLabel(That that, string locator = null, Casing casing = Casing.Ignore) => BelowLabel(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand BelowLabel(string locator = null, Casing casing = Casing.Ignore) => BelowLabel(That.Equals, locator, casing);

        #endregion

        #region [LeftOf]

        private ICommand LeftOfLabel(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Label,
                Limiter = limiter,
                TargetPosition = TargetPosition.LeftOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand LeftOfLabel(The the, That that, string locator = null, Casing casing = Casing.Ignore) => LeftOfLabel(the.ToLimiterType(), that, locator, casing);
        public ICommand LeftOfLabel(The the, string locator = null, Casing casing = Casing.Ignore) => LeftOfLabel(the, That.Equals, locator, casing);
        public ICommand LeftOfLabel(That that, string locator = null, Casing casing = Casing.Ignore) => LeftOfLabel(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand LeftOfLabel(string locator = null, Casing casing = Casing.Ignore) => LeftOfLabel(That.Equals, locator, casing);

        #endregion

        #region [RightOf]

        private ICommand RightOfLabel(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Label,
                Limiter = limiter,
                TargetPosition = TargetPosition.RightOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand RightOfLabel(The the, That that, string locator = null, Casing casing = Casing.Ignore) => RightOfLabel(the.ToLimiterType(), that, locator, casing);
        public ICommand RightOfLabel(The the, string locator = null, Casing casing = Casing.Ignore) => RightOfLabel(the, That.Equals, locator, casing);
        public ICommand RightOfLabel(That that, string locator = null, Casing casing = Casing.Ignore) => RightOfLabel(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand RightOfLabel(string locator = null, Casing casing = Casing.Ignore) => RightOfLabel(That.Equals, locator, casing);

        #endregion

        #region [Near]

        private ICommand NearLabel(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Label,
                Limiter = limiter,
                TargetPosition = TargetPosition.Near,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand NearLabel(The the, That that, string locator = null, Casing casing = Casing.Ignore) => NearLabel(the.ToLimiterType(), that, locator, casing);
        public ICommand NearLabel(The the, string locator = null, Casing casing = Casing.Ignore) => NearLabel(the, That.Equals, locator, casing);
        public ICommand NearLabel(That that, string locator = null, Casing casing = Casing.Ignore) => NearLabel(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand NearLabel(string locator = null, Casing casing = Casing.Ignore) => NearLabel(That.Equals, locator, casing);

        #endregion

        #endregion

        #endregion

        #region [Checkbox]

        #region [TargetPosition]

        #region [Above]

        private ICommand AboveCheckbox(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Checkbox,
                Limiter = limiter,
                TargetPosition = TargetPosition.Above,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand AboveCheckbox(The the, That that, string locator = null, Casing casing = Casing.Ignore) => AboveCheckbox(the.ToLimiterType(), that, locator, casing);
        public ICommand AboveCheckbox(The the, string locator = null, Casing casing = Casing.Ignore) => AboveCheckbox(the, That.Equals, locator, casing);
        public ICommand AboveCheckbox(That that, string locator = null, Casing casing = Casing.Ignore) => AboveCheckbox(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand AboveCheckbox(string locator = null, Casing casing = Casing.Ignore) => AboveCheckbox(That.Equals, locator, casing);

        #endregion

        #region [Below]

        private ICommand BelowCheckbox(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Checkbox,
                Limiter = limiter,
                TargetPosition = TargetPosition.Below,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand BelowCheckbox(The the, That that, string locator = null, Casing casing = Casing.Ignore) => BelowCheckbox(the.ToLimiterType(), that, locator, casing);
        public ICommand BelowCheckbox(The the, string locator = null, Casing casing = Casing.Ignore) => BelowCheckbox(the, That.Equals, locator, casing);
        public ICommand BelowCheckbox(That that, string locator = null, Casing casing = Casing.Ignore) => BelowCheckbox(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand BelowCheckbox(string locator = null, Casing casing = Casing.Ignore) => BelowCheckbox(That.Equals, locator, casing);

        #endregion

        #region [LeftOf]

        private ICommand LeftOfCheckbox(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Checkbox,
                Limiter = limiter,
                TargetPosition = TargetPosition.LeftOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand LeftOfCheckbox(The the, That that, string locator = null, Casing casing = Casing.Ignore) => LeftOfCheckbox(the.ToLimiterType(), that, locator, casing);
        public ICommand LeftOfCheckbox(The the, string locator = null, Casing casing = Casing.Ignore) => LeftOfCheckbox(the, That.Equals, locator, casing);
        public ICommand LeftOfCheckbox(That that, string locator = null, Casing casing = Casing.Ignore) => LeftOfCheckbox(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand LeftOfCheckbox(string locator = null, Casing casing = Casing.Ignore) => LeftOfCheckbox(That.Equals, locator, casing);

        #endregion

        #region [RightOf]

        private ICommand RightOfCheckbox(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Checkbox,
                Limiter = limiter,
                TargetPosition = TargetPosition.RightOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand RightOfCheckbox(The the, That that, string locator = null, Casing casing = Casing.Ignore) => RightOfCheckbox(the.ToLimiterType(), that, locator, casing);
        public ICommand RightOfCheckbox(The the, string locator = null, Casing casing = Casing.Ignore) => RightOfCheckbox(the, That.Equals, locator, casing);
        public ICommand RightOfCheckbox(That that, string locator = null, Casing casing = Casing.Ignore) => RightOfCheckbox(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand RightOfCheckbox(string locator = null, Casing casing = Casing.Ignore) => RightOfCheckbox(That.Equals, locator, casing);

        #endregion

        #region [Near]

        private ICommand NearCheckbox(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Checkbox,
                Limiter = limiter,
                TargetPosition = TargetPosition.Near,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand NearCheckbox(The the, That that, string locator = null, Casing casing = Casing.Ignore) => NearCheckbox(the.ToLimiterType(), that, locator, casing);
        public ICommand NearCheckbox(The the, string locator = null, Casing casing = Casing.Ignore) => NearCheckbox(the, That.Equals, locator, casing);
        public ICommand NearCheckbox(That that, string locator = null, Casing casing = Casing.Ignore) => NearCheckbox(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand NearCheckbox(string locator = null, Casing casing = Casing.Ignore) => NearCheckbox(That.Equals, locator, casing);

        #endregion

        #endregion

        #endregion

        #region [Radiobox]

        #region [TargetPosition]

        #region [Above]

        private ICommand AboveRadiobox(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Radiobox,
                Limiter = limiter,
                TargetPosition = TargetPosition.Above,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand AboveRadiobox(The the, That that, string locator = null, Casing casing = Casing.Ignore) => AboveRadiobox(the.ToLimiterType(), that, locator, casing);
        public ICommand AboveRadiobox(The the, string locator = null, Casing casing = Casing.Ignore) => AboveRadiobox(the, That.Equals, locator, casing);
        public ICommand AboveRadiobox(That that, string locator = null, Casing casing = Casing.Ignore) => AboveRadiobox(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand AboveRadiobox(string locator = null, Casing casing = Casing.Ignore) => AboveRadiobox(That.Equals, locator, casing);

        #endregion

        #region [Below]

        private ICommand BelowRadiobox(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Radiobox,
                Limiter = limiter,
                TargetPosition = TargetPosition.Below,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand BelowRadiobox(The the, That that, string locator = null, Casing casing = Casing.Ignore) => BelowRadiobox(the.ToLimiterType(), that, locator, casing);
        public ICommand BelowRadiobox(The the, string locator = null, Casing casing = Casing.Ignore) => BelowRadiobox(the, That.Equals, locator, casing);
        public ICommand BelowRadiobox(That that, string locator = null, Casing casing = Casing.Ignore) => BelowRadiobox(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand BelowRadiobox(string locator = null, Casing casing = Casing.Ignore) => BelowRadiobox(That.Equals, locator, casing);

        #endregion

        #region [LeftOf]

        private ICommand LeftOfRadiobox(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Radiobox,
                Limiter = limiter,
                TargetPosition = TargetPosition.LeftOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand LeftOfRadiobox(The the, That that, string locator = null, Casing casing = Casing.Ignore) => LeftOfRadiobox(the.ToLimiterType(), that, locator, casing);
        public ICommand LeftOfRadiobox(The the, string locator = null, Casing casing = Casing.Ignore) => LeftOfRadiobox(the, That.Equals, locator, casing);
        public ICommand LeftOfRadiobox(That that, string locator = null, Casing casing = Casing.Ignore) => LeftOfRadiobox(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand LeftOfRadiobox(string locator = null, Casing casing = Casing.Ignore) => LeftOfRadiobox(That.Equals, locator, casing);

        #endregion

        #region [RightOf]

        private ICommand RightOfRadiobox(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Radiobox,
                Limiter = limiter,
                TargetPosition = TargetPosition.RightOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand RightOfRadiobox(The the, That that, string locator = null, Casing casing = Casing.Ignore) => RightOfRadiobox(the.ToLimiterType(), that, locator, casing);
        public ICommand RightOfRadiobox(The the, string locator = null, Casing casing = Casing.Ignore) => RightOfRadiobox(the, That.Equals, locator, casing);
        public ICommand RightOfRadiobox(That that, string locator = null, Casing casing = Casing.Ignore) => RightOfRadiobox(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand RightOfRadiobox(string locator = null, Casing casing = Casing.Ignore) => RightOfRadiobox(That.Equals, locator, casing);

        #endregion

        #region [Near]

        private ICommand NearRadiobox(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Radiobox,
                Limiter = limiter,
                TargetPosition = TargetPosition.Near,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand NearRadiobox(The the, That that, string locator = null, Casing casing = Casing.Ignore) => NearRadiobox(the.ToLimiterType(), that, locator, casing);
        public ICommand NearRadiobox(The the, string locator = null, Casing casing = Casing.Ignore) => NearRadiobox(the, That.Equals, locator, casing);
        public ICommand NearRadiobox(That that, string locator = null, Casing casing = Casing.Ignore) => NearRadiobox(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand NearRadiobox(string locator = null, Casing casing = Casing.Ignore) => NearRadiobox(That.Equals, locator, casing);

        #endregion

        #endregion

        #endregion

        #region [Row]

        #region [TargetPosition]

        #region [At]

        private ICommand Row(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Row,
                Limiter = limiter,
                TargetPosition = TargetPosition.At,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand Row(The the, That that, string locator = null, Casing casing = Casing.Ignore) => Row(the.ToLimiterType(), that, locator, casing);
        public ICommand Row(The the, string locator = null, Casing casing = Casing.Ignore) => Row(the, That.Equals, locator, casing);
        public ICommand Row(That that, string locator = null, Casing casing = Casing.Ignore) => Row(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand Row(string locator = null, Casing casing = Casing.Ignore) => Row(That.Equals, locator, casing);

        private ICommand Row(Limiter limiter, int position)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = position.ToString(),
                TargetType = TargetType.Row,
                Limiter = limiter,
                TargetPosition = TargetPosition.At,
                SearchType = SearchType.Position
            });
            return this;
        }

        public ICommand Row(The the, int position) => Row(the.ToLimiterType(), position);
        public ICommand Row(int position) => Row(Limiter.Everything, position);


        private ICommand AtRow(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Row,
                Limiter = limiter,
                TargetPosition = TargetPosition.At,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand AtRow(The the, That that, string locator = null, Casing casing = Casing.Ignore) => AtRow(the.ToLimiterType(), that, locator, casing);
        public ICommand AtRow(The the, string locator = null, Casing casing = Casing.Ignore) => AtRow(the, That.Equals, locator, casing);
        public ICommand AtRow(That that, string locator = null, Casing casing = Casing.Ignore) => AtRow(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand AtRow(string locator = null, Casing casing = Casing.Ignore) => AtRow(That.Equals, locator, casing);


        private ICommand AtRow(Limiter limiter, int position)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = position.ToString(),
                TargetType = TargetType.Row,
                Limiter = limiter,
                TargetPosition = TargetPosition.At,
                SearchType = SearchType.Position
            });
            return this;
        }

        public ICommand AtRow(The the, int position) => AtRow(the.ToLimiterType(), position);
        public ICommand AtRow(int position) => AtRow(Limiter.Everything, position);

        #endregion

        #region [Above]

        private ICommand AboveRow(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Row,
                Limiter = limiter,
                TargetPosition = TargetPosition.Above,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand AboveRow(The the, That that, string locator = null, Casing casing = Casing.Ignore) => AboveRow(the.ToLimiterType(), that, locator, casing);
        public ICommand AboveRow(The the, string locator = null, Casing casing = Casing.Ignore) => AboveRow(the, That.Equals, locator, casing);
        public ICommand AboveRow(That that, string locator = null, Casing casing = Casing.Ignore) => AboveRow(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand AboveRow(string locator = null, Casing casing = Casing.Ignore) => AboveRow(That.Equals, locator, casing);

        private ICommand AboveRow(Limiter limiter, int position)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = position.ToString(),
                TargetType = TargetType.Row,
                Limiter = limiter,
                TargetPosition = TargetPosition.At,
                SearchType = SearchType.Position
            });
            return this;
        }

        public ICommand AboveRow(The the, int position) => AboveRow(the.ToLimiterType(), position);
        public ICommand AboveRow(int position) => AboveRow(Limiter.Everything, position);

        #endregion

        #region [Below]

        private ICommand BelowRow(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Row,
                Limiter = limiter,
                TargetPosition = TargetPosition.Below,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand BelowRow(The the, That that, string locator = null, Casing casing = Casing.Ignore) => BelowRow(the.ToLimiterType(), that, locator, casing);
        public ICommand BelowRow(The the, string locator = null, Casing casing = Casing.Ignore) => BelowRow(the, That.Equals, locator, casing);
        public ICommand BelowRow(That that, string locator = null, Casing casing = Casing.Ignore) => BelowRow(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand BelowRow(string locator = null, Casing casing = Casing.Ignore) => BelowRow(That.Equals, locator, casing);

        private ICommand BelowRow(Limiter limiter, int position)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = position.ToString(),
                TargetType = TargetType.Row,
                Limiter = limiter,
                TargetPosition = TargetPosition.At,
                SearchType = SearchType.Position
            });
            return this;
        }

        public ICommand BelowRow(The the, int position) => BelowRow(the.ToLimiterType(), position);
        public ICommand BelowRow(int position) => BelowRow(Limiter.Everything, position);

        #endregion

        #region [LeftOf]

        private ICommand LeftOfRow(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Row,
                Limiter = limiter,
                TargetPosition = TargetPosition.LeftOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand LeftOfRow(The the, That that, string locator = null, Casing casing = Casing.Ignore) => LeftOfRow(the.ToLimiterType(), that, locator, casing);
        public ICommand LeftOfRow(The the, string locator = null, Casing casing = Casing.Ignore) => LeftOfRow(the, That.Equals, locator, casing);
        public ICommand LeftOfRow(That that, string locator = null, Casing casing = Casing.Ignore) => LeftOfRow(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand LeftOfRow(string locator = null, Casing casing = Casing.Ignore) => LeftOfRow(That.Equals, locator, casing);

        private ICommand LeftOfRow(Limiter limiter, int position)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = position.ToString(),
                TargetType = TargetType.Row,
                Limiter = limiter,
                TargetPosition = TargetPosition.At,
                SearchType = SearchType.Position
            });
            return this;
        }

        public ICommand LeftOfRow(The the, int position) => LeftOfRow(the.ToLimiterType(), position);
        public ICommand LeftOfRow(int position) => LeftOfRow(Limiter.Everything, position);

        #endregion

        #region [RightOf]

        private ICommand RightOfRow(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Row,
                Limiter = limiter,
                TargetPosition = TargetPosition.RightOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand RightOfRow(The the, That that, string locator = null, Casing casing = Casing.Ignore) => RightOfRow(the.ToLimiterType(), that, locator, casing);
        public ICommand RightOfRow(The the, string locator = null, Casing casing = Casing.Ignore) => RightOfRow(the, That.Equals, locator, casing);
        public ICommand RightOfRow(That that, string locator = null, Casing casing = Casing.Ignore) => RightOfRow(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand RightOfRow(string locator = null, Casing casing = Casing.Ignore) => RightOfRow(That.Equals, locator, casing);

        private ICommand RightOfRow(Limiter limiter, int position)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = position.ToString(),
                TargetType = TargetType.Row,
                Limiter = limiter,
                TargetPosition = TargetPosition.At,
                SearchType = SearchType.Position
            });
            return this;
        }

        public ICommand RightOfRow(The the, int position) => RightOfRow(the.ToLimiterType(), position);
        public ICommand RightOfRow(int position) => RightOfRow(Limiter.Everything, position);

        #endregion

        #region [Near]

        private ICommand NearRow(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Row,
                Limiter = limiter,
                TargetPosition = TargetPosition.Near,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand NearRow(The the, That that, string locator = null, Casing casing = Casing.Ignore) => NearRow(the.ToLimiterType(), that, locator, casing);
        public ICommand NearRow(The the, string locator = null, Casing casing = Casing.Ignore) => NearRow(the, That.Equals, locator, casing);
        public ICommand NearRow(That that, string locator = null, Casing casing = Casing.Ignore) => NearRow(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand NearRow(string locator = null, Casing casing = Casing.Ignore) => NearRow(That.Equals, locator, casing);

        private ICommand NearRow(Limiter limiter, int position)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = position.ToString(),
                TargetType = TargetType.Row,
                Limiter = limiter,
                TargetPosition = TargetPosition.At,
                SearchType = SearchType.Position
            });
            return this;
        }

        public ICommand NearRow(The the, int position) => NearRow(the.ToLimiterType(), position);
        public ICommand NearRow(int position) => NearRow(Limiter.Everything, position);

        #endregion

        #endregion

        #endregion

        #region [RowColumns]

        #region [TargetPosition]


        #region [At]

        private ICommand AtRowColumns(Limiter limiter, That that, Casing casing, params string[] locator)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = string.Join("\n", locator),
                TargetType = TargetType.Row,
                Limiter = limiter,
                TargetPosition = TargetPosition.At,
                SearchType = that.ToSearchType(casing)
            });
            return this;
        }
        public ICommand AtRowColumns(The the, That that, Casing casing, params string[] locator) => AtRowColumns(the.ToLimiterType(), that, casing, locator);
        public ICommand AtRowColumns(The the, That that, params string[] locator) => AtRowColumns(the, that, Casing.Ignore, locator);
        public ICommand AtRowColumns(The the, Casing casing, params string[] locator) => AtRowColumns(the, That.Equals, casing, locator);
        public ICommand AtRowColumns(The the, params string[] locator) => AtRowColumns(the, That.Equals, locator);
        public ICommand AtRowColumns(The the) => AtRowColumns(the, string.Empty);
        public ICommand AtRowColumns(That that, Casing casing, params string[] locator) => AtRowColumns(Limiter.Everything, that, casing, locator);
        public ICommand AtRowColumns(That that, params string[] locator) => AtRowColumns(that, Casing.Ignore, locator);
        public ICommand AtRowColumns(Casing casing, params string[] locator) => AtRowColumns(That.Equals, casing, locator);
        public ICommand AtRowColumns(params string[] locator) => AtRowColumns(That.Equals, locator);
        public ICommand AtRowColumns() => AtRowColumns(string.Empty);

        #endregion


        #region [Above]

        private ICommand AboveRowColumns(Limiter limiter, That that, Casing casing, params string[] locator)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = string.Join("\n", locator),
                TargetType = TargetType.Row,
                Limiter = limiter,
                TargetPosition = TargetPosition.Above,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }
        public ICommand AboveRowColumns(The the, That that, Casing casing, params string[] locator) => AboveRowColumns(the.ToLimiterType(), that, casing, locator);
        public ICommand AboveRowColumns(The the, That that, params string[] locator) => AboveRowColumns(the, that, Casing.Ignore, locator);
        public ICommand AboveRowColumns(The the, Casing casing, params string[] locator) => AboveRowColumns(the, That.Equals, casing, locator);
        public ICommand AboveRowColumns(The the, params string[] locator) => AboveRowColumns(the, That.Equals, locator);
        public ICommand AboveRowColumns(The the) => AboveRowColumns(the, string.Empty);
        public ICommand AboveRowColumns(That that, Casing casing, params string[] locator) => AboveRowColumns(Limiter.Everything, that, casing, locator);
        public ICommand AboveRowColumns(That that, params string[] locator) => AboveRowColumns(that, Casing.Ignore, locator);
        public ICommand AboveRowColumns(Casing casing, params string[] locator) => AboveRowColumns(That.Equals, casing, locator);
        public ICommand AboveRowColumns(params string[] locator) => AboveRowColumns(That.Equals, locator);
        public ICommand AboveRowColumns() => AboveRowColumns(string.Empty);

        #endregion

        #region [Below]

        private ICommand BelowRowColumns(Limiter limiter, That that, Casing casing, params string[] locator)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = string.Join("\n", locator),
                TargetType = TargetType.Row,
                Limiter = limiter,
                TargetPosition = TargetPosition.Below,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }
        public ICommand BelowRowColumns(The the, That that, Casing casing, params string[] locator) => BelowRowColumns(the.ToLimiterType(), that, casing, locator);
        public ICommand BelowRowColumns(The the, That that, params string[] locator) => BelowRowColumns(the, that, Casing.Ignore, locator);
        public ICommand BelowRowColumns(The the, Casing casing, params string[] locator) => BelowRowColumns(the, That.Equals, casing, locator);
        public ICommand BelowRowColumns(The the, params string[] locator) => BelowRowColumns(the, That.Equals, locator);
        public ICommand BelowRowColumns(The the) => BelowRowColumns(the, string.Empty);
        public ICommand BelowRowColumns(That that, Casing casing, params string[] locator) => BelowRowColumns(Limiter.Everything, that, casing, locator);
        public ICommand BelowRowColumns(That that, params string[] locator) => BelowRowColumns(that, Casing.Ignore, locator);
        public ICommand BelowRowColumns(Casing casing, params string[] locator) => BelowRowColumns(That.Equals, casing, locator);
        public ICommand BelowRowColumns(params string[] locator) => BelowRowColumns(That.Equals, locator);
        public ICommand BelowRowColumns() => BelowRowColumns(string.Empty);

        #endregion

        #region [LeftOf]

        private ICommand LeftOfRowColumns(Limiter limiter, That that, Casing casing, params string[] locator)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = string.Join("\n", locator),
                TargetType = TargetType.Row,
                Limiter = limiter,
                TargetPosition = TargetPosition.LeftOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }
        public ICommand LeftOfRowColumns(The the, That that, Casing casing, params string[] locator) => LeftOfRowColumns(the.ToLimiterType(), that, casing, locator);
        public ICommand LeftOfRowColumns(The the, That that, params string[] locator) => LeftOfRowColumns(the, that, Casing.Ignore, locator);
        public ICommand LeftOfRowColumns(The the, Casing casing, params string[] locator) => LeftOfRowColumns(the, That.Equals, casing, locator);
        public ICommand LeftOfRowColumns(The the, params string[] locator) => LeftOfRowColumns(the, That.Equals, locator);
        public ICommand LeftOfRowColumns(The the) => LeftOfRowColumns(the, string.Empty);
        public ICommand LeftOfRowColumns(That that, Casing casing, params string[] locator) => LeftOfRowColumns(Limiter.Everything, that, casing, locator);
        public ICommand LeftOfRowColumns(That that, params string[] locator) => LeftOfRowColumns(that, Casing.Ignore, locator);
        public ICommand LeftOfRowColumns(Casing casing, params string[] locator) => LeftOfRowColumns(That.Equals, casing, locator);
        public ICommand LeftOfRowColumns(params string[] locator) => LeftOfRowColumns(That.Equals, locator);
        public ICommand LeftOfRowColumns() => LeftOfRowColumns(string.Empty);

        #endregion

        #region [RightOf]

        private ICommand RightOfRowColumns(Limiter limiter, That that, Casing casing, params string[] locator)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = string.Join("\n", locator),
                TargetType = TargetType.Row,
                Limiter = limiter,
                TargetPosition = TargetPosition.RightOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }
        public ICommand RightOfRowColumns(The the, That that, Casing casing, params string[] locator) => RightOfRowColumns(the.ToLimiterType(), that, casing, locator);
        public ICommand RightOfRowColumns(The the, That that, params string[] locator) => RightOfRowColumns(the, that, Casing.Ignore, locator);
        public ICommand RightOfRowColumns(The the, Casing casing, params string[] locator) => RightOfRowColumns(the, That.Equals, casing, locator);
        public ICommand RightOfRowColumns(The the, params string[] locator) => RightOfRowColumns(the, That.Equals, locator);
        public ICommand RightOfRowColumns(The the) => RightOfRowColumns(the, string.Empty);
        public ICommand RightOfRowColumns(That that, Casing casing, params string[] locator) => RightOfRowColumns(Limiter.Everything, that, casing, locator);
        public ICommand RightOfRowColumns(That that, params string[] locator) => RightOfRowColumns(that, Casing.Ignore, locator);
        public ICommand RightOfRowColumns(Casing casing, params string[] locator) => RightOfRowColumns(That.Equals, casing, locator);
        public ICommand RightOfRowColumns(params string[] locator) => RightOfRowColumns(That.Equals, locator);
        public ICommand RightOfRowColumns() => RightOfRowColumns(string.Empty);

        #endregion

        #region [Near]

        private ICommand NearRowColumns(Limiter limiter, That that, Casing casing, params string[] locator)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = string.Join("\n", locator),
                TargetType = TargetType.Row,
                Limiter = limiter,
                TargetPosition = TargetPosition.Near,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }
        public ICommand NearRowColumns(The the, That that, Casing casing, params string[] locator) => NearRowColumns(the.ToLimiterType(), that, casing, locator);
        public ICommand NearRowColumns(The the, That that, params string[] locator) => NearRowColumns(the, that, Casing.Ignore, locator);
        public ICommand NearRowColumns(The the, Casing casing, params string[] locator) => NearRowColumns(the, That.Equals, casing, locator);
        public ICommand NearRowColumns(The the, params string[] locator) => NearRowColumns(the, That.Equals, locator);
        public ICommand NearRowColumns(The the) => NearRowColumns(the, string.Empty);
        public ICommand NearRowColumns(That that, Casing casing, params string[] locator) => NearRowColumns(Limiter.Everything, that, casing, locator);
        public ICommand NearRowColumns(That that, params string[] locator) => NearRowColumns(that, Casing.Ignore, locator);
        public ICommand NearRowColumns(Casing casing, params string[] locator) => NearRowColumns(That.Equals, casing, locator);
        public ICommand NearRowColumns(params string[] locator) => NearRowColumns(That.Equals, locator);
        public ICommand NearRowColumns() => NearRowColumns(string.Empty);

        #endregion

        #endregion

        #endregion

        #region [Item]

        #region [TargetPosition]

        #region [Above]

        private ICommand AboveItem(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Item,
                Limiter = limiter,
                TargetPosition = TargetPosition.Above,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand AboveItem(The the, That that, string locator = null, Casing casing = Casing.Ignore) => AboveItem(the.ToLimiterType(), that, locator, casing);
        public ICommand AboveItem(The the, string locator = null, Casing casing = Casing.Ignore) => AboveItem(the, That.Equals, locator, casing);
        public ICommand AboveItem(That that, string locator = null, Casing casing = Casing.Ignore) => AboveItem(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand AboveItem(string locator = null, Casing casing = Casing.Ignore) => AboveItem(That.Equals, locator, casing);

        #endregion

        #region [Below]

        private ICommand BelowItem(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Item,
                Limiter = limiter,
                TargetPosition = TargetPosition.Below,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand BelowItem(The the, That that, string locator = null, Casing casing = Casing.Ignore) => BelowItem(the.ToLimiterType(), that, locator, casing);
        public ICommand BelowItem(The the, string locator = null, Casing casing = Casing.Ignore) => BelowItem(the, That.Equals, locator, casing);
        public ICommand BelowItem(That that, string locator = null, Casing casing = Casing.Ignore) => BelowItem(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand BelowItem(string locator = null, Casing casing = Casing.Ignore) => BelowItem(That.Equals, locator, casing);

        #endregion

        #region [LeftOf]

        private ICommand LeftOfItem(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Item,
                Limiter = limiter,
                TargetPosition = TargetPosition.LeftOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand LeftOfItem(The the, That that, string locator = null, Casing casing = Casing.Ignore) => LeftOfItem(the.ToLimiterType(), that, locator, casing);
        public ICommand LeftOfItem(The the, string locator = null, Casing casing = Casing.Ignore) => LeftOfItem(the, That.Equals, locator, casing);
        public ICommand LeftOfItem(That that, string locator = null, Casing casing = Casing.Ignore) => LeftOfItem(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand LeftOfItem(string locator = null, Casing casing = Casing.Ignore) => LeftOfItem(That.Equals, locator, casing);

        #endregion

        #region [RightOf]

        private ICommand RightOfItem(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Item,
                Limiter = limiter,
                TargetPosition = TargetPosition.RightOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand RightOfItem(The the, That that, string locator = null, Casing casing = Casing.Ignore) => RightOfItem(the.ToLimiterType(), that, locator, casing);
        public ICommand RightOfItem(The the, string locator = null, Casing casing = Casing.Ignore) => RightOfItem(the, That.Equals, locator, casing);
        public ICommand RightOfItem(That that, string locator = null, Casing casing = Casing.Ignore) => RightOfItem(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand RightOfItem(string locator = null, Casing casing = Casing.Ignore) => RightOfItem(That.Equals, locator, casing);

        #endregion

        #region [Near]

        private ICommand NearItem(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Item,
                Limiter = limiter,
                TargetPosition = TargetPosition.Near,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand NearItem(The the, That that, string locator = null, Casing casing = Casing.Ignore) => NearItem(the.ToLimiterType(), that, locator, casing);
        public ICommand NearItem(The the, string locator = null, Casing casing = Casing.Ignore) => NearItem(the, That.Equals, locator, casing);
        public ICommand NearItem(That that, string locator = null, Casing casing = Casing.Ignore) => NearItem(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand NearItem(string locator = null, Casing casing = Casing.Ignore) => NearItem(That.Equals, locator, casing);

        #endregion

        #endregion

        #endregion

        #region [Value]

        #region [TargetPosition]

        #region [Above]

        private ICommand AboveValue(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Value,
                Limiter = limiter,
                TargetPosition = TargetPosition.Above,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand AboveValue(The the, That that, string locator = null, Casing casing = Casing.Ignore) => AboveValue(the.ToLimiterType(), that, locator, casing);
        public ICommand AboveValue(The the, string locator = null, Casing casing = Casing.Ignore) => AboveValue(the, That.Equals, locator, casing);
        public ICommand AboveValue(That that, string locator = null, Casing casing = Casing.Ignore) => AboveValue(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand AboveValue(string locator = null, Casing casing = Casing.Ignore) => AboveValue(That.Equals, locator, casing);

        #endregion

        #region [Below]

        private ICommand BelowValue(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Value,
                Limiter = limiter,
                TargetPosition = TargetPosition.Below,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand BelowValue(The the, That that, string locator = null, Casing casing = Casing.Ignore) => BelowValue(the.ToLimiterType(), that, locator, casing);
        public ICommand BelowValue(The the, string locator = null, Casing casing = Casing.Ignore) => BelowValue(the, That.Equals, locator, casing);
        public ICommand BelowValue(That that, string locator = null, Casing casing = Casing.Ignore) => BelowValue(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand BelowValue(string locator = null, Casing casing = Casing.Ignore) => BelowValue(That.Equals, locator, casing);

        #endregion

        #region [LeftOf]

        private ICommand LeftOfValue(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Value,
                Limiter = limiter,
                TargetPosition = TargetPosition.LeftOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand LeftOfValue(The the, That that, string locator = null, Casing casing = Casing.Ignore) => LeftOfValue(the.ToLimiterType(), that, locator, casing);
        public ICommand LeftOfValue(The the, string locator = null, Casing casing = Casing.Ignore) => LeftOfValue(the, That.Equals, locator, casing);
        public ICommand LeftOfValue(That that, string locator = null, Casing casing = Casing.Ignore) => LeftOfValue(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand LeftOfValue(string locator = null, Casing casing = Casing.Ignore) => LeftOfValue(That.Equals, locator, casing);

        #endregion

        #region [RightOf]

        private ICommand RightOfValue(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Value,
                Limiter = limiter,
                TargetPosition = TargetPosition.RightOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand RightOfValue(The the, That that, string locator = null, Casing casing = Casing.Ignore) => RightOfValue(the.ToLimiterType(), that, locator, casing);
        public ICommand RightOfValue(The the, string locator = null, Casing casing = Casing.Ignore) => RightOfValue(the, That.Equals, locator, casing);
        public ICommand RightOfValue(That that, string locator = null, Casing casing = Casing.Ignore) => RightOfValue(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand RightOfValue(string locator = null, Casing casing = Casing.Ignore) => RightOfValue(That.Equals, locator, casing);

        #endregion

        #region [Near]

        private ICommand NearValue(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Value,
                Limiter = limiter,
                TargetPosition = TargetPosition.Near,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand NearValue(The the, That that, string locator = null, Casing casing = Casing.Ignore) => NearValue(the.ToLimiterType(), that, locator, casing);
        public ICommand NearValue(The the, string locator = null, Casing casing = Casing.Ignore) => NearValue(the, That.Equals, locator, casing);
        public ICommand NearValue(That that, string locator = null, Casing casing = Casing.Ignore) => NearValue(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand NearValue(string locator = null, Casing casing = Casing.Ignore) => NearValue(That.Equals, locator, casing);

        #endregion

        #endregion

        #endregion

        #region [File]

        #region [TargetPosition]

        #region [Above]

        private ICommand AboveFile(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.File,
                Limiter = limiter,
                TargetPosition = TargetPosition.Above,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand AboveFile(The the, That that, string locator = null, Casing casing = Casing.Ignore) => AboveFile(the.ToLimiterType(), that, locator, casing);
        public ICommand AboveFile(The the, string locator = null, Casing casing = Casing.Ignore) => AboveFile(the, That.Equals, locator, casing);
        public ICommand AboveFile(That that, string locator = null, Casing casing = Casing.Ignore) => AboveFile(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand AboveFile(string locator = null, Casing casing = Casing.Ignore) => AboveFile(That.Equals, locator, casing);

        #endregion

        #region [Below]

        private ICommand BelowFile(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.File,
                Limiter = limiter,
                TargetPosition = TargetPosition.Below,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand BelowFile(The the, That that, string locator = null, Casing casing = Casing.Ignore) => BelowFile(the.ToLimiterType(), that, locator, casing);
        public ICommand BelowFile(The the, string locator = null, Casing casing = Casing.Ignore) => BelowFile(the, That.Equals, locator, casing);
        public ICommand BelowFile(That that, string locator = null, Casing casing = Casing.Ignore) => BelowFile(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand BelowFile(string locator = null, Casing casing = Casing.Ignore) => BelowFile(That.Equals, locator, casing);

        #endregion

        #region [LeftOf]

        private ICommand LeftOfFile(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.File,
                Limiter = limiter,
                TargetPosition = TargetPosition.LeftOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand LeftOfFile(The the, That that, string locator = null, Casing casing = Casing.Ignore) => LeftOfFile(the.ToLimiterType(), that, locator, casing);
        public ICommand LeftOfFile(The the, string locator = null, Casing casing = Casing.Ignore) => LeftOfFile(the, That.Equals, locator, casing);
        public ICommand LeftOfFile(That that, string locator = null, Casing casing = Casing.Ignore) => LeftOfFile(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand LeftOfFile(string locator = null, Casing casing = Casing.Ignore) => LeftOfFile(That.Equals, locator, casing);

        #endregion

        #region [RightOf]

        private ICommand RightOfFile(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.File,
                Limiter = limiter,
                TargetPosition = TargetPosition.RightOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand RightOfFile(The the, That that, string locator = null, Casing casing = Casing.Ignore) => RightOfFile(the.ToLimiterType(), that, locator, casing);
        public ICommand RightOfFile(The the, string locator = null, Casing casing = Casing.Ignore) => RightOfFile(the, That.Equals, locator, casing);
        public ICommand RightOfFile(That that, string locator = null, Casing casing = Casing.Ignore) => RightOfFile(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand RightOfFile(string locator = null, Casing casing = Casing.Ignore) => RightOfFile(That.Equals, locator, casing);

        #endregion

        #region [Near]

        private ICommand NearFile(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.File,
                Limiter = limiter,
                TargetPosition = TargetPosition.Near,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand NearFile(The the, That that, string locator = null, Casing casing = Casing.Ignore) => NearFile(the.ToLimiterType(), that, locator, casing);
        public ICommand NearFile(The the, string locator = null, Casing casing = Casing.Ignore) => NearFile(the, That.Equals, locator, casing);
        public ICommand NearFile(That that, string locator = null, Casing casing = Casing.Ignore) => NearFile(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand NearFile(string locator = null, Casing casing = Casing.Ignore) => NearFile(That.Equals, locator, casing);

        #endregion

        #endregion

        #endregion

        #region [Tick]

        #region [TargetPosition]

        #region [Above]

        private ICommand AboveTick(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Tick,
                Limiter = limiter,
                TargetPosition = TargetPosition.Above,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand AboveTick(The the, That that, string locator = null, Casing casing = Casing.Ignore) => AboveTick(the.ToLimiterType(), that, locator, casing);
        public ICommand AboveTick(The the, string locator = null, Casing casing = Casing.Ignore) => AboveTick(the, That.Equals, locator, casing);
        public ICommand AboveTick(That that, string locator = null, Casing casing = Casing.Ignore) => AboveTick(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand AboveTick(string locator = null, Casing casing = Casing.Ignore) => AboveTick(That.Equals, locator, casing);

        #endregion

        #region [Below]

        private ICommand BelowTick(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Tick,
                Limiter = limiter,
                TargetPosition = TargetPosition.Below,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand BelowTick(The the, That that, string locator = null, Casing casing = Casing.Ignore) => BelowTick(the.ToLimiterType(), that, locator, casing);
        public ICommand BelowTick(The the, string locator = null, Casing casing = Casing.Ignore) => BelowTick(the, That.Equals, locator, casing);
        public ICommand BelowTick(That that, string locator = null, Casing casing = Casing.Ignore) => BelowTick(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand BelowTick(string locator = null, Casing casing = Casing.Ignore) => BelowTick(That.Equals, locator, casing);

        #endregion

        #region [LeftOf]

        private ICommand LeftOfTick(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Tick,
                Limiter = limiter,
                TargetPosition = TargetPosition.LeftOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand LeftOfTick(The the, That that, string locator = null, Casing casing = Casing.Ignore) => LeftOfTick(the.ToLimiterType(), that, locator, casing);
        public ICommand LeftOfTick(The the, string locator = null, Casing casing = Casing.Ignore) => LeftOfTick(the, That.Equals, locator, casing);
        public ICommand LeftOfTick(That that, string locator = null, Casing casing = Casing.Ignore) => LeftOfTick(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand LeftOfTick(string locator = null, Casing casing = Casing.Ignore) => LeftOfTick(That.Equals, locator, casing);

        #endregion

        #region [RightOf]

        private ICommand RightOfTick(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Tick,
                Limiter = limiter,
                TargetPosition = TargetPosition.RightOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand RightOfTick(The the, That that, string locator = null, Casing casing = Casing.Ignore) => RightOfTick(the.ToLimiterType(), that, locator, casing);
        public ICommand RightOfTick(The the, string locator = null, Casing casing = Casing.Ignore) => RightOfTick(the, That.Equals, locator, casing);
        public ICommand RightOfTick(That that, string locator = null, Casing casing = Casing.Ignore) => RightOfTick(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand RightOfTick(string locator = null, Casing casing = Casing.Ignore) => RightOfTick(That.Equals, locator, casing);

        #endregion

        #region [Near]

        private ICommand NearTick(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Tick,
                Limiter = limiter,
                TargetPosition = TargetPosition.Near,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand NearTick(The the, That that, string locator = null, Casing casing = Casing.Ignore) => NearTick(the.ToLimiterType(), that, locator, casing);
        public ICommand NearTick(The the, string locator = null, Casing casing = Casing.Ignore) => NearTick(the, That.Equals, locator, casing);
        public ICommand NearTick(That that, string locator = null, Casing casing = Casing.Ignore) => NearTick(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand NearTick(string locator = null, Casing casing = Casing.Ignore) => NearTick(That.Equals, locator, casing);

        #endregion

        #endregion

        #endregion

        #region [Table]

        #region [TargetPosition]

        #region [Above]

        private ICommand AboveTable(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Table,
                Limiter = limiter,
                TargetPosition = TargetPosition.Above,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand AboveTable(The the, That that, string locator = null, Casing casing = Casing.Ignore) => AboveTable(the.ToLimiterType(), that, locator, casing);
        public ICommand AboveTable(The the, string locator = null, Casing casing = Casing.Ignore) => AboveTable(the, That.Equals, locator, casing);
        public ICommand AboveTable(That that, string locator = null, Casing casing = Casing.Ignore) => AboveTable(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand AboveTable(string locator = null, Casing casing = Casing.Ignore) => AboveTable(That.Equals, locator, casing);

        #endregion

        #region [Below]

        private ICommand BelowTable(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Table,
                Limiter = limiter,
                TargetPosition = TargetPosition.Below,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand BelowTable(The the, That that, string locator = null, Casing casing = Casing.Ignore) => BelowTable(the.ToLimiterType(), that, locator, casing);
        public ICommand BelowTable(The the, string locator = null, Casing casing = Casing.Ignore) => BelowTable(the, That.Equals, locator, casing);
        public ICommand BelowTable(That that, string locator = null, Casing casing = Casing.Ignore) => BelowTable(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand BelowTable(string locator = null, Casing casing = Casing.Ignore) => BelowTable(That.Equals, locator, casing);

        #endregion

        #region [LeftOf]

        private ICommand LeftOfTable(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Table,
                Limiter = limiter,
                TargetPosition = TargetPosition.LeftOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand LeftOfTable(The the, That that, string locator = null, Casing casing = Casing.Ignore) => LeftOfTable(the.ToLimiterType(), that, locator, casing);
        public ICommand LeftOfTable(The the, string locator = null, Casing casing = Casing.Ignore) => LeftOfTable(the, That.Equals, locator, casing);
        public ICommand LeftOfTable(That that, string locator = null, Casing casing = Casing.Ignore) => LeftOfTable(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand LeftOfTable(string locator = null, Casing casing = Casing.Ignore) => LeftOfTable(That.Equals, locator, casing);

        #endregion

        #region [RightOf]

        private ICommand RightOfTable(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Table,
                Limiter = limiter,
                TargetPosition = TargetPosition.RightOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand RightOfTable(The the, That that, string locator = null, Casing casing = Casing.Ignore) => RightOfTable(the.ToLimiterType(), that, locator, casing);
        public ICommand RightOfTable(The the, string locator = null, Casing casing = Casing.Ignore) => RightOfTable(the, That.Equals, locator, casing);
        public ICommand RightOfTable(That that, string locator = null, Casing casing = Casing.Ignore) => RightOfTable(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand RightOfTable(string locator = null, Casing casing = Casing.Ignore) => RightOfTable(That.Equals, locator, casing);

        #endregion

        #region [Near]

        private ICommand NearTable(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Table,
                Limiter = limiter,
                TargetPosition = TargetPosition.Near,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand NearTable(The the, That that, string locator = null, Casing casing = Casing.Ignore) => NearTable(the.ToLimiterType(), that, locator, casing);
        public ICommand NearTable(The the, string locator = null, Casing casing = Casing.Ignore) => NearTable(the, That.Equals, locator, casing);
        public ICommand NearTable(That that, string locator = null, Casing casing = Casing.Ignore) => NearTable(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand NearTable(string locator = null, Casing casing = Casing.Ignore) => NearTable(That.Equals, locator, casing);

        #endregion

        #endregion

        #endregion

        #region [Column]

        #region [TargetPosition]

        #region [At]

        private ICommand Column(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Column,
                Limiter = limiter,
                TargetPosition = TargetPosition.Column,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand Column(The the, That that, string locator = null, Casing casing = Casing.Ignore) => Column(the.ToLimiterType(), that, locator, casing);
        public ICommand Column(The the, string locator = null, Casing casing = Casing.Ignore) => Column(the, That.Equals, locator, casing);
        public ICommand Column(That that, string locator = null, Casing casing = Casing.Ignore) => Column(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand Column(string locator = null, Casing casing = Casing.Ignore) => Column(That.Equals, locator, casing);

        private ICommand AtColumn(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Column,
                Limiter = limiter,
                TargetPosition = TargetPosition.At,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand AtColumn(The the, That that, string locator = null, Casing casing = Casing.Ignore) => AtColumn(the.ToLimiterType(), that, locator, casing);
        public ICommand AtColumn(The the, string locator = null, Casing casing = Casing.Ignore) => AtColumn(the, That.Equals, locator, casing);
        public ICommand AtColumn(That that, string locator = null, Casing casing = Casing.Ignore) => AtColumn(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand AtColumn(string locator = null, Casing casing = Casing.Ignore) => AtColumn(That.Equals, locator, casing);

        #endregion

        #region [Above]

        private ICommand AboveColumn(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Column,
                Limiter = limiter,
                TargetPosition = TargetPosition.Above,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand AboveColumn(The the, That that, string locator = null, Casing casing = Casing.Ignore) => AboveColumn(the.ToLimiterType(), that, locator, casing);
        public ICommand AboveColumn(The the, string locator = null, Casing casing = Casing.Ignore) => AboveColumn(the, That.Equals, locator, casing);
        public ICommand AboveColumn(That that, string locator = null, Casing casing = Casing.Ignore) => AboveColumn(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand AboveColumn(string locator = null, Casing casing = Casing.Ignore) => AboveColumn(That.Equals, locator, casing);

        #endregion

        #region [Below]

        private ICommand BelowColumn(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Column,
                Limiter = limiter,
                TargetPosition = TargetPosition.Below,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand BelowColumn(The the, That that, string locator = null, Casing casing = Casing.Ignore) => BelowColumn(the.ToLimiterType(), that, locator, casing);
        public ICommand BelowColumn(The the, string locator = null, Casing casing = Casing.Ignore) => BelowColumn(the, That.Equals, locator, casing);
        public ICommand BelowColumn(That that, string locator = null, Casing casing = Casing.Ignore) => BelowColumn(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand BelowColumn(string locator = null, Casing casing = Casing.Ignore) => BelowColumn(That.Equals, locator, casing);

        #endregion

        #region [LeftOf]

        private ICommand LeftOfColumn(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Column,
                Limiter = limiter,
                TargetPosition = TargetPosition.LeftOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand LeftOfColumn(The the, That that, string locator = null, Casing casing = Casing.Ignore) => LeftOfColumn(the.ToLimiterType(), that, locator, casing);
        public ICommand LeftOfColumn(The the, string locator = null, Casing casing = Casing.Ignore) => LeftOfColumn(the, That.Equals, locator, casing);
        public ICommand LeftOfColumn(That that, string locator = null, Casing casing = Casing.Ignore) => LeftOfColumn(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand LeftOfColumn(string locator = null, Casing casing = Casing.Ignore) => LeftOfColumn(That.Equals, locator, casing);

        #endregion

        #region [RightOf]

        private ICommand RightOfColumn(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Column,
                Limiter = limiter,
                TargetPosition = TargetPosition.RightOf,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand RightOfColumn(The the, That that, string locator = null, Casing casing = Casing.Ignore) => RightOfColumn(the.ToLimiterType(), that, locator, casing);
        public ICommand RightOfColumn(The the, string locator = null, Casing casing = Casing.Ignore) => RightOfColumn(the, That.Equals, locator, casing);
        public ICommand RightOfColumn(That that, string locator = null, Casing casing = Casing.Ignore) => RightOfColumn(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand RightOfColumn(string locator = null, Casing casing = Casing.Ignore) => RightOfColumn(That.Equals, locator, casing);

        #endregion

        #region [Near]

        private ICommand NearColumn(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Scopes.Add(new ScopeTarget
            {
                Text = locator ?? string.Empty,
                TargetType = TargetType.Column,
                Limiter = limiter,
                TargetPosition = TargetPosition.Near,
                SearchType = that.ToSearchType(casing)
            });
            return this;

        }

        public ICommand NearColumn(The the, That that, string locator = null, Casing casing = Casing.Ignore) => NearColumn(the.ToLimiterType(), that, locator, casing);
        public ICommand NearColumn(The the, string locator = null, Casing casing = Casing.Ignore) => NearColumn(the, That.Equals, locator, casing);
        public ICommand NearColumn(That that, string locator = null, Casing casing = Casing.Ignore) => NearColumn(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public ICommand NearColumn(string locator = null, Casing casing = Casing.Ignore) => NearColumn(That.Equals, locator, casing);

        #endregion

        #endregion

        #endregion

        #endregion

        #endregion

        #region [IFrame]

        private WindowContext IFrame(Limiter limiter, That that, string locator, Casing casing)
        {
            Target.Text = locator ?? string.Empty;
            Target.ActionType = TargetActionType.IFrame;
            Target.Limiter = limiter;
            Target.SearchType = that.ToSearchType(casing);
            Target.TargetType = TargetType.IFrame;
            return RunCommand(this, () => new WindowContext(this,Target));
        }

        public WindowContext IFrame(The the, That that, string locator = null, Casing casing = Casing.Ignore) => IFrame(the.ToLimiterType(), that, locator, casing);
        public WindowContext IFrame(The the, string locator = null, Casing casing = Casing.Ignore) => IFrame(the, That.Equals, locator, casing);
        public WindowContext IFrame(That that, string locator = null, Casing casing = Casing.Ignore) => IFrame(locator.IsEmpty() ? Limiter.Single : Limiter.Everything, that, locator, casing);
        public WindowContext IFrame(string locator = null, Casing casing = Casing.Ignore) => IFrame(That.Equals, locator, casing);

        #endregion

        #region [Module]

        /// <summary>
        /// Creates a page model context object for strongly-typed access to page elements.
        /// </summary>
        public TPageModel Module<TPageModel>() where TPageModel : IDisposable
        {
            return (TPageModel)Activator.CreateInstance(typeof(TPageModel), new object[] { this });
        }

        #endregion
    }
}
