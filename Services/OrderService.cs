using Asal.OrderReportingSystem.Interfaces;
using Asal.OrderReportingSystem.Repositories;
using Asal.OrderReportingSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asal.OrderReportingSystem.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public void AddOrder()
        {
            Guid customerId = MyUtilities.ReadGuid("Enter customer ID: ");
            decimal amount = MyUtilities.ReadPositiveAmount("Enter order amount: ");
            if(_repository.AddOrder(customerId, amount))
            Console.WriteLine("Order added successfully.");
        }
        public void DisplayAllOrders()
        {
            _repository.DisplayAllOrders();
        }

        public void DisplayOrdersWithin()
        {
            DateTime startDate = MyUtilities.ReadDate("Enter start date: ");
            DateTime endDate = MyUtilities.ReadDate("Enter end date: ");

            try
            {
                if (endDate < startDate)
                    throw new ArgumentException("End date cannot be before start date.");
                var orders=_repository.DisplayOrdersWithin(startDate, endDate);
                _repository.PrintOrders(orders);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DisplayCompletedOrders()
        {
            var orders=_repository.GetCompletedOrders();
            _repository.PrintOrders(orders);
        }

        public void DisplayCustomerOrdersTotalAmount()
        {
            var customerOrders = _repository.GetCustomerOrdersTotalAmount();

            foreach (var item in customerOrders)
            {
                MyUtilities.PrintCustomerOrdersTotalAmount(
                    item.Key,
                    item.Value
                );
            }
        }

        public void DisplayCustomerWithOrdersWithHighestTotalAmount()
        {
            try
            {
                var customer = _repository.GetCustomerWithHighestOrdersAmount();

                if (customer is null)
                    throw new InvalidOperationException("There's no orders.");
                MyUtilities.PrintCustomer(customer);

            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void DisplayOrderById()
        {
            try
            {
                Guid orderId = MyUtilities.ReadGuid("Enter order ID: ");

                var order = _repository.GetOrderById(orderId);

                if (order is null)
                    throw new InvalidOperationException("There's no order with this ID.");

                MyUtilities.PrintOrder(order);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DisplayOrdersAbove()
        {
            decimal amount = MyUtilities.ReadPositiveAmount("Enter The amount: ");
            var orders=_repository.GetOrdersAbove(amount);
            _repository.PrintOrders(orders);
        }

        public void DisplayOrdersBySpecificCustomer()
        {
            try
            {
                Guid customerId = MyUtilities.ReadGuid("Enter customer ID: ");

                var orders = _repository.GetOrdersBySpecificCustomer(customerId);

                _repository.PrintOrders(orders);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DisplayOrdersSortedByAmount()
        {
            var orders = _repository.GetOrdersSortedByAmount();

            foreach (var order in orders)
            {
                MyUtilities.PrintOrder(order);
            }
        }

        public void DisplayOrdersSortedByDate()
        {
            var orders = _repository.GetOrdersSortedByDate();

            foreach (var order in orders)
            {
                MyUtilities.PrintOrder(order);
            }
        }

        public void DisplayOrdersTotalAmount()
        {
            decimal totalAmount = _repository.GetOrdersTotalAmount();

            Console.WriteLine($"Total Orders Amount: {totalAmount:C}");
        }
    }
}
