using System;
using System.Linq.Expressions;
using EntityFrameworkDynamicQuerySamples.Models;

namespace EntityFrameworkDynamicQuerySamples.Helpers
{
    internal static class Extensions
    {
        public static Expression<Func<Customer, bool>> ToLambdaExpression(this CustomerQueryConditions self)
        {
            var queryConditionsResolver = new CustomerQueryConditionsResolver(self);

            return queryConditionsResolver.Resolve();
        }
    }
}