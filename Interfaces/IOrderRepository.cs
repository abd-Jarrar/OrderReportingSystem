using System;
using System.Collections.Generic;
using System.Text;
using Asal.OrderReportingSystem.Models;

namespace Asal.OrderReportingSystem.Interfaces
{
    public interface IOrderRepository
    {
        public bool AddOrder(Guid CustomerId, decimal Amount);
        public List<Order> GetAllOrders();

        public Order? GetOrderById(Guid OrderId);

        public List<Order> GetCompletedOrders();

        public List<Order> GetOrdersAbove(decimal Amount);
        public List<Order> GetOrdersWithin(DateTime StartDate, DateTime EndDate);

        public List<Order> GetOrdersBySpecificCustomer(Guid CustomerId);

        public decimal GetOrdersTotalAmount();

        public Dictionary<Customer, decimal> GetCustomerOrdersTotalAmount();

        public Customer GetCustomerWithHighestOrdersAmount();

        public List<Order> GetOrdersSortedByAmount(bool ascending);

        public List<Order> GetOrdersSortedByDate(bool ascending);

    }
}
