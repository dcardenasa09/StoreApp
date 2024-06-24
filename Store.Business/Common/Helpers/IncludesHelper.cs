using System.Linq.Expressions;
using System.Reflection;

namespace Store.Business.Common.Helpers;

public static class IncludesHelper
{
    public static string[] GetIncludes<T>(params Expression<Func<T, object?>>[] expressions) {
        string[]? includes = [];
        foreach(var expression in expressions) {
            if (expression.Body is UnaryExpression unex) {
                if (unex.NodeType == ExpressionType.Convert) {
                    Expression ex = unex.Operand;
                    MemberExpression mex = (MemberExpression)ex;
                    includes = includes.Append(mex.Member.Name).ToArray();
                }
            }

            MemberExpression clientExpression    = (MemberExpression)expression.Body;
            MemberExpression clientExpressionOrg = clientExpression;

            string Path = "";
            while (clientExpression.Expression.NodeType == ExpressionType.MemberAccess) {
                var propInfo  = clientExpression.Expression.GetType().GetProperty("Member");
                var propValue = propInfo.GetValue(clientExpression.Expression, null) as PropertyInfo;
                Path = propValue.Name + "." + Path;

                clientExpression = clientExpression.Expression as MemberExpression;
            }

            includes = includes.Append(Path + clientExpressionOrg.Member.Name).ToArray();
        }

        return includes;
    }
}