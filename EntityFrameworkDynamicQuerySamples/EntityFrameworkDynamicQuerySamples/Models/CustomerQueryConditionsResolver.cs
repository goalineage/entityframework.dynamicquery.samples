using System;
using System.Linq.Expressions;

namespace EntityFrameworkDynamicQuerySamples.Models
{
    public class CustomerQueryConditionsResolver : QueryConditionsResolver<Customer, CustomerQueryConditions>
    {
        public CustomerQueryConditionsResolver(CustomerQueryConditions customerQueryConditions)
            : base(customerQueryConditions)
        {
        }

        public override Expression<Func<Customer, bool>> Resolve()
        {
            this.And(this.QueryConditions.City, nameof(Customer.City));
            this.And(this.QueryConditions.District, nameof(Customer.District));
            this.And(this.QueryConditions.Name, nameof(Customer.Name));

            return this.GenerateLambdaExpression();
        }
    }
}