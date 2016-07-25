using System;
using System.Collections.Generic;
using System.Linq;
using EntityFrameworkDynamicQuerySamples.Helpers;
using EntityFrameworkDynamicQuerySamples.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EntityFrameworkDynamicQuerySamples
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [Ignore]
        public void Test_add_test_data()
        {
            using (ERPContext context = new ERPContext())
            {
                var customers =
                    new List<Customer>()
                    {
                        new Customer()
                        {
                            Id = Guid.NewGuid(),
                            Name = "馬英九",
                            City = "台北市",
                            District = "南港區"
                        },
                        new Customer()
                        {
                            Id = Guid.NewGuid(),
                            Name = "蔡英文",
                            City = "台北市",
                            District = "大安區"
                        },
                        new Customer()
                        {
                            Id = Guid.NewGuid(),
                            Name = "蔡陽文",
                            City = "台北市",
                            District = "大安區"
                        },
                        new Customer()
                        {
                            Id = Guid.NewGuid(),
                            Name = "吳敦義",
                            City = "台北市",
                            District = "大安區"
                        },
                        new Customer()
                        {
                            Id = Guid.NewGuid(),
                            Name = "林佳龍",
                            City = "台中市",
                            District = "南屯區"
                        },
                        new Customer()
                        {
                            Id = Guid.NewGuid(),
                            Name = "胡志強",
                            City = "台中市",
                            District = "霧峰區"
                        },
                    };

                context.Customers.AddRange(customers);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void Test_query_台北市()
        {
            using (var context = new ERPContext())
            {
                var customers = GetCustomers(
                    new CustomerQueryConditions()
                    {
                        City = new QueryCondition<string>(QueryComparsion.Equal, "台北市")
                    });

                Assert.AreEqual(4, customers.Count);
            }
        }

        [TestMethod]
        public void Test_query_台北市_大安區()
        {
            using (var context = new ERPContext())
            {
                var customers = GetCustomers(
                    new CustomerQueryConditions()
                    {
                        City = new QueryCondition<string>(QueryComparsion.Equal, "台北市"),
                        District = new QueryCondition<string>(QueryComparsion.Equal, "大安區")
                    });

                Assert.AreEqual(3, customers.Count);
            }
        }

        [TestMethod]
        public void Test_query_台北市_大安區_姓蔡的()
        {
            using (var context = new ERPContext())
            {
                var customers = GetCustomers(
                    new CustomerQueryConditions()
                    {
                        City = new QueryCondition<string>(QueryComparsion.Equal, "台北市"),
                        District = new QueryCondition<string>(QueryComparsion.Equal, "大安區"),
                        Name = new QueryCondition<string>(QueryComparsion.StartsWith, "蔡")
                    });

                Assert.AreEqual(2, customers.Count);
            }
        }

        private static List<Customer> GetCustomers(CustomerQueryConditions customerQueryConditions)
        {
            using (var context = new ERPContext())
            {
                var customers = context.Customers
                                       .AsNoTracking()
                                       .Where(customerQueryConditions.ToLambdaExpression());

                return customers.ToList();
            }
        }
    }
}