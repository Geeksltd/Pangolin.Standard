using System;
using System.Collections.Generic;
using Geeks.Pangolin.Core.Dom;
using Geeks.Pangolin.Core.Helper.TargetFinderFactory;
using Geeks.Pangolin.Core.Helper.Targets;
using Geeks.Pangolin.Core.Scopes;
using Geeks.Pangolin.Service.Helper.Extensions;
using Geeks.Pangolin.Service.Helper.WebElementFinder;

namespace Geeks.Pangolin.Service.Targets
{
    public class WebTargetFinder : TargetFinder
    {
        #region [Property]

        const int RETRY_MISSING_DOM_CONTEXT = 5;

        #endregion

        #region [Constructor]

        public WebTargetFinder(IElementFinder elementFinder) : base(elementFinder) => ElementFinder = elementFinder as WebElementFinder;

        #endregion

        #region [Public Method]

        public override IEnumerable<Element> Find(TargetBase target, ScopesCollection scopes)
        {
            Exception lastError = null;
            for (var attempt = 0; attempt < RETRY_MISSING_DOM_CONTEXT; attempt++)
            {
                try
                {
                    return DoFind(target, scopes);
                }
                catch (Exception err) when (err.Message.Contains("Cannot find execution context with given id") ||
                                            err.Message.Contains("element is not attached to the page document"))
                {
                    lastError = err;
                    OnBeforeRetryFind();
                }
            }

            throw lastError;
        }

        #endregion

        #region [Private Method]

        protected override void OnBeforeRetryFind() => (ElementFinder as WebElementFinder).Browser.SwitchToIframeIfNecessary();

        protected override IEnumerable<Element> DoFind(TargetBase target, ScopesCollection scopes)
        {
            try
            {
                return base.DoFind(target, scopes);
            }
            catch (OpenQA.Selenium.StaleElementReferenceException err)
            {
                throw new Geeks.Pangolin.Core.Exception.StaleElementReferenceException(err.Message, err);
            }
        }

        #endregion
    }
}
