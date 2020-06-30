using Geeks.Pangolin.Core.Exception;
using Geeks.Pangolin.Core.Scopes;
using Geeks.Pangolin.Core.Helper.Targets;

namespace Geeks.Pangolin.Service.Scopes
{
    public class WebScopeFactory : IScopeFactory
    {
        public ScopeBase CreateScope(TargetPosition targetPosition)
        {
            switch (targetPosition)
            {
                case TargetPosition.At: return new At();
                case TargetPosition.Above: return new Above();
                case TargetPosition.Below: return new Below();
                case TargetPosition.LeftOf: return new LeftOf();
                case TargetPosition.RightOf: return new RightOf();
                case TargetPosition.Near: return new Near();
                case TargetPosition.Column: return new Column();
                default:
                    throw new SyntaxErrorException("Unknown scope");
            }
        }
    }
}
