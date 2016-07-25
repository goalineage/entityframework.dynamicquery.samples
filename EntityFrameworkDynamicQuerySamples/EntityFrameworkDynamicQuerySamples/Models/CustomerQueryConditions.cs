namespace EntityFrameworkDynamicQuerySamples.Models
{
    public class CustomerQueryConditions
    {
        public QueryCondition<string> City { get; set; }

        public QueryCondition<string> District { get; set; }

        public QueryCondition<string> Name { get; set; }
    }
}