using Geeks.Pangolin.Core.Scopes;
using System;
using Geeks.Pangolin.Core.Helper.Context;
using Geeks.Pangolin.Core.Helper.Targets;
using Geeks.Pangolin.Core.Helper.TargetFinderFactory;

namespace Geeks.Pangolin.Core.Commands
{
    public abstract partial class Command
    {
        #region [Property]

        protected Context Context;
        protected string Content;
        protected ScopesCollection Scopes;
        protected IScopeFactory ScopeFactory;
        protected IElementFinderFactory ElementFinderFactory;
        protected ITargetFinderFactory TargetFinderFactory;
        private ActionTarget Target;
        IElementFinder _Finder;

        #endregion

        #region [Constructor]

        #endregion

        #region [Public Method]

        public IElementFinder Finder => _Finder ?? (_Finder = ElementFinderFactory.CreateElementFinder());

        public void Execute()
        {
            OnBeforeRetryFind();
            CreateScope();
            switch (Target.ActionType)
            {
                case TargetActionType.Set:
                    Set(Target);
                    break;
                case TargetActionType.Click:
                    Click(Target);
                    break;
                case TargetActionType.Expect:
                case TargetActionType.ExpectNo:
                    Expect(Target);
                    break;
                case TargetActionType.WaitToSee:
                case TargetActionType.WaitToSeeNo:
                    Wait(Target);
                    break;
                case TargetActionType.HoverOver:
                    HoverOver(Target);
                    break;
                case TargetActionType.IFrame:
                    IFrame(Target);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion

        #region [Protected Method]

        protected Command(Context context, ActionTarget target, IScopeFactory scopeFactory, IElementFinderFactory elementFinderFactory, ITargetFinderFactory targetFinderFactory)
        {
            Context = context;
            Target = target;
            ScopeFactory = scopeFactory;
            ElementFinderFactory = elementFinderFactory;
            TargetFinderFactory = targetFinderFactory;
        }
        protected abstract void OnBeforeRetryFind();
        protected abstract void RememberCurrentPageState();
        protected abstract void ExecuteWaitForPopup();
        protected abstract void ExecuteWaitForNewPage();

        #endregion

        #region [Private Method]

        private void CreateScope()
        {
            Scopes = ScopesCollection.Extract(Target.Scopes, ScopeFactory);
            Scopes.UpdateFinderArea(TargetFinderFactory.CreateTargetFinder(Finder));
        }

        #endregion
    }    
}
