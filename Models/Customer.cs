using System;
using System.Collections.Generic;
using System.Text;

namespace Asal.OrderReportingSystem.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;

        public string CustomerEmail { get; set; } = null!;
    }
}
