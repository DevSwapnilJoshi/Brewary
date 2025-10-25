using System;
using System.Collections.Generic;

namespace EGlossary.Domain.Entities
{
    public class CustomerEntity : BaseEntity
    {
        public CustomerEntity()
        {
            Orders = new List<OrderEntity>();
        }

        public string CustomerName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<OrderEntity> Orders { get; set; }
    }
}