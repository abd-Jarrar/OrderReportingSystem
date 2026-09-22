using System;
using System.Collections.Generic;
using System.Text;

namespace Asal.OrderReportingSystem.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Customer Customer { get; set; } = null!;

        public decimal OrderTotalAmount { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
