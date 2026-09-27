using Asal.OrderReportingSystem.Interfaces;
using Asal.OrderReportingSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace Asal.OrderReportingSystem.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers = new List<Customer>()
        {
             new Customer
            {
                CustomerId = Guid.Parse("3f8a1c2e-7b4d-4f91-a632-9c5e8d1b2047"),
                CustomerName = "abd jarrar",
                CustomerEmail = "abd@gmail.com"
            },
             new Customer
            {
            CustomerId = Guid.Parse("a72d4e91-6c3f-48b2-9e15-7d8a3f2c6019"),
            CustomerName = "rami ahmad",
            CustomerEmail = "rami@gmail.com"
            },
             new Customer
            {
            CustomerId = Guid.Parse("b15e9c73-2a64-4d81-8f37-c9e5b2147a06"),
            CustomerName = "yanal salem",
            CustomerEmail = "yanal@gmail.com"
            }
        };

        public bool AddCustomer(string customerName, string customerEmail)
        {
            if (string.IsNullOrWhiteSpace(customerName))
                return false;
            if (string.IsNullOrWhiteSpace(customerEmail))
                return false;
            foreach (var customer in _customers)
            {
                if (string.Equals(customerEmail, customer.CustomerEmail, StringComparison.OrdinalIgnoreCase))
                    return false;

            }
            var newCustomer =new Customer {CustomerId=Guid.NewGuid() ,CustomerEmail = customerEmail, CustomerName= customerName, CustomerOrders=new()};
            _customers.Add(newCustomer);
            return true;
        }

        public bool DeleteCustomer(Guid CustomerId)
        {
            var customer = GetCustomerById(CustomerId);
            if (customer is null)
                return false;
            _customers.Remove(customer);
            return true;

        }

        public void DisplayAllCustomers()
        {
            DisplayCustomers(_customers);
        }

        public void DisplayCustomer(Guid CustomerId)
        {
            var customer = _customers.FirstOrDefault(c => c.CustomerId == CustomerId);

            if (customer == null)
                throw new InvalidOperationException("Customer not found.");

            Console.WriteLine($"ID: {customer.CustomerId}");
            Console.WriteLine($"Name: {customer.CustomerName}");
            Console.WriteLine($"Email: {customer.CustomerEmail}");
        }

        public void DisplayCustomers(List<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine($"ID: {customer.CustomerId}");
                Console.WriteLine($"Name: {customer.CustomerName}");
                Console.WriteLine($"Email: {customer.CustomerEmail}");
                Console.WriteLine("-------------------------");
            }
        }

        public Customer? GetCustomerById(Guid CustomerId)
        {
            return _customers.FirstOrDefault(c => c.CustomerId == CustomerId);
        }

        public List<Order> GetCustomerOrders(Guid CustomerId)
        {
            var customer = GetCustomerById(CustomerId);
            if (customer is null)
                throw new InvalidOperationException("Customer was not found.");
            return customer.CustomerOrders;
        }
    }
}
