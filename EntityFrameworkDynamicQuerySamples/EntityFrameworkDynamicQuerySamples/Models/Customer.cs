using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkDynamicQuerySamples.Models
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        [Index, MaxLength(20)]
        public string City { get; set; }

        [Index, MaxLength(20)]
        public string District { get; set; }
    }
}