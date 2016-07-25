using System.Data.Entity;
using EntityFrameworkDynamicQuerySamples.Models;

namespace EntityFrameworkDynamicQuerySamples
{
    public class ERPContext : DbContext
    {
        public ERPContext()
            : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ERP;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}