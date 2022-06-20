using System.Linq.Expressions;
using System.Reflection;

namespace UniNote.Core.Extensions;

public static class LambdaExtensions
{
    public static void SetPropertyValue<T, TValue>(this T target, Expression<Func<T, TValue>> member, TValue value)
    {
        if (member.Body is not MemberExpression memberSelectorExpression) return;
        
        var property = memberSelectorExpression.Member as PropertyInfo;
        if (property != null)
            property.SetValue(target, value, null);
        
    }
}