using System;
using System.Collections.Generic;
using System.Text;
using Asal.OrderReportingSystem.Models;

namespace Asal.OrderReportingSystem.Interfaces
{
    public interface IOrderRepository
    {
        public bool AddOrder(Guid CustomerId, decimal Amount);
        public void DisplayAllOrders();

        public Order? GetOrderById(Guid OrderId);

        public List<Order> GetCompletedOrders();

        public List<Order> GetOrdersAbove(decimal Amount);
        public List<Order> DisplayOrdersWithin(DateTime StartDate, DateTime EndDate);

        public List<Order> GetOrdersBySpecificCustomer(Guid CustomerId);

        public decimal GetOrdersTotalAmount();

        public Dictionary<Customer, decimal> GetCustomerOrdersTotalAmount();

        public Customer GetCustomerWithHighestOrdersAmount();

        public List<Order> GetOrdersSortedByAmount();

        public List<Order> GetOrdersSortedByDate();

        public void PrintOrder(Guid OrderId);

        public void PrintOrders(List<Order>orders);

    }
}
