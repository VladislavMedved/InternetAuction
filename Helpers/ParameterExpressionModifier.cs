using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class ParameterExpressionModifier<From, To> : ExpressionVisitor
    {
        public ParameterExpression NewParameterExpr { get; private set; }

        public ParameterExpressionModifier(ParameterExpression newParamExpr)
        {
            NewParameterExpr = newParamExpr;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return NewParameterExpr;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Member.DeclaringType == typeof(From))
                return Expression.MakeMemberAccess(this.Visit(node.Expression),
                   typeof(To).GetMember(node.Member.Name).FirstOrDefault());
            return base.VisitMember(node);
        }
    }
}
