using System;
using System.Linq;
using Geeks.Pangolin.Core.Exception;
using Geeks.Pangolin.Core.Helper;
using Geeks.Pangolin.Core.Helper.Targets;

namespace Geeks.Pangolin.Service.Commands
{
    partial class WebCommand
    {
        #region [Public Method]

        protected override void ExecuteWaitUntil(ActionTarget target, bool disapears)
        {
            Func<bool> check = () => disapears ? CheckNotExists(target) : CheckExists(target);

            try
            {
                check.RepeatUntilTrue(Context.Config.WaitUntilTimeout);
            }
            catch (TimeoutException)
            {
                throw new ApplicationException($"Waited {Context.Config.WaitUntilTimeout} but condition did not pass");
            }
        }

        #endregion

        #region [Private Method]

        private bool CheckNotExists(ActionTarget target)
        {
            try
            {
                return TargetFinderFactory.CreateTargetFinder(Finder).Find(target, Scopes).None();
            }
            catch (ElementNotFoundException)
            {
                return true;
            }
            catch (OpenQA.Selenium.StaleElementReferenceException)
            {
                return false;
            }
        }

        private bool CheckExists(ActionTarget target)
        {
            try
            {
                return TargetFinderFactory.CreateTargetFinder(Finder).Find(target, Scopes).Any();
            }
            catch (ElementNotFoundException)
            {
                return false;
            }
            catch (MultipleElementsFoundException)
            {
                return true;
            }
            catch (OpenQA.Selenium.StaleElementReferenceException)
            {
                return false;
            }
        }

        #endregion
    }
}
