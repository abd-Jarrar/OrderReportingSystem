using Asal.OrderReportingSystem.Interfaces;
using Asal.OrderReportingSystem.Models;
using Asal.OrderReportingSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asal.OrderReportingSystem.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ICustomerRepository _customers;
        public OrderRepository(ICustomerRepository customers)
        {
            _customers=customers;
        }
        private readonly List<Order> _orders = new List<Order>() {
        new Order
        {
            OrderId = Guid.Parse("7d3f8a21-4c6b-4e95-a217-8f3d6b9c1042"),
            Customer =  new Customer
            {
                CustomerId = Guid.Parse("3f8a1c2e-7b4d-4f91-a632-9c5e8d1b2047"),
                CustomerName = "abd jarrar",
                CustomerEmail = "abd@gmail.com"
            },
            OrderTotalAmount = 150.50m,
            OrderStatus = OrderStatus.Cancelled,
            CreatedDate = new DateTime(2026,3,1)
        },

        new Order
        {
            OrderId = Guid.Parse("b92e4f17-6a35-47c8-9d21-5f7a3b8e6204"),
            Customer = new Customer
            {
            CustomerId = Guid.Parse("a72d4e91-6c3f-48b2-9e15-7d8a3f2c6019"),
            CustomerName = "rami ahmad",
            CustomerEmail = "rami@gmail.com"
            },
            OrderTotalAmount = 250.00m,
            OrderStatus = OrderStatus.Completed,
            CreatedDate = new DateTime(2026,2,1)
        },

        new Order
        {
            OrderId = Guid.Parse("93f7d124-5b68-4a39-8e17-c2d9465b7013"),
            Customer = new Customer
            {
            CustomerId = Guid.Parse("b15e9c73-2a64-4d81-8f37-c9e5b2147a06"),
            CustomerName = "yanal salem",
            CustomerEmail = "yanal@gmail.com"
            },
            OrderTotalAmount = 75.25m,
            OrderStatus = OrderStatus.Pending,
            CreatedDate = new DateTime(2026,1,1)
        }
    };

        public bool AddOrder(Guid CustomerId, decimal Amount)
        {
            var customer = _customers.GetCustomerById(CustomerId);

            if (customer is null)
                throw new InvalidOperationException("There's no customer with this ID.");

            var order = new Order
            {
                OrderId = Guid.NewGuid(),
                Customer = customer,
                OrderTotalAmount = Amount,
                OrderStatus = OrderStatus.Pending,
                CreatedDate = DateTime.Now
            };

            _orders.Add(order);

            return true;
        }

        public void DisplayAllOrders()
        {
            PrintOrders(_orders);
        }

        public List<Order> DisplayOrdersWithin(DateTime StartDate, DateTime EndDate)
        {
            return _orders.Where(o => o.CreatedDate >= StartDate && o.CreatedDate <= EndDate).ToList();
        }

        public List<Order> GetCompletedOrders()
        {
            return _orders.Where(o=>o.OrderStatus == OrderStatus.Completed).ToList();
        }

        public Dictionary<Customer,decimal> GetCustomerOrdersTotalAmount()
        {
            return _orders.GroupBy(o => o.Customer).ToDictionary(g => g.Key,g => g.Sum(o => o.OrderTotalAmount));
        }

        public Customer GetCustomerWithHighestOrdersAmount()
        {
            var customerAmounts = _orders.GroupBy(o => o.Customer).ToDictionary(g => g.Key,g => g.Sum(o => o.OrderTotalAmount));
            return customerAmounts.MaxBy(x => x.Value).Key;
        }

        public Order? GetOrderById(Guid OrderId)
        {
            return _orders.FirstOrDefault(o => o.OrderId == OrderId);
        }

        public List<Order> GetOrdersAbove(decimal Amount)
        {
            return _orders.Where(o => o.OrderTotalAmount > Amount).ToList();
        }

        public List<Order> GetOrdersBySpecificCustomer(Guid CustomerId)
        {
            var customer=_customers.GetCustomerById(CustomerId);
            if (customer is null)
                throw new InvalidOperationException("couldn't find customer with this Id!!!!");

            return _orders.Where(o=>o.Customer.CustomerId == CustomerId).ToList();
        }

        public List<Order> GetOrdersSortedByAmount()
        {
            var sortType = MyUtilities.GetSortType();

            if (sortType)
                return _orders.OrderBy(o => o.OrderTotalAmount).ToList();
            else
            {
                return _orders.OrderByDescending(o => o.OrderTotalAmount).ToList();

            }
        }

        public List<Order> GetOrdersSortedByDate()
        {
            var sortType = MyUtilities.GetSortType();

            if (sortType)
                return _orders.OrderBy(o => o.CreatedDate).ToList();
            else
            {
                return _orders.OrderByDescending(o => o.CreatedDate).ToList();

            }
        }

        public decimal GetOrdersTotalAmount()
        {
            return _orders.Sum(o => o.OrderTotalAmount);
        }

        public void PrintOrder(Guid OrderId)
        {
            var order = _orders.FirstOrDefault(o => o.OrderId == OrderId);

            if (order is null)
            {
                throw new InvalidOperationException("the order with this id was not found!!!");
            }

            Console.WriteLine($"Order ID: {order.OrderId}");
            Console.WriteLine($"Customer: {order.Customer.CustomerName}");
            Console.WriteLine($"Total Amount: {order.OrderTotalAmount:C}");
            Console.WriteLine($"Status: {order.OrderStatus}");
            Console.WriteLine($"Created Date: {order.CreatedDate}");
        }

        public void PrintOrders(List<Order> orders)
        {
            if (orders is null || orders.Count == 0)
            {
                Console.WriteLine("No orders found.");
                return;
            }

            foreach (var order in orders)
            {
                Console.WriteLine($"Order ID: {order.OrderId}");
                Console.WriteLine($"Customer: {order.Customer.CustomerName}");
                Console.WriteLine($"Total Amount: {order.OrderTotalAmount:C}");
                Console.WriteLine($"Status: {order.OrderStatus}");
                Console.WriteLine($"Created Date: {order.CreatedDate}");
                Console.WriteLine("-------------------------");
            }
        }
    }
}
